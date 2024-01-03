using Microsoft.EntityFrameworkCore;
using Product.Doamin.AggregateModels.ProductAggrerate;
using Product.Doamin.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastucture.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected readonly ProductContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ProductRepository(ProductContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(ProductEntity product)
        {
            if (product.IsTransient())
            {
                _context.Products.Add(product);
            }
        }

        public async Task<ProductEntity> GetAsync(int id)
        {
            return await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
    }
}
