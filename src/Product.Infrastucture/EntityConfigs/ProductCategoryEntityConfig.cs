using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Doamin.AggregateModels.ProductAggrerate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastucture.EntityConfigs
{
    public class ProductCategoryEntityConfig : IEntityTypeConfiguration<ProductCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryEntity> config)
        {
            config.ToTable("product_categories", ProductContext.DEFAULT_SCHEMA);
            config.HasKey(p => p.Id);
            config.Ignore(p => p.DomainEvents);

            config.Property(p => p.D1CategoryId).HasColumnName("d1_category_id");
            config.Property(p => p.D2CategoryId).HasColumnName("d2_category_id");
            config.Property(p => p.D3CategoryId).HasColumnName("d3_category_id");

            config.Property<int>("ProductEntityId").HasColumnName("product_id").IsRequired();
        }
    }
}
