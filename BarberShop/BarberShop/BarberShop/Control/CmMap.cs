using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms.Maps;

namespace BarberShop
{
	public class CmMap : Map
	{
		public ObservableCollection<Position> PolyPointer
		{
			get;
			set;
		}

		public CmMap(ObservableCollection<Position> PolyPoint)
		{

			PolyPointer = new ObservableCollection<Position>();


			foreach (var item in PolyPoint)
			{
				PolyPointer.Add(item);
			}


		}

	}
}
