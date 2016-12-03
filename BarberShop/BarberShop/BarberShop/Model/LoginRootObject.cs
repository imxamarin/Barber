using System;
namespace BarberShop
{
	public class LoginRootObject
	{


		public string UserId { get; set; }
		public string Name { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public byte [] Password { get; set; }
		public byte [] EmailId { get; set; }
		public byte [] PhoneNo { get; set; }
		public bool Status { get; set; }
		public string AccessToken { get; set; }
	}

}

