namespace BlazorShop.Web.Client.Infrastructure.Services.ShoppingCarts {
    using Models;
    using Models.ShoppingCarts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IShoppingCartsService {
        Task<Result> AddProduct(ShoppingCartRequestModel model);

        Task<Result> UpdateProduct(ShoppingCartRequestModel model);

        Task<Result> RemoveProduct(long id);

        Task<int> TotalProducts();

        Task<IEnumerable<ShoppingCartProductsResponseModel>> Mine();
    }
}
