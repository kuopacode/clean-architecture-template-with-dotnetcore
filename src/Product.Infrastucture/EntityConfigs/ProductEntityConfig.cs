using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product.Doamin.AggregateModels.ProductAggrerate;

namespace Product.Infrastucture.EntityConfigs
{
    public class ProductEntityConfig : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> config)
        {
            config.ToTable("products", ProductContext.DEFAULT_SCHEMA);
            config.HasKey(p => p.Id);
            config.Ignore(b => b.DomainEvents);

            config.Property(p => p.ProductName).HasColumnName("product_name");
            config.Property(p => p.Description).HasColumnName("description");
            {
                var converter = new ValueConverter<ProductStatus, int>(
                        from => from.Id,
                        to => ProductStatus.From(to)
                    );
                config.Property(p => p.Status).HasConversion(converter).HasColumnName("status");
            }
            config.Property(pd => pd.SaleStartDate).HasColumnName("sale_start_date");
            config.Property(pd => pd.SaleEndDate).HasColumnName("sale_end_date");
            config.Property(p => p.Stock).HasColumnName("stock");
            config.Property(p => p.CreateTime).HasColumnName("create_time");

            config.Metadata.FindNavigation(nameof(ProductEntity.ProductInfos))?.SetPropertyAccessMode(PropertyAccessMode.Field);
            config.Metadata.FindNavigation(nameof(ProductEntity.ProductPics))?.SetPropertyAccessMode(PropertyAccessMode.Field);
            config.Metadata.FindNavigation(nameof(ProductEntity.ProductPriceSchedules))?.SetPropertyAccessMode(PropertyAccessMode.Field);
            config.Metadata.FindNavigation(nameof(ProductEntity.ProductCategories))?.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
