using System;
using GalaSoft.MvvmLight;
using Xamarin.Forms;
using System.Windows.Input;

namespace BarberShop
{
	public class AppointmentViewModel : ViewModelBase
	{

		#region Variables
		private INavigation navigation;
		ICommand selectCalender;
		ICommand selectGallery;
		ICommand selectMap;
		ICommand selectServices;
		bool buttonState;

		#endregion

		#region Properties

		public bool ButtonState {
			get {
				return buttonState;
			}

			set {
				buttonState = value;
				RaisePropertyChanged ("ButtonState");
			}
		}

		public INavigation Navigation {
			get {
				return navigation;
			}

			set {
				navigation = value;
				RaisePropertyChanged ("Navigation");
			}
		}

		public ICommand SelectCalender {
			get {
				return selectCalender;
			}

			set {
				selectCalender = value;
				RaisePropertyChanged ("SelectCalender");
			}
		}

		public ICommand SelectGallery {
			get {
				return selectGallery;
			}

			set {
				selectGallery = value;
				RaisePropertyChanged ("SelectGallery");
			}
		}

		public ICommand SelectMap {
			get {
				return selectMap;
			}

			set {
				selectMap = value;
				RaisePropertyChanged ("SelectMap");
			}
		}

		public ICommand SelectServices {
			get {
				return selectServices;
			}

			set {
				selectServices = value;
				RaisePropertyChanged ("SelectServices");
			}
		}

		#endregion


		public AppointmentViewModel ()
		{
			ButtonState = false;
			SelectCalender = new Command (JumpToCalender);
			SelectGallery = new Command (JumpToGallery);
			SelectMap = new Command (JumpToMap);
			SelectServices = new Command (JumpToServices);
			RaisePropertyChanged ("ButtonState");
		}

		#region Local Calling
		#region Map Routing
		async void JumpToMap ()
		{
			if (!String.IsNullOrEmpty (Identity.Company.CompanyAddress) && String.IsNullOrEmpty (Identity.Company.CompanyCity)) {
				try {
					await Navigation.PushAsync (new CurrentMap (), false);
					RaisePropertyChanged ("SelectMap");
					RaisePropertyChanged ("Navigation");

				} catch (Exception ex) {
					await Navigation.PushModalAsync (new NavigationPage (new DefaultExPage (ex)));

				}
			} else {
				App.Current.MainPage.DisplayAlert ("Address is blank", "TryAgain", "Proceed");
			}
		}

		#endregion

		#region ServicesProvided
		async void JumpToServices ()
		{
			try {
				await Navigation.PushAsync (new ServicesOffer (), false);
				RaisePropertyChanged ("SelectServices");
				RaisePropertyChanged ("Navigation");

			} catch (Exception ex) {
				await Navigation.PushModalAsync (new NavigationPage (new DefaultExPage (ex)));
			}
		}
		#endregion

		#region ImageGallery
		async void JumpToGallery ()
		{
			try {
				await Navigation.PushAsync (new GalleryPlus (), false);
				RaisePropertyChanged ("SelectGallery");
				RaisePropertyChanged ("Navigation");
			} catch (Exception ex) {
				await Navigation.PushModalAsync (new NavigationPage (new DefaultExPage (ex)));
			}

		}
		#endregion

		#region Calender
		async void JumpToCalender ()
		{
			await Navigation.PushAsync (new AppointmentCalender (), false);
			RaisePropertyChanged ("SelectCalender");
			RaisePropertyChanged ("Navigation");

		}
		#endregion
		#endregion
	}
}
