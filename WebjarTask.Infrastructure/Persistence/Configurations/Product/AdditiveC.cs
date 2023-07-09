using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebjarTask.Domain.Entities.Product;

namespace WebjarTask.Infrastructure.Persistence.Configurations.Product
{
    internal sealed class AdditiveC : IEntityTypeConfiguration<AdditiveM>
    {
        public void Configure(EntityTypeBuilder<AdditiveM> builder)
        {
            #region propertyConfigs
            builder.HasKey(e => e.Id);
            builder.ToTable("Additive", "dbo");
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            #endregion
            #region FluentApi
            builder.HasMany(e => e.ProductAdditives).WithOne(e => e.Additive)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
