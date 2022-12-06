namespace BlazorShop.Data.Models {
    using Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product : BaseDeletableModel {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageSource { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<WishlistProduct> Wishlists { get; } = new HashSet<WishlistProduct>();

        public ICollection<ShoppingCartProduct> ShoppingCarts { get; } = new HashSet<ShoppingCartProduct>();

        public ICollection<OrderProduct> Orders { get; } = new HashSet<OrderProduct>();
    }
}