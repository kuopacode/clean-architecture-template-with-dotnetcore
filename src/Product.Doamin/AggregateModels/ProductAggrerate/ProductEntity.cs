using Product.Doamin.SeedWork;
using Product.Doamin.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Doamin.AggregateModels.ProductAggrerate
{
    public class ProductEntity : Entity, IAggregateRoot
    {
        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public ProductStatus Status { get; private set; }
        public DateTime SaleStartDate { get; private set; }
        public DateTime SaleEndDate { get; private set; }
        public int Stock { get; private set; }
        public DateTime CreateTime { get; private set; }
        public List<ProductInfoEntity> ProductInfos { get; private set; }
        public List<ProductPicEntity> ProductPics { get; private set; }
        public List<ProductPriceScheduleEntity> ProductPriceSchedules { get; private set; }
        public List<ProductCategoryEntity> ProductCategories { get; private set; }

        public ProductEntity() { }
        public ProductEntity(IProductEntity product)
        {
            ProductName = product.ProductName;
            Description = product.Description;
            Status = ProductStatus.Draft;
            SaleStartDate = product.SaleStartDate;
            SaleEndDate = product.SaleEndDate;
            Stock = 0;
            CreateTime = DateTime.Now;

            ProductInfos = product.ProductInfos.Select(x => new ProductInfoEntity(x)).ToList();
            ProductPics = product.ProductPics.Select(x => new ProductPicEntity(x)).ToList();
            ProductPriceSchedules = product.ProductPriceSchedules.Select(x => new ProductPriceScheduleEntity(x)).ToList();
            ProductCategories = product.ProductCategories.Select(x => new ProductCategoryEntity(x)).ToList();
        }

    }
}
