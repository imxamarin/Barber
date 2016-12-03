using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Gms.Gcm;
using Android.Util;
using BarberShop.Droid;
using Android;

namespace BarberShop.Droid
{
	[Service (Exported = false), IntentFilter (new [] { "com.google.android.c2dm.intent.RECEIVE" })]

	public class MyGcmListenerService : GcmListenerService
	{
		public override void OnMessageReceived (string from, Bundle data)
		{
			var message = data.GetString ("message");
			Log.Debug ("MyGcmListenerService", "From:    " + from);
			Log.Debug ("MyGcmListenerService", "Message: " + message);
			SendNotification (message);
		}

		void SendNotification (string message)
		{
			var intent = new Intent (this, typeof (MainActivity));
			intent.AddFlags (ActivityFlags.ClearTop);
			var pendingIntent = PendingIntent.GetActivity (this, 0, intent, PendingIntentFlags.OneShot);

			var notificationBuilder = new Notification.Builder (this)
													  .SetSmallIcon (Resource.Drawable.DarkHeader)
				.SetContentTitle ("Barber Discount")
				.SetContentText (message)
				  .SetAutoCancel (false)
				.SetContentIntent (pendingIntent);

			var notificationManager = (NotificationManager)GetSystemService (Context.NotificationService);
			notificationManager.Notify (0, notificationBuilder.Build ());
		}
	}
}