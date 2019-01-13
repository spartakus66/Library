using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        public string Pesel { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Position { get; set; }
        
        public int Phone { get; set; }

        public string Email { get; set; }

        public int AddressID { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Borrow> Borrows { get; set; }

    }
}