namespace BlazorShop.Web.Client.Infrastructure.Services.Products {
    using Models;
    using Models.Products;
    using System.Threading.Tasks;

    public interface IProductsService {
        Task<long> CreateAsync(ProductsRequestModel model);

        Task<Result> UpdateAsync(long id, ProductsRequestModel model);

        Task<Result> DeleteAsync(long id);

        Task<TModel> DetailsAsync<TModel>(long id) where TModel : class;

        Task<ProductsSearchResponseModel> SearchAsync(ProductsSearchRequestModel model);
    }
}