using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BarberShop
{
	public partial class SidePageSee : ContentPage
	{
		public ListView ListView { get { return listView; } }
		ListView listView;

		public SideMasterViewModel vm {
			get { return this.BindingContext as SideMasterViewModel; }
		}
		public SidePageSee ()
		{
			//		NavigationPage.SetHasNavigationBar (this, false);
			this.BindingContext = App.Locator.SideHamPage;
			App.Locator.SideHamPage.Navigation = Navigation;
			InitializeComponent ();
			listView = OffersListView;

		}

		void Handler_Clicked (object sender, System.EventArgs e)
		{
			Navigation.PushModalAsync (new NavigationPage (new UserProfile ()));
		}

		public void Handle_Clicked (object sender, System.EventArgs e)
		{
			if (Device.OS.Equals (TargetPlatform.iOS)) {
				DependencyService.Get<ISecuredDataProvider> ().Clear ("AzureAuth");
				Navigation.PushModalAsync (new NavigationPage (new LoginPage ()), false);
			} else if (Device.OS.Equals (TargetPlatform.Android)) {
				DependencyService.Get<ISecuredDataProvider> ().Clear ("AzureAuth");
				Application.Current.MainPage = new NavigationPage (new LoginPage ());
			}
		}


	}
}
