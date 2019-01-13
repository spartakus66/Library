using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class KeyWord
    {
        public int KeyWordID { get; set; }

        public string KeyWordName { get; set; }

        public virtual ICollection<BookKeyWord> BookKeyWords { get; set; }

    }
}