namespace BlazorShop.Web.Client.Services {
    using Models.Orders;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrdersService {
        Task<string> Purchase(OrdersRequestModel model);

        Task<OrdersDetailsResponseModel> Details(string id);

        Task<IEnumerable<OrdersListingResponseModel>> Mine();
    }
}