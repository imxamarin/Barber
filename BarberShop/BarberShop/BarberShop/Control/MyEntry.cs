using Xamarin.Forms;
namespace BarberShop
{
	public class MyEntry:Entry
	{
		public string bgImage { get; set; }

		public static readonly BindableProperty FontProperty =
			BindableProperty.Create("Font", typeof(Font), typeof(MyEntry), new Font());


		public static readonly BindableProperty XAlignProperty =
			BindableProperty.Create("XAlign", typeof(TextAlignment), typeof(MyEntry),
				TextAlignment.Start);

		public static readonly BindableProperty HasBorderProperty =
			BindableProperty.Create("HasBorder", typeof(bool), typeof(MyEntry), false);

		public static readonly BindableProperty HasLeftImageProperty =
			BindableProperty.Create("LeftImage", typeof(string), typeof(MyEntry), string.Empty);


		public static readonly BindableProperty PlaceholderTextColorProperty =
			BindableProperty.Create("PlaceholderTextColor", typeof(Color), typeof(MyEntry), Color.Default);

		public static readonly BindableProperty MaxLengthProperty =
			BindableProperty.Create("MaxLength", typeof(int), typeof(MyEntry), int.MaxValue);

		public int MaxLength
		{
			get { return (int)this.GetValue(MaxLengthProperty); }
			set { this.SetValue(MaxLengthProperty, value); }
		}

		public Font Font
		{
			get { return (Font)GetValue(FontProperty); }
			set { SetValue(FontProperty, value); }
		}

		public TextAlignment XAlign
		{
			get { return (TextAlignment)GetValue(XAlignProperty); }
			set { SetValue(XAlignProperty, value); }
		}

		public bool HasBorder
		{
			get { return (bool)GetValue(HasBorderProperty); }
			set { SetValue(HasBorderProperty, value); }
		}

		public string LeftImage
		{
			get { return (string)GetValue(HasLeftImageProperty); }
			set { SetValue(HasLeftImageProperty, value); }
		}

		public Color PlaceholderTextColor
		{
			get { return (Color)GetValue(PlaceholderTextColorProperty); }
			set { SetValue(PlaceholderTextColorProperty, value); }
		}

	}
}
