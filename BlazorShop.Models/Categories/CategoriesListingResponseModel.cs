namespace BlazorShop.Models.Categories {
    using Common.Mapping;
    using Data.Models;

    public class CategoriesListingResponseModel : IMapFrom<Category> {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}