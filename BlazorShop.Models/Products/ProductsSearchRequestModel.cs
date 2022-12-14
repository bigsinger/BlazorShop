using BlazorShop.Common;
using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Models.Products {
    public class ProductsSearchRequestModel {
        public string Query { get; set; }

        public long? Category { get; set; }

        [Range(0, int.MaxValue)]

        public decimal? MinPrice { get; set; }

        [Range(1, int.MaxValue)]
        public decimal? MaxPrice { get; set; }

        public int Page { get; set; } = 1;
    }
}
