using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryBySeller(int sellerId);
        ICollection<Seller> GetSellersFromACountry(int countryId);
        bool CountryExists(int id);
    }
}
