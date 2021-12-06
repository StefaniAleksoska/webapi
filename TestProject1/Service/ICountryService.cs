using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject1.Models;

namespace TestProject1.Service
{
    public interface ICountryService
    {
        Task<Country>GetCountryID(int id);
        Task<Country>createCountry(Country req);
        Task updateCountry(Country req);
        Task<int> deleteCountry(int id);
        Task<List<Country>> GetCountries();
    }
}
