using MediatR;
using Product.Doamin.AggregateModels.ProductAggrerate;

namespace Product.Api.Applications.Commands
{
    public class AddProductCommand : IRequest<bool>, IProductEntity
    {
        public string ProductName { get;  set; }
        public string Description { get; set; }
        public DateTime SaleStartDate { get; set; }
        public DateTime SaleEndDate { get; set; }
        public List<string> ProductPics { get; set; }
        public List<IProductInfoEntity> ProductInfos { get; set; }
        public List<IProductPriceScheduleEntity> ProductPriceSchedules { get; set; }
        public List<IProductCategoryEntity> ProductCategories { get; set; }

        #region model
        public class ProductInfoModel : IProductInfoEntity
        {
            public string Title { get; set; }
            public string Content { get; set; }
        }
        public class ProductPriceScheduleModel : IProductPriceScheduleEntity
        {
            public int MarketPrice { get; set; }
            public int SalePrice { get; set; }
            public DateTime SaleStartDate { get; set; }
            public DateTime SaleEndDate { get; set; }
        }
        public class ProductCategoryModel : IProductCategoryEntity
        {
            public int D1CategoryId { get; set; }
            public int D2CategoryId { get; set; }
            public int D3CategoryId { get; set; }
        }
        #endregion
    }

}
