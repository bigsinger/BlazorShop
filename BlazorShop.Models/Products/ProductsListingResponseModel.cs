namespace BlazorShop.Models.Products {
    using Common.Mapping;
    using Data.Models;
    using System;

    public class ProductsListingResponseModel : IMapFrom<Product> {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ImageSource { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
