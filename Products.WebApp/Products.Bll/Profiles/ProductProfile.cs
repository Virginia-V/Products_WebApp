using AutoMapper;
using Products.Common.Dtos.Products;
using Products.Common.Dtos.Ratings;
using Products.Domain;

namespace Products.Bll.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Rating, RatingDto>();
            CreateMap<RatingDto, Rating>();
            CreateMap<CreateProductDto, Product>();
        }
    }
}
