using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Code);

            builder.Property(p => p.Description).HasMaxLength(500).IsRequired();
            builder.Property(p => p.ManufacturedDate).IsRequired();
            builder.Property(p => p.ValidityDate).IsRequired();
            builder.Property(p => p.Status).IsRequired();

            builder.HasOne(p => p.Supplier).WithMany(s => s.Products)
                .HasForeignKey(s => s.CodeSupplier);

        }
    }
}
