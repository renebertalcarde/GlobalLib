using GlobalLib.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GlobalLib.Abstracts
{
    public abstract class _Person : IPerson
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string NameExt { get; set; }

        public string Fullname { get => Procs.FullName(LastName, FirstName, MiddleName, NameExt); }

        public string Fullname_FN { get => Procs.FullName_FN(LastName, FirstName, MiddleName, NameExt); }
    }
}
