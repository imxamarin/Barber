
using Foundation;
using UIKit;
using Google.Maps;
using System.Reflection;
using Syncfusion.SfCalendar.XForms.iOS;
using DLToolkit.Forms.Controls;
using FFImageLoading.Forms.Touch;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
namespace BarberShop.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : FormsApplicationDelegate
	{

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Forms.Init ();
			FlowListView.Init ();
			CachedImageRenderer.Init ();
			var cv = typeof (Xamarin.Forms.CarouselView);
			var assembly = Assembly.Load (cv.FullName);
			new SfCalendarRenderer ();
			Xamarin.FormsMaps.Init ();
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init ();
			MapServices.ProvideAPIKey ("AIzaSyBVLJRH9mQ718yH3feqsUKpMb6q7A4Xxrg");
			LoadApplication (new App ());
			return base.FinishedLaunching (app, options);
		}
	}
}
