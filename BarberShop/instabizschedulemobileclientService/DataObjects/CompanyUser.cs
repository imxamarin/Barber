using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static instabizschedulemobileclientService.Types.Enums;

namespace instabizschedulemobileclientService.DataObjects
{
    public class CompanyUser : EntityData
    {
        public AccessLevel AccessLevel { get; set; }
        public int Status { get; set; }
        public string Sig { get; set; }
        public string RTF { get; set; }
        public string Email { get; set; }
        public string UserID { get; set; }
        public string AuthenticationID { get; set; }
        public string CompanyID { get; set; }
        //public virtual Users User { get; set; }
        public virtual Company Company { get; set; }
    }
}