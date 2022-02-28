using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor.Entities;

namespace Rookie.Ecom.Business
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            FromDataAccessorLayer();
            FromPresentationLayer();
        }

        private void FromPresentationLayer()
        {
            CreateMap<CategoryDto, Category>()
               .ForMember(d => d.Products, t => t.Ignore());

            CreateMap<ProductDto, Product>();

            CreateMap<ProductPictureDto, ProductPicture>();

            CreateMap<BrandDto, Brand>();

            CreateMap<OrderDto, Order>();

            CreateMap<OrderDetailDto, OrderDetail>();
                

            CreateMap<ProductRatingDto, ProductRating>();
        }

        private void FromDataAccessorLayer()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductPicture, ProductPictureDto>();
            CreateMap<Brand, BrandDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<ProductRating, ProductRatingDto>();
        }
    }
}
