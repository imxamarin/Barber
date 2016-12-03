using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarberShop
{
	public partial class Profile : ContentPage
	{
		public Profile (string message)
		{
			InitializeComponent ();
			this.LoadFromXaml (typeof (Profile));
			lblmessage.Text = message;
		}
	}
}
