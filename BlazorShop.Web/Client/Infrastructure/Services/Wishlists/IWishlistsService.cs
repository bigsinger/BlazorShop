namespace BlazorShop.Web.Client.Infrastructure.Services.Wishlists {
    using Models;
    using Models.Wishlists;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWishlistsService {
        Task<Result> AddProduct(long id);

        Task<Result> RemoveProduct(long id);

        Task<IEnumerable<WishlistsProductsResponseModel>> Mine();
    }
}
