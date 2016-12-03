using System;

using BarberShop;
using BarberShop.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CmDatePicker), typeof(CmDatePickerIoS))]
namespace BarberShop.iOS
{
	public class CmDatePickerIoS : DatePickerRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
			{
						Control.Layer.CornerRadius = 22f;
						Control.Layer.MasksToBounds = true;
						Control.Text = "SELECT DATE";
						Control.BackgroundColor = UIColor.FromRGB(226, 93, 51);
						Control.TextAlignment = UITextAlignment.Center;

					}
			}

	}
}

