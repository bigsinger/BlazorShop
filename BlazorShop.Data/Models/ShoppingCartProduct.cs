namespace BlazorShop.Data.Models {
    using Contracts;

    public class ShoppingCartProduct : BaseModel {
        public long ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
