using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject1.DAL;

namespace TestProject1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public ValueController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public dynamic GetValue()
        {
            


                var value = _context.Company//.Where(c => c.ID == 1)
                    .Include(c => c.Contacts)
                    .ThenInclude(c => c.Country)
                    .ToList();

                return Ok(value);

            
        }
    }
}


