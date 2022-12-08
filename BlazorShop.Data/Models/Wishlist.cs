namespace BlazorShop.Data.Models {
    using Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Wishlist : BaseModel {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; } = 0;

        public string UserId { get; set; }

        public BlazorShopUser User { get; set; }

        public ICollection<WishlistProduct> Products { get; } = new HashSet<WishlistProduct>();
    }
}
