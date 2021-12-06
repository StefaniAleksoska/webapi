using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject1.Models;

namespace TestProject1.Service
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyID(int id);
        Task<Company> createCompany(Company req);
        Task updateCompany(Company req);
        Task<int> deleteCompany(int id);
        Task<List<Company>> GetCompanies();

    }
}