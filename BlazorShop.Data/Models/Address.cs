namespace BlazorShop.Data.Models {
    using Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Address : BaseDeletableModel {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; } = 0;

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Description { get; set; }

        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public string UserId { get; set; }

        public BlazorShopUser User { get; set; }

        public ICollection<Order> Orders { get; } = new HashSet<Order>();
    }
}