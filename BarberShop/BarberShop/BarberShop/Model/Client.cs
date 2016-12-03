using System;
using System.Collections.Generic;
using InstaBiz.PCL.ModelVM;

namespace InstaBiz.Model
{
    public class Client : BaseObject
    {
        //        
        public string CompanyName { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string JobTitle { get; set; } = "";
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public string MobilePhone { get; set; } = "";
        public string BusinessPhone { get; set; } = "";
        public string HomePhone { get; set; } = "";
        public string Email { get; set; } = "";
        public string Fax { get; set; } = "";
        public string Webpage { get; set; } = "";
        public string DisplayID { get; set; }
        public string CompanyID { get; set; }

        internal ClientVM ToVM()
        {
            ClientVM dn = new ClientVM();
            dn.ClientTag = this;
            dn.Id = this.Id;
            if (this.CompanyName == "")
                dn.Title = this.FirstName + " " + this.LastName;
            else
            {
                dn.Title = this.CompanyName;
            }
           
            dn.CollectionTitle = dn.Title;
            dn.Subtitle = dn.SecondaryName;
            dn.Subtitle2 = this.MobilePhone != "" ? this.MobilePhone : this.HomePhone;
            

            dn.Company = this.CompanyName;
            dn.Contact = this.MobilePhone;
            
            dn.ClientTag = this;
            return dn;
        }
        //public virtual BillingInfo BillingInfo { get; set; }
        ////public virtual ICollection<ClientPayment> ClientPayments { get; set; }        
        ////public virtual ICollection<Job> Jobs { get; set; }        


    }
}
