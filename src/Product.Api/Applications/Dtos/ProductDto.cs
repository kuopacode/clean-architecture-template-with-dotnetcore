using Product.Doamin.AggregateModels.ProductAggrerate;
using static Product.Api.Applications.Commands.AddProductCommand;

namespace Product.Api.Applications.Dtos
{
    public class ProductDto : IProductEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public DateTime SaleStartDate { get; set; }
        public DateTime SaleEndDate { get; set; }
        public List<string> ProductPics { get; set; }
        public List<IProductInfoEntity> ProductInfos { get; set; }
        public List<IProductPriceScheduleEntity> ProductPriceSchedules { get; set; }
        public List<IProductCategoryEntity> ProductCategories { get; set; }

        public class ProductInfoDto : IProductInfoEntity
        {
            public int ProductInfoType { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string Content { get; set; }
        }
        public class ProductPriceScheduleDto : IProductPriceScheduleEntity
        {
            public int MarketPrice { get; set; }
            public int SalePrice { get; set; }
            public DateTime SaleStartDate { get; set; }
            public DateTime SaleEndDate { get; set; }
        }
        public class ProductCategoryDto : IProductCategoryEntity
        {
            public int D1CategoryId { get; set; }
            public int D2CategoryId { get; set; }
            public int D3CategoryId { get; set; }
        }
    }
}
