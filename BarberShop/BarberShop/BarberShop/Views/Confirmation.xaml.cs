using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BarberShop
{
	public partial class Confirmation : ContentPage
	{

		public ConfirmationViewModel vm {
			get { return this.BindingContext as ConfirmationViewModel; }
		}

		public Confirmation ()
		{
			this.BindingContext = App.Locator.ConfirmPage;
			App.Locator.ConfirmPage.Navigation = Navigation;
			InitializeComponent ();
		}


	}
}
