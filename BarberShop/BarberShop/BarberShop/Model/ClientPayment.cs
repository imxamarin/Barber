using System;

using System.Collections.Generic;

namespace InstaBiz.Model
{
    public class ClientPayment 
    {
        public string Id { get; set; }
        public string ClientID { get; set; }
        public decimal PayAmount { get; set; }
        public DateTimeOffset PayDate { get; set; }
        public string PayType { get; set; }
        public string Refnum { get; set; }

        public string CompanyID { get; set; }
        //public virtual ICollection<JobPayment> JobPayments { get; set; }
    }
}
