using System;
using BarberShop;
using BarberShop.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.App;
using Xamarin.Auth;
using System.Json;

[assembly: ExportRenderer (typeof (FaceBookPage), typeof (FacebookPageRenderer))]
namespace BarberShop.Droid
{
	public class FacebookPageRenderer : PageRenderer
	{
		public FacebookPageRenderer ()
		{

			var activity = this.Context as Activity;
			var auth = new OAuth2Authenticator (
				clientId: "1700808443582152",
				scope: "",
				authorizeUrl: new Uri ("https://m.facebook.com/dialog/oauth/"),
				redirectUrl: new Uri ("http://www.facebook.com/connect/login_success.html")
			);


			auth.Completed += async (sender, e) => {
				if (e.IsAuthenticated) {
					var accessToken = e.Account.Properties ["access_token"].ToString ();
					var expiresIn = Convert.ToDouble (e.Account.Properties);
					var expiryDate = DateTime.Now + TimeSpan.FromSeconds (expiresIn);

					var request = new OAuth2Request ("GET", new Uri ("https://graph.facebook.com/me"), null, e.Account);
					var responce = await request.GetResponseAsync ();
					var obj = JsonObject.Parse (responce.GetResponseText ());

					var id = obj ["id"].ToString ().Replace ("\"", "");
					var name = obj ["name"].ToString ().Replace ("\"", "");
					App.NavigateToProfile (string.Format ("Ola{0}", name));
				} else {
					App.NavigateToProfile ("Determine");
				}

			};

			activity.StartActivity (auth.GetUI (activity));
		}
	}
}
