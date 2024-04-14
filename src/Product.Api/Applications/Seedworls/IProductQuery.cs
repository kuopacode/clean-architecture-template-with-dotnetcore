using Product.Api.Applications.Dtos;

namespace Product.Api.Applications.Seedworls
{
    public interface IProductQuery
    {
        Task<GetProductDto> GetProduct(int id);
    }
}
