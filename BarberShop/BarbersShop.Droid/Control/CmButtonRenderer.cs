using System;
using Android.Graphics.Drawables;
using BarberShop;
using BarberShop.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof (CmButton), typeof (CmButtonRenderer))]
namespace BarberShop.Droid
{
	public class CmButtonRenderer : ButtonRenderer
	{
		private GradientDrawable _normal, _pressed;

		protected override void OnElementChanged (ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged (e);
			var view = e.NewElement as CmButton;
			var views = e.OldElement as CmButton;
			if (view.WhiteBg == true) {
				GradientDrawable gd = new GradientDrawable ();
				gd.SetColor (Android.Graphics.Color.Transparent);
				gd.SetCornerRadius (100);
				gd.SetStroke (4, Android.Graphics.Color.Black);

#pragma warning disable CS0618 // Type or member is obsolete
				Control.SetBackgroundDrawable (gd);
				this.Control.SetPadding (30, 0, 30, 0);
#pragma warning restore CS0618 // Type or member is obsolete
			}
			if (view.WhiteBg == false) {
				GradientDrawable gd = new GradientDrawable ();
				gd.SetColor (Android.Graphics.Color.Black);
				gd.SetCornerRadius (100);
				gd.SetStroke (2, Android.Graphics.Color.Black);

#pragma warning disable CS0618 // Type or member is obsolete
				Control.SetBackgroundDrawable (gd);
#pragma warning restore CS0618 // Type or member is obsolete
			}

			if (view.SaffaronBg == true) {

				GradientDrawable gd = new GradientDrawable ();
				gd.SetColor (Android.Graphics.Color.ParseColor ("#E25D33"));
				gd.SetCornerRadius (100);
				gd.SetStroke (2, Android.Graphics.Color.Transparent);
#pragma warning disable CS0618 // Type or member is obsolete
				this.Control.SetBackgroundDrawable (gd);
				this.Control.SetPadding (30, 0, 30, 0);
#pragma warning restore CS0618 // Type or member is obsolete

				//Control.Gravity = Android.Views.GravityFlags.CenterHorizontal;
				Control.Gravity = Android.Views.GravityFlags.Center;
			}



			if (view.ButtonHasSelected == true) {

				Control.SetTextColor (Android.Graphics.Color.Black);
				GradientDrawable gd = new GradientDrawable ();
				gd.SetColor (Android.Graphics.Color.ParseColor ("#F1F1F1"));
				gd.SetCornerRadius (100);
				gd.SetStroke (2, Android.Graphics.Color.Transparent);
#pragma warning disable CS0618 // Type or member is obsolete
				this.Control.SetBackgroundDrawable (gd);
				this.Control.SetPadding (30, 0, 30, 0);
#pragma warning restore CS0618 // Type or member is obsolete

				//Control.Gravity = Android.Views.GravityFlags.CenterHorizontal;
				Control.Gravity = Android.Views.GravityFlags.Center;

			}

			if (view.ButtonHasNotSelected == true) {

				Control.SetTextColor (Android.Graphics.Color.White);
				GradientDrawable gds = new GradientDrawable ();
				gds.SetColor (Android.Graphics.Color.Black);
				gds.SetCornerRadius (100);
				gds.SetStroke (2, Android.Graphics.Color.Black);
#pragma warning disable CS0618 // Type or member is obsolete
				this.Control.SetBackgroundDrawable (gds);
				this.Control.SetPadding (30, 0, 30, 0);
#pragma warning restore CS0618 // Type or member is obsolete
				//Control.Gravity = Android.Views.GravityFlags.CenterHorizontal;
				Control.Gravity = Android.Views.GravityFlags.Center;


			}


			if (view.UserProfile == true) {
				Control.SetTextColor (Android.Graphics.Color.Black);
				GradientDrawable gds = new GradientDrawable ();
				gds.SetColor (Android.Graphics.Color.White);
				gds.SetCornerRadius (100);
				gds.SetStroke (2, Android.Graphics.Color.Black);
#pragma warning disable CS0618 // Type or member is obsolete
				this.Control.SetBackgroundDrawable (gds);
				this.Control.SetPadding (30, 0, 30, 0);
#pragma warning restore CS0618 // Type or member is obsolete
				//Control.Gravity = Android.Views.GravityFlags.CenterHorizontal;
				Control.Gravity = Android.Views.GravityFlags.Center;
			}


			if (view.timeslot == true) {

				Control.SetTextColor (Android.Graphics.Color.Black);
				GradientDrawable gd = new GradientDrawable ();
				gd.SetColor (Android.Graphics.Color.ParseColor ("#F1F1F1"));
				gd.SetCornerRadius (100);
				gd.SetStroke (2, Android.Graphics.Color.Transparent);
#pragma warning disable CS0618 // Type or member is obsolete
				this.Control.SetBackgroundDrawable (gd);
				this.Control.SetPadding (30, 0, 30, 0);
#pragma warning restore CS0618 // Type or member is obsolete

				//Control.Gravity = Android.Views.GravityFlags.CenterHorizontal;
				Control.Gravity = Android.Views.GravityFlags.Center;

				Control.Click += (sender, eq) => {



					Control.SetTextColor (Android.Graphics.Color.White);
					GradientDrawable gds = new GradientDrawable ();
					gds.SetColor (Android.Graphics.Color.Black);
					gds.SetCornerRadius (100);
					gds.SetStroke (2, Android.Graphics.Color.Black);
#pragma warning disable CS0618 // Type or member is obsolete
					this.Control.SetBackgroundDrawable (gds);
					this.Control.SetPadding (30, 0, 30, 0);
#pragma warning restore CS0618 // Type or member is obsolete

					//Control.Gravity = Android.Views.GravityFlags.CenterHorizontal;
					Control.Gravity = Android.Views.GravityFlags.Center;


				};


			}




			if (view.timeslot == true && view.timeselected == true) {
				GradientDrawable gd = new GradientDrawable ();
				gd.SetColor (Android.Graphics.Color.Black);
				gd.SetCornerRadius (100);
				//gd.SetShape(ShapeType.Oval);
				gd.SetStroke (2, Android.Graphics.Color.Transparent);
#pragma warning disable CS0618 // Type or member is obsolete
				this.Control.SetBackgroundDrawable (gd);
				//  this.Control.SetPadding(30, 0, 30, 0);
#pragma warning restore CS0618 // Type or member is obsolete



			}


			if (view.btnType == true) {

				Control.SetBackgroundColor (Android.Graphics.Color.Transparent);

			}


			if (view.alphaCircle == true) {

				GradientDrawable gd = new GradientDrawable ();
				gd.SetColor (Android.Graphics.Color.Black);
				gd.SetCornerRadius (500);
				//gd.SetShape(ShapeType.Oval);
				gd.SetStroke (2, Android.Graphics.Color.Transparent);
#pragma warning disable CS0618 // Type or member is obsolete
				this.Control.SetBackgroundDrawable (gd);
				//  this.Control.SetPadding(30, 0, 30, 0);
#pragma warning restore CS0618 // Type or member is obsolete


			}


			if (view.betaCircle == true) {

				GradientDrawable gd = new GradientDrawable ();
				gd.SetColor (Android.Graphics.Color.ParseColor ("#E25D33"));
				gd.SetCornerRadius (500);
				//gd.SetShape(ShapeType.Oval);
				gd.SetStroke (2, Android.Graphics.Color.Transparent);
#pragma warning disable CS0618 // Type or member is obsolete
				this.Control.SetBackgroundDrawable (gd);
				//  this.Control.SetPadding(30, 0, 30, 0);
#pragma warning restore CS0618 // Type or member is obsolete


			}


			/*
				if (view.btnType == true)
				{

					var button = (CmButton)e.NewElement;

					button.SizeChanged += (s, args) =>
					{
						var radius = (float)Math.Min(button.Width, button.Height);

						// Create a drawable for the button's normal state
						_normal = new Android.Graphics.Drawables.GradientDrawable();

						if (button.BackgroundColor.R == -1.0 && button.BackgroundColor.G == -1.0 && button.BackgroundColor.B == -1.0)
							_normal.SetColor(Android.Graphics.Color.ParseColor("#ff2c2e2f"));
						else
							_normal.SetColor(button.BackgroundColor.ToAndroid());

						_normal.SetCornerRadius(radius);

						// Create a drawable for the button's pressed state
						_pressed = new Android.Graphics.Drawables.GradientDrawable();
						var highlight = Context.ObtainStyledAttributes(new int[] { Android.Resource.Attribute.ColorActivatedHighlight }).GetColor(0, Android.Graphics.Color.Gray);
						_pressed.SetColor(highlight);
						_pressed.SetCornerRadius(radius);

						// Add the drawables to a state list and assign the state list to the button
						var sld = new StateListDrawable();
						sld.AddState(new int[] { Android.Resource.Attribute.StatePressed }, _pressed);
						sld.AddState(new int[] { }, _normal);
	#pragma warning disable CS0618 // Type or member is obsolete
						Control.SetBackgroundDrawable(sld);
	#pragma warning restore CS0618 // Type or member is obsolete
					};
				}
				*/

			//if (view.ValBlack == true)
			//{

			//	Control.SetBackgroundResource(Resource.Xml.CmButtonXml);

			//}


		}
	}
}

