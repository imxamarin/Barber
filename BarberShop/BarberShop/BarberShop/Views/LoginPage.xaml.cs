using BarberShop;
using BarberShop.ViewModel;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Linq;
namespace BarberShop
{
	public partial class LoginPage : ContentPage
	{
		public LoginPageViewModel vm {
			get { return this.BindingContext as LoginPageViewModel; }
		}

		public LoginPage ()
		{
			BindingContext = App.Locator.LoginPage;
			App.Locator.LoginPage.Navigation = Navigation;
			NavigationPage.SetHasNavigationBar (this, false);
			InitializeComponent ();
			this.LoadFromXaml (typeof (LoginPage));

		}


	}
}
