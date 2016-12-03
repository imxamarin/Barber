using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BarberShop
{
	public partial class ServicesOffer : ContentPage
	{
		public ServiceOfferViewModel vm {
			get { return this.BindingContext as ServiceOfferViewModel; }
		}

		public ServicesOffer ()
		{
			this.BindingContext = App.Locator.ServiceOffer;
			App.Locator.ServiceOffer.Navigation = Navigation;
			InitializeComponent ();

		}


		void Handle_ItemSelected (object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{

			Navigation.PushAsync (new AppointmentCalender (), false);

		}


		//async void Click_Button(object sender, EventArgs e)
		//{
		//    await vm.LoadServices();
		//}

	}
}
