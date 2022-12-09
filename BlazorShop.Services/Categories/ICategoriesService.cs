namespace BlazorShop.Services.Categories {
    using BlazorShop.Common.Common;
    using Common;
    using Models.Categories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService : IService {
        Task<long> CreateAsync(CategoriesRequestModel model);

        Task<Result> UpdateAsync(long id, CategoriesRequestModel model);

        Task<Result> DeleteAsync(long id);

        Task<IEnumerable<CategoriesListingResponseModel>> AllAsync();
    }
}