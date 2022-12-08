namespace BlazorShop.Models.Products {
    public class ProductsDetailsResponseModel : ProductsListingResponseModel {
        public int Quantity { get; set; }

        public long CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
