using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class Borrow
    {
        public int BorrowId { get; set; }

        public DateTime BorrowDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int BookCopyID { get; set; }

        public int ReaderID { get; set; }

        public int EmployeeID { get; set; }

        public virtual BookCopy BookCopy { get; set; }

        public virtual Reader Reader { get; set; }

        public virtual Employee Employee { get; set; }

    }
}