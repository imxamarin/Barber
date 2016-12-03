using System;
using BarberShop.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly : ExportRenderer(typeof(NavigationPage),typeof(CmNavigation))]
namespace BarberShop.iOS
{
	public class CmNavigation : NavigationRenderer
	{


		public override void SetViewControllers(UIKit.UIViewController[] controllers, bool animated)
		{
			base.SetViewControllers(controllers, animated);
			foreach (var controller in controllers)
			{
				// Disable swipe back
				((UINavigationController)controller).InteractivePopGestureRecognizer.Enabled = false;
			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			if (InteractivePopGestureRecognizer != null)
			{
				InteractivePopGestureRecognizer.Enabled = false;
			}
		}
	}
}

