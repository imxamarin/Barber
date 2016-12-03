using GalaSoft.MvvmLight;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using InstaBiz.Model;
using BarberShop.Services;

namespace BarberShop
{
	public class ForgetPasswordViewModel : ViewModelBase
	{
		#region Variables
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
		public ICommand SendPassword { get; set; }
		private string email;
		public string Email {
			get { return email; }
			set {
				email = value;
				RaisePropertyChanged ("Email");
			}
		}


		private string iemail;
		public string iEmail {
			get { return iemail; }
			set {
				iemail = value;
				RaisePropertyChanged ("iEmail");
			}
		}
		#endregion


		public ForgetPasswordViewModel ()
		{
			SendPassword = new Command (SetUpTheMail);
		}

		#region Verification Mail

		public void SetUpTheMail ()
		{
			if (!String.IsNullOrEmpty (iEmail)) {
				var EmailValidationResult = ValidationCheck.EmailValidation (iEmail);
				DoActionOnValidation (EmailValidationResult);
			}
		}

		#endregion

		#region ValidatingData
		async void DoActionOnValidation (bool MailValidator)
		{
			if (MailValidator.Equals (true)) {
				JumpToSendData ();
			} else if (MailValidator.Equals (false)) {
				await Application.Current.MainPage.DisplayAlert ("Alert", "Enter A valid Email ID", "Retry");
			}
		}
		#endregion

		#region AzureServices
		async void JumpToSendData ()
		{
			string valid = await ServicesCall.ForgetPassword (iEmail);
			bool validMail = true;
			if (validMail) {
				GetResponceCode ();
			} else {
				await App.Current.MainPage.DisplayAlert ("Notification", "Email not found", "proceed");
			}
		}
		#endregion

		#region ResponceCode
		async void GetResponceCode ()
		{
			var code = await ServicesCall.GetingResponce ();
			if (code.Equals (true)) {
				await App.Current.MainPage.DisplayAlert ("Notification", "Mail Sent Check you Inbox", "proceed");
			} else {
				await App.Current.MainPage.DisplayAlert ("Notification", "Something Went Wrong", "Try Again");
			}
		}
		#endregion
	}
}