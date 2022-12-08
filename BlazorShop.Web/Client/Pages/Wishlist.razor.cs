namespace BlazorShop.Web.Client.Pages {
    using Models.ShoppingCarts;
    using Models.Wishlists;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public partial class Wishlist {
        private IEnumerable<WishlistsProductsResponseModel> products;

        protected override async Task OnInitializedAsync() => await this.LoadDataAsync();

        private async Task LoadDataAsync() => this.products = await this.WishlistsService.Mine();

        private async Task OnSubmitAsync(long id) {
            var cartRequest = new ShoppingCartRequestModel
            {
                ProductId = id,
                Quantity = 1
            };

            await this.ShoppingCartsService.AddProduct(cartRequest);

            this.NavigationManager.NavigateTo("/cart", forceLoad: true);
        }

        private async Task OnRemoveAsync(long id) {
            var result = await this.WishlistsService.RemoveProduct(id);

            if (result.Succeeded) {
                await this.LoadDataAsync();
            }
        }
    }
}
