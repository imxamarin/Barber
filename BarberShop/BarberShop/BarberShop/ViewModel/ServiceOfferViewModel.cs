using BarberShop.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading;
using System.Linq;
namespace BarberShop
{
	public class ServiceOfferViewModel : ViewModelBase
	{

		#region Variables
		public ObservableCollection<CmCell> ListBar { get; set; }
		public ObservableCollection<string> Treater { get; set; }
		public ObservableCollection<decimal> Pricer { get; set; }
		ICommand toolbarItemCommand;
		string showStatus;
		string _theTreatment;
		string _thePrice;
		bool acIns;
		bool lvShow;
		bool defacto;

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

		public ICommand DoSomeSyncOp {
			get {
				return doSomeSyncOp;
			}

			set {
				doSomeSyncOp = value;
			}
		}

		public string TheTreatment {
			get {
				return _theTreatment;
			}

			set {
				_theTreatment = value;
				RaisePropertyChanged ("TheTreatment");
			}
		}

		public string ThePrice {
			get {
				return _thePrice;
			}

			set {
				_thePrice = value;
				RaisePropertyChanged ("ThePrice");
			}
		}

		public bool AcIns {
			get {
				return acIns;
			}

			set {
				acIns = value;
				RaisePropertyChanged ("AcIns");
			}
		}

		public bool Defacto {
			get {
				return defacto;
			}

			set {
				defacto = value;
				RaisePropertyChanged ("Defacto");
			}
		}

		public bool LvShow {
			get {
				return lvShow;
			}

			set {
				lvShow = value;
				RaisePropertyChanged ("LvShow");
			}
		}

		public string ShowStatus {
			get {
				return showStatus;
			}

			set {
				showStatus = value;
				RaisePropertyChanged ("ShowStatus");
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

		ICommand doSomeSyncOp;

		private bool _inactive;
		public bool Inactive {
			get {
				return _inactive;
			}
			set {
				if (_inactive != value) {
					_inactive = value;
					((Command)ToolbarItemCommand).ChangeCanExecute ();
					RaisePropertyChanged ("Inactive");
				}
			}
		}

		#endregion

		public ServiceOfferViewModel ()
		{
			try {
				ShowStatus = "Loading list from Server";
				Defacto = true;
				LvShow = false;
				CallThis ();
				AcIns = true;
				ToolbarItemCommand = new Command (async () => {
					Inactive = false;
					await CallThis ();
					//await CallThisForSync ();

				},
										  () => {
											  return Inactive;
										  });
				RaisePropertyChanged ("Inactive");
				RaisePropertyChanged ("AcIns");

			} catch (Exception ex) {
				Navigation.PushModalAsync (new NavigationPage (new DefaultExPage (ex)));
			}
		}

		#region Getting The Services From server
		async Task CallThisForSync ()
		{
			try {
				ShowStatus = "Loading list from Server..";
				var result = ServicesCall.GetProducts ();
				ShowStatus = "Loading list from Server...";
				var ProductList = await result;
				if (ProductList.Count > 0 && !ProductList.Equals (null)) {
					ShowStatus = "Loading list from Server....";
					if (Defacto.Equals (bool.TrueString)) {
						Defacto = false;
					}
					if (ProductList.Count == 1) {
						foreach (var item in ProductList) {
							item.Treatments.Equals (null);
							break;
						}
					}
					ListBar = new ObservableCollection<CmCell> ();
					AcIns = false;
					LvShow = true;
					foreach (var item in ProductList) {
						ListBar.Add (new CmCell {
							Logo = item.Logo,
							Price = item.Price,
							Dollar = "$",
							Treatments = item.Treatments
						});
					}
				} else {
					ShowStatus = "Currently No Services Avaliable";
					AcIns = false;
					LvShow = false;
					Defacto = true;
				}
				Inactive = true;

				RaisePropertyChanged ("Inactive");
				RaisePropertyChanged ("Defacto");
				RaisePropertyChanged ("AcIns");
				RaisePropertyChanged ("LvShow");

			} catch (Exception ex) {
				App.Locator.LoginPage.Navigation = Navigation;
			}

		}
		#endregion

		#region AzureMobileService
		async Task CallThis ()
		{

			try {
				ShowStatus = "Loading list from Server..";
				var result = AzureMobileServices.GetProducts ();
				ShowStatus = "Loading list from Server...";
				var ProductList = await result;
				if (ProductList.Count > 0 && !ProductList.Equals (null)) {
					ShowStatus = "Loading list from Server....";
					if (Defacto.Equals (bool.TrueString)) {
						Defacto = false;
					}
					if (ProductList.Count == 1) {
						foreach (var item in ProductList) {
							item.Name.Equals (null);
							break;
						}
					}
					ListBar = new ObservableCollection<CmCell> ();
					AcIns = false;
					LvShow = true;
					foreach (var item in ProductList) {
						ListBar.Add (new CmCell {
							//Logo = item.Logo,
							Price = item.UnitPrice,
							Dollar = "$",
							Treatments = item.Name
						});
					}
				} else {
					ShowStatus = "Currently No Services Avaliable";
					AcIns = false;
					LvShow = false;
					Defacto = true;
				}
				Inactive = true;

				RaisePropertyChanged ("Inactive");
				RaisePropertyChanged ("Defacto");
				RaisePropertyChanged ("AcIns");
				RaisePropertyChanged ("LvShow");

			} catch (Exception ex) {
				App.Locator.LoginPage.Navigation = Navigation;
			}

		}
		#endregion

		#region Default Static Services
		void CallThisMethod ()
		{
			ListBar = new ObservableCollection<CmCell> ();
			ListBar.Add (new CmCell {
				Logo = "cut_line_up.png",
				Price = 22,
				Dollar = "$",
				Treatments = "Cut"
			});

			ListBar.Add (new CmCell {
				Logo = "etc1.png",
				Price = 27,
				Dollar = "$",
				Treatments = "Cut and Line"
			});


			ListBar.Add (new CmCell {
				Logo = "etc2.png",
				Price = 35,
				Dollar = "$",
				Treatments = "Hot Towel Shave"
			});

			ListBar.Add (new CmCell {
				Logo = "etc3.png",
				Price = 35,
				Dollar = "$",
				Treatments = "Etc"
			});

		}

		#endregion

	}
}
