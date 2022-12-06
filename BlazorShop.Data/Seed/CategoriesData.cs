namespace BlazorShop.Data.Seed {
    using Contracts;
    using Models;
    using System;
    using System.Collections.Generic;

    public class CategoriesData : IInitialData {
        public Type EntityType => typeof(Category);

        public IEnumerable<object> GetData()
            => new List<Category>
            {
                new Category { Id = 1, Name = "Fashion" },
                new Category { Id = 2, Name = "Electronics" },
                new Category { Id = 3, Name = "Books, Movies & Music" }
            };
    }
}
