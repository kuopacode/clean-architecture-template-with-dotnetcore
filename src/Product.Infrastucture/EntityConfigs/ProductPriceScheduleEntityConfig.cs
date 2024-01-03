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
    public class ProductPriceScheduleEntityConfig : IEntityTypeConfiguration<ProductPriceScheduleEntity>
    {
        public void Configure(EntityTypeBuilder<ProductPriceScheduleEntity> config)
        {
            config.ToTable("product_price_schedules", ProductContext.DEFAULT_SCHEMA);
            config.HasKey(p => p.Id);
            config.Ignore(p => p.DomainEvents);

            config.Property(p => p.SaleStartDate).HasColumnName("sale_start_date");
            config.Property(p => p.SaleEndDate).HasColumnName("sale_end_date");
            config.Property(p => p.MarketPrice).HasColumnName("market_price");
            config.Property(p => p.SalePrice).HasColumnName("sale_price");
            config.Property(p => p.CreateTime).HasColumnName("create_time");
            config.Property(p => p.IsDelete).HasColumnName("is_delete");

            config.Property<int>("ProductEntityId").HasColumnName("product_id").IsRequired();
        }
    }
}
