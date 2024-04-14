using AutoMapper;
using Product.Api.Applications.Commands;
using Product.Api.Applications.Dtos;
using Product.Api.Applications.Models;
using Product.Api.Applications.ViewModels;
using Product.Doamin.AggregateModels.ProductAggrerate;
using static Product.Api.Applications.Commands.AddProductCommand;
using static Product.Api.Applications.Dtos.GetProductDto;
using static Product.Api.Applications.Models.ProductEntityModel;
using static Product.Api.Applications.ViewModels.GetProductVo;

namespace Product.Api.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddProductCommand, ProductEntityModel>();
            CreateMap<ProductInfoModel, IProductInfoEntity>().As<ProductInfoEntityModel>();
            CreateMap<ProductInfoModel, ProductInfoEntityModel>();
            CreateMap<ProductPriceScheduleModel, IProductPriceScheduleEntity>().As<ProductPriceScheduleEntityModel>();
            CreateMap<ProductPriceScheduleModel, ProductPriceScheduleEntityModel>();
            CreateMap<ProductCategoryModel, IProductCategoryEntity>().As<ProductCategoryEntityModel>();
            CreateMap<ProductCategoryModel, ProductCategoryEntityModel>();

            CreateMap<GetProductDto, GetProductVo>();
            CreateMap<ProductInfoDto, ProductInfoVo>();
            CreateMap<ProductPriceScheduleDto, ProductPriceScheduleVo>();
            CreateMap<ProductCategoryDto, ProductCategoryVo>();
        }
    }
}
