using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Product.Doamin.AggregateModels.ProductAggrerate;
using Product.Doamin.SeedWork;
using Product.Infrastucture.Extensions;

namespace Product.Infrastucture
{
    public class ProductContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "product";
        public DbSet<ProductEntity> Products { get; set; }

        private readonly IMediator _mediator;

        private IDbContextTransaction _currentTransaction;

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        private readonly ILogger<ProductContext> _logger;
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;

        public ProductContext(DbContextOptions<ProductContext> options, IMediator mediator, ILogger<ProductContext> logger) : base(options)
        {
            _logger = logger;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);
            try
            {
                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
