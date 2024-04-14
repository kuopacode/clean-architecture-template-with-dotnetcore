using Product.Doamin.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Doamin.AggregateModels.ProductAggrerate
{
    public class ProductInfoType : Enumeration
    {
        /// <summary>
        /// 商品介紹
        /// </summary>
        public static ProductInfoType Description = new ProductInfoType(1, "Description");

        /// <summary>
        /// 行銷標語
        /// </summary>
        public static ProductInfoType Slogan = new ProductInfoType(2, "Slogan");

        /// <summary>
        /// 特價資訊
        /// </summary>
        public static ProductInfoType SpecialOffer = new ProductInfoType(3, "SpecialOffer");

        /// <summary>
        /// 注意事項
        /// </summary>
        public static ProductInfoType Precaution = new ProductInfoType(4, "Precaution");
        public ProductInfoType(int id, string name) : base(id, name)
        {
        }

        public static ProductInfoType From(int id)
        {
            var state = Enumeration.GetAll<ProductInfoType>().SingleOrDefault(s => s.Id == id);
            if (state == null)
            {
                return null;
            }

            return state;
        }
    }
}
