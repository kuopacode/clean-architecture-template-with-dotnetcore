using Product.Doamin.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Doamin.AggregateModels.ProductAggrerate
{
    public class ProductInfoEntity : Entity
    {
        public ProductInfoType InfoType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Title => InfoType.Name;
        public string Content { get; set; }

        public ProductInfoEntity() { }
        public ProductInfoEntity(IProductInfoEntity info)
        {
            InfoType = ProductInfoType.From(info.ProductInfoType);
            StartDate = info.StartDate;
            EndDate = info.EndDate;
            Content = info.Content;
        }
    }
}
