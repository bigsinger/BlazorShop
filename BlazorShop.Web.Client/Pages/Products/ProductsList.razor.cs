namespace BlazorShop.Web.Client.Pages.Products {
    using Microsoft.AspNetCore.Components;
    using Models.Categories;
    using Models.Products;
    using Models.ShoppingCarts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public partial class ProductsList {
        private readonly ProductsSearchRequestModel model = new();

        private ProductsSearchResponseModel searchResponse;
        private IEnumerable<ProductsListingResponseModel> products;
        private IEnumerable<CategoriesListingResponseModel> categories;

        [Parameter]
        public long? CategoryId { get; set; }

        [Parameter]
        public string CategoryName { get; set; }

        [Parameter]
        public string SearchQuery { get; set; } = string.Empty;

        [Parameter]
        public int Page { get; set; } = 1;

        [Parameter]
        public bool ListView { get; set; } = false;

        private string getListViewActiveStr(bool active) {
            return active ? "active" : "";
        }

        protected override async Task OnInitializedAsync() => await this.LoadData();

        protected override async Task OnParametersSetAsync() => await this.LoadData(withCategories: false);

        private async Task SelectedPage(int page) {
            this.Page = page;

            await this.LoadData(withCategories: false);
        }

        private async Task LoadData(bool withCategories = true) {
            if(this.Page == 0) {
                this.Page = 1;
            }

            this.model.Category = this.CategoryId;
            this.model.Query = this.SearchQuery;
            this.model.Page = this.Page;

            this.searchResponse = await this.ProductsService.SearchAsync(this.model);
            this.products = this.searchResponse.Products;

            if(withCategories) {
                this.categories = await this.CategoriesService.All();
            }

            this.Filter();
        }

        private async Task AddToWishlist(long id) {
            var result = await this.WishlistsService.AddProduct(id);
            if(result != null && result.Succeeded) {
                this.NavigationManager.NavigateTo("/wishlist");
            } else {
                this.ToastService.ShowError(result?.Errors.First());
            }
        }

        private async Task AddToCart(long id) {
            var cartRequest = new ShoppingCartRequestModel {
                ProductId = id,
            };

            var result = await this.ShoppingCartsService.AddProduct(cartRequest);
            if(result != null && result.Succeeded) {
                this.NavigationManager.NavigateTo("/cart", forceLoad: false);
            } else {
                this.ToastService.ShowError(result?.Errors.First());
            }
        }

        private void ChangeView() {
            this.ListView = !this.ListView;
        }

        private void Reset() {
            this.model.MinPrice = null;
            this.model.MaxPrice = null;
            this.NavigationManager.NavigateTo("/products/page/1");
        }

        private void Filter() {
            if(!string.IsNullOrWhiteSpace(this.model.Query) && string.IsNullOrWhiteSpace(this.CategoryName) && !this.model.Category.HasValue) {
                this.NavigationManager.NavigateTo($"/products/search/{this.model.Query}/page/{this.model.Page}");
            } else if(!string.IsNullOrWhiteSpace(this.model.Query) && !string.IsNullOrWhiteSpace(this.CategoryName) && this.model.Category.HasValue) {
                this.NavigationManager.NavigateTo($"/products/category/{this.CategoryName}/{this.model.Category}/search/{this.model.Query}/page/{this.model.Page}");
            } else if(!string.IsNullOrWhiteSpace(this.CategoryName) && this.model.Category.HasValue) {
                this.NavigationManager.NavigateTo($"/products/category/{this.CategoryName}/{this.model.Category}/page/{this.model.Page}");
            } else if(string.IsNullOrWhiteSpace(this.model.Query) && string.IsNullOrWhiteSpace(this.CategoryName) && !this.model.Category.HasValue) {
                this.NavigationManager.NavigateTo($"/products/page/{this.model.Page}");
            }
        }
    }
}
