using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BarberShop
{
	public partial class AppointmentCalender : ContentPage
	{
		public AppointmentCalenderViewModel vm {
			get { return this.BindingContext as AppointmentCalenderViewModel; }
		}
		public AppointmentCalender ()
		{
			this.BindingContext = App.Locator.BookAppointment;
			App.Locator.BookAppointment.Navigation = Navigation;
			InitializeComponent ();
		}
	}
}
