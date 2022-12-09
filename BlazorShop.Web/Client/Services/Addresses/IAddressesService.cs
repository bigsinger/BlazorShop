namespace BlazorShop.Web.Client.Services {
    using BlazorShop.Common;
    using Models.Addresses;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAddressesService {
        Task<long> CreateAsync(AddressesRequestModel model);

        Task<Result> DeleteAsync(long id);

        Task<IEnumerable<AddressesListingResponseModel>> Mine();
    }
}
