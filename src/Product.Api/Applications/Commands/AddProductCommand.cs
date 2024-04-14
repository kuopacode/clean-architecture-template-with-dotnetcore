using MediatR;
using Product.Doamin.AggregateModels.ProductAggrerate;

namespace Product.Api.Applications.Commands
{
    public class AddProductCommand : IRequest<bool>
    {
        public string ProductName { get;  set; }
        public string Description { get; set; }
        public DateTime SaleStartDate { get; set; }
        public DateTime SaleEndDate { get; set; }
        public List<string> ProductPics { get; set; }
        public List<ProductInfoModel> ProductInfos { get; set; }
        public List<ProductPriceScheduleModel> ProductPriceSchedules { get; set; }
        public List<ProductCategoryModel> ProductCategories { get; set; }

        #region model
        public class ProductInfoModel
        {
            public int ProductInfoType { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string Content { get; set; }
        }
        public class ProductPriceScheduleModel
        {
            public int MarketPrice { get; set; }
            public int SalePrice { get; set; }
            public DateTime SaleStartDate { get; set; }
            public DateTime SaleEndDate { get; set; }
        }
        public class ProductCategoryModel
        {
            public int D1CategoryId { get; set; }
            public int D2CategoryId { get; set; }
            public int D3CategoryId { get; set; }
        }
        #endregion
    }

}
