using Barbershop.PCL.Types;
using Barbershop.PCL.Types;


namespace InstaBiz.Model
{

    public class Contact 
    {
        public string Id { get; set; }
        public RefType RefType { get; set; }
        public string ParentID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Phone { get; set; } = "";
        public string AltPhone { get; set; } = "";
        public string JobTitle { get; set; } = "";
        public string Email { get; set; } = "";
        public string Info { get; set; } = "";
        public string CompanyID { get; set; }




    }
}
