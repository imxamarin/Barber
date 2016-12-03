using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DLToolkit.Forms.Controls;
using FFImageLoading.Forms;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace BarberShop
{
	public class GalleryPlus : ContentPage
	{

		const string keys = Constants.InstagramKey;
		#region Variables
		ObservableCollection<string> images = new ObservableCollection<string> ();
		ObservableCollection<ItemModel> List;

		ProgressBar pb;
		public bool boolVisible {
			get;
			set;
		}
		public bool boolRunning {
			get;
			set;
		}

		#endregion

		async Task<bool> AlphaPhase ()
		{
			try {
				RootObject rootobject = new RootObject ();
				var client = new System.Net.Http.HttpClient ();
				string Jsonstr = string.Format ("https://api.instagram.com/v1/users/self/media/recent?access_token={0}", keys);
				var response = await client.GetAsync (Jsonstr);
				var earthquakesJson = response.Content.ReadAsStringAsync ().Result;
				rootobject = JsonConvert.DeserializeObject<RootObject> (earthquakesJson);
				await pb.ProgressTo (.5, 250, Easing.Linear);
				foreach (var item in rootobject.data) {
					images.Add (item.images.low_resolution.url);
				}
				if (images.Count > 0) {
					await pb.ProgressTo (.6, 250, Easing.Linear);
					return true;
				} else {
					await pb.ProgressTo (.99, 250, Easing.Linear);
					return false;
				}

			} catch (Exception ex) {
				return false;
			}
		}

		async void BetaPhase ()
		{
			try {
				await pb.ProgressTo (.4, 250, Easing.Linear);
				var result = await AlphaPhase ();
				if (result.Equals (true)) {
					int number = 0;
					//	for (int n = 0; n < 20; n++) {
					for (int i = 0; i < images.Count; i++) {
						number++;
						var item = new ItemModel () {
							ImageUrl = images [i],
							FileName = string.Format ("image_{0}.jpg", number),
						};

						List.Add (item);
						//	}
					}

					await pb.ProgressTo (.7, 250, Easing.Linear);

				}
			} catch (Exception ex) {
				await Navigation.PushModalAsync (new NavigationPage (new DefaultExPage (ex)));
			}

		}



		public GalleryPlus ()
		{
			try {
				List = new ObservableCollection<ItemModel> ();
				Image imge = new Image { Source = "gallery_iamge.png", Aspect = Aspect.AspectFill };

				pb = new ProgressBar { IsVisible = true, IsEnabled = true, Progress = .2 };

				//		StackLayout sco = new StackLayout ();
				FlowListView listView = new FlowListView () {
					FlowColumnTemplate = new DataTemplate (typeof (ListCell)),
					SeparatorVisibility = SeparatorVisibility.None,
					HasUnevenRows = true,
					FlowColumnMinWidth = 110,
					FlowItemsSource = List,
				};
				listView.FlowItemTapped += (s, e) => {
					var item = (ItemModel)e.Item;
					if (item != null) {
						Navigation.PushAsync (new GallaryImage () { Title = "Instagram" }, false);
					}
				};

				Content = new StackLayout {
					Children = {

					imge,
					pb,
				   listView
				}
				};
				BetaPhase ();
			} catch (Exception ex) {
				Navigation.PushModalAsync (new NavigationPage (new DefaultExPage (ex)));
			}



		}
		public class ItemModel
		{
			public string ImageUrl { get; set; }
			public string FileName { get; set; }

		}
		public class ListCell : ContentView
		{
			public ListCell ()
			{
				CachedImage IconImage = new CachedImage {
					HeightRequest = 100,
					Aspect = Aspect.Fill,
					DownsampleHeight = 100,
					DownsampleUseDipUnits = false,

				};
				IconImage.SetBinding (CachedImage.SourceProperty, "ImageUrl");
				Grid grd = new Grid {
					Padding = 3,
					ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
				},
					RowDefinitions = {
					new RowDefinition { Height=GridLength.Star},
				},
				};
				grd.Children.Add (IconImage, 0, 0);

				Content = grd;
			}
		}


	}
}


