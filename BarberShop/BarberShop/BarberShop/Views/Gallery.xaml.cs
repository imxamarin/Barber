
using BarberShop.ViewModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLToolkit.Forms.Controls;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace BarberShop
{
	public partial class Gallery : ContentPage
	{
		public GalleryViewModel vm {
			get { return this.BindingContext as GalleryViewModel; }
		}
		//	public ObservableCollection<ImageSource> ImgSrc { get; set; }
		public Gallery ()
		{
			this.BindingContext = App.Locator.Gallery;
			App.Locator.Gallery.Navigation = Navigation;
			InitializeComponent ();


			// GetInstagramFeed();
		}
		/*

        async void GetInstagramFeed()
        {
            RootObject rootobject = new RootObject();
            var client = new System.Net.Http.HttpClient();
            var response = await client.GetAsync("https://www.instagram.com/tomsbarbershop/media/");

            var json = response.Content.ReadAsStringAsync().Result;

            var obj = JsonConvert.DeserializeObject<RootObject>(json);

            List<string> ImageUris = new List<string>();

            foreach (var item in obj.items)
            {
                ImageUris.Add(item.images.low_resolution.url);
            }



            int row = 0;
            int col = 0;
            int total = ImageUris.Count;

            TapGestureRecognizer cmd = new TapGestureRecognizer();
            cmd.Command = vm.TapCommand;
            foreach (var uri in ImageUris)
            {
                Image img = new Image();
                img.Source = uri;
                img.GestureRecognizers.Add(cmd);
                
                
            }





            //foreach (var utem in ImageUris)
            //{
            //    ImgSrc.Add(utem);
            //}





            //ImgA = ImgSrc[0];
            //ImgB = ImgSrc[1];
            //ImgC = ImgSrc[2];
            //ImgD = ImgSrc[3];
            //ImgE = ImgSrc[4];
            //ImgF = ImgSrc[5];
            //response.Dispose();
            //StatusOk = false;
            //StatOk = false;

            //RaisePropertyChanged("StatOk");
            //RaisePropertyChanged("StatusOk");
            //RaisePropertyChanged("ImgA");
            //RaisePropertyChanged("ImgB");
            //RaisePropertyChanged("ImgC");
            //RaisePropertyChanged("ImgD");
            //RaisePropertyChanged("ImgE");
            //RaisePropertyChanged("ImgF");
        }


*/
	}

}
