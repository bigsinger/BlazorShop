namespace BlazorShop.Services.Products {
    using BlazorShop.Common.Common;
    using Common;
    using Models.Products;
    using System.Threading.Tasks;

    public interface IProductsService : IService {
        Task<long> CreateAsync(ProductsRequestModel model);

        Task<Result> UpdateAsync(long id, ProductsRequestModel model);

        Task<Result> DeleteAsync(long id);

        Task<ProductsDetailsResponseModel> DetailsAsync(long id);

        Task<ProductsSearchResponseModel> SearchAsync(ProductsSearchRequestModel model);
    }
}