using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject1.Models;
using TestProject1.Repository;
using TestProject1.Service;

namespace TestProject1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [Route("GetCompany")]
        public async Task<IActionResult> GetCompany()
        {
            try
            {
                var company = await _companyService.GetCompanies();
                if (company == null)
                {
                    return NotFound();
                }

                return Ok(company);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        //[HttpGet]
        //[Route("GetPosts")]
        //public async Task<IActionResult> GetPosts()
        //{
        //    try
        //    {
        //        var posts = await postRepository.GetPosts();
        //        if (posts == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(posts);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpGet]
        [Route("GetCompany/{Id}")]
        public async Task<IActionResult> GetCompanyID(int Id)
        {
           
            try
            {
                var company = await _companyService.GetCompanyID(Id);

                if (company == null)
                {
                    return NotFound();
                }

                return Ok(company);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddCompany")]
        public async Task<IActionResult> CreateCompany([FromBody] Company model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var company = await _companyService.createCompany(model);
                    if (company.ID > 0)
                    {
                        return Ok(company);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteCompany")]
        public async Task<IActionResult> DeleteCompany(int? companyID)
        {
            int result = 0;

            if (companyID == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _companyService.deleteCompany(companyID.Value);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut]
        [Route("UpdateCompany")]
        public async Task<IActionResult> UpdateCompany([FromBody] Company model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _companyService.updateCompany(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

    }
}
    
