namespace BlazorShop.Web.Server.Controllers;

using BlazorShop.Web.Server.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Addresses;
using Services.Addresses;
using System.Collections.Generic;
using System.Threading.Tasks;

[Authorize]
public class AddressesController : ApiController {
    private readonly IAddressesService addresses;
    private readonly ICurrentUserService currentUser;

    public AddressesController(
        IAddressesService addresses,
        ICurrentUserService currentUser) {
        this.addresses = addresses;
        this.currentUser = currentUser;
    }

    [HttpGet]
    public async Task<IEnumerable<AddressesListingResponseModel>> Mine()
        => await this.addresses.ByUserAsync(this.currentUser.UserId);

    [HttpPost]
    public async Task<ActionResult> Create(AddressesRequestModel model) {
        var userId = this.currentUser.UserId;

        var id = await this.addresses.CreateAsync(model, userId);

        return Created(nameof(this.Create), id);
    }

    [HttpDelete(Id)]
    public async Task<ActionResult> Delete(long id)
        => await this.addresses
            .DeleteAsync(id, this.currentUser.UserId)
            .ToActionResult();
}
