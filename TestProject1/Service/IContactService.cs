using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject1.Models;

namespace TestProject1.Service
{
    public interface IContactService
    {
        

        Task<Contact> GetContactID(int id);
        Task<Contact> createContact(Contact req);
        Task updateContact(Contact req);
        Task<int> deleteContact(int id);
        Task<List<Contact>> GetContacts();
    }
}
