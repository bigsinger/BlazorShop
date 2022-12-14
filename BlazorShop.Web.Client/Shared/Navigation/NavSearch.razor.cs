namespace BlazorShop.Web.Client.Shared.Navigation {
    using Models.Products;

    public partial class NavSearch {
        private readonly ProductsSearchRequestModel searchModel = new ProductsSearchRequestModel();

        private void Search() => this.NavigationManager.NavigateTo($"/products?key={this.searchModel.Query}");
    }
}
