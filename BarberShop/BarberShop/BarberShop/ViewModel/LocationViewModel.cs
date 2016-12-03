using GalaSoft.MvvmLight;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BarberShop
{
	public class LocationAvaliableViewModel : ViewModelBase
	{
		public const string keys = Constants.MapKey;
		public const string mobileNumber = Constants.MobileNumber;
		public const double MyLatitute = Constants.ShopLatitute;
		public const double MyLogitute = Constants.ShopLogitute;
		bool aCI;
		bool haltBtn;
		ICommand getMyLocation;
		ICommand getNumber;
		public ObservableCollection<CmMap> SideMap { get; set; }
		public ObservableCollection<string> PolyPointer { get; set; }
		public ObservableCollection<iLocation> Latlo { get; set; }
		public ObservableCollection<Xamarin.Forms.Maps.Position> Letse { get; set; }
		INavigation navigation;
		public MyLocationTracker msi;
		public MyConnectivityTracker msk;


		public INavigation Navigation {
			get {
				return navigation;
			}

			set {
				navigation = value;
				RaisePropertyChanged ("Navigation");
			}
		}

		public ICommand GetMyLocation {
			get {
				return getMyLocation;
			}

			set {
				getMyLocation = value;
				RaisePropertyChanged ("GetMyLocation");
			}
		}
		double shopLat;

		public double ShopLat {
			get {
				return shopLat;
			}

			set {
				shopLat = value;
				RaisePropertyChanged ("ShopLat");
			}
		}

		double shopLog;

		public double ShopLog {
			get {
				return shopLog;
			}

			set {
				shopLog = value;
				RaisePropertyChanged ("ShopLog");
			}
		}


		double betaLat;

		public double BetaLat {
			get {
				return betaLat;
			}

			set {
				betaLat = value;
				RaisePropertyChanged ("BetaLat");
			}
		}

		double betaLog;

		public double BetaLog {
			get {
				return betaLog;
			}

			set {
				betaLog = value;
				RaisePropertyChanged ("BetaLog");
			}
		}

		public ICommand GetNumber {
			get {
				return getNumber;
			}

			set {
				getNumber = value;
				RaisePropertyChanged ("GetNumber");
			}
		}

		public bool ACI {
			get {
				return aCI;
			}

			set {
				aCI = value;
				RaisePropertyChanged ("ACI");
			}
		}

		public bool HaltBtn {
			get {
				return haltBtn;
			}

			set {
				haltBtn = value;
				RaisePropertyChanged ("HaltBtn");
			}
		}
		Double inq;

		public Double Inq {
			get {
				return inq;
			}

			set {
				inq = value;
				RaisePropertyChanged ("HaltBtn");

			}
		}

		public LocationAvaliableViewModel ()
		{
			HaltBtn = true;
			msi = DependencyService.Get<MyLocationTracker> ();
			msi.locationObtained += (object sender, MyLocationEventArgs e) => {
				Inq = e.lat;
			};
			msi.ObtainMyLocation ();
			msk = DependencyService.Get<MyConnectivityTracker> ();
			msk.ObtainMyConnectionStatus ();
			ShopLat = MyLatitute;
			ShopLog = MyLogitute;
			GetMyLocation = new Command (FindMeMap);
			GetNumber = new Command (CallMeThis);
			RaisePropertyChanged ("HaltBtn");
		}

		#region Calling Services
		async void CallMeThis ()
		{

			HaltBtn = false;
			ACI = true;
			if (await App.Current.MainPage.DisplayAlert (
					 "DAIL A NUMBER",
					 "CALLING " + mobileNumber + "...",
					 "Yes",
					 "No")) {
				var dialer = DependencyService.Get<IDailer> ();
				if (dialer != null) {
					dialer.Dial (mobileNumber);
				}
			}
			HaltBtn = true;
			ACI = false;
			RaisePropertyChanged ("ACI");
			RaisePropertyChanged ("HaltBtn");
		}


		#endregion

		#region Routing
		async void FindMeMap ()
		{

			ACI = true;
			HaltBtn = false;
			var locator = CrossGeolocator.Current;

			RootingObject rootobject = new RootingObject ();

			if (locator.IsGeolocationEnabled == false) {
				if (Device.OS == TargetPlatform.Android) {
					msi = DependencyService.Get<MyLocationTracker> ();
					msi.locationObtained += (object Esender, MyLocationEventArgs ew) => {
						//
					};
					msi.ObtainMyLocation ();


				} else if (Device.OS == TargetPlatform.iOS) {
					msi = DependencyService.Get<MyLocationTracker> ();
					msi.locationObtained += (object Jsender, MyLocationEventArgs je) => {
						//
					};
					msi.ObtainMyLocation ();
				}
			}

			locator.DesiredAccuracy = 50;
			var position = await locator.GetPositionAsync (timeoutMilliseconds: 100000);
			BetaLat = position.Latitude;
			BetaLog = position.Longitude;
			Position currentloc = new Position (BetaLat, BetaLog);
			Position shopPos = new Position (ShopLat, ShopLog);
			string Jsonstr = string.Format ("json?origin={0},{1}&destination={2},{3}&key={4}", ShopLat, ShopLog, BetaLat, BetaLog, keys);
			var client = new System.Net.Http.HttpClient ();
			client.BaseAddress = new Uri ("https://maps.googleapis.com/maps/api/directions/");
			var response = await client.GetAsync (Jsonstr);
			var earthquakesJson = response.Content.ReadAsStringAsync ().Result;
			rootobject = JsonConvert.DeserializeObject<RootingObject> (earthquakesJson);
			PolyPointer = new ObservableCollection<string> ();
			foreach (var item in rootobject.routes) {
				foreach (var items in item.legs) {
					foreach (var iteq in items.steps) {
						PolyPointer.Add (iteq.polyline.points);
					}
				}
			}
			Latlo = new ObservableCollection<iLocation> ();
			Letse = new ObservableCollection<Position> ();
			foreach (var item in PolyPointer) {
				Latlo = DecodePolylinePoints (item);
				foreach (var items in Latlo) {
					Letse.Add (new Position (items.lat, items.lng));
				}
			}
			var xn = Letse.Count;
			ACI = false;
			HaltBtn = true;
			await Navigation.PushAsync (new RoutePage (Letse, currentloc, shopPos));
			RaisePropertyChanged ("ACI");
			RaisePropertyChanged ("HaltBtn");

		}
		#endregion

		#region Decoding The Postion
		public ObservableCollection<iLocation> DecodePolylinePoints (string encodedPoints)
		{
			if (encodedPoints == null || encodedPoints == "") return null;
			ObservableCollection<iLocation> poly = new ObservableCollection<iLocation> ();
			char [] polylinechars = encodedPoints.ToCharArray ();
			int index = 0;
			int currentLat = 0;
			int currentLng = 0;
			int next5bits;
			int sum;
			int shifter;
			try {
				while (index < polylinechars.Length) {
					// calculate next latitude
					sum = 0;
					shifter = 0;
					do {
						next5bits = (int)polylinechars [index++] - 63;
						sum |= (next5bits & 31) << shifter;
						shifter += 5;
					} while (next5bits >= 32 && index < polylinechars.Length);

					if (index >= polylinechars.Length)
						break;

					currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);
					//calculate next longitude
					sum = 0;
					shifter = 0;
					do {
						next5bits = (int)polylinechars [index++] - 63;
						sum |= (next5bits & 31) << shifter;
						shifter += 5;
					} while (next5bits >= 32 && index < polylinechars.Length);

					if (index >= polylinechars.Length && next5bits >= 32)
						break;

					currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);
					iLocation p = new iLocation ();
					p.lat = Convert.ToDouble (currentLat) / 100000.0;
					p.lng = Convert.ToDouble (currentLng) / 100000.0;
					poly.Add (p);
					RaisePropertyChanged ("PBStatus");
				}
			} catch (Exception ex) {
				// logo it
			}
			return poly;
		}
		#endregion


	}

}

