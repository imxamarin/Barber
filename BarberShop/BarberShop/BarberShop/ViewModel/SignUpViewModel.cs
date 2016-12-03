using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BarberShop.Services;
using GalaSoft.MvvmLight;
using InstaBiz.Model;
using Xamarin.Forms;
using System.Linq;

namespace BarberShop
{
	public class SignUpViewModel : ViewModelBase
	{

		#region Variables
		string iemail;
		string ipassword;
		string imobileNumber;
		string ifirstName;
		string ilastName;
		string iusername;
		ICommand regCmd;
		bool indicatorStatus;
		bool buttonStatus;
		INavigation navigtion;
		#endregion

		#region Property
		public INavigation Navigation {
			get {
				return navigtion;
			}

			set {
				navigtion = value;
				RaisePropertyChanged ("Navigation");
			}
		}

		public string iEmail {
			get {
				return iemail;
			}

			set {
				iemail = value;
				RaisePropertyChanged ("iEmail");
			}
		}

		public string iPassword {
			get {
				return ipassword;
			}

			set {
				ipassword = value;
				RaisePropertyChanged ("iPassword");
			}
		}

		public string iMobileNumber {
			get {
				return imobileNumber;
			}

			set {
				imobileNumber = value;
				RaisePropertyChanged ("iMobileNumber");
			}
		}

		public string iFirstName {
			get {
				return ifirstName;
			}

			set {
				ifirstName = value;
				RaisePropertyChanged ("iFirstName");
			}
		}

		public string iUsername {
			get {
				return iusername;
			}

			set {
				iusername = value;
				RaisePropertyChanged ("iUsername");
			}
		}

		public string iLastName {
			get {
				return ilastName;
			}

			set {
				ilastName = value;
				RaisePropertyChanged ("iLastName");
			}
		}


		public ICommand RegCmd {
			get {
				return regCmd;
			}

			set {
				regCmd = value;
				RaisePropertyChanged ("RegCmd");
			}
		}

		public bool IndicatorStatus {
			get {
				return indicatorStatus;
			}

			set {
				indicatorStatus = value;
				RaisePropertyChanged ("IndicatorStatus");
			}
		}


		public bool ButtonStatus {
			get {
				return buttonStatus;
			}

			set {
				buttonStatus = value;
				RaisePropertyChanged ("ButtonStatus");
			}
		}


		#endregion

		public SignUpViewModel ()
		{

			ButtonStatus = true;
			IndicatorStatus = false;
			RegCmd = new Command (JumpToSignUp);
			RaisePropertyChanged ("ButtonStatus");
			RaisePropertyChanged ("IndicatorStatus");
			RaisePropertyChanged ("RegCmd");
		}
		#region LocalMethod


		#region SignUp Region
		void JumpToSignUp ()
		{

			var EmailValidationResult = ValidationCheck.EmailValidation (iEmail);
			var PassValidationResult = ValidationCheck.PasswordValidation (iPassword);
			var MobileNumValidationResult = ValidationCheck.MobileNumValidation (iMobileNumber);
			DoActionOnValidation (EmailValidationResult, PassValidationResult, MobileNumValidationResult);


		}
		#endregion

		#region Mail&Password Validation
		async void DoActionOnValidation (bool MailValidator, bool PassValidator, bool NumValidator)
		{
			if (MailValidator.Equals (true) && PassValidator.Equals (true) && NumValidator.Equals (true)) {
				JumpToAzureServer ();
			} else if (MailValidator.Equals (false) && PassValidator.Equals (false) && NumValidator.Equals (false)) {
				await Application.Current.MainPage.DisplayAlert ("Alert", "Enter valid Email ID and Password", "Retry");
			} else if (MailValidator.Equals (false)) {
				await Application.Current.MainPage.DisplayAlert ("Alert", "Enter A valid Email ID", "Retry");
			} else if (PassValidator.Equals (false)) {
				await Application.Current.MainPage.DisplayAlert ("Alert", "Enter 8 digit Password", "Retry");
			} else if (NumValidator.Equals (false)) {
				await Application.Current.MainPage.DisplayAlert ("Alert", "Enter 8 digit Password", "Retry");
			}

		}
		#endregion


		#region AzureServices
		async void JumpToAzureServer ()
		{
			IndicatorStatus = true;
			ButtonStatus = false;
			RaisePropertyChanged ("IndicatorStatus");
			RaisePropertyChanged ("ButtonStatus");
			var encyrptPassSalt = Crypto.CreateSalt (iPassword.Length);
			var encyrptMailSalt = Crypto.CreateSalt (iEmail.Length);
			var usernamePro = String.Format ($"{iFirstName}{iLastName}");
			Users usersignup = new Users () {
				UserName = usernamePro, Email = iEmail, FirstName = iFirstName, LastName = iLastName,
				Password = iPassword, MobileNumber = iMobileNumber
			};


			bool valid = await AzureMobileServices.CreateNewUser (usersignup);
			if (valid) {
				var obs = new ObservableCollection<Users> ();
				obs.Add (usersignup);
				Globals.LoginCollection = new ObservableCollection<Users> ();
				Globals.LoginCollection.Add (usersignup);
				Globals.LoginCollection = obs;
				Globals.userName = usernamePro;
				Globals.userMail = iEmail;
				Globals.FirstName = iFirstName;
				Globals.LastName = iLastName;
				Globals.MobileNumber = iMobileNumber;
				DependencyService.Get<ISecuredDataProvider> ().Store (Globals.FirstName, "AzureAuth", new Dictionary<string, string> { { "AzureToken", Globals.userMail } });
				IndicatorStatus = false;
				ButtonStatus = true;
				RaisePropertyChanged ("IndicatorStatus");
				RaisePropertyChanged ("ButtonStatus");
				await App.Current.MainPage.DisplayAlert ("UserAdded", "The Login Successfull", "Proceed");
				Page originalRootPage = App.Current.MainPage.Navigation.NavigationStack.Last ();
				//		await App.Current.MainPage.Navigation.PushModalAsync (new MasterDPage ());
				App.Current.MainPage.Navigation.RemovePage (originalRootPage);
			} else {
				IndicatorStatus = false;
				ButtonStatus = true;
				await App.Current.MainPage.DisplayAlert ("Error", "Error", "OK");
				RaisePropertyChanged ("IndicatorStatus");
				RaisePropertyChanged ("ButtonStatus");
			}
		}
		#endregion

		#endregion
	}
}
