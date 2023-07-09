using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebjarTask.Domain.Entities.Product;

namespace WebjarTask.Infrastructure.Persistence.Configurations.Product
{
    internal sealed class ProductAdditiveC : IEntityTypeConfiguration<ProductAdditiveM>
    {
        public void Configure(EntityTypeBuilder<ProductAdditiveM> builder)
        {
            #region propertyConfigs
            builder.HasKey(e => new { e.ProductId , e.AdditiveId});
            builder.ToTable("ProductAdditive", "dbo");
            builder.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            #endregion
            #region FluentApi
            builder.HasOne(e => e.Product).WithMany(e => e.ProductAdditives)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.Additive).WithMany(e => e.ProductAdditives)
                .HasForeignKey(e=>e.AdditiveId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
