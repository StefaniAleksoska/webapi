using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject1.Models;

namespace TestProject1.Repository
{
   public  interface ICompanyRepository
    {

        Task<List<Company>> GetCompanies();



        Task<Company> GetCompanyID(int? CompanyId);

        Task<Company> createCompany(Company company);

        Task<int> DeleteCompany(int? CompanyId);

        Task UpdateCompany(Company company);






    }
}
