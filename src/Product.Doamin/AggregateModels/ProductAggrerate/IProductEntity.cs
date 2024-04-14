using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Doamin.AggregateModels.ProductAggrerate
{
    public interface IProductEntity
    {
        string ProductName { get; set; }
        string Description { get; set; }
        DateTime SaleStartDate { get; set; }
        DateTime SaleEndDate { get; set; }
        List<string> ProductPics { get; set; }
        List<IProductInfoEntity> ProductInfos { get; set; }
        List<IProductPriceScheduleEntity> ProductPriceSchedules { get; set; }
        List<IProductCategoryEntity> ProductCategories { get; set; }
    }

    public interface IProductInfoEntity
    {
        int ProductInfoType { get; set; }
        DateTime? StartDate { get; set; }
        DateTime? EndDate { get; set; }
        string Content { get; set; }
    }
    public interface IProductPriceScheduleEntity
    {
        int MarketPrice { get; set; }
        int SalePrice { get; set; }
        DateTime SaleStartDate { get; set; }
        DateTime SaleEndDate { get; set; }
    }
    public interface IProductCategoryEntity
    {
        int D1CategoryId { get; set; }
        int D2CategoryId { get; set; }
        int D3CategoryId { get; set; }
    }
}
