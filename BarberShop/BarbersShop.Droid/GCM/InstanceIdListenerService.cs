using System;
using Android.App;
using Android.Content;
using Android.Gms.Gcm.Iid;

namespace BarberShop.Droid
{
    [Service(Exported = false), IntentFilter(new[] { "com.google.android.gms.iid.InstanceID" })]
    public class InstanceIdListenerService : InstanceIDListenerService
    {
        public override void OnTokenRefresh()
        {
            var intent = new Intent(this, typeof(RegistrationIntentService));
            StartService(intent);
        }
    }
}