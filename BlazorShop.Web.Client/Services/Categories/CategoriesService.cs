namespace BlazorShop.Web.Client.Services {
    using Models.Categories;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    public class CategoriesService : ICategoriesService {
        private readonly HttpClient http;

        private const string CategoriesPath = "api/categories";

        public CategoriesService(HttpClient http) => this.http = http;

        public async Task<IEnumerable<CategoriesListingResponseModel>> All()
            => await this.http.GetFromJsonAsync<IEnumerable<CategoriesListingResponseModel>>(CategoriesPath);
    }
}
