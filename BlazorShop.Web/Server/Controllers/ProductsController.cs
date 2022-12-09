namespace BlazorShop.Web.Server.Controllers {
    using BlazorShop.Web.Server.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Products;
    using Services.Products;
    using System.Threading.Tasks;
    using static BlazorShop.Data.Constants;

    [Authorize(Roles = AdministratorRole)]
    public class ProductsController : ApiController {
        private readonly IProductsService products;

        public ProductsController(IProductsService products)
            => this.products = products;

        [HttpGet]
        [AllowAnonymous]
        public async Task<ProductsSearchResponseModel> Search([FromQuery] ProductsSearchRequestModel model)
            => await this.products.SearchAsync(model);

        [HttpGet(Id)]
        [AllowAnonymous]
        public async Task<ProductsDetailsResponseModel> Details(long id)
            => await this.products.DetailsAsync(id);

        [HttpPost]
        public async Task<ActionResult> Create(ProductsRequestModel model) {
            var id = await this.products.CreateAsync(model);

            return Created(nameof(this.Create), id);
        }

        [HttpPut(Id)]
        public async Task<ActionResult> Update(long id, ProductsRequestModel model)
            => await this.products
                .UpdateAsync(id, model)
                .ToActionResult();

        [HttpDelete(Id)]
        public async Task<ActionResult> Delete(long id)
            => await this.products
                .DeleteAsync(id)
                .ToActionResult();
    }
}
