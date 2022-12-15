﻿namespace BlazorShop.Web.Client.Services {
    using BlazorShop.Common;
    using BlazorShop.Web.Client.Extensions;
    using Models.Products;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    public class ProductsService : IProductsService {
        private readonly HttpClient http;

        private const string ProductsPath = "api/products";
        private const string ProductsPathWithSlash = ProductsPath + "/";
        private const string ProductsSearchPath = ProductsPath + "?category={0}&minPrice={1}&maxPrice={2}&query={3}&page={4}&orderby={5}";

        public ProductsService(HttpClient http) => this.http = http;

        public async Task<long> CreateAsync(
            ProductsRequestModel model) {
            var response = await this.http.PostAsJsonAsync(ProductsPath, model);
            var id = await response.Content.ReadFromJsonAsync<long>();

            return id;
        }

        public async Task<Result> UpdateAsync(long id, ProductsRequestModel model)
            => await this.http
                .PutAsJsonAsync(ProductsPathWithSlash + id, model)
                .ToResult();

        public async Task<Result> DeleteAsync(long id)
            => await this.http
                .DeleteAsync(ProductsPathWithSlash + id)
                .ToResult();

        public async Task<TModel> DetailsAsync<TModel>(long id) where TModel : class
            => await this.http.GetFromJsonAsync<TModel>(ProductsPathWithSlash + id);

        public async Task<ProductsSearchResponseModel> SearchAsync(ProductsSearchRequestModel model)
            => await this.http.GetFromJsonAsync<ProductsSearchResponseModel>(
                string.Format(ProductsSearchPath,
                    model.Category,
                    model.MinPrice,
                    model.MaxPrice,
                    model.Query,
                    model.Page,
                    model.OrderBy));
    }
}