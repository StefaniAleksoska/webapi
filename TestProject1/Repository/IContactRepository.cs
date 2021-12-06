using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject1.Models;

namespace TestProject1.Repository
{
    public interface IContactRepository
    {

        Task<List<Contact>> GetContacts();



        Task<Contact> GetContactID(int? ContactId);

        Task<Contact> createContact(Contact contact);

        Task<int> DeleteContact(int? ContactId);

        Task UpdateContact(Contact contact);


    }
}
