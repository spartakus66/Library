using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class BookSubject
    {
        public int BookSubjectID { get; set; }

        public int BookID { get; set; }

        public int SubjectID { get; set; }

        public virtual Book Book { get; set; }

        public virtual Subject Subject { get; set; }

    }
}