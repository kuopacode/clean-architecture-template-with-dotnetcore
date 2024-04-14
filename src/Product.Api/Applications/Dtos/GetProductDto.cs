namespace Product.Api.Applications.Dtos
{
    public class GetProductDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public DateTime SaleStartDate { get; set; }
        public DateTime SaleEndDate { get; set; }
        public List<string> ProductPics { get; set; }
        public List<ProductInfoDto> ProductInfos { get; set; }
        public List<ProductPriceScheduleDto> ProductPriceSchedules { get; set; }
        public List<ProductCategoryDto> ProductCategories { get; set; }

        public GetProductDto()
        {
            ProductPics = new List<string>();
            ProductInfos = new List<ProductInfoDto>();
            ProductPriceSchedules = new List<ProductPriceScheduleDto>();
            ProductCategories = new List<ProductCategoryDto>();
        }

        public class ProductInfoDto
        {
            public int ProductInfoType { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
        }
        public class ProductPriceScheduleDto
        {
            public int Id { get; set; }
            public int MarketPrice { get; set; }
            public int SalePrice { get; set; }
            public DateTime SaleStartDate { get; set; }
            public DateTime SaleEndDate { get; set; }
        }
        public class ProductCategoryDto
        {
            public int D1CategoryId { get; set; }
            public int D2CategoryId { get; set; }
            public int D3CategoryId { get; set; }
        }
    }
}

