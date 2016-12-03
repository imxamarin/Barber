namespace InstaBiz.Model
{
    public class Product 
    {
        public string Id { get; set; }
        public string DisplayID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ProductCost { get; set; }
        public string CompanyID { get; set; }

        //public string SuppID { get; set; }
        //public string ProductGroupID { get; set; }

        //public virtual Supplier Supplier { get; set; }
        //public virtual ProductGroup ProductGroup {get;set;}


        public Product()
        {
            Name = "";
            Details = "";
        }

        public Product(string suppid, string product, decimal unitprice, string details = "", decimal productcost = 0)
        {
            //SuppID = suppid;
            Name = product;
            Details = details;
            UnitPrice = unitprice;
            //ProductGroupID = null;
            ProductCost = productcost;
        }


    }
}
