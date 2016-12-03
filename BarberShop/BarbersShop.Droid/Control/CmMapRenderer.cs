using System;
using System.Collections.ObjectModel;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using BarberShop;
using BarberShop.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof (CmMap), typeof (CmMapRenderer))]
namespace BarberShop.Droid
{
	public class CmMapRenderer : MapRenderer, IOnMapReadyCallback
	{


		GoogleMap map;
		ObservableCollection<Position> GotCords;



		//   protected override void OnElementChanged(ElementChangedEventArgs<View> e)
		protected override void OnElementChanged (ElementChangedEventArgs<Map> e)
		{

			base.OnElementChanged (e);


			if (e.OldElement != null) {


			}

			if (e.NewElement != null) {
				var formsMap = (CmMap)e.NewElement;

				GotCords = new ObservableCollection<Position> ();

				foreach (var io in formsMap.PolyPointer) {
					GotCords.Add (new Position (io.Latitude, io.Longitude));
				}



				((MapView)Control).GetMapAsync (this);
			}



		}



		public void OnMapReady (GoogleMap googleMap)
		{
			map = googleMap;

			var polylineOptions = new PolylineOptions ();
			polylineOptions.InvokeColor (Android.Graphics.Color.Aqua);


			foreach (var position in GotCords) {
				polylineOptions.Add (new LatLng (position.Latitude, position.Longitude));
			}

			Console.WriteLine (polylineOptions.ToString ());
			map.AddPolyline (polylineOptions);
		}



	}
}

