namespace Product.Api.Applications.ViewModels
{
    public class GetProductVo
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public DateTime SaleStartDate { get; set; }
        public DateTime SaleEndDate { get; set; }
        public List<string> ProductPics { get; set; }
        public List<ProductInfoVo> ProductInfos { get; set; }
        public List<ProductPriceScheduleVo> ProductPriceSchedules { get; set; }
        public List<ProductCategoryVo> ProductCategories { get; set; }

        public class ProductInfoVo
        {
            public int ProductInfoType { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
        }
        public class ProductPriceScheduleVo
        {
            public int Id { get; set; }
            public int MarketPrice { get; set; }
            public int SalePrice { get; set; }
            public DateTime SaleStartDate { get; set; }
            public DateTime SaleEndDate { get; set; }
        }
        public class ProductCategoryVo
        {
            public int D1CategoryId { get; set; }
            public int D2CategoryId { get; set; }
            public int D3CategoryId { get; set; }
        }
    }
}

