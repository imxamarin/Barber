using System;
using System.Linq;
using Android.Content;
using Android.Telephony;

using Xamarin.Forms;
using Android.Net;
using BarberShop.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(PhoneDailer))]
namespace BarberShop.Droid
{
	public class PhoneDailer : IDailer
	{
		public PhoneDailer()
		{
		}

		bool IDailer.Dial(string number)
		{
			var context = Forms.Context;
			if (context == null)
				return false;

			var intent = new Intent(Intent.ActionCall);
			intent.SetData(Android.Net.Uri.Parse("tel:" + number));

			
			if (IsIntentAvailable(context, intent))
			{
				context.StartActivity(intent);
				return true;
			}

			return false;
		}


		public static bool IsIntentAvailable(Context context, Intent intent)
		{

			var packageManager = context.PackageManager;

			var list = packageManager.QueryIntentServices(intent, 0)
				.Union(packageManager.QueryIntentActivities(intent, 0));
			if (list.Any())
				return true;

			TelephonyManager mgr = TelephonyManager.FromContext(context);
			return mgr.PhoneType != PhoneType.None;
		}
	}
}

