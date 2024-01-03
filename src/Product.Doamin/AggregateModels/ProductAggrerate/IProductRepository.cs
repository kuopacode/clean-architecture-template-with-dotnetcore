using Product.Doamin.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Doamin.AggregateModels.ProductAggrerate
{
    public interface IProductRepository : IRepository<ProductEntity>
    {
        void Add(ProductEntity product);
        Task<ProductEntity> GetAsync(int id);
    }
}
