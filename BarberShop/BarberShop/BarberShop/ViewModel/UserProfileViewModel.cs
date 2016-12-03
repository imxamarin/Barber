using System;
using System.Windows.Input;
using BarberShop.Services;
using GalaSoft.MvvmLight;
using InstaBiz.Model;
using Xamarin.Forms;

namespace BarberShop
{
	public class UserProfileViewModel : ViewModelBase
	{
		#region Variables
		string UName;
		string UPass;
		string MNumber;
		bool btnVisibility;
		bool pBVisibility;
		bool pBRunning;

		private string firstName;
		private string lastName;
		private string email;
		private string phoneNumber;


		private string userName;
		public string UserName {
			get {
				return userName;
			}


		}
		INavigation navigation;
		public INavigation Navigation {
			get {
				return navigation;
			}

			set {
				navigation = value;
				RaisePropertyChanged ("Navigation");
			}
		}
		private string password;

		public string Password {
			get { return password; }
			set {
				password = value;
				RaisePropertyChanged ("Password");
			}
		}

		private string name;
		public string Name {
			get { return name; }
			set {
				name = value;
				RaisePropertyChanged ("Name");
			}
		}

		ICommand toolbarItemCommand;


		private string mobileNumber;
		public string MobileNumber {
			get { return mobileNumber; }
			set {
				mobileNumber = value;
				RaisePropertyChanged ("MobileNumber");
			}
		}

		public bool BtnVisibility {
			get {
				return btnVisibility;
			}

			set {
				btnVisibility = value;
				RaisePropertyChanged ("BtnVisibility");
			}
		}

		public bool PBVisibility {
			get {
				return pBVisibility;
			}

			set {
				pBVisibility = value;
				RaisePropertyChanged ("PBVisibility");
			}
		}

		public bool PBRunning {
			get {
				return pBRunning;
			}

			set {
				pBRunning = value;
				RaisePropertyChanged ("PBRunning");
			}
		}

		ICommand update;
		public ICommand Update {
			get {
				return update;
			}

			set {
				update = value;
				RaisePropertyChanged ("Update");
			}
		}

		public string FirstName {
			get {
				return firstName;
			}


		}

		public string LastName {
			get {
				return lastName;
			}


		}

		public string Email {
			get {
				return email;
			}


		}

		public string PhoneNumber {
			get {
				return phoneNumber;
			}


		}

		public ICommand ToolbarItemCommand {
			get {
				return toolbarItemCommand;
			}

			set {
				toolbarItemCommand = value;
				RaisePropertyChanged ("ToolbarItemCommand");
			}
		}
		#endregion


		public UserProfileViewModel ()
		{
			userName = Globals.userName;
			firstName = Globals.FirstName;
			lastName = Globals.LastName;
			MobileNumber = Globals.MobileNumber;
			email = Globals.userMail;
			BtnVisibility = true;
			PBVisibility = false;
			PBRunning = false;
			Update = new Command (DoSomethingInDB);
			ToolbarItemCommand = new Command (DoSomething);
			RaisePropertyChanged ("PBVisibility");
			RaisePropertyChanged ("PBRunning");
			RaisePropertyChanged ("BtnVisibility");
		}

		#region PopUp
		void DoSomething ()
		{
			Navigation.PopModalAsync ();
		}
		#endregion

		#region Retrive UserInfo
		async void DoSomethingInDB ()
		{
			PBVisibility = true;
			PBRunning = true;
			BtnVisibility = false;

			RaisePropertyChanged ("PBVisibility");
			RaisePropertyChanged ("PBRunning");
			RaisePropertyChanged ("BtnVisibility");
			Users user = new Users () { Id = Globals.UserID, FirstName = Name, Password = Password, MobileNumber = MobileNumber };
			bool valid = await AzureMobileServices.UpdateUser (user);

			if (valid) {
				await App.Current.MainPage.DisplayAlert ("User Details", "User Details get Updated", "Proceed");
				Navigation.PopModalAsync ();
			} else
				await App.Current.MainPage.DisplayAlert ("Error", "Error", "OK");
		}
		#endregion
	}
}
