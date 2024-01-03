using AutoMapper;
using MediatR;
using Product.Api.Applications.Dtos;
using Product.Doamin.AggregateModels.ProductAggrerate;

namespace Product.Api.Applications.Commands
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, bool>
    {
        //private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public AddProductCommandHandler(
            //IProductRepository repo,
            IMapper mapper)
        {
            //_repo = repo;
            _mapper = mapper;
        }
        public async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductDto>(request);
            var entity = new ProductEntity(product);

            //_repo.Add(entity);
            //return await _repo.UnitOfWork.SaveEntitiesAsync(cancellationToken) > 0;
            return true;
        }
    }
}
