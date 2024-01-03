using Product.Doamin.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Doamin.AggregateModels.ProductAggrerate
{
    public class ProductPriceScheduleEntity : Entity
    {
        public int MarketPrice { get; set; }
        public int SalePrice { get; set; }
        public DateTime SaleStartDate { get; set; }
        public DateTime SaleEndDate { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDelete { get; set; }

        public ProductPriceScheduleEntity() { }
        public ProductPriceScheduleEntity(IProductPriceScheduleEntity schedule)
        {
            MarketPrice = schedule.MarketPrice;
            SalePrice = schedule.SalePrice;
            SaleStartDate = schedule.SaleStartDate;
            SaleEndDate = schedule.SaleEndDate;
            CreateTime = DateTime.Now;
            IsDelete = false;
        }
    }
}
