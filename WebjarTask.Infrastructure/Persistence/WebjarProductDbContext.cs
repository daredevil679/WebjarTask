using Microsoft.EntityFrameworkCore;
using WebjarTask.Domain.Entities.Product;

namespace WebjarTask.Infrastructure.Persistence
{
    public class WebjarProductDbContext : DbContext
    {
        public WebjarProductDbContext(DbContextOptions<WebjarProductDbContext> options)
        : base(options) { }
        #region Tables
        public DbSet<AdditiveM> Additive { get; set; }
        public DbSet<FeaturesM> Features { get; set; }
        public DbSet<ProductAdditiveM> ProductAdditive { get; set; }
        public DbSet<ProductFeaturesM> ProductFeatures { get; set; }
        public DbSet<ProductM> Product { get; set; }
        public DbSet<ProductPriceM> ProductPrice { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(WebjarProductDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
