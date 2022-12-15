using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Models.Products {
	public class ProductsSearchRequestModel {
		public string Query { get; set; } = string.Empty;

		public long? Category { get; set; }

		[Range(0, int.MaxValue)]

		public decimal? MinPrice { get; set; }

		[Range(1, int.MaxValue)]
		public decimal? MaxPrice { get; set; }

		public int Page { get; set; } = 1;

		public string OrderBy { get; set; }

	}
}
