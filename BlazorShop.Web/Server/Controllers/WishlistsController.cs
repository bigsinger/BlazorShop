namespace BlazorShop.Web.Server.Controllers {
    using Infrastructure.Extensions;
    using Infrastructure.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Wishlists;
    using Services.Wishlists;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Authorize]
    public class WishlistsController : ApiController {
        private readonly IWishlistsService wishlists;
        private readonly ICurrentUserService currentUser;

        public WishlistsController(
            IWishlistsService wishlists,
            ICurrentUserService currentUser) {
            this.wishlists = wishlists;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IEnumerable<WishlistsProductsResponseModel>> Mine()
            => await this.wishlists.ByUserAsync(this.currentUser.UserId);

        [HttpPost(nameof(AddProduct) + PathSeparator + Id)]
        public async Task<ActionResult> AddProduct(long id)
            => await this.wishlists
                .AddProductAsync(id, this.currentUser.UserId)
                .ToActionResult();

        [HttpDelete(nameof(RemoveProduct) + PathSeparator + Id)]
        public async Task<ActionResult> RemoveProduct(long id)
            => await this.wishlists
                .RemoveProductAsync(id, this.currentUser.UserId)
                .ToActionResult();
    }
}
