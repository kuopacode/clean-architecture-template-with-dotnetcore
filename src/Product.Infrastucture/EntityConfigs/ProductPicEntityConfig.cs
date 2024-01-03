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
    public class ProductPicEntityConfig : IEntityTypeConfiguration<ProductPicEntity>
    {
        public void Configure(EntityTypeBuilder<ProductPicEntity> config)
        {
            config.ToTable("product_pics", ProductContext.DEFAULT_SCHEMA);
            config.HasKey(p => p.Id);
            config.Ignore(p => p.DomainEvents);

            config.Property(p => p.PictureUrl).HasColumnName("picture_url");

            config.Property<int>("ProductEntityId").HasColumnName("product_id").IsRequired();
        }
    }
}
