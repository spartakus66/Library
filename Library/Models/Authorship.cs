using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Authorship
    {
        public int AuthorshipID { get; set; }

        public int AuthorID { get; set; }

        public int BookID { get; set; }

        public virtual Author Author { get; set; }

        public virtual Book Book { get; set; }

    }
}