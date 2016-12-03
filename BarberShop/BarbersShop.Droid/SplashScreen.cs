
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using System.Threading;
using Android.Content.PM;

namespace BarberShop.Droid
{
	[Activity (Label = "Barber", MainLauncher = true, Theme = "@style/Theme.Splash", NoHistory = true, Icon = "@drawable/ic_launcher", ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize)]
	public class SplashScreen : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			System.Threading.Thread.Sleep (5000);
			StartActivity (typeof (MainActivity));

		}
	}
}

