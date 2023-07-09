using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebjarTask.Domain.Entities.Product;

namespace WebjarTask.Infrastructure.Persistence.Configurations.Product
{
    internal sealed class ProductC : IEntityTypeConfiguration<ProductM>
    {
        public void Configure(EntityTypeBuilder<ProductM> builder)
        {
            #region propertyConfigs
            builder.HasKey(e => e.Id);
            builder.ToTable("Product", "dbo");
            builder.Property(e => e.Name).IsRequired().HasMaxLength(150);
            builder.Property(e => e.ImageLink).IsRequired().HasMaxLength(300);
            #endregion
            #region FluentApi
            builder.HasMany(e => e.ProductAdditives).WithOne(e => e.Product)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
