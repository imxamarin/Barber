namespace InstaBiz.Model
{
    public class InvoiceTask 
    {
        public string Id { get; set; }
        public string ProductID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public decimal Quantity { get; set; }
        public decimal ClientPrice { get; set; }
        public bool Include { get; set; }
        public int Order { get; set; }
        public string CompanyID { get; set; }

        public string InvoiceID { get; set; }
        //public virtual Invoice Invoice { get; set; }


        public InvoiceTask()
        {
        }

        public InvoiceTask(string invoiceId)
        {
            InvoiceID = invoiceId;
            Include = true;
        }

        public InvoiceTask(Invoice q)
        {
            InvoiceID = q.Id;
            Include = true;
        }



        public InvoiceTask(string invoiceid, string invoicetaskid, string name, string details, decimal clientprice)
        {
            InvoiceID = invoiceid;
            Name = name;
            Details = details;
            Id = invoicetaskid;
            ClientPrice = clientprice;
            Include = true;
        }
    }
}
