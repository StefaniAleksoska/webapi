using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject1.Models;
using TestProject1.Repository;

namespace TestProject1.Service
{
    public class CompanyService : ICompanyService
    {

        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<Company> GetCompanyID(int id)
        {
            var company = await _companyRepository.GetCompanyID(id);
            return company;
        }


        public async Task<Company> createCompany(Company req)
        {
            var company = await _companyRepository.createCompany(req);

            return company;
        }

        public async Task<int> deleteCompany(int id)
        {
            var idResult = await _companyRepository.DeleteCompany(id);

            return idResult;
        }

        public async Task<List<Company>> GetCompanies()
        {
            var company = await _companyRepository.GetCompanies();
            return company;
        }

        public async Task updateCompany(Company req)
        {
            await  _companyRepository.UpdateCompany(req);
            
        }
    }
}
