namespace BlazorShop.Web.Client.Services {
    using BlazorShop.Common;
    using Models.Identity;
    using System.Threading.Tasks;

    public interface IAuthService {
        Task<Result> Register(RegisterRequestModel model);

        Task<Result> Login(LoginRequestModel model);

        Task Logout();
    }
}
