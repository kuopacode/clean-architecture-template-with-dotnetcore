using Product.Doamin.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Doamin.AggregateModels.ProductAggrerate
{
    public class ProductCategoryEntity : Entity
    {
        public int D1CategoryId { get; set; }
        public int D2CategoryId { get; set; }
        public int D3CategoryId { get; set; }
    }
}
