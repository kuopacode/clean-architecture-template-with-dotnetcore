using Product.Doamin.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Doamin.AggregateModels.ProductAggrerate
{
    public class ProductStatus : Enumeration
    {
        public static ProductStatus Draft = new ProductStatus(1, "草稿");
        public static ProductStatus Review = new ProductStatus(2, "待審核");
        public static ProductStatus NotReady = new ProductStatus(3, "審核未過");
        public static ProductStatus Ready = new ProductStatus(4, "審核通過");
        public static ProductStatus Active = new ProductStatus(5, "上架中");
        public static ProductStatus Inactive = new ProductStatus(6, "下架");
        public static ProductStatus Deleted = new ProductStatus(7, "刪除");

        public ProductStatus(int id, string name) : base(id, name)
        { }

        public static ProductStatus From(int id)
        {
            var state = Enumeration.GetAll<ProductStatus>().SingleOrDefault(s => s.Id == id);
            if (state == null)
            {
                return null;
            }

            return state;
        }
    }
}
