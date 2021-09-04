using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;

namespace DevReviews.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ProductReview, ProductReviewViewModel>().ReverseMap();
            CreateMap<ProductReview, ProductReviewDetailsViewModel>().ReverseMap();

            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Product, ProductDetailsViewModel>().ReverseMap();
        }
    }
}
