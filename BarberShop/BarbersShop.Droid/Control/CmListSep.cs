using System;
using Xamarin.Forms;

using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using BarberShop;
using BarberShop.Droid;

[assembly : ExportRenderer(typeof(CmListView), typeof(CmListSep))]
namespace BarberShop.Droid
{
    public class CmListSep : ListViewRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Divider = new ColorDrawable(Android.Graphics.Color.ParseColor("#CCCCCC"));
               
                Control.DividerHeight = 2;

                

            }


        }
    }
}

