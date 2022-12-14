namespace BlazorShop.Data.Models {
    using Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product : BaseDeletableModel {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; } = 0;

        public string Name { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public string ImageSource { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        // 浏览次数
        public long ViewCount { get; set; }
		
        // 下载次数
		public long DownCount { get; set; }

		public long CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<WishlistProduct> Wishlists { get; } = new HashSet<WishlistProduct>();

        public ICollection<ShoppingCartProduct> ShoppingCarts { get; } = new HashSet<ShoppingCartProduct>();

        public ICollection<OrderProduct> Orders { get; } = new HashSet<OrderProduct>();
    }
}