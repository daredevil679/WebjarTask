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
    internal sealed class ProductFeaturesC : IEntityTypeConfiguration<ProductFeaturesM>
    {
        public void Configure(EntityTypeBuilder<ProductFeaturesM> builder)
        {
            #region propertyConfigs
            builder.HasKey(e => new { e.ProductPriceId, e.FeatureId });
            builder.ToTable("ProductFeatures", "dbo");
            builder.Property(e => e.Value).IsRequired().HasMaxLength(150);
            #endregion
            #region FluentApi
            builder.HasOne(e => e.ProductPrice).WithMany(e => e.ProductFeatures)
                .HasForeignKey(e=>e.ProductPriceId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.Feature).WithMany(e => e.ProductFeatures)
                .HasForeignKey(e => e.FeatureId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
