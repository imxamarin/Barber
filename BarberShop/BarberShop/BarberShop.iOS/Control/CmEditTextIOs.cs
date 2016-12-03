using System;
using System.Drawing;

using BarberShop;
using BarberShop.iOS;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyEntry), typeof(CmEditTextIOs))]

namespace BarberShop.iOS
{
	public class CmEditTextIOs : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			var view = e.NewElement as MyEntry;
			if (Control != null)
			{



				Control.Layer.CornerRadius = 22f;
				Control.BackgroundColor = UIColor.FromRGB(109, 109, 109);
				Control.BorderStyle = UITextBorderStyle.RoundedRect;
				Control.TextAlignment = UITextAlignment.Justified;
				SetPadding(Control, 10);

				if (!string.IsNullOrEmpty(view.LeftImage))
				{
					var PwdView1 = new UIImageView(new CGRect(0, 0, 20, 20));
					PwdView1.Image = UIImage.FromFile(view.LeftImage + ".png");
					UIView objLeftPwdView1 = new UIView(new RectangleF(0, 0, 40, 30));
					objLeftPwdView1.AddSubview(PwdView1);
					Control.RightViewMode = UITextFieldViewMode.Always;
					Control.RightView = objLeftPwdView1;
				}

			}

		}

		public static void SetPadding(UITextField f, int padding)
		{
			UIView paddingView = new UIView(new RectangleF(0, 0, padding, 20));
			f.LeftView = paddingView;
			f.LeftViewMode = UITextFieldViewMode.Always;
		}

	}
}

