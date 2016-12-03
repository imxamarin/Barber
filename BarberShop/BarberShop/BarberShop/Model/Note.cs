using Barbershop.PCL.Types;
using System;


namespace InstaBiz.Model
{
    public class Note 
    {
        public string Id { get; set; }
        public RefType RefType { get; set; }        
        public string Message { get; set; }
        public DateTimeOffset CDateTime { get; set; }         
        public string Stamp { get; set; }
        public string CompanyID { get; set; }
        public string ParentID { get; set; }
        public string CalEventID { get; set; }
        public string UserName { get; set; }
        public string UserID { get; set; }
        public string Permissions { get; set; }

        //public virtual BaseObject Parent { get; set; }
        //public virtual CalEvent CalEvent { get; set; }




    }
}
