using System;
using Android.Graphics.Drawables;
using BarberShop;
using BarberShop.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyEntry), typeof(CmEditText))]
namespace BarberShop.Droid
{
	public class CmEditText: EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
	{
		base.OnElementChanged(e);
		var view = e.NewElement as MyEntry;
		if (Control != null)
		{
			GradientDrawable gd = new GradientDrawable();
			gd.SetColor(Android.Graphics.Color.ParseColor("#6D6D6D"));
			gd.SetCornerRadius(100);
				gd.SetStroke(2, Android.Graphics.Color.Transparent);
#pragma warning disable CS0618 // Type or member is obsolete
			this.Control.SetBackgroundDrawable(gd);
			this.Control.SetPadding(30, 0, 30, 0);
#pragma warning restore CS0618 // Type or member is obsolete

			if (!string.IsNullOrEmpty(view.LeftImage))
			{
				int resID = Resources.GetIdentifier(view.LeftImage, "drawable", Context.PackageName);
				Control.SetCompoundDrawablesWithIntrinsicBounds(0, 0, resID, 0);
				Control.CompoundDrawablePadding = 5;

			}

			Control.Gravity = Android.Views.GravityFlags.CenterVertical;
			Control.SetHintTextColor(Android.Graphics.Color.White);
		}
	}
}
}
