using Barbershop.PCL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.PCL.Model
{
    public class Mail
    {
        public string Id{ get; set; }
        public string FromAddress { get; set; } = "";
        public string ToAddress { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Details { get; set; } = "";
        public DateTimeOffset DateSent { get; set; }
        public string CompanyUsersID { get; set; }
        public string User { get; set; }
        public RefType RefType { get; set; }
        public string ParentID { get; set; }
        public string Attachments { get; set; }

        public Mail()
        {

        }

        public Mail(string companyUserID, string parentID, string subject, string details)
        {
            CompanyUsersID = companyUserID;
            ParentID = parentID;
            //ToAddress = toAddress;
            Subject = subject;
            Details = details;
        }

    }
}
