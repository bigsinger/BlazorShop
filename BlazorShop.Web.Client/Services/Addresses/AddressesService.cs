namespace BlazorShop.Web.Client.Services {
    using BlazorShop.Common;
    using Extensions;
    using Models.Addresses;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    public class AddressesService : IAddressesService {
        private readonly HttpClient http;

        private const string AddressesPath = "api/addresses";
        private const string AddressesPathWithSlash = AddressesPath + "/";

        public AddressesService(HttpClient http) => this.http = http;

        public async Task<long> CreateAsync(AddressesRequestModel model) {
            var addressResponse = await this.http.PostAsJsonAsync(AddressesPath, model);
            var addressId = await addressResponse.Content.ReadFromJsonAsync<long>();

            return addressId;
        }

        public async Task<Result> DeleteAsync(long id)
            => await this.http
                .DeleteAsync(AddressesPathWithSlash + id)
                .ToResult();

        public async Task<IEnumerable<AddressesListingResponseModel>> Mine()
            => await this.http.GetFromJsonAsync<IEnumerable<AddressesListingResponseModel>>(AddressesPath);
    }
}
