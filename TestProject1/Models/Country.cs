using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject1.Models
{
    public class Country
    {
        public int ID { get; set; }
        public string CountryName { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
