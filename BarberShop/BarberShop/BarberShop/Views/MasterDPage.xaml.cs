using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Auth;
using BarberShop.Services;
using System.Linq;
using System.Diagnostics;
using InstaBiz.Model;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace BarberShop
{
	public partial class MasterDPage : MasterDetailPage
	{

		public string Mail {
			get;
			set;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			bool invalid = false;
			Dictionary<string, string> alpha = null;
			try {
				alpha = DependencyService.Get<ISecuredDataProvider> ().Retreive ("AzureAuth");
				foreach (var item in alpha) {
					Mail = item.Value;
				}
			} catch {
				invalid = true;
			}


			if (alpha == null || alpha.Count <= 0 || invalid) {
				Navigation.PushModalAsync (new NavigationPage (new LoginPage ()));
			}
			//else {
			//	Dothis ();
			//}
		}

		async void Dothis ()
		{
			try {
				var alphas = AzureMobileServices.GetUsersFromServer ();
				var alpa = await alphas;
				var result = alpa.Where (n => n.Email == Mail).FirstOrDefault ();
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

			} catch (Exception ex) {
				await Navigation.PushModalAsync (new NavigationPage (new DefaultExPage (ex)));
			}
		}

		//(user.Id, "FacebookAuth", new Dictionary<string, string> { { "FacebookToken", token } });



		public MasterDPage ()
		{
			NavigationPage.SetHasNavigationBar (this, false);
			InitializeComponent ();
			//this.LoadFromXaml (typeof (MasterDPage));
			masterPage.ListView.ItemSelected += OnItemSelected;
		}
		//var pgi = new NavigationPage((Page)Activator.CreateInstance(item.TargetType)) , Title = item.Tile };
		void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as CmSideBar;
			if (item != null) {
				var pgi = ((Page)Activator.CreateInstance (item.TargetType));
				masterPage.ListView.SelectedItem = null;
				IsPresented = false;
				Master.Icon = null;
				Detail.Navigation.PushAsync (pgi);
			}
			Master.Icon = new FileImageSource () { File = "toggle.png" };

		}

	}

}
