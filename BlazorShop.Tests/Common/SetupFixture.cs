namespace BlazorShop.Tests.Common {
    using AutoMapper;
    using BlazorShop.Data;
    using BlazorShop.Models.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System;

    public abstract class SetupFixture : IDisposable {
        protected SetupFixture() {
            this.Data = InitializeDbContext();
            this.Mapper = InitializeAutoMapper();
        }

        protected BlazorShopDbContext Data { get; }

        protected IMapper Mapper { get; }

        public void Dispose() => this.Data?.Dispose();

        private static BlazorShopDbContext InitializeDbContext() {
            var options = new DbContextOptionsBuilder<BlazorShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new BlazorShopDbContext(options);
        }

        private static IMapper InitializeAutoMapper() {
            var profile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));

            return new Mapper(configuration);
        }
    }
}
