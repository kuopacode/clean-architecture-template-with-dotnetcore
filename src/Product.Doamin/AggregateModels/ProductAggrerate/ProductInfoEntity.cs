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
    }
}
