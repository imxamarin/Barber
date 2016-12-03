using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BarberShop
{
	public class RoutePage : ContentPage
	{

		ObservableCollection<Position> PolylinePoints;

		public RoutePage (ObservableCollection<Position> Polylinepoint, Position current, Position OfficePos)
		{

			if (Device.OS.Equals (TargetPlatform.iOS)) {
				NavigationPage.SetHasNavigationBar (this, true);
			}

			PolylinePoints = new ObservableCollection<Position> ();
			try {
				foreach (var item in Polylinepoint) {
					PolylinePoints.Add (item);
				}
				Pin usercurrent = new Pin {
					Type = PinType.Place,
					Position = current,
					Label = " " + current.Latitude + " , " + current.Longitude
				};

				Pin ShoperCurrent = new Pin {
					Type = PinType.Place,
					Position = OfficePos,
					Label = " " + OfficePos.Latitude + " , " + OfficePos.Longitude

				};
				this.Title = "Routing";
				var routeMap = new CmMap (PolylinePoints) {
					HeightRequest = Height,
					WidthRequest = Width,
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					MapType = MapType.Street

				};

				routeMap.Pins.Add (usercurrent);
				routeMap.Pins.Add (ShoperCurrent);


				routeMap.MoveToRegion (MapSpan.FromCenterAndRadius (new Position (current.Latitude, current.Longitude), Xamarin.Forms.Maps.Distance.FromKilometers (20)));
				Content = routeMap;
			} catch (Exception ex) {
				Navigation.PushModalAsync (new NavigationPage (new DefaultExPage (ex)));

			}





		}




	}
}
