using System;


namespace InstaBiz.Model
{
    public class Invoice 
    {
        public string Id { get; set; }
        public string QuoteID { get; set; }
        public string Description { get; set; }        
        public DateTimeOffset InvoiceDate { get; set; }        
        public DateTimeOffset DueDate { get; set; }        
        public DateTimeOffset? SentOn { get; set; }        
        public string SentBy { get; set; }        
        public string InvoiceCode { get; set; }        
        public string GroupCode { get; set; }        
        public string PONum { get; set; }        
        public decimal PercentageDue { get; set; }        
        public decimal AmountDue { get; set; }        
        public decimal Tax { get; set; }
        public string TermID { get; set; }
        public string CompanyID { get; set; }


        public string JobID { get; set; }
        public string DocumentID { get; set; }

        //public virtual Document Document { get; set; }
        //public virtual Job Job { get; set; }


        public Invoice()
        {
            SentBy = "";
            PONum = "";
            Description = "";
            Tax = 13;
            InvoiceDate = DateTime.Now;
            DueDate = DateTime.Now.AddDays(30);
            GroupCode = "";
            InvoiceCode = "";
            PercentageDue = 100;
            PONum = "";
            AmountDue = 0;
        }


    }
}
