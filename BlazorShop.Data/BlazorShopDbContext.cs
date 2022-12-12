namespace BlazorShop.Data {
    using Contracts;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Models;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class BlazorShopDbContext : IdentityDbContext<BlazorShopUser, BlazorShopRole, string> {
        public BlazorShopDbContext(DbContextOptions<BlazorShopDbContext> options) : base(options) {
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProduct> OrdersProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<ShoppingCartProduct> ShoppingCartsProducts { get; set; }

        public DbSet<Wishlist> Wishlists { get; set; }

        public DbSet<WishlistProduct> WishlistsProducts { get; set; }

        public override int SaveChanges() {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ConfigureWarnings(wb => wb
                .Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning)
                .Ignore(CoreEventId.PossibleIncorrectRequiredNavigationWithQueryFilterInteractionWarning)
            );
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<Address>()
                .HasQueryFilter(f => !f.IsDeleted)
                .Property(f => f.Id).ValueGeneratedOnAdd();

            builder.Entity<Category>()
                .HasQueryFilter(f => !f.IsDeleted)
                .Property(f => f.Id).ValueGeneratedOnAdd();

            builder.Entity<Product>()
                .HasQueryFilter(f => !f.IsDeleted)
                .Property(f => f.Id).ValueGeneratedOnAdd();

            builder.Entity<BlazorShopUser>()
                .HasQueryFilter(f => !f.IsDeleted);

            builder.Entity<ShoppingCart>().Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Entity<ShoppingCartProduct>().Property(f => f.ShoppingCartId).ValueGeneratedOnAdd();
            builder.Entity<Wishlist>().Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Entity<WishlistProduct>().Property(f => f.WishlistId).ValueGeneratedOnAdd();

            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        private void ApplyAuditInfoRules()
            => this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added ||
                     e.State == EntityState.Modified))
                .ToList()
                .ForEach(entry => {
                    var entity = (IAuditInfo)entry.Entity;

                    if(entry.State == EntityState.Added) {
                        entity.CreatedOn = DateTime.UtcNow;
                    } else {
                        entity.ModifiedOn = DateTime.UtcNow;
                    }
                });

        private void ApplyDeletableEntityRules()
            => this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IDeletableEntity &&
                    e.State == EntityState.Deleted)
                .ToList()
                .ForEach(entry => {
                    var entity = (IDeletableEntity)entry.Entity;

                    entity.IsDeleted = true;
                    entity.DeletedOn = DateTime.UtcNow;
                    entry.State = EntityState.Modified;
                });
    }
}
