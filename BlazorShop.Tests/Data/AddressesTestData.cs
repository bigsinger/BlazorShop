namespace BlazorShop.Tests.Data {
    using BlazorShop.Data.Models;
    using MyTested.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public static class AddressesTestData {
        public static List<Address> GetAddresses(int count, bool sameUser = true) {
            var user = new BlazorShopUser
            {
                Id = TestUser.Identifier,
                UserName = TestUser.Username
            };

            var addresses = Enumerable
                .Range(1, count)
                .Select(i => new Address
                {
                    Id = (long)i,
                    Country = $"Country {i}",
                    State = $"State {i}",
                    City = $"City {i}",
                    Description = $"Description {i}",
                    PostalCode = $"{i}{i}{i}{i}",
                    PhoneNumber = "0888888888",
                    User = sameUser ? user : new BlazorShopUser
                    {
                        Id = $"User Id {i}",
                        UserName = $"User {i}"
                    }
                })
                .ToList();

            return addresses;
        }
    }
}
