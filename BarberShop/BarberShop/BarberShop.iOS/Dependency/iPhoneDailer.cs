using System;
using BarberShop.iOS;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(iPhoneDailer))]
namespace BarberShop.iOS
{
	public class iPhoneDailer : IDailer
	{
		public iPhoneDailer()
		{
		}

		bool IDailer.Dial(string number)
		{
			return UIApplication.SharedApplication.OpenUrl(
			new NSUrl("tel:" + number));
		}
	}
}

