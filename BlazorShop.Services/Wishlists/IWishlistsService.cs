namespace BlazorShop.Services.Wishlists {
    using BlazorShop.Common.Common;
    using Common;
    using Models.Wishlists;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWishlistsService : IService {
        Task<Result> AddProductAsync(long productId, string userId);

        Task<Result> RemoveProductAsync(long productId, string userId);

        Task<IEnumerable<WishlistsProductsResponseModel>> ByUserAsync(string userId);
    }
}
