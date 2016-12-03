using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Windows.Input;

namespace BarberShop
{
	public class GalleryViewModel : ViewModelBase
	{
		public class ItemModel
		{
			public string ImageUrl { get; set; }
			public string FileName { get; set; }

		}
		ObservableCollection<object> items;
		public ObservableCollection<object> Items {
			get { return items; }
			set {
				items = value;
				RaisePropertyChanged ("Items");

			}
		}

		const string keys = "3933956838.ba4c844.92abf83359364a69a2d7b2e9d815eb9a";
		ObservableCollection<string> images { get; set; }
		ObservableCollection<ItemModel> List { get; set; }


		public ObservableCollection<InstaImage> ListImg { get; set; }


		ObservableCollection<Object> thor { get; set; }

		public ObservableCollection<ImageSource> ImgSrc { get; set; }

		private bool statusOk;
		private bool statOk;
		private ImageSource imgA;
		private ImageSource imgB;
		private ImageSource imgC;
		private ImageSource imgD;
		private ImageSource imgE;
		private ImageSource imgF;

		INavigation navigation;
		ICommand tapCommand;
		public ImageSource ImgA {
			get {
				return imgA;
			}

			set {
				imgA = value;
				RaisePropertyChanged ("ImgA");

			}
		}

		private TapGestureRecognizer callingThis;

		public bool StatusOk {
			get {
				return statusOk;
			}

			set {
				statusOk = value;
				RaisePropertyChanged ("StatusOk");
			}
		}

		public TapGestureRecognizer CallingThis {
			get {
				return callingThis;
			}

			set {
				callingThis = value;
				RaisePropertyChanged ("CallingThis");
			}
		}

		public ImageSource ImgB {
			get {
				return imgB;
			}

			set {
				imgB = value;
				RaisePropertyChanged ("ImgB");
			}
		}

		public ImageSource ImgC {
			get {
				return imgC;
			}

			set {
				imgC = value;
				RaisePropertyChanged ("ImgC");
			}
		}

		public ImageSource ImgD {
			get {
				return imgD;
			}

			set {
				imgD = value;
				RaisePropertyChanged ("ImgD");
			}
		}

		public ImageSource ImgE {
			get {
				return imgE;
			}

			set {
				imgE = value;
				RaisePropertyChanged ("ImgE");
			}
		}

		public ImageSource ImgF {
			get {
				return imgF;
			}

			set {
				imgF = value;
				RaisePropertyChanged ("ImgF");
			}
		}

		public INavigation Navigation {
			get {
				return navigation;
			}

			set {
				navigation = value;
			}
		}

		public ICommand TapCommand {
			get {
				return tapCommand;
			}

			set {
				tapCommand = value;
			}
		}

		public bool StatOk {
			get {
				return statOk;
			}

			set {
				statOk = value;
				RaisePropertyChanged ("StatOk");
			}
		}



		async Task<bool> AlphaPhase ()
		{

			RootObject rootobject = new RootObject ();
			var client = new System.Net.Http.HttpClient ();
			string Jsonstr = string.Format ("https://api.instagram.com/v1/users/self/media/recent?access_token={0}", keys);
			var response = await client.GetAsync (Jsonstr);
			var earthquakesJson = response.Content.ReadAsStringAsync ().Result;
			rootobject = JsonConvert.DeserializeObject<RootObject> (earthquakesJson);
			foreach (var item in rootobject.data) {
				images.Add (item.images.low_resolution.url);
			}
			response.Dispose ();

			if (images.Count > 0) {
				return true;
			} else {
				return false;
			}
		}

		async void BetaPhase ()
		{

			var result = await AlphaPhase ();
			if (result.Equals (true)) {
				int number = 0;
				for (int n = 0; n < 20; n++) {
					for (int i = 0; i < images.Count; i++) {
						number++;
						var item = new ItemModel () {
							ImageUrl = images [i],
							FileName = string.Format ("image_{0}.jpg", number),
						};


						List.Add (item);
					}
				}
				StatusOk = false;
				StatOk = false;
				RaisePropertyChanged ("StatusOk");
				RaisePropertyChanged ("StatOk");
			}
		}


		public GalleryViewModel ()
		{
			StatusOk = true;
			StatOk = true;
			//thor = new ObservableCollection<object> ();
			//thor.Add (new Image { Source = "back.png" });
			//thor.Add (new Image { Source = "cancel.png" });
			//thor.Add (new Image { Source = "cut.png" });
			//thor.Add (new Image { Source = "etc1.png" });
			//thor.Add (new Image { Source = "etc2.png" });
			//ImgSrc = new ObservableCollection<ImageSource> ();
			////	GetInstagramFeed();
			//CallthisMethodForInstaGram ();
			images = new ObservableCollection<string> ();
			List = new ObservableCollection<ItemModel> ();
			BetaPhase ();
			TapCommand = new Command (Jumphere);

		}

		async void Jumphere ()
		{
			await Navigation.PushAsync (new GallaryImage () { Title = "Instagram" }, false);
		}


		async void GetInstagramFeed ()
		{
			RootObject rootobject = new RootObject ();
			var client = new System.Net.Http.HttpClient ();
			var response = await client.GetAsync ("https://www.instagram.com/tomsbarbershop/media/");

			var json = response.Content.ReadAsStringAsync ().Result;

			var obj = JsonConvert.DeserializeObject<RootObject> (json);

			List<string> ImageUris = new List<string> ();

			foreach (var item in obj.items) {
				ImageUris.Add (item.images.low_resolution.url);
			}



			int row = 0;
			int col = 0;
			int total = ImageUris.Count;

			Items = new ObservableCollection<object> ();
			TapGestureRecognizer cmd = new TapGestureRecognizer ();
			cmd.Command = TapCommand;
			foreach (var uri in ImageUris) {
				Items.Add (new ImageObject (uri));
			}
		}


		async void CallthisMethodForInstaGram ()
		{
			RootObject rootobject = new RootObject ();
			var client = new System.Net.Http.HttpClient ();
			string Jsonstr = string.Format ("https://api.instagram.com/v1/users/self/media/recent?access_token={0}", keys);
			var response = await client.GetAsync (Jsonstr);

			var earthquakesJson = response.Content.ReadAsStringAsync ().Result;
			rootobject = JsonConvert.DeserializeObject<RootObject> (earthquakesJson);


			List<string> PolyPointer = new List<string> ();


			foreach (var item in rootobject.data) {

				PolyPointer.Add (item.images.low_resolution.url);
			}


			foreach (var utem in PolyPointer) {

				ImgSrc.Add (utem);
			}

			ImgA = ImgSrc [0];
			ImgB = ImgSrc [1];
			ImgC = ImgSrc [2];
			ImgD = ImgSrc [3];
			ImgE = ImgSrc [4];
			ImgF = ImgSrc [5];
			response.Dispose ();
			StatusOk = false;
			StatOk = false;

			RaisePropertyChanged ("StatOk");
			RaisePropertyChanged ("StatusOk");
			RaisePropertyChanged ("ImgA");
			RaisePropertyChanged ("ImgB");
			RaisePropertyChanged ("ImgC");
			RaisePropertyChanged ("ImgD");
			RaisePropertyChanged ("ImgE");
			RaisePropertyChanged ("ImgF");


		}
	}

	public class ImageObject : ObservableObject
	{
		string url;
		public string Url {
			get { return url; }
			set {
				url = value;
				RaisePropertyChanged ("Url");
			}
		}

		public ImageObject (string url)
		{
			Url = url;
		}
	}
}
