
using Barbershop.PCL.Types;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace InstaBiz.Model
{
    public class Company 
    {        
        public string Id { get; set; }
        public string CompanyName { get; set; } = "";
        public string CompanyPass { get; set; } = "";
        public string CompanyAddress { get; set; } = "";
        public string CompanyCity { get; set; } = "";
        public string CompanyPostal { get; set; } = "";
        public string CompanyPhone { get; set; } = "";
        public string CompanyFax { get; set; } = "";
        public string CompanyEmail { get; set; } = "";
        public string AccountingEmail { get; set; } = "";
        public string CompanyWebsite { get; set; } = "";
        public string Expiry { get; set; } = "";
        public string CalendarUpdate { get; set; } = "";
        public bool isSubscribed { get; set; }
        public int DefaultWorkflow { get; set; }
        public string Signature { get; set; } = "";
        public string MainUser { get; set; } = "";
        public string CompanyColor { get; set; } = "";
        public CompanyType CompanyType { get; set; }
        public string TaxNumber { get; set; } = "";
        public decimal DefaultTax { get; set; } = 0;
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string DocumentID { get; set; } = "";
        public string DefaultQuoteTermsID { get; set; }
        public string DefaultInvoiceTermsID { get; set; }
        public string DefaultStatementTermsID { get; set; }
        public string DefaultPurchaseOrderTermsID { get; set; }





    }
}
