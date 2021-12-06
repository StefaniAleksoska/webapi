using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject1.Models
{
    public class GetContactsWithCompanyAndCountry
    {
        public class Company
        {
            public int ID { get; set; }
            public string CompanyName { get; set; }
            public virtual ICollection<Contact> Contacts { get; set; }
        }
        public class Contact
        {
            public int ID { get; set; }
            public int CompanyID { get; set; }
            public int CountryID { get; set; }
            public string ContactName { get; set; }
            public Company Company { get; set; }
            public Country Country { get; set; }

        }
        public class Country
        {
            public int ID { get; set; }
            public string CountryName { get; set; }
            public virtual ICollection<Contact> Contacts { get; set; }
        }
    }
}
