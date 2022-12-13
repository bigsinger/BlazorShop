namespace BlazorShop.Tests.Data {
    using BlazorShop.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public static class ProductsTestData {
        public static List<Product> GetProducts(int count)
            => Enumerable
                .Range(1, count)
                .Select(i => new Product {
                    Name = $"Product {i}",
                    Summary = $"Summary {i}",
                    Description = $"Description {i}",
                    ImageSource = $"Image {i}",
                    Quantity = i,
                    Price = i + 0.5m,
                    CategoryId = (long)i
                })
                .ToList();
    }
}
