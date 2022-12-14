namespace BlazorShop.Web.Server.Controllers {
    using BlazorShop.Web.Server.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.ShoppingCarts;
    using Services.ShoppingCarts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Authorize]
    public class ShoppingCartsController : ApiController {
        private readonly IShoppingCartsService shoppingCarts;
        private readonly ICurrentUserService currentUser;

        public ShoppingCartsController(
            IShoppingCartsService shoppingCarts,
            ICurrentUserService currentUser) {
            this.shoppingCarts = shoppingCarts;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IEnumerable<ShoppingCartProductsResponseModel>> Mine()
            => await this.shoppingCarts.ByUserAsync(this.currentUser.UserId);

        [HttpGet(nameof(TotalProducts))]
        public async Task<ActionResult<int>> TotalProducts()
            => await this.shoppingCarts.TotalAsync(this.currentUser.UserId);

        [HttpPost(nameof(AddProduct))]
        public async Task<ActionResult> AddProduct(ShoppingCartRequestModel model)
            => await this.shoppingCarts
                .AddProductAsync(model, this.currentUser.UserId)
                .ToActionResult();

        [HttpPut(nameof(UpdateProduct))]
        public async Task<ActionResult> UpdateProduct(ShoppingCartRequestModel model)
            => await this.shoppingCarts
                .UpdateProductAsync(model, this.currentUser.UserId)
                .ToActionResult();

        [HttpDelete(nameof(RemoveProduct) + PathSeparator + Id)]
        public async Task<ActionResult> RemoveProduct(long id)
            => await this.shoppingCarts
                .RemoveProductAsync(id, this.currentUser.UserId)
                .ToActionResult();
    }
}
