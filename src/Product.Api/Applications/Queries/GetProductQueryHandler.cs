using AutoMapper;
using MediatR;
using Product.Api.Applications.Dtos;
using Product.Api.Applications.Seedworls;
using Product.Api.Applications.ViewModels;
using Product.Infrastucture.Seedworks;

namespace Product.Api.Applications.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductVo>
    {
        private readonly IProductQuery _query;
        private readonly IMapper _mapper;
        public GetProductQueryHandler(IProductQuery query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public async Task<GetProductVo> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _query.GetProduct(request.ProductId);
            var result = _mapper.Map<GetProductVo>(product);

            return result;
        }
    }
}
