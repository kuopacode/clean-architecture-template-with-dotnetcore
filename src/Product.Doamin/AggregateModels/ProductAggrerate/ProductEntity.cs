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
        public string SaleCode { get; private set; }
        public string Description { get; set; }
        public ProductStatus Status { get; private set; }
        public DateTime SaleStartDate { get; private set; }
        public DateTime SaleEndDate { get; private set; }
        public int Stock { get; private set; }
        public DateTime CreateTime { get; private set; }
        public List<ProductInfoEntity> ProductInfos { get; private set; }
        public List<ProductPicEntity> ProductPics { get; private set; }
        public List<ProductPriceScheduleEntity> ProductPriceSchedules { get; private set; }
        public List<ProductCategoryEntity> ProductCategories { get; private set; }

    }
}
