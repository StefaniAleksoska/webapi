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
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpGet]
        [Route("GetCountry")]
        public async Task<IActionResult> GetCountry()
        {
            try
            {
                var country = await _countryService.GetCountries();
                if (country == null)
                {
                    return NotFound();
                }

                return Ok(country);
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
        [Route("GetCountry/{Id}")]
        public async Task<IActionResult> GetCountryID(int Id)
        {

            try
            {
                var country = await _countryService.GetCountryID(Id);

                if (country == null)
                {
                    return NotFound();
                }

                return Ok(country);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddCountry")]
        public async Task<IActionResult> CreateCountry([FromBody] Country model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var country = await _countryService.createCountry(model);
                    if (country.ID > 0)
                    {
                        return Ok(country);
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
        [Route("DeleteCountry")]
        public async Task<IActionResult> DeleteCountry(int? countryID)
        {
            int result = 0;

            if (countryID == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _countryService.deleteCountry(countryID.Value);
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
        [Route("UpdateCountry")]
        public async Task<IActionResult> UpdateCountry([FromBody] Country model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _countryService.updateCountry(model);

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

