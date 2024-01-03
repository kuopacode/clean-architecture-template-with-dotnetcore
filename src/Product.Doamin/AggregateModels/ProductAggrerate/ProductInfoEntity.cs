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
        public string Title { get; set; }
        public string Content { get; set; }

        public ProductInfoEntity() { }
        public ProductInfoEntity(IProductInfoEntity info)
        {
            Title = info.Title;
            Content = info.Content;
        }
    }
}
