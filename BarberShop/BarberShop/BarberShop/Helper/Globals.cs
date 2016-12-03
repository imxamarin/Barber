using System;
using PInvoke;
//using Xamarin.Auth;
using System.Collections.ObjectModel;
using InstaBiz.Model;
namespace BarberShop
{
	public class Globals
	{
		public static string UserID {
			get;
			set;
		}

		public readonly string Usernameing;
		public static string userName { get; set; }
		public static string userMail { get; set; }
		public static string FirstName { get; set; }
		public static string LastName { get; set; }
		public static string MobileNumber { get; set; }

		public static ObservableCollection<Users> LoginCollection { get; set; }


	}
}

