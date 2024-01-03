using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Doamin.SeedWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
