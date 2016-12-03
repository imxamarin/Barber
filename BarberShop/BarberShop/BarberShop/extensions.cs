using InstaBiz.Model;
using Microsoft.WindowsAzure.MobileServices;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop
{
    public static class extensions
    {
        public static ObservableCollection<T> ToObservable<T>(this IEnumerable<T> s)
        {
            ObservableCollection<T> objlist = new ObservableCollection<T>();
            foreach (var c in s)
            {
                objlist.Add(c);
            }
            return objlist;
        }


























        public static string splitoncaps(this string s)
        {

            string newstring = "";

            if (s.Contains("_"))
            {
                newstring = s.Trim('_');
            }
            else
            {
                int index = 0;
                foreach (Char c in s)
                {
                    if (Char.IsUpper(c) && index != 0)
                    {
                        newstring += " ";
                    }

                    newstring += c;
                    index++;
                }
            }
            return newstring;
        }

        public static decimal ToDec(this string d)
        {
            if (d.Contains("$"))
                d = d.TrimStart('$');

            return Math.Round(Convert.ToDecimal(d), MidpointRounding.AwayFromZero);
        }

        public static string ToMoney(this decimal d, bool sign = true)
        {
            string s = "";
            if (sign)
            {
                s += "$";
            }
            //s += Math.Round(d, 2).ToString();
            s += Math.Round(d, 2, MidpointRounding.AwayFromZero).ToString("N2");
            return s;
        }


        public static string ToMoneyExact(this decimal d, bool sign = true)
        {
            string s = "";
            if (sign)
            {
                s += "$";
            }
            //s += Math.Round(d, 2).ToString();
            s += d.ToString("N4");
            s = s.TrimEnd('0');

            string sub = s.Substring(s.LastIndexOf('.') + 1);

            while (sub.Length < 2)
                sub += "0";

            s = s.Substring(0, s.LastIndexOf('.') + 1) + sub;

            return s;
        }

        //public static ObservableCollection<T> ToObservable<T>(this List<T> s)
        //{
        //    ObservableCollection<T> objlist = new ObservableCollection<T>();
        //    foreach (var c in s)
        //    {
        //        objlist.Add(c);
        //    }
        //    return objlist;
        //}



        public static string ToSpanString(this TimeSpan In)
        {
            double mins = In.TotalMinutes;


            string span = "";
            //string span = mins > 59 ? Math.Round(Convert.ToDecimal(mins / 60),2).ToString() + " hours" : ((int)mins).ToString() + " mins";

            if (In.Hours > 0)
                span = In.Hours + "h " + In.Minutes + "m";
            else
                span = In.Minutes + "m";

            return span;
        }
        public static string ToTime(this DateTime? In)
        {
            if (In != null)
            {
                string s = ((DateTime)In).ToString("hh:mm tt");
                return s;
            }
            else
                return null;
        }

        public static string ToShortTime(this DateTime? In)
        {
            if (In != null)
            {
                string s = ((DateTime)In).ToString("h:mmtt");
                return s;
            }
            else
                return null;
        }

        public static string ToShortTime(this DateTime In)
        {
            if (In != null)
            {
                string s = ((DateTime)In).ToString("h:mmtt");
                return s;
            }
            else
                return null;
        }

        public static string ToDate(this DateTime? In)
        {
            string s = ((DateTime)In).ToString("yyyy-MM-dd");
            return s;
        }

        public static string ToTime(this DateTime In)
        {
            string s = ((DateTime)In).ToString("hh:mm tt");
            return s;
        }

        public static string ToDate(this DateTime In)
        {
            string s = ((DateTime)In).ToString("dd-MM-yyyy");
            return s;
        }

        public static string ToLongDate(this DateTime In)
        {
            string s = ((DateTime)In).ToString("ddd dd MMM, yyyy");
            return s;
        }

        public static string ToSemiLongDate(this DateTime In)
        {
            string s = ((DateTime)In).ToString("MMM dd, yyyy");
            return s;
        }

        public static string ToDateAtTime(this DateTime In)
        {
            string s = ((DateTime)In).ToString("MMM dd, yyyy @ hh:mm tt");
            return s;
        }










        public static string ToTime(this DateTimeOffset? In)
        {
            if (In != null)
            {
                string s = ((DateTimeOffset)In).ToString("hh:mm tt");
                return s;
            }
            else
                return null;
        }

        public static string ToShortTime(this DateTimeOffset? In)
        {
            if (In != null)
            {
                string s = ((DateTimeOffset)In).ToString("h:mmtt");
                return s;
            }
            else
                return null;
        }

        public static string ToShortTime(this DateTimeOffset In)
        {
            if (In != null)
            {
                string s = ((DateTimeOffset)In).ToString("h:mmtt");
                return s;
            }
            else
                return null;
        }

        public static string ToDate(this DateTimeOffset? In)
        {
            string s = ((DateTimeOffset)In).ToString("yyyy-MM-dd");
            return s;
        }

        public static string ToTime(this DateTimeOffset In)
        {
            string s = ((DateTimeOffset)In).ToString("hh:mm tt");
            return s;
        }

        public static string ToDate(this DateTimeOffset In)
        {
            string s = ((DateTimeOffset)In).ToString("yyyy-MM-dd");
            return s;
        }

        public static string ToLongDate(this DateTimeOffset In)
        {
            string s = ((DateTimeOffset)In).ToString("ddd dd MMM, yyyy");
            return s;
        }


        public static string ToSemiLongDate(this DateTimeOffset In)
        {
            string s = ((DateTimeOffset)In).ToString("MMM dd, yyyy");
            return s;
        }

        public static string ToDateAtTime(this DateTimeOffset In)
        {
            string s = ((DateTimeOffset)In).ToString("MMM dd, yyyy @ hh:mm tt");
            return s;
        }

        public static string Safely(this string s)
        {
            return s.Replace('"', '\"').Replace('”', '\"');
        }

        //async public static Task<List<Job>> Search(this List<Job> joblist, string search)
        //{
        //    List<Job> jlist = joblist.Where(c => (c.Address.ToLower().Contains(search) || c.City.ToLower().Contains(search) || c.ProjectID.ToString().Contains(search) || c.GetClient().MobilePhone.Contains(search) || c.GetClient().MobilePhone.Replace("-", "").Contains(search) || c.GetClientTitle().ToLower().Contains(search) || c.GetStatus().ToLower().Contains(search))).ToList<Job>();

        //    foreach (Job j in joblist)
        //    {
        //        Client c = await j.GetClient();
        //        if (c != null)
        //        {
        //            List<Contact> contactlist = await c.GetContacts();
        //            Contact con = contactlist.Find(x => x.FirstName.ToLower().Contains(search) || x.LastName.ToLower().Contains(search) || x.Email.ToLower().Contains(search) || x.Phone.Contains(search) || x.Phone.Replace("-", "").Contains(search));
        //            if (con != null && !jlist.Contains(j))
        //                jlist.Add(j);
        //        }
        //    }
        //    return jlist;
        //}

        //async public static Task<List<Client>> Search(this List<Client> clientlist, string search)
        //{
        //    List<Client> clist = clientlist.Where(c => (c.Address.ToLower().Contains(search) || c.City.ToLower().Contains(search) || c.ClientID_.ToString().Contains(search) || c.MobilePhone.Contains(search) || c.MobilePhone.Replace("-", "").Contains(search) || c.FirstName.ToLower().Contains(search) || c.LastName.ToLower().Contains(search) || c.Company.ToLower().Contains(search))).ToList<Client>();

        //    foreach (Client c in clientlist)
        //    {
        //        List<Contact> contactlist = await c.GetContacts();
        //        Contact con = contactlist.Find(x => x.FirstName.ToLower().Contains(search) || x.LastName.ToLower().Contains(search) || x.Email.ToLower().Contains(search) || x.Phone.Contains(search) || x.Phone.Replace("-", "").Contains(search));
        //        if (con != null && !clist.Contains(c))
        //            clist.Add(c);
        //    }
        //    return clist;
        //}

        //async public static Task<List<employee>> Search(this List<employee> emplist, string search)
        //{
        //    List<employee> clist = emplist.Where(c => (c.Address.ToLower().Contains(search) || c.City.ToLower().Contains(search) || c.EmpID_.ToString().Contains(search) || c.MobilePhone.Contains(search) || c.MobilePhone.Replace("-", "").Contains(search) || c.FirstName.ToLower().Contains(search) || c.LastName.ToLower().Contains(search) || c.Company.ToLower().Contains(search))).ToList<employee>();

        //    foreach (employee c in emplist)
        //    {
        //        List<Contact> contactlist = await c.GetContacts();
        //        Contact con = contactlist.Find(x => x.FirstName.ToLower().Contains(search) || x.LastName.ToLower().Contains(search) || x.Email.ToLower().Contains(search) || x.Phone.Contains(search) || x.Phone.Replace("-", "").Contains(search));
        //        if (con != null && !clist.Contains(c))
        //            clist.Add(c);
        //    }
        //    return clist;
        //}

        //async public static Task<List<supplier>> Search(this List<supplier> supplist, string search)
        //{
        //    List<supplier> clist = supplist.Where(c => (c.Address.ToLower().Contains(search) || c.City.ToLower().Contains(search) || c.SuppID_.ToString().Contains(search) || c.Phone.Contains(search) || c.Phone.Replace("-", "").Contains(search) || c.Company.ToLower().Contains(search))).ToList<supplier>();

        //    foreach (supplier c in supplist)
        //    {
        //        List<Contact> contactlist = await c.GetContacts();
        //        Contact con = contactlist.Find(x => x.FirstName.ToLower().Contains(search) || x.LastName.ToLower().Contains(search) || x.Email.ToLower().Contains(search) || x.Phone.Contains(search) || x.Phone.Replace("-", "").Contains(search));
        //        if (con != null && !clist.Contains(c))
        //            clist.Add(c);
        //    }
        //    return clist;
        //}



        public async static Task<List<T>> All<T>(this IMobileServiceTableQuery<T> query)
        {
            List<T> templist = await query.Take(1000).ToListAsync();
            if (templist.Count == 1000)
            {
                int i = 0;
                bool getmore = true;
                while (getmore)
                {
                    i++;
                    var tlist = await query.Skip(1000 * i).All();
                    if (tlist.Count != 1000)
                        getmore = false;
                    templist.AddRange(tlist);
                }
            }

            return templist;
        }

        //public async static Task<List<T>> SpecifyCompany<T>(this IMobileServiceTable<T> table, int id)
        //{

        //    Dictionary<string, string> parameters = new Dictionary<string, string>
        //        {
        //            { "specific", id.ToString() },
        //        };

        //    return await table.Take(1000).WithParameters(parameters).ToListAsync();

        //}

        //public async static Task<List<T>> In<T>(this IMobileServiceTable<T> table, List<int> ids, string column, string additional = "", List<int> otherids = null)
        //{
        //    if (ids.Count > 0)
        //    {
        //        int remaining = ids.Count;
        //        int skip = 0;
        //        List<T> retlist = new List<T>();
        //        while (remaining > 0)
        //        {


        //            Dictionary<string, string> parameters = new Dictionary<string, string>
        //            {
        //                { "column", column },
        //                { "ids", string.Join(",", ids.Skip(skip).Take(remaining > 200 ? 200 : remaining)) },
        //            };
        //            if (additional != "")
        //                parameters.Add(additional, string.Join(",", otherids));

        //            var templist = await table.Take(1000).WithParameters(parameters).All();
        //            retlist.AddRange(templist);
        //            skip += remaining > 200 ? 200 : remaining;
        //            remaining -= 200;

        //        }
        //        return retlist;
        //    }
        //    else
        //    {
        //        return new List<T>();
        //    }
        //}


        //public static string GetHardwareId()
        //{
        //    var token = HardwareIdentification.GetPackageSpecificToken(null);
        //    var hardwareId = token.Id;
        //    var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(hardwareId);

        //    byte[] bytes = new byte[hardwareId.Length];
        //    dataReader.ReadBytes(bytes);

        //    return BitConverter.ToString(bytes);
        //}


        static public string ToReadableSize(long Size)
        {
            if (Size != 0)
            {
                string s;
                var tempsize = (Size / 1024);
                if (tempsize < 1024)
                {
                    if (tempsize == 0)
                        tempsize = 1;
                    s = tempsize.ToString() + " KB";
                }
                else
                {
                    s = Math.Round((tempsize * 0.000976562), 2).ToString() + " MB";
                }
                return s;
            }
            else
                return "0";
        }


        
    }
}
