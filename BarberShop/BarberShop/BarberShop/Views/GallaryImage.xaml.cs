using System;
using System.Collections.Generic;
using BarberShop.ViewModel;
using Xamarin.Forms;

namespace BarberShop
{
	public partial class GallaryImage : ContentPage
	{
		public InstaViewModel vm {
			get { return this.BindingContext as InstaViewModel; }
		}
		public GallaryImage ()
		{
			this.BindingContext = App.Locator.InstaPage;
			App.Locator.InstaPage.Navigation = Navigation;
			InitializeComponent ();
		}
	}
}
