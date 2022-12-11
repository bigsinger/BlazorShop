namespace BlazorShop.Web.Client.Services {
    using BlazorShop.Common;
    using BlazorShop.Web.Client.Extensions;
    using Models.ShoppingCarts;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    public class ShoppingCartsService : IShoppingCartsService {
        private readonly HttpClient http;

        private const string ShoppingCartsPath = "api/shoppingcarts";

        public ShoppingCartsService(HttpClient http) => this.http = http;

        public async Task<Result> AddProduct(ShoppingCartRequestModel model) {
            try {
                return await this.http
                .PostAsJsonAsync($"{ShoppingCartsPath}/{nameof(this.AddProduct)}", model)
                .ToResult();
            } catch (Exception e) {
                if (e.Message.Contains("token")) {
                    return "未登录\n" + e.Message;
                }
                return e.Message;
            }
        }

        public async Task<Result> UpdateProduct(ShoppingCartRequestModel model)
            => await this.http
                .PutAsJsonAsync($"{ShoppingCartsPath}/{nameof(this.UpdateProduct)}", model)
                .ToResult();

        public async Task<Result> RemoveProduct(long id)
            => await this.http.DeleteAsync($"{ShoppingCartsPath}/{nameof(this.RemoveProduct)}/{id}").ToResult();

        public async Task<int> TotalProducts()
            => await this.http.GetFromJsonAsync<int>($"{ShoppingCartsPath}/{nameof(this.TotalProducts)}");

        public async Task<IEnumerable<ShoppingCartProductsResponseModel>> Mine()
            => await this.http.GetFromJsonAsync<IEnumerable<ShoppingCartProductsResponseModel>>(ShoppingCartsPath);
    }
}
