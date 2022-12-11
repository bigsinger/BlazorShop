namespace BlazorShop.Web.Client.Extensions {
    using BlazorShop.Common;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    public static class ResultExtensions {
        public static async Task<Result> ToResult(this Task<HttpResponseMessage> responseTask) {
            var response = await responseTask;

            if(!response.IsSuccessStatusCode) {
                var errors = await response.Content.ReadFromJsonAsync<string[]>();

                return Result.Failure(errors);
            }

            return Result.Success;
        }
    }
}
