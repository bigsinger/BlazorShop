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
                new Category { Id = 1, Name = "软件" },
                new Category { Id = 2, Name = "书籍" },
                new Category { Id = 3, Name = "其他" },
            };
    }
}
