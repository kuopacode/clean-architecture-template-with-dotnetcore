using AutoMapper;
using Product.Api.Applications.Commands;
using Product.Api.Applications.Dtos;
using Product.Doamin.AggregateModels.ProductAggrerate;
using static Product.Api.Applications.Commands.AddProductCommand;
using static Product.Api.Applications.Dtos.ProductDto;

namespace Product.Api.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddProductCommand, ProductDto>();
            CreateMap<ProductInfoModel, IProductInfoEntity>().As<ProductInfoDto>();
            CreateMap<ProductInfoModel, ProductInfoDto>();
            CreateMap<ProductPriceScheduleModel, IProductPriceScheduleEntity>().As<ProductPriceScheduleDto>();
            CreateMap<ProductPriceScheduleModel, ProductPriceScheduleDto>();
            CreateMap<ProductCategoryModel, IProductCategoryEntity>().As<ProductCategoryDto>();
            CreateMap<ProductCategoryModel, ProductCategoryDto>();
        }
    }
}
