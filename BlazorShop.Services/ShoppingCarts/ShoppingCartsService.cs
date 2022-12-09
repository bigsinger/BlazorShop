namespace BlazorShop.Services.ShoppingCarts {
    using AutoMapper;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.ShoppingCarts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ShoppingCartsService : BaseService<ShoppingCart>, IShoppingCartsService {
        private const string InvalidErrorMessage = "This user cannot edit this shopping cart.";
        private const string NotEnoughProductsMessage = "There are not enough products in stock.";
        private const string NotLogin = "您尚未登录";

        public ShoppingCartsService(BlazorShopDbContext db, IMapper mapper) : base(db, mapper) {
        }

        public async Task<Result> AddProductAsync(ShoppingCartRequestModel model, string userId) {
            var productId = model.ProductId;
            var requestQuantity = model.Quantity;

            var productQuantity = await this.GetProductQuantityById(productId);

            if (productQuantity < requestQuantity) {
                return NotEnoughProductsMessage;
            }

            var shoppingCartProduct = await this.FindByProductAndUserAsync(productId, userId);
            if (shoppingCartProduct == null) {
                var shoppingCart = await this.All().FirstOrDefaultAsync(c => c.UserId == userId);

                shoppingCart ??= new ShoppingCart
                {
                    UserId = userId
                };

                shoppingCartProduct = new ShoppingCartProduct
                {
                    ShoppingCart = shoppingCart,
                    ProductId = productId,
                    Quantity = requestQuantity
                };

                try {
                    await this.Data.AddAsync(shoppingCartProduct);
                    await this.Data.SaveChangesAsync();
                } catch (System.Exception) {
                    return NotLogin;
                }
            } else {
                model.Quantity = shoppingCartProduct.Quantity + 1;
                return await UpdateProductAsync(model, userId);
            }

            return Result.Success;
        }

        public async Task<Result> UpdateProductAsync(ShoppingCartRequestModel model, string userId) {
            var productId = model.ProductId;
            var requestQuantity = model.Quantity;

            var productQuantity = await this.GetProductQuantityById(productId);

            if (productQuantity < requestQuantity) {
                return NotEnoughProductsMessage;
            }

            var shoppingCartProduct = await this.FindByProductAndUserAsync(productId, userId);

            if (shoppingCartProduct == null) {
                return InvalidErrorMessage;
            }

            shoppingCartProduct.Quantity = requestQuantity;

            try {
                await this.Data.SaveChangesAsync();
            } catch (System.Exception) {
                return NotLogin;
            }

            return Result.Success;
        }

        public async Task<Result> RemoveProductAsync(long productId, string userId) {
            var shoppingCartProduct = await this.FindByProductAndUserAsync(productId, userId);

            if (shoppingCartProduct == null) {
                return InvalidErrorMessage;
            }

            this.Data.Remove(shoppingCartProduct);

            await this.Data.SaveChangesAsync();

            return Result.Success;
        }

        public async Task<int> TotalAsync(
            string userId)
            => await this
                .AllByUserId(userId)
                .CountAsync();

        public async Task<IEnumerable<ShoppingCartProductsResponseModel>> ByUserAsync(
            string userId)
            => await this.Mapper
                .ProjectTo<ShoppingCartProductsResponseModel>(this
                    .AllByUserId(userId)
                    .AsNoTracking())
                .ToListAsync();

        private async Task<ShoppingCartProduct> FindByProductAndUserAsync(long productId, string userId)
            => await this.AllByUserId(userId).FirstOrDefaultAsync(c => c.ProductId == productId);

        private IQueryable<ShoppingCartProduct> AllByUserId(string userId)
            => this.All().Where(c => c.UserId == userId).SelectMany(c => c.Products);

        private async Task<int> GetProductQuantityById(long productId)
            => await this
                .Data
                .Products
                .Where(p => p.Id == productId)
                .Select(p => p.Quantity)
                .FirstOrDefaultAsync();
    }
}
