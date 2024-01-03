using Product.Doamin.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Doamin.AggregateModels.ProductAggrerate
{
    public class ProductPicEntity : Entity
    {
        public string PictureUrl { get; set; }
        public ProductPicEntity() { }
        public ProductPicEntity(string url)
        {
            PictureUrl = url;
        }
    }
}
