using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace BarberShop
{
	public class InstaViewModel : ViewModelBase
	{
		const string keys = Constants.InstagramKey;
		#region Variables
		private bool statusOk;
		private bool statOk;
		public ObservableCollection<InstaImage> ListImg { get; set; }

		private INavigation navigation;
		public INavigation Navigation {
			get {
				return navigation;
			}

			set {
				navigation = value;
				RaisePropertyChanged ("Navigation");
			}
		}

		public ImageSource ImgA {
			get {
				return imgA;
			}

			set {
				imgA = value;
			}
		}

		public ImageSource ImgB {
			get {
				return imgB;
			}

			set {
				imgB = value;
			}
		}

		public ImageSource ImgC {
			get {
				return imgC;
			}

			set {
				imgC = value;
			}
		}

		public ImageSource ImgD {
			get {
				return imgD;
			}

			set {
				imgD = value;
			}
		}

		public ImageSource ImgE {
			get {
				return imgE;
			}

			set {
				imgE = value;
			}
		}

		public ImageSource ImgF {
			get {
				return imgF;
			}

			set {
				imgF = value;
			}
		}

		public bool StatueOk {
			get {
				return statusOk;
			}

			set {
				statusOk = value;
				RaisePropertyChanged ("StatueOk");
			}
		}

		public bool StateOk {
			get {
				return statOk;
			}

			set {
				statOk = value;
				RaisePropertyChanged ("StateOk");
			}
		}

		private ImageSource imgA;
		private ImageSource imgB;
		private ImageSource imgC;
		private ImageSource imgD;
		private ImageSource imgE;
		private ImageSource imgF;
		#endregion
		public InstaViewModel ()
		{
			StatueOk = true;
			StateOk = true;
			ListImg = new ObservableCollection<InstaImage> ();
			CallthisMethodForInstaGram ();
			//CreateDownloadTask();
		}

		#region StartDownloadTask Alternative
		public async Task<ObservableCollection<InstaImage>> CreateDownloadTask ()
		{

			RootObject rootobject = new RootObject ();
			HttpClient client = new HttpClient ();
			string Jsonstr = string.Format ("https://api.instagram.com/v1/users/self/media/recent?access_token={0}", keys);
			var response = await client.GetAsync (Jsonstr);
			var earthquakesJson = response.Content.ReadAsStringAsync ().Result;
			rootobject = JsonConvert.DeserializeObject<RootObject> (earthquakesJson);
			foreach (var item in rootobject.data) {
				ListImg.Add (new InstaImage { InstaSource = item.images.standard_resolution.url });
			}
			response.Dispose ();
			return ListImg;


		}
		#endregion

		#region Geting & Showing The Pictures
		async void CallthisMethodForInstaGram ()
		{
			try {
				RootObject rootobject = new RootObject ();
				var client = new System.Net.Http.HttpClient ();
				string Jsonstr = string.Format ("https://api.instagram.com/v1/users/self/media/recent?access_token={0}", keys);
				var response = await client.GetAsync (Jsonstr);

				var earthquakesJson = response.Content.ReadAsStringAsync ().Result;
				rootobject = JsonConvert.DeserializeObject<RootObject> (earthquakesJson);

				foreach (var item in rootobject.data) {
					ListImg.Add (new InstaImage { InstaSource = item.images.standard_resolution.url });
				}
				response.Dispose ();
				StatueOk = false;
				StateOk = false;
				RaisePropertyChanged ("StateOk");
				RaisePropertyChanged ("StatueOk");
				RaisePropertyChanged ("ImgA");
				RaisePropertyChanged ("ImgB");
				RaisePropertyChanged ("ImgC");
				RaisePropertyChanged ("ImgD");
				RaisePropertyChanged ("ImgE");
				RaisePropertyChanged ("ImgF");
			} catch (Exception ex) {
				await Navigation.PushModalAsync (new NavigationPage (new DefaultExPage (ex)));
			}

		}
		#endregion
	}
}
