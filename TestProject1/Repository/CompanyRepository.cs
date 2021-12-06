using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject1.DAL;
using TestProject1.Models;

namespace TestProject1.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DatabaseContext db;
        public CompanyRepository(DatabaseContext _db)
        {
            db = _db;
        }

        

        public async Task<Company> createCompany(Company company)
        {
            if (db != null)
            {
                await db.Company.AddAsync(company);
                await db.SaveChangesAsync();

                return company;
            }

            return null;
        }

        public async Task<int> DeleteCompany(int? CompanyId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var company = await db.Company.FirstOrDefaultAsync(x => x.ID == CompanyId);

                if (company != null)
                {
                    //Delete that post
                    db.Company.Remove(company);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                if(result == 1)
                {
                    return CompanyId.Value;
                }
          
            }

            return result;
        }

        public async Task<List<Company>> GetCompanies()
        {
            if (db != null)
            {
                return await db.Company.ToListAsync();
            }

            return null;
        }

        public async Task<Company> GetCompanyID(int? CompanyId)
        {
            if (db != null)
            {
                return await(from p in db.Company
                             where p.ID == CompanyId
                             select new Company
                             {
                                 ID = p.ID,
                                 CompanyName = p.CompanyName
                             }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task UpdateCompany(Company company)
        {
            if (db != null)
            {
                //Delete that post
                db.Company.Update(company);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}