using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Publisher
    {
        public int PublisherID { get; set; }

        public string PublisherName { get; set; }

        public int AddressID { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}