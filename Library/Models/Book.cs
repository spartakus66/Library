using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Book
    {
        public int BookID { get; set; }

        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Destription { get; set; }

        public int PublisherID { get; set; }

        public virtual Publisher Publisher { get; set; }

        public virtual ICollection<Authorship> Authorships { get; set; }

        public virtual ICollection<BookSubject> BookSubject { get; set; }

        public virtual ICollection<BookCopy> BookCopies { get; set; }
    }
}