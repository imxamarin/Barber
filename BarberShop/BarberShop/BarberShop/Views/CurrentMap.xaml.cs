using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using BarberShop.ViewModel;

namespace BarberShop
{
	public partial class CurrentMap : ContentPage
	{

		public LocationAvaliableViewModel vm {

			get { return this.BindingContext as LocationAvaliableViewModel; }
		}

		public CurrentMap ()
		{
			this.BindingContext = App.Locator.LocationAvaliabe;
			App.Locator.LocationAvaliabe.Navigation = Navigation;
			InitializeComponent ();
			this.LoadFromXaml (typeof (CurrentMap));
			//const double ShopLat = Constants.ShopLatitute;
			//const double ShopLog = Constants.ShopLogitute;
			//Position shopAdd = new Position (ShopLat, ShopLog);

			//Pin pns = new Pin {
			//	Type = PinType.Place,
			//	Position = shopAdd,
			//	Label = " " + ShopLat + " , " + ShopLog
			//};

			//MyMap.MoveToRegion (MapSpan.FromCenterAndRadius (new Position (ShopLat, ShopLog), Xamarin.Forms.Maps.Distance.FromKilometers (10)));
			//MyMap.Pins.Add (pns);

		}

	}
}
