using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Address
    {
        public int AddressID { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public virtual ICollection<Publisher> Publishers { get; set; }

        public virtual ICollection<Reader> Readers { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public override string ToString()
        {
            return (Street+","+ZipCode+" "+City+","+Country).ToString();
        }
    }
}