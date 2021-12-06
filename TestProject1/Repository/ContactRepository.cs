using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject1.DAL;
using TestProject1.Models;

namespace TestProject1.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DatabaseContext db;
        public ContactRepository(DatabaseContext _db)
        {
            db = _db;
        }
        
        public async Task<Contact> createContact(Contact contact)
        {
            if (db != null)
            {
                await db.Contact.AddAsync(contact);
                await db.SaveChangesAsync();

                return contact;
            }

            return null;
        }

        public async Task<int> DeleteContact(int? ContactId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var contact = await db.Contact.FirstOrDefaultAsync(x => x.ID == ContactId);

                if (contact != null)
                {
                    //Delete that post
                    db.Contact.Remove(contact);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                if (result == 1)
                {
                    return ContactId.Value;
                }

            }

            return result;
        }

        public async Task<List<Contact>> GetContacts()
        {
            if (db != null)
            {
                return await db.Contact.ToListAsync();
            }

            return null;
        }

        public async Task<Contact> GetContactID(int? ContactId)
        {
            if (db != null)
            {
                return await (from p in db.Contact
                              where p.ID == ContactId
                              select new Contact
                              {
                                  ID = p.ID,
                                  ContactName = p.ContactName
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task UpdateContact(Contact contact)
        {
            if (db != null)
            {
                //Delete that post
                db.Contact.Update(contact);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
