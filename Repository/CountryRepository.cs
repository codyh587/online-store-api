using AutoMapper;
using OnlineStoreAPI.Data;
using OnlineStoreAPI.Interfaces;
using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CountryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryBySeller(int sellerId)
        {
            return _context.Sellers.Where(s => s.Id == sellerId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Seller> GetSellersFromACountry(int countryId)
        {
            return _context.Sellers.Where(c => c.Country.Id == countryId).ToList();
        }
    }
}
