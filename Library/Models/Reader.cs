using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Reader
    {
        public int ReaderID { get; set; }

        public string Pesel { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int AddressID { get; set; }

        public string Password { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Borrow> Borrows { get; set; }

    }
}