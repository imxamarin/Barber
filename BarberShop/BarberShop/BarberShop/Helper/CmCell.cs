using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace BarberShop
{
	public class CmCell
	{


        public String Treatments { get; set; }

		public decimal Price { get; set; }

		public ImageSource Logo { get; set; }

		public String Dollar { get; set; }

		public String Datepick { get; set; }

		public String Timepick { get; set; }

		public bool statusCode { get; set; }

		public ICommand Command { get; set; }

	}
}
