namespace BlazorShop.Web.Client.Services {
    using Models.Categories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService {
        Task<IEnumerable<CategoriesListingResponseModel>> All();
    }
}
