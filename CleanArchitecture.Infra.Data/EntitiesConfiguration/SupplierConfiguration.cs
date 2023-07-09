using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.Data.EntitiesConfiguration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(s => s.Code);

            builder.Property(s => s.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(s => s.Cnpj)
                .IsRequired();

            builder.HasData(
                new Supplier(1, "AutoGlass", "12.016.210/0001-57"),
                new Supplier(2, "JBS", "24.700.814/0001-05")
                ); 
        }
    }
}
