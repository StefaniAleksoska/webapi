using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject1.Models;
using TestProject1.Repository;

namespace TestProject1.Service
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
       
        public async Task<Contact> GetContactID(int id)
        {
            var contact = await _contactRepository.GetContactID(id);
            return contact;
        }


        public async Task<Contact> createContact(Contact req)
        {
            var contact = await _contactRepository.createContact(req);

            return contact;
        }

        public async Task<int> deleteContact(int id)
        {
            var idResult = await _contactRepository.DeleteContact(id);

            return idResult;
        }

        public async Task<List<Contact>> GetContacts()
        {
            var contact = await _contactRepository.GetContacts();
            return contact;
        }

        public async Task updateContact(Contact req)
        {
            await _contactRepository.UpdateContact(req);

        }
    }
}
