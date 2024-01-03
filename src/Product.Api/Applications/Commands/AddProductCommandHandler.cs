using MediatR;
using Product.Doamin.AggregateModels.ProductAggrerate;

namespace Product.Api.Applications.Commands
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, bool>
    {
        private readonly IProductRepository _repo;
        public AddProductCommandHandler(IProductRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = new ProductEntity(request);
            _repo.Add(productEntity);

            return await _repo.UnitOfWork.SaveEntitiesAsync(cancellationToken) > 0;
        }
    }
}
