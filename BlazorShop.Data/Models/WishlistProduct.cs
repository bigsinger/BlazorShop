namespace BlazorShop.Data.Models {
    using Contracts;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WishlistProduct : BaseModel {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long WishlistId { get; set; }

        public Wishlist Wishlist { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; }
    }
}
