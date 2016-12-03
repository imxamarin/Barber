using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using BarberShop.Services;
using GalaSoft.MvvmLight;
using InstaBiz.Model;
using Xamarin.Forms;

namespace BarberShop
{
	public class SideMasterViewModel : ViewModelBase
	{
		#region Variables
		ICommand fPageNavigation;
		public ObservableCollection<CmSideBar> SideBar { get; set; }
		private string userName;

		INavigation navigation;

		public ICommand FPageNavigation {
			get {
				return fPageNavigation;
			}

			set {
				fPageNavigation = value;
				RaisePropertyChanged ("FPageNavigation");
			}
		}


		public string Mail {
			get;
			set;
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

		public string UserName {
			get {
				return userName;
			}
			set {
				userName = value;
				RaisePropertyChanged ("UserName");
			}

		}
		#endregion

		public SideMasterViewModel ()
		{
			DoThisForUserName ();
			SideBar = new ObservableCollection<CmSideBar> ();
			SideBar.Add (new CmSideBar (
					 ImageSource.FromFile ("appointment.png"),
					 "BOOK APPOINTMENT",
				typeof (AppointmentCalender)));

			SideBar.Add (new CmSideBar (
					 ImageSource.FromFile ("gallery"),
					 "GALLARY",
					 typeof (GalleryPlus)
				));

			SideBar.Add (new CmSideBar (
				 ImageSource.FromFile ("services"),
				 "SERVICES",
				 typeof (ServicesOffer)
			));
			SideBar.Add (new CmSideBar (
					ImageSource.FromFile ("location"),
					 "LOCATION",
					typeof (CurrentMap)
				));


			FPageNavigation = new Command (JumpToThis);
			RaisePropertyChanged ("UserName");
		}

		#region UserProfile
		async void DoThisForUserName ()
		{
			try {
				UserName = Globals.LoginCollection [0]?.FirstName;
				RaisePropertyChanged ("UserName");
				if (String.IsNullOrEmpty (UserName)) {
					var alpha = DependencyService.Get<ISecuredDataProvider> ().Retreive ("AzureAuth");
					foreach (var item in alpha) {
						Mail = item.Value;
					}
					var alphas = AzureMobileServices.GetUsersFromServer ();
					var alpa = await alphas;
					var result = alpa.Where (n => n.Email == Mail).FirstOrDefault ();
					UserName = result.FirstName;
					var obs = new ObservableCollection<Users> ();
					obs.Add (result);
					Globals.LoginCollection = new ObservableCollection<Users> ();
					Globals.LoginCollection.Add (result);
					Globals.LoginCollection = obs;
					RaisePropertyChanged ("UserName");
				}
				foreach (var item in Globals.LoginCollection) {
					UserName = item.FirstName;
					RaisePropertyChanged ("UserName");
				}


				UserName = "AlphaUser";
				RaisePropertyChanged ("UserName");
			} catch (Exception ex) {
				var alpha = DependencyService.Get<ISecuredDataProvider> ().Retreive ("AzureAuth");


				foreach (var item in alpha) {
					Mail = item.Value;
				}
				var alphas = AzureMobileServices.GetUsersFromServer ();
				var alpa = await alphas;
				var result = alpa.Where (n => n.Email == Mail).FirstOrDefault ();
				UserName = result.FirstName;

				var obs = new ObservableCollection<Users> ();
				obs.Add (result);
				Globals.LoginCollection = new ObservableCollection<Users> ();
				Globals.LoginCollection.Add (result);
				Globals.LoginCollection = obs;
				RaisePropertyChanged ("UserName");
			}

		}
		#endregion

		#region Logout
		void JumpToThis ()
		{
			Navigation.PushModalAsync (new LoginPage (), false);
		}

		#endregion

	}


}
