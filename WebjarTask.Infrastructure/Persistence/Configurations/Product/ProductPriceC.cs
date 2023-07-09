using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebjarTask.Domain.Entities.Product;

namespace WebjarTask.Infrastructure.Persistence.Configurations.Product
{
    internal sealed class ProductPriceC : IEntityTypeConfiguration<ProductPriceM>
    {
        public void Configure(EntityTypeBuilder<ProductPriceM> builder)
        {
            #region propertyConfigs
            builder.HasKey(e => e.Id);
            builder.ToTable("ProductPrice", "dbo");
            builder.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.DiscountAmount).IsRequired(false).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.DiscountExpireAt).IsRequired(false);
            #endregion
            #region FluentApi
            builder.HasOne(e => e.Product).WithMany(e => e.ProductPrices)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.ProductFeatures).WithOne(e => e.ProductPrice)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
