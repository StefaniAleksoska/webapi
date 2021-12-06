using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject1.DAL;
using TestProject1.Models;

namespace TestProject1.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DatabaseContext db;
        public CountryRepository(DatabaseContext _db)
        {
            db = _db;
        }

        public async Task<Country> createCountry(Country country)
        {
            if (db != null)
            {
                await db.Country.AddAsync(country);
                await db.SaveChangesAsync();

                return country;
            }

            return null;
        }

        public async Task<int> DeleteCountry(int? CountryId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var country = await db.Country.FirstOrDefaultAsync(x => x.ID == CountryId);

                if (country != null)
                {
                    //Delete that post
                    db.Country.Remove(country);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                if (result == 1)
                {
                    return CountryId.Value;
                }

            }

            return result;
        }

        public async Task<List<Country>> GetCountries()
        {
            if (db != null)
            {
                return await db.Country.ToListAsync();
            }

            return null;
        }

        public async Task<Country> GetCountryID(int? CountryId)
        {
            if (db != null)
            {
                return await (from p in db.Country
                              where p.ID == CountryId
                              select new Country
                              {
                                  ID = p.ID,
                                  CountryName = p.CountryName
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task UpdateCountry(Country country)
        {
            if (db != null)
            {
                //Delete that post
                db.Country.Update(country);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }

    }
}
 
