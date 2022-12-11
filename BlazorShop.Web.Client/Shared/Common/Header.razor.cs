namespace BlazorShop.Web.Client.Shared.Common {
    using Models.Categories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public partial class Header {
        private IEnumerable<CategoriesListingResponseModel> categories;

        protected override async Task OnInitializedAsync()
            => this.categories = await this.CategoriesService.All();
    }
}
