namespace BlazorShop.Services {
    using AutoMapper;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public abstract class BaseService<TEntity> where TEntity : class {
        protected BaseService(BlazorShopDbContext data, IMapper mapper) {
            this.Data = data;
            this.Mapper = mapper;
        }

        protected BlazorShopDbContext Data { get; }

        protected IMapper Mapper { get; }

        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        protected IQueryable<TEntity> AllAsNoTracking() => this.All().AsNoTracking();
    }
}
