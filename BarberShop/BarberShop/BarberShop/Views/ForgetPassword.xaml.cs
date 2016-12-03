using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BarberShop
{
	public partial class ForgetPassword : ContentPage
	{

		public ForgetPasswordViewModel vm {
			get { return this.BindingContext as ForgetPasswordViewModel; }
		}
		public ForgetPassword ()
		{
			this.BindingContext = App.Locator.ForgetPassword;
			App.Locator.ForgetPassword.Navigation = Navigation;
			InitializeComponent ();
		}
	}
}
