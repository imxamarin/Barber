using BarberShop;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BarberShop
{
	public partial class Appointment : ContentPage
	{
		public AppointmentViewModel vm {
			get { return this.BindingContext as AppointmentViewModel; }
		}

		public Appointment ()
		{
			//	NavigationPage.SetHasNavigationBar (this, false);
			this.BindingContext = App.Locator.HomePage;
			App.Locator.HomePage.Navigation = Navigation;
			InitializeComponent ();

		}





	}
}
