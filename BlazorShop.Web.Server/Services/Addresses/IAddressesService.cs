namespace BlazorShop.Services.Addresses {
    using BlazorShop.Common.Common;
    using Common;
    using Models.Addresses;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAddressesService : IService {
        Task<long> CreateAsync(AddressesRequestModel model, string userId);

        Task<Result> DeleteAsync(long id, string userId);

        Task<IEnumerable<AddressesListingResponseModel>> ByUserAsync(string userId);
    }
}