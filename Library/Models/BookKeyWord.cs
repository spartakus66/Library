using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class BookKeyWord
    {
        public int BookKeyWordID { get; set; }

        public int BookCopyID { get; set; }

        public int KeyWordID { get; set; }

        public virtual BookCopy BookCopy { get; set; }

        public virtual KeyWord KeyWord { get; set; }

    }
}