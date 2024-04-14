using Dapper;
using Product.Api.Applications.Dtos;
using Product.Infrastucture.Seedworks;
using static Product.Api.Applications.Dtos.GetProductDto;

namespace Product.Api.Applications.Seedworls
{
    public class ProductQuery : IProductQuery
    {
        private readonly IUnitOfWorkDapper _dapper;

        public ProductQuery(IUnitOfWorkDapper dapper)
        {
            _dapper = dapper;
        }

        /// <summary>
        /// 取得商品資訊
        /// </summary>
        /// <param name="id">product pk</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<GetProductDto> GetProduct(int id)
        {
            var sql = @"
SELECT
	Id,
	product_name,
	description,
	status,
	sale_start_date,
	sale_end_date,
	stock
FROM product.products
WHERE id = @id;

SELECT
	picture_url
FROM product.product_pics
WHERE product_id = @id;

SELECT
	info_type AS ProductInfoType,
	title,
	content,
	start_date,
	end_date
FROM product.product_infos
WHERE product_id = @id;

SELECT
	Id,
	sale_start_date,
	sale_end_date,
	market_price,
	sale_price
FROM product.product_price_schedules
WHERE product_id = @id
AND is_delete = false;

SELECT
	d1_category_id AS D1CategoryId,
	d2_category_id AS D2CategoryId,
	d3_category_id AS D3CategoryId
FROM product.product_categories
WHERE product_id = @id;
";

			var multi = await _dapper.Master.QueryMultipleAsync(sql, new
			{
				id = id,
			});

			var product = (multi.Read<GetProductDto>()).FirstOrDefault();
			if(product == null)
			{
				throw new ArgumentException("Product is not found.");
			}

			product.ProductPics = (multi.Read<string>()).ToList();
			product.ProductInfos = (multi.Read<ProductInfoDto>()).ToList();
			product.ProductPriceSchedules = (multi.Read<ProductPriceScheduleDto>()).ToList();
			product.ProductCategories = (multi.Read<ProductCategoryDto>()).ToList();

			return product;
        }
    }
}
