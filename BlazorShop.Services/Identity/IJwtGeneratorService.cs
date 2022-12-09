namespace BlazorShop.Services.Identity {
    using BlazorShop.Common.Common;
    using Data.Models;
    using System.Threading.Tasks;

    public interface IJwtGeneratorService : IService {
        Task<string> GenerateJwtAsync(BlazorShopUser user);
    }
}
