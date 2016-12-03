using System;
using GalaSoft.MvvmLight;
using Xamarin.Forms;
using System.Windows.Input;

namespace BarberShop
{
	public class ConfirmationViewModel : ViewModelBase
	{
		#region Variables
		private string confirmate;
		private string appointaCon;
		private ICommand clickConn;
		public string Confirmate {
			get {
				return confirmate;
			}

			set {
				confirmate = value;
				RaisePropertyChanged ("Confirmate");
			}
		}

		private INavigation navigation;

		public INavigation Navigation {
			get {
				return navigation;
			}

			set {
				navigation = value;
				RaisePropertyChanged ("Navigation");
			}
		}

		public string AppointaCon {
			get {
				return appointaCon;
			}

			set {
				appointaCon = value;
				RaisePropertyChanged ("AppointaCon");
			}
		}

		public ICommand ClickConn {
			get {
				return clickConn;
			}

			set {
				clickConn = value;
				RaisePropertyChanged ("ClickConn");

			}
		}
		#endregion

		public ConfirmationViewModel ()
		{
			try {
				Confirmate = "THANK YOU";
				AppointaCon = "Your appointment confirmed";

				ClickConn = new Command (JumpHereToNavigate);
				RaisePropertyChanged ("ClickConn");
			} catch (Exception ex) {
				Navigation.PushModalAsync (new NavigationPage (new DefaultExPage (ex)));

			}

		}

		void JumpHereToNavigate ()
		{
			Navigation.PopModalAsync ();
			Navigation.PushModalAsync (new MasterDPage ());
		}
	}
}
