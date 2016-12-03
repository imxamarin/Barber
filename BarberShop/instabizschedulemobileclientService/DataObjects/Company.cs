using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace instabizschedulemobileclientService.DataObjects
{
    public class Company : EntityData
    {
        public string CompanyName { get; set; }
        public string CompanyPass { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyPostal { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyFax { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyWebsite { get; set; }
        public string CompanyColor { get; set; }
        public decimal DefaultTax { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        




    }
}