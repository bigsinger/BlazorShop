﻿namespace BlazorShop.Models.Products {
    public class ProductsSearchRequestModel {
        public string Query { get; set; }

        public long? Category { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public int Page { get; set; } = 1;
    }
}
