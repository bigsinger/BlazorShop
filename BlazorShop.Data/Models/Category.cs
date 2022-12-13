namespace BlazorShop.Data.Models {
    using Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category : BaseDeletableModel {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; } = 0;
        public long ParentId { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; } = new HashSet<Product>();
    }
}