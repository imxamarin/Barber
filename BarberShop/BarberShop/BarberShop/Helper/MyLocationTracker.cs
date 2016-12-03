using System;
namespace BarberShop
{
	public interface MyLocationTracker
	{
		void ObtainMyLocation();
		event EventHandler<MyLocationEventArgs> locationObtained;

	}

	public interface MyLocationEventArgs
	{
		double lat { get; set; }
		double lng { get; set; }
	}
}
