using System;
using Xamarin.Forms;

using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using BarberShop;
using BarberShop.Droid;

[assembly: ExportRenderer(typeof(CmDatePicker), typeof(CmCal))]
namespace BarberShop.Droid
{
    public class CmCal: DatePickerRenderer
    {
       

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);


            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(Android.Graphics.Color.ParseColor("#E25D33"));
                gd.SetCornerRadius(100);
                gd.SetStroke(2, Android.Graphics.Color.Transparent);
                #pragma warning disable CS0618 // Type or member is obsolete
                this.Control.SetBackgroundDrawable(gd);
                this.Control.SetPadding(30, 0, 30, 0);
                #pragma warning restore CS0618 // Type or member is obsolete

                //Control.Gravity = Android.Views.GravityFlags.CenterHorizontal;
                Control.Gravity = Android.Views.GravityFlags.Center;
				Control.SetTextColor(Android.Graphics.Color.White);
            }

        }


    }
}

