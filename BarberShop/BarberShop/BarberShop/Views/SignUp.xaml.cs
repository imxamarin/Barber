using System;
using System.Collections.Generic;
using BarberShop.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace BarberShop
{
	public partial class SignUp : ContentPage
	{
		public SignUpViewModel vm {
			get { return this.BindingContext as SignUpViewModel; }
		}
		public SignUp ()
		{
			BindingContext = App.Locator.SignUpPage;
			App.Locator.SignUpPage.Navigation = Navigation;
			InitializeComponent ();
			this.LoadFromXaml (typeof (SignUp));
		}
	}
}
