namespace BlazorShop.Services.Orders {
    using BlazorShop.Common.Common;
    using Models.Orders;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrdersService : IService {
        Task<string> PurchaseAsync(OrdersRequestModel model, string userId);

        Task<OrdersDetailsResponseModel> DetailsAsync(string id);

        Task<IEnumerable<OrdersListingResponseModel>> ByUserAsync(string userId);
    }
}