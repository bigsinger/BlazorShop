namespace BlazorShop.Services.Wishlists {
    using AutoMapper;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.Wishlists;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class WishlistsService : BaseService<Wishlist>, IWishlistsService {
        private const string NotLogin = "您尚未登录";
        public WishlistsService(BlazorShopDbContext db, IMapper mapper) : base(db, mapper) {
        }

        public async Task<Result> AddProductAsync(long productId, string userId) {
            var wishlist = await this
                .All()
                .FirstOrDefaultAsync(w => w.UserId == userId);

            wishlist ??= new Wishlist
            {
                UserId = userId
            };

            var wishlistProduct = new WishlistProduct
            {
                Wishlist = wishlist,
                ProductId = productId
            };

            try {
                await this.Data.AddAsync(wishlistProduct);
                await this.Data.SaveChangesAsync();
            } catch (System.Exception) {
                return NotLogin;
            }

            return Result.Success;
        }

        public async Task<Result> RemoveProductAsync(long productId, string userId) {
            var wishlistProduct = await this
                .AllByUserId(userId)
                .FirstOrDefaultAsync(w => w.ProductId == productId);

            if (wishlistProduct == null) {
                return "This user cannot delete products from this wishlist.";
            }

            this.Data.Remove(wishlistProduct);

            await this.Data.SaveChangesAsync();

            return Result.Success;
        }

        public async Task<IEnumerable<WishlistsProductsResponseModel>> ByUserAsync(string userId)
            => await this.Mapper
                .ProjectTo<WishlistsProductsResponseModel>(this
                    .AllByUserId(userId)
                    .AsNoTracking())
                .ToListAsync();

        private IQueryable<WishlistProduct> AllByUserId(string userId)
            => this
                .All()
                .Where(w => w.UserId == userId)
                .SelectMany(w => w.Products);
    }
}
