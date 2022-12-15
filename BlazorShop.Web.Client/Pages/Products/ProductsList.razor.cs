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
        [SupplyParameterFromQuery(Name = "categoryId")]
        public long? CategoryId { get; set; }

        [Parameter]
        [SupplyParameterFromQuery(Name = "categoryName")]
        public string CategoryName { get; set; }

        [Parameter]
        [SupplyParameterFromQuery(Name = "key")]
        public string SearchQuery { get; set; } = string.Empty;

        [Parameter]
        [SupplyParameterFromQuery(Name = "orderby")]
        public string OrderBy { get; set; } = string.Empty;

        [Parameter]
        [SupplyParameterFromQuery(Name = "page")]
        public int Page { get; set; } = 1;

        [Parameter]
        [SupplyParameterFromQuery(Name = "view")]
        public string viewMode { get; set; } = "list";

        private bool ListView = false;

        private string getListViewActiveStr(bool active) {
            return active ? "active" : "";
        }

        protected override async Task OnInitializedAsync() {
            await this.LoadData();
        }

        protected override async Task OnParametersSetAsync() {
            ListView = viewMode != null && viewMode.Contains("list");
            await this.LoadData(withCategories: false);
        }

        private async Task SelectedPage(int page) {
            this.Page = page;

            await this.LoadData(withCategories: false);
        }

        private async Task LoadData(bool withCategories = true) {
            if(this.Page <= 0) { this.Page = 1; }

            this.model.Category = this.CategoryId;
            this.model.Query = this.SearchQuery;
            this.model.OrderBy = this.OrderBy;
            this.model.Page = this.Page;

            this.searchResponse = await this.ProductsService.SearchAsync(this.model);
            this.products = this.searchResponse.Products;

            if(withCategories) {
                this.categories = await this.CategoriesService.All();
            }
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
            viewMode = this.ListView ? "list" : "grid";
        }

        private void Reset() {
            this.model.MinPrice = null;
            this.model.MaxPrice = null;
            this.NavigationManager.NavigateTo("/products");
        }
    }
}
