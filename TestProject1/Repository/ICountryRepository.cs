using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject1.Models;

namespace TestProject1.Repository
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetCountries();



        Task<Country> GetCountryID(int? CountryId);

        Task<Country> createCountry(Country country);

        Task<int> DeleteCountry(int? CountryId);

        Task UpdateCountry(Country country);
    }
}
