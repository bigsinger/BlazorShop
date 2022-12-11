namespace BlazorShop.Services.ShoppingCarts {
    using BlazorShop.Common.Common;
    using Common;
    using Models.ShoppingCarts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IShoppingCartsService : IService {
        Task<Result> AddProductAsync(ShoppingCartRequestModel model, string userId);

        Task<Result> UpdateProductAsync(ShoppingCartRequestModel model, string userId);

        Task<Result> RemoveProductAsync(long productId, string userId);

        Task<int> TotalAsync(string userId);

        Task<IEnumerable<ShoppingCartProductsResponseModel>> ByUserAsync(string userId);
    }
}
