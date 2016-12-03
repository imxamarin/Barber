using BarberShop;
using BarberShop.Services;
using BarberShop.ViewModel;
using InstaBiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace BarberShop
{
	public partial class App : Application
	{
		// Facebook Login Dependecy Services For LOGIN
		#region	Facebook
		public static Action HideLoginView {
			get {
				return new Action (() => App.Current.MainPage.Navigation.PopModalAsync ());
			}
		}

		public async static Task NavigateToProfile (string message)
		{
			await App.Current.MainPage.Navigation.PushModalAsync (new Profile (message));
		}
		#endregion

		//Defining the ViewModel
		private static ViewModelLocator _locator;
		public static ViewModelLocator Locator {
			get {
				return _locator ?? (_locator = new ViewModelLocator ());
			}
		}

		public App ()
		{
			InitializeComponent ();
			MainPage = new NavigationPage (new MasterDPage ());

		}
		protected override void OnStart ()
		{

			// Handle when your app starts

		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes


		}
	}
}
