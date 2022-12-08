namespace BlazorShop.Models.Orders {
    using System.ComponentModel.DataAnnotations;

    public class OrdersRequestModel {
        [Required]
        public long AddressId { get; set; }
    }
}