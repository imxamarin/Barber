using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;
using Google.Maps;
using System.Collections.Generic;
using MapKit;
using CoreLocation;
using System.Drawing;
using BarberShop;
using BarberShop.iOS;
using System.Collections.ObjectModel;
using Xamarin.Forms.Maps;

[assembly: ExportRenderer(typeof(CmMap), typeof(CmIMapRendrerer))]
namespace BarberShop.iOS
{
	public class CmIMapRendrerer : MapRenderer
	{
		
		ObservableCollection<Position> GotCords;
		MKPolylineRenderer polylineRenderer;

		MapView ml;


		protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<Xamarin.Forms.View> e)
		{
			base.OnElementChanged(e);
	
			if (e.OldElement != null)
			{
				var nativeMap = Control as MKMapView;
				nativeMap.OverlayRenderer = null;

			}

			if (e.NewElement != null)
			{
				var formsMap = (CmMap)e.NewElement;
				var nativeMap = Control as MKMapView;
		


				GotCords = new ObservableCollection<Position>();

				foreach (var io in formsMap.PolyPointer)
				{
					GotCords.Add(new Position(io.Latitude, io.Longitude));
				}

				nativeMap.OverlayRenderer = GetOverlayRenderer;

				CLLocationCoordinate2D[] coords = new CLLocationCoordinate2D[GotCords.Count];

				int index = 0;
				foreach (var position in GotCords)
				{
					coords[index] = new CLLocationCoordinate2D(position.Latitude, position.Longitude);
					index++;
				}

				var routeOverlay = MKPolyline.FromCoordinates(coords);
				nativeMap.AddOverlay(routeOverlay);
			
			}

		}

	

	MKOverlayRenderer GetOverlayRenderer(MKMapView mapView, IMKOverlay overlay)
	{
		if (polylineRenderer == null)
		{
			polylineRenderer = new MKPolylineRenderer(overlay as MKPolyline);
				polylineRenderer.FillColor = UIKit.UIColor.DarkGray;
				polylineRenderer.StrokeColor =  UIKit.UIColor.Blue;
			polylineRenderer.LineWidth = 3;
			polylineRenderer.Alpha = 0.4f;
		}
		return polylineRenderer;
	}


	}
}

