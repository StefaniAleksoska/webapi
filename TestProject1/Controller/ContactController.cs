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
    public class ContactController : ControllerBase
    {
            private readonly IContactService _contactService;
            public ContactController(IContactService contactService)
            {
                _contactService = contactService;
            }

    



        [HttpGet]
        [Route("GetContact")]
        public async Task<IActionResult> GetContact()
        {
            try
            {
                var contact = await _contactService.GetContacts();
                if (contact == null)
                {
                    return NotFound();
                }

                return Ok(contact);
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
        [Route("GetContact/{Id}")]
        public async Task<IActionResult> GetContactID(int Id)
        {

            try
            {
                var contact = await _contactService.GetContactID(Id);

                if (contact == null)
                {
                    return NotFound();
                }

                return Ok(contact);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddContact")]
        public async Task<IActionResult> CreateContact([FromBody] Contact model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var contact = await _contactService.createContact(model);
                    if (contact.ID > 0)
                    {
                        return Ok(contact);
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
        [Route("DeleteContact")]
        public async Task<IActionResult> DeleteContact(int? contactID)
        {
            int result = 0;

            if (contactID == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _contactService.deleteContact(contactID.Value);
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
        [Route("UpdateContact")]
        public async Task<IActionResult> UpdateContact([FromBody] Contact model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _contactService.updateContact(model);

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

