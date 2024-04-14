using MediatR;
using Product.Api.Applications.Dtos;
using Product.Api.Applications.ViewModels;

namespace Product.Api.Applications.Queries
{
    public class GetProductQuery : IRequest<GetProductVo>
    {
        public int ProductId { get; set; }
    }
}
