namespace BlazorShop.Data.Models {
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class Order : BaseModel {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UserId { get; set; }

        public BlazorShopUser User { get; set; }

        public long DeliveryAddressId { get; set; }

        public Address DeliveryAddress { get; set; }

        public ICollection<OrderProduct> Products { get; } = new HashSet<OrderProduct>();
    }
}
