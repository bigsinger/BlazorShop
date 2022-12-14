namespace BlazorShop.Web.Server.Controllers {
    using BlazorShop.Web.Server.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Identity;
    using Services.Identity;
    using System.Threading.Tasks;

    public class IdentityController : ApiController {
        private readonly IIdentityService identity;
        private readonly ICurrentUserService currentUser;

        public IdentityController(
            IIdentityService identity,
            ICurrentUserService currentUser) {
            this.identity = identity;
            this.currentUser = currentUser;
        }

        [HttpPost(nameof(Register))]
        public async Task<ActionResult> Register(
            RegisterRequestModel model)
            => await this.identity
                .RegisterAsync(model)
                .ToActionResult();

        [HttpPost(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(
            LoginRequestModel model)
            => await this.identity
                .LoginAsync(model)
                .ToActionResult();

        [Authorize]
        [HttpPut(nameof(ChangeSettings))]
        public async Task<ActionResult> ChangeSettings(
            ChangeSettingsRequestModel model)
            => await this.identity
                .ChangeSettingsAsync(model, this.currentUser.UserId)
                .ToActionResult();

        [Authorize]
        [HttpPut(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword(
            ChangePasswordRequestModel model)
            => await this.identity
                .ChangePasswordAsync(model, this.currentUser.UserId)
                .ToActionResult();
    }
}
