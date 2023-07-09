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
    internal sealed class FeaturesC : IEntityTypeConfiguration<FeaturesM>
    {
        public void Configure(EntityTypeBuilder<FeaturesM> builder)
        {
            #region propertyConfigs
            builder.HasKey(e => e.Id);
            builder.ToTable("Features", "dbo");
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            #endregion
            #region FluentApi
            builder.HasMany(e => e.ProductFeatures).WithOne(e => e.Feature)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
