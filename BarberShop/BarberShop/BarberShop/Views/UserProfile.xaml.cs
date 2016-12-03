using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BarberShop
{
	public partial class UserProfile : ContentPage
	{


		public UserProfileViewModel vm {
			get { return this.BindingContext as UserProfileViewModel; }
		}
		public UserProfile ()
		{
			BindingContext = App.Locator.USSR;
			App.Locator.USSR.Navigation = Navigation;
			InitializeComponent ();
		}
	}
}
