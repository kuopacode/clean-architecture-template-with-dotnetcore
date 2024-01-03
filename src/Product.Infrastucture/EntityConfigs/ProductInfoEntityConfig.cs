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
    public class ProductInfoEntityConfig : IEntityTypeConfiguration<ProductInfoEntity>
    {
        public void Configure(EntityTypeBuilder<ProductInfoEntity> config)
        {
            config.ToTable("product_infos", ProductContext.DEFAULT_SCHEMA);
            config.HasKey(p => p.Id);
            config.Ignore(p => p.DomainEvents);

            config.Property(p => p.Title).HasColumnName("title");
            config.Property(p => p.Content).HasColumnName("content");

            config.Property<int>("ProductEntityId").HasColumnName("product_id").IsRequired();
        }
    }
}
