using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Syncfusion.SfCalendar.XForms.Droid;
using FFImageLoading.Forms.Droid;
using Microsoft.WindowsAzure.MobileServices;

namespace BarberShop.Droid
{
	[Activity (Label = "BarberShop.Droid", Icon = "@drawable/ic_launcher", Theme = "@style/MyTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			CachedImageRenderer.Init ();

			//TabLayoutResource = Resource.Layout.Tabbar;
			//ToolbarResource = Resource.Layout.Toolbar;
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			new SfCalendarRenderer ();
			var intent = new Intent (this, typeof (RegistrationIntentService));
			StartService (intent);
			Xamarin.FormsMaps.Init (this, bundle);

			CurrentPlatform.Init ();


			LoadApplication (new App ());

		}
	}
}
