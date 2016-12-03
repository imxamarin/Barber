using System;
using Xamarin.Forms;
namespace BarberShop
{
	public class DefaultExPage : ContentPage
	{
		public DefaultExPage (Exception e)
		{
			var MainLayout = new StackLayout ();
			var LabelAlpha = new Label { Text = "Opps Something went Wrong" };
			var LabelBeta = new Label { Text = String.Format ($"{e.Message}") };

			MainLayout.Children.Add (LabelBeta);
			MainLayout.Children.Add (LabelAlpha);
			Content = MainLayout;


		}
	}
}
