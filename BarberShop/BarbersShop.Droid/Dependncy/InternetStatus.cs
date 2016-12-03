using System;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using BarberShop.Droid;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(InternetStatus))]
namespace BarberShop.Droid
{
	public class InternetStatus : MyConnectivityTracker
	{

		
		public InternetStatus()
		{
		}

		void MyConnectivityTracker.ObtainMyConnectionStatus()
		{
			ConnectivityManager connectivityManager = (ConnectivityManager)Forms.Context.GetSystemService(Context.ConnectivityService);

			NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
			bool isOnline = (activeConnection != null) && activeConnection.IsConnected;

			if (!isOnline)
			{

				AlertDialog.Builder builder = new AlertDialog.Builder(Forms.Context);
				builder.SetTitle("INTERNET INACTIVE");
				builder.SetMessage("PLEASE ENABLE THE INTERNET ");

				builder.SetPositiveButton("ACTIVATE", (object sender, DialogClickEventArgs e) =>
				{



					Intent intent = new Intent(Android.Provider.Settings.ActionWifiSettings);


					Forms.Context.StartActivity(intent);



				});
				Dialog alertDailog = builder.Create();

				alertDailog.SetCanceledOnTouchOutside(false);
				alertDailog.Show();

			}

			else if(isOnline) {

				AlertDialog.Builder builder = new AlertDialog.Builder(Forms.Context);
				builder.SetTitle("INTERNET ACTIVE");
				builder.SetMessage("PLEASE ENABLE THE INTERNET ");

				builder.SetPositiveButton("ACTIVATE", (object sender, DialogClickEventArgs e) =>
				{



					Intent intent = new Intent(Android.Provider.Settings.ActionWirelessSettings);


					Forms.Context.StartActivity(intent);

					Dialog alertDailog = builder.Create();

					alertDailog.SetCanceledOnTouchOutside(false);
					alertDailog.Show();


				});
			}



		}
	}
}

