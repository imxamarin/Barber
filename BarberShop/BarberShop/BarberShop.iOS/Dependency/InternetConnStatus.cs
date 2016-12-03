using System;
using BarberShop.iOS;
using CoreLocation;
using SystemConfiguration;

[assembly: Xamarin.Forms.Dependency(typeof(InternetConnStatus))]
namespace BarberShop.iOS
{
	public class InternetConnStatus : MyConnectivityTracker
	{
		public InternetConnStatus()
		{
		}

		void MyConnectivityTracker.ObtainMyConnectionStatus()
		{
			var reachabelity = new NetworkReachability("www.google.com");


		}
	}
}

