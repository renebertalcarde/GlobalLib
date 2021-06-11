using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GlobalLib.Interfaces
{
    public interface IPerson
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string NameExt { get; set; }

        public string Fullname { get; }

        public string Fullname_FN { get; }
    }
}
