using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }

        public string SubjectName { get; set; }

        public virtual ICollection<BookSubject> BookSubjects { get; set; }

    }
}