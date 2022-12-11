namespace BlazorShop.Web.Client.Services {
    using BlazorShop.Common;
    using BlazorShop.Web.Client.Extensions;
    using Models.Wishlists;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    public class WishlistsService : IWishlistsService {
        private readonly HttpClient http;

        private const string WishlistsPath = "api/wishlists";

        public WishlistsService(HttpClient http) => this.http = http;

        public async Task<Result> AddProduct(long id) {
            try {
                return await this.http
                            .PostAsJsonAsync($"{WishlistsPath}/{nameof(this.AddProduct)}/{id}", id)
                            .ToResult();
            } catch (Exception e) {
                if (e.Message.Contains("token")) {
                    return "未登录\n" + e.Message;
                }
                return e.Message;
            }
        }

        public async Task<Result> RemoveProduct(long id)
            => await this.http
                .DeleteAsync($"{WishlistsPath}/{nameof(this.RemoveProduct)}/{id}")
                .ToResult();

        public async Task<IEnumerable<WishlistsProductsResponseModel>> Mine()
            => await this.http.GetFromJsonAsync<IEnumerable<WishlistsProductsResponseModel>>(WishlistsPath);
    }
}
