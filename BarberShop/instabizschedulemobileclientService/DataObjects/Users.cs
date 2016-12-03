using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace instabizschedulemobileclientService.DataObjects
{
    public class Users : EntityData
    {
        public string AuthenticationID { get; set; }
        public string AuthenticationType { get; set; }
        public int Status { get; set; }
        public string AppVersion { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset? LastLogged { get; set; }

        //public virtual ICollection<CompanyUser> CompanyUsers { get; set; }


        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string SaltedHash { get; set; }
        public string AuthenticationToken { get; set; }



    }
}