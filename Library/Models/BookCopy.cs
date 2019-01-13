using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class BookCopy
    {
        public int BookCopyID { get; set; }

        public int PublishYear { get; set; }

        public virtual ICollection<BookKeyWord> BookKeyWords { get; set; }

        public virtual ICollection<Borrow> Borrows { get; set; }
        
        public int BookID { get; set; }

        public virtual Book Book { get; set; }

    }
}