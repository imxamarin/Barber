using System;
using System.Drawing;
using BarberShop;
using BarberShop.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CmLabel), typeof(CmLabeliOS))]
namespace BarberShop.iOS
{
	public class CmLabeliOS : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);


			Control.Layer.CornerRadius = 16f;
			Control.BackgroundColor = UIColor.FromRGB(241, 241, 241);
			Control.Layer.MasksToBounds = true;


		}
	
	}
}

