using System;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Widget;

using BarberShop.Droid;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(GetMyLocationStatus))]
namespace BarberShop.Droid
{
	public class GetMyLocationStatus: Java.Lang.Object,MyLocationTracker,ILocationListener
	{


		private LocationManager _locationManager;
	
		private Location _currentLocation { get; set; }
	
		public GetMyLocationStatus() {
			
		this.InitializeLocationManager();

		}
		public event EventHandler<MyLocationEventArgs> locationObtained;

		event EventHandler<MyLocationEventArgs> MyLocationTracker.locationObtained
		{
			add
			{
				locationObtained += value;

			}

			remove
			{
				locationObtained -= value;

			}
		}




		void InitializeLocationManager()
		{
			_locationManager = (LocationManager)Forms.Context.GetSystemService(Context.LocationService);
		}

	
		public void OnLocationChanged(Location location)
		{
			_currentLocation = location;

			if (location != null)
			{
				LocationEventArgs args = new LocationEventArgs();
				args.lat = location.Latitude;
				args.lng = location.Longitude;

				locationObtained(this, args);



			}

			//else {

			//	_locationManager = (LocationManager)Forms.Context.GetSystemService(Context.LocationService);

			//	if (!_locationManager.IsProviderEnabled(LocationManager.GpsProvider) || !_locationManager.IsProviderEnabled(LocationManager.NetworkProvider))
			//	{


			//		builder.SetTitle("Location service not active");
			//		builder.SetMessage("Please Enable Location Service and GPS");
			//		builder.SetPositiveButton("Ok", (object sender, DialogClickEventArgs e) =>
			//		{

			//			var MyButton = sender as Xamarin.Forms.Button;

			//			if (MyButton != null)
			//			{

			//				Intent intent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
			//				Forms.Context.StartActivity(intent);

			//			}


			//		});

			//		Dialog alertDailog = builder.Create();

			//		alertDailog.SetCanceledOnTouchOutside(false);
			//		alertDailog.Show();
			//	}



			//}
		}


		public void OnStatusChanged(string provider, Availability status, global::Android.OS.Bundle extras)
		{
			//Not Implemented
		}

		public void OnProviderDisabled(string provider)
		{
			//Not Implemented
		}

		public void OnProviderEnabled(string provider)
		{
			//Not Implemented
		}

		void MyLocationTracker.ObtainMyLocation()
		{
			_locationManager = (LocationManager)Forms.Context.GetSystemService(Context.LocationService);

			if (!_locationManager.IsProviderEnabled(LocationManager.GpsProvider) || !_locationManager.IsProviderEnabled(LocationManager.NetworkProvider))
			{

				AlertDialog.Builder builder = new AlertDialog.Builder(Forms.Context);
				builder.SetTitle("LOCATION UNAVALIABLE");
				builder.SetMessage("PLEASE ENABLE THE LOCATION SERVICE AND GPS");
				builder.SetPositiveButton("ACTIVATE", (object sender, DialogClickEventArgs e) =>
				{

				

						Intent intent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
						Forms.Context.StartActivity(intent);

				


				});

				Dialog alertDailog = builder.Create();

				alertDailog.SetCanceledOnTouchOutside(false);
				alertDailog.Show();
			}

			else {
				
				_locationManager.RequestLocationUpdates(
					LocationManager.NetworkProvider,
						0,   //---time in ms---
						0,   //---distance in metres---
						this);
			}



		}


		~GetMyLocationStatus(){
			_locationManager.RemoveUpdates(this);
		}

	}


	public class LocationEventArgs : EventArgs, MyLocationEventArgs
	{
		public double lat { get; set; }
		public double lng { get; set; }
	}
}

