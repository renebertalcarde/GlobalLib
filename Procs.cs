using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GlobalLib
{
    public static class Procs
    {
        public static string ShowErrors(ModelStateDictionary ModelState, string delimeter = "\n")
        {
            string[] errors = ModelState.Values.Where(x => x.ValidationState == ModelValidationState.Invalid).SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToArray();
            return ShowErrors(errors, delimeter);
        }

        public static string ShowErrors(Exception e, string delimeter = "\n")
        {
            string ret = "";

            if (e != null)
            {
                ret += e.Message;
                ret += (!String.IsNullOrEmpty(ret) ? delimeter : "") + ShowErrors(e.InnerException, delimeter);
            }

            return ret;
        }

        public static string ShowErrors(string[] array, string delimeter = "\n")
        {
            string ret = "";

            foreach (string err in array)
            {
                ret += (!String.IsNullOrEmpty(ret) ? delimeter : "") + err;
            }

            return ret;
        }

        public static string FullName(string LastName, string FirstName, string MiddleName, string NameExt)
        {
            string ret = "";

            if ((LastName ?? "").Trim() != "" || (FirstName ?? "").Trim() != "" || (MiddleName ?? "").Trim() != "" || (NameExt ?? "").Trim() != "")
            {
                string mn = "";
                if (!string.IsNullOrEmpty(MiddleName))
                {
                    if (MiddleName.Trim() != "")
                    {
                        List<string> _mn = MiddleName.Trim().Split(' ').ToList();
                        mn = " " + _mn.Last().ToString()[0].ToString() + ".";
                    }
                }

                ret = string.Format("{0}{1}, {2}{3}",
                    LastName ?? "",
                    string.IsNullOrEmpty(NameExt) ? "" : (" " + NameExt),
                    FirstName ?? "",
                    mn
                    );
            }
            return ret;
        }

        public static string FullName_FN(string LastName, string FirstName, string MiddleName, string NameExt)
        {
            string ret = "";

            if ((LastName ?? "").Trim() != "" || (FirstName ?? "").Trim() != "" || (MiddleName ?? "").Trim() != "" || (NameExt ?? "").Trim() != "")
            {
                string mn = "";
                if (!string.IsNullOrEmpty(MiddleName))
                {
                    if (MiddleName.Trim() != "")
                    {
                        List<string> _mn = MiddleName.Trim().Split(' ').ToList();
                        mn = _mn.Last().ToString()[0].ToString() + ". ";
                    }
                }

                ret = string.Format("{0} {1}{2}{3}",
                    FirstName ?? "",
                    mn,
                    LastName ?? "",
                    string.IsNullOrEmpty(NameExt) ? "" : (" " + NameExt)
                    );
            }
            return ret;
        }

        public static int? Age(DateTime? DOB)
        {
            if (DOB == null)
            {
                return null;
            }
            else
            {
                DateTime now = DateTime.Now;
                int age = now.Year - DOB.Value.Year;
                if (now < DOB.Value.AddYears(age))
                {
                    age--;
                }

                return age;
            }
        }

        public static string FriendlyPeriod(DateTime d1, DateTime d2, bool fullMonth = false)
        {
            string ret = "";

            if (d1 == null && d2 == null)
            {
                return ret;
            }

            if (d1 == null)
            {
                d1 = d2;
            }

            if (d2 == null)
            {
                d2 = d1;
            }

            d1 = d1.Date;
            d2 = d2.Date;

            string mo = fullMonth ? "MMMM" : "MMM";

            if (d1 == d2)
            {
                ret = d1.ToString(mo + " dd, yyyy");
            }
            else if (d1.Month == d2.Month && d1.Year == d1.Year)
            {
                ret = string.Format("{0}-{1}", d1.ToString(mo + " d"), d2.ToString("d, yyyy"));
            }
            else if (d1.Year == d1.Year)
            {
                ret = string.Format("{0}-{1}", d1.ToString(mo + " d"), d2.ToString(mo + " d, yyyy"));
            }
            else
            {
                ret = string.Format("{0}-{1}", d1.ToString(mo + " d, yyyy"), d2.ToString(mo + " d, yyyy"));
            }

            return ret;
        }

        public static string FriendlyDate(DateTime d)
        {
            string ret = "";

            DateTime n = DateTime.Now.Date;
            TimeSpan ts = n - d.Date;

            if (d < n.AddYears(-1))
            {
                ret = "Last " + d.ToString("yyyy");
            }
            else if (d < n.AddMonths(-1))
            {
                ret = "Last " + d.ToString("MMMM");
            }
            else if (ts.TotalDays > 1)
            {
                ret = ts.TotalDays + " days ago";
            }
            else if (ts.TotalDays == 1)
            {
                ret = "Yesterday";
            }
            else if (ts.TotalHours >= 1)
            {
                ret = ts.TotalHours + " hours ago";
            }
            else if (ts.TotalMinutes > 5)
            {
                ret = ts.TotalMinutes + " minutes ago";
            }
            else
            {
                ret = "Just now";
            }

            return ret;
        }
    }
}
