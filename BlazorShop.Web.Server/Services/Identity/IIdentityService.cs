namespace BlazorShop.Services.Identity {
    using BlazorShop.Common.Common;
    using Common;
    using Models.Identity;
    using System.Threading.Tasks;

    public interface IIdentityService : IService {
        Task<Result> RegisterAsync(RegisterRequestModel model);

        Task<Result<LoginResponseModel>> LoginAsync(LoginRequestModel model);

        Task<Result> ChangeSettingsAsync(ChangeSettingsRequestModel model, string userId);

        Task<Result> ChangePasswordAsync(ChangePasswordRequestModel model, string userId);
    }
}
