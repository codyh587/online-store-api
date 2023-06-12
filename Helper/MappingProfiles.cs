using AutoMapper;
using OnlineStoreAPI.Dto;
using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Helper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();

            CreateMap<Seller, SellerDto>();
            CreateMap<SellerDto, Seller>();
            
            CreateMap<Review, ReviewDto>();
            
            CreateMap<Reviewer, ReviewerDto>();
        }
    }
}
