using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System;
using InstaBiz.PCL.ModelVM;
using System.Threading.Tasks;

namespace InstaBiz.Model
{
    public class Employee : BaseObject
    {
        //        
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string JobTitle { get; set; } = "";
        public string CompanyName { get; set; } = "";
        public string MobilePhone { get; set; } = "";
        public string HomePhone { get; set; } = "";
        public string EmergencyPhone { get; set; } = "";
        public string EmergencyContact { get; set; } = "";
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public string EmploymentStatus { get; set; } = "";
        public bool Active { get; set; }
        public decimal Wage { get; set; }
        public string PayrollTypeID { get; set; }
        public string Pin { get; set; }
        public string OvertimeMethod { get; set; }     
        public string DisplayID { get; set; }
        public string CompanyID { get; set; }

        //[IgnoreDataMember]
        //[JsonIgnore]
        public string EmpHoursID { get; set; }
        public int EmpNum { get; set; }

        internal EmployeeVM ToVM()
        {
            EmployeeVM dn = new EmployeeVM();

            dn.Title = this.FirstName + " " + this.LastName;
            dn.CollectionTitle = dn.Title;
            dn.Subtitle = this.JobTitle;
            dn.Subtitle2 = this.MobilePhone != "" ? this.MobilePhone : this.HomePhone;

            dn.Id = this.Id;
            dn.Name = this.FirstName + " " + this.LastName;
            dn.FirstName = this.FirstName;
            dn.LastName = this.LastName;
            dn.Position = this.JobTitle;
            dn.Contact = this.MobilePhone;


            dn.EmployeeTag = this;




            return dn;
        }

        //public virtual Company Company { get; set; }
        //public virtual ICollection<EmpHours> EmpHours { get; set; }

    }
}
