using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace InstaBiz.Model
{
    public class Users 
    {
        //[JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string AuthenticationID { get; set; }
        public string AuthenticationType { get; set; }
        public int Status { get; set; }
        public string AppVersion { get; set; } ="";
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset? LastLogged { get; set; }

        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string SaltedHash { get; set; }
        public string AuthenticationToken { get; set; }

        //[CreatedAt]
        //public DateTimeOffset? CreatedAt { get; set; }

        //[XmlIgnore]
        //public virtual ICollection<CompanyUser> CompanyUsers { get; set; }

    }
}
