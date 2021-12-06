using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject1.Models;
using TestProject1.Repository;

namespace TestProject1.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public async Task<Country> GetCountryID(int id)
        {
            var country = await _countryRepository.GetCountryID(id);
            return country;
        }


        public async Task<Country> createCountry(Country req)
        {
            var country = await _countryRepository.createCountry(req);

            return country;
        }

        public async Task<int> deleteCountry(int id)
        {
            var idResult = await _countryRepository.DeleteCountry(id);

            return idResult;
        }

        public async Task<List<Country>> GetCountries()
        {
            var country = await _countryRepository.GetCountries();
            return country;
        }

        public async Task updateCountry(Country req)
        {
            await _countryRepository.UpdateCountry(req);

        }
    }
}
