using System;
using Xamarin.Forms;

namespace BarberShop
{
	public class CmSideBar
	{
		public string Tile { get; set; }

		public ImageSource log { get; set; }

		public Type TargetType { get; set; }

		public CmSideBar(ImageSource Log, string tile,Type targetType)
		{
			Tile = tile;
			log = Log;
			TargetType = targetType;
		}
		public override string ToString()
		{
			return Tile;
		}
	}
}
