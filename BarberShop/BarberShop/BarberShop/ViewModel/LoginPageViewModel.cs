using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;
using InstaBiz.Model;
using BarberShop.Services;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BarberShop
{
	public class LoginPageViewModel : ViewModelBase
	{
		#region Variables
		string iemail;
		string ipassword;
		ICommand loginCmd;
		ICommand forgetPassCmd;
		ICommand regCmd;
		bool indicatorStatus;
		bool buttonStatus;
		INavigation navigtion;
		#endregion


		#region Properties

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


		public ICommand LoginCmd {
			get {
				return loginCmd;
			}

			set {
				loginCmd = value;
				RaisePropertyChanged ("LoginCmd");
			}
		}


		public ICommand ForgetPassCmd {
			get {
				return forgetPassCmd;
			}

			set {
				forgetPassCmd = value;
				RaisePropertyChanged ("ForgetPassCmd");
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
		Color btnColor;

		public Color BtnColor {
			get {
				return btnColor;
			}

			set {
				btnColor = value;
				RaisePropertyChanged ("ButtonStatus");
			}
		}

		#endregion


		public LoginPageViewModel ()
		{

#if DEBUG
			iEmail = "loop@pool.in";
			iPassword = "asdfghjkl";
#endif
			BtnColor = Color.Black;
			ButtonStatus = true;
			IndicatorStatus = false;
			LoginCmd = new Command (JumpToLogin);
			RegCmd = new Command (JumpToSignUp);
			ForgetPassCmd = new Command (JumpToForget);
			RaisePropertyChanged ("ButtonStatus");
			RaisePropertyChanged ("IndicatorStatus");
			RaisePropertyChanged ("LoginCmd");
			RaisePropertyChanged ("ForgetPassCmd");
			RaisePropertyChanged ("RegCmd");
			RaisePropertyChanged ("BtnColor");
		}

		#region LocalCalling

		#region SignUp Region
		void JumpToSignUp ()
		{
			try {
				if (Device.OS.Equals (TargetPlatform.iOS)) {
					Navigation.PushAsync (new NavigationPage (new SignUp ()) { Title = "SIGN UP", BarBackgroundColor = Color.Black, BarTextColor = Color.White }, false);
				} else if (Device.OS.Equals (TargetPlatform.Android)) {
					Navigation.PushAsync (new SignUp () { Title = "SIGN UP" }, false);
				} else if (Device.OS.Equals (TargetPlatform.Windows)) {
					Navigation.PushAsync (new SignUp () { Title = "SIGN UP" }, false);
				}
			} catch (Exception ex) {
				Navigation.PushModalAsync (new NavigationPage (new DefaultExPage (ex)));
			}

		}
		#endregion

		#region ForgetPassword Region
		void JumpToForget ()
		{
			try {
				if (Device.OS.Equals (TargetPlatform.iOS)) {
					Navigation.PushAsync (new NavigationPage (new ForgetPassword ()) { Title = "FORGET PASSWORD", BarBackgroundColor = Color.Black, BarTextColor = Color.White }, false);
				} else if (Device.OS.Equals (TargetPlatform.Android)) {
					//Navigation.PushAsync (new ForgetPassword () { Title = "FORGET PASSWORD" }, false);
					App.Current.MainPage.Navigation.PushModalAsync (new ForgetPassword ());
				}
			} catch (Exception ex) {
				Navigation.PushModalAsync (new NavigationPage (new DefaultExPage (ex)));
			}
		}
		#endregion

		#region Login 
		async void JumpToLogin ()
		{

			RaisePropertyChanged ("BtnColor");
			Device.BeginInvokeOnMainThread (() => {
				BtnColor = Color.Silver;
				IndicatorStatus = true;
				ButtonStatus = false;
				RaisePropertyChanged ("IndicatorStatus");
				RaisePropertyChanged ("ButtonStatus");
				RaisePropertyChanged ("BtnColor");

			});


			if (!String.IsNullOrEmpty (iEmail) && !String.IsNullOrEmpty (iPassword)) {
				var EmailValidationResult = ValidationCheck.EmailValidation (iEmail);
				var PassValidationResult = ValidationCheck.PasswordValidation (iPassword);
				DoActionOnValidation (EmailValidationResult, PassValidationResult);

			} else {
				await App.Current.MainPage.DisplayAlert ("Alert", "Email & Password Cant Be Empty", "Try Again");
				IndicatorStatus = false;
				ButtonStatus = true;
				BtnColor = Color.Black;
				RaisePropertyChanged ("BtnColor");
				RaisePropertyChanged ("IndicatorStatus");
				RaisePropertyChanged ("ButtonStatus");
			}

		}
		#endregion
		#region ValidatingData
		async void DoActionOnValidation (bool MailValidator, bool PassValidator)
		{
			if (MailValidator.Equals (true) && PassValidator.Equals (true)) {
				JumpToSendData ();
				//JumpToGetData ();
			} else if (MailValidator.Equals (false) && PassValidator.Equals (false)) {
				IndicatorStatus = false;
				ButtonStatus = true;
				BtnColor = Color.Black;
				RaisePropertyChanged ("BtnColor");
				RaisePropertyChanged ("IndicatorStatus");
				RaisePropertyChanged ("ButtonStatus");
				await Application.Current.MainPage.DisplayAlert ("Alert", "Enter valid Email ID and Password", "Retry");
			} else if (MailValidator.Equals (false)) {
				IndicatorStatus = false;
				ButtonStatus = true;
				BtnColor = Color.Black;
				RaisePropertyChanged ("BtnColor");
				RaisePropertyChanged ("IndicatorStatus");
				RaisePropertyChanged ("ButtonStatus");
				await Application.Current.MainPage.DisplayAlert ("Alert", "Enter A valid Email ID", "Retry");
			} else if (PassValidator.Equals (false)) {
				IndicatorStatus = false;
				ButtonStatus = true;
				BtnColor = Color.Black;
				RaisePropertyChanged ("BtnColor");
				RaisePropertyChanged ("IndicatorStatus");
				RaisePropertyChanged ("ButtonStatus");
				await Application.Current.MainPage.DisplayAlert ("Alert", "Enter 8 digit Password", "Retry");
			}
		}
		#endregion

		#region AzureServices
		async void JumpToSendData ()
		{
			Users user = new Users () { Email = iEmail, Password = iPassword };
			bool valid = await AzureMobileServices.LoginUser (user);
			if (valid.Equals (true)) {
				var Userlist = AzureMobileServices.GetUsersFromServer ();
				var UsersFromServer = await Userlist;
				var result = UsersFromServer.Where (n => n.Email == iEmail).FirstOrDefault ();
				var obs = new ObservableCollection<Users> ();
				obs.Add (result);
				Globals.LoginCollection = new ObservableCollection<Users> ();
				Globals.LoginCollection.Add (result);
				Globals.LoginCollection = obs;
				Globals.UserID = result.Id;
				Globals.userName = result.UserName;
				Globals.userMail = result.Email;
				Globals.FirstName = result.FirstName;
				Globals.LastName = result.LastName;
				Globals.MobileNumber = result.MobileNumber;
				DependencyService.Get<ISecuredDataProvider> ().Store (Globals.FirstName, "AzureAuth", new Dictionary<string, string> { { "AzureToken", Globals.userMail } });

				//	Application.Current.MainPage = new NavigationPage (new MasterDPage ());
				Page originalRootPage = App.Current.MainPage.Navigation.NavigationStack.Last ();
				IndicatorStatus = false;
				ButtonStatus = true;
				BtnColor = Color.Black;
				RaisePropertyChanged ("BtnColor");
				RaisePropertyChanged ("IndicatorStatus");
				RaisePropertyChanged ("ButtonStatus");
				await App.Current.MainPage.Navigation.PushModalAsync (new MasterDPage ());
				//	App.Current.MainPage.Navigation.RemovePage (originalRootPage);
				//	await Navigation.PushModalAsync (new MasterDPage ());
			} else {
				IndicatorStatus = false;
				ButtonStatus = true;
				BtnColor = Color.Black;
				RaisePropertyChanged ("BtnColor");
				RaisePropertyChanged ("IndicatorStatus");
				RaisePropertyChanged ("ButtonStatus");

				await App.Current.MainPage.DisplayAlert ("Alert", "Invalid UserName or Password", "Try Again");
				BtnColor = Color.Black;
				RaisePropertyChanged ("BtnColor");
			}
		}
		#endregion

		#region Encrypt
		async void JumpToGetData ()
		{
			var encyrptPassSalt = Crypto.CreateSalt (iPassword.Length);
			var encyrptMailSalt = Crypto.CreateSalt (iEmail.Length);
			var encryptMail = Crypto.EncryptAes (iEmail, iPassword, encyrptMailSalt);
			var encryptPass = Crypto.EncryptAes (iPassword, iEmail, encyrptPassSalt);

			var UserLogin = new List<LoginRootObject> ();
			UserLogin.Add (
				new LoginRootObject {
					EmailId = encryptMail,
					Password = encryptPass
				}
			);
			//Decrypting in Case of Debuging
#if DEBUG
			var mailresult = Crypto.DecryptAes (encryptMail, iPassword, encyrptMailSalt);
			var Passresult = Crypto.DecryptAes (encryptPass, iemail, encyrptPassSalt);
#endif
			//Sending the Request
			try {
				var result = ServicesCall.CallingServer (UserLogin, false);
				var resulttData = await result;
				//Geting Back The Request
				var tokens = JsonConvert.DeserializeObject<LoginRootObject> (resulttData);
				Globals.userName = tokens.AccessToken;
			} catch (Exception ex) {
				await Navigation.PushModalAsync (new NavigationPage (new DefaultExPage (ex)));
			}

		}
		#endregion

		#endregion

	}
}
