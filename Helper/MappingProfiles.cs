using AutoMapper;
using OnlineStoreAPI.Dto;
using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Helper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Country, CountryDto>().ReverseMap();

            CreateMap<Seller, SellerDto>().ReverseMap();
            
            CreateMap<Review, ReviewDto>().ReverseMap();
            
            CreateMap<Reviewer, ReviewerDto>().ReverseMap();
        }
    }
}
