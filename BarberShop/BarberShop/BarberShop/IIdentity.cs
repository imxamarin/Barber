using Barbershop.PCL.Types;
using BarberShop.Model;
using BarberShop.Services;
using InstaBiz.Model;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop
{
    public interface IIdentity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">Type of Authentication provider</param>
        /// <param name="context">Used for Android development, send "this"</param>
        /// <param name="login"></param>
        /// <returns></returns>
        /// 

        //AppStatus AppStatus { get; set; }
        //StorageFolder DocumentStorage { get; set; }
        string Platform { get; }
        AuthenticationType AuthenticationType { get; set; }

        Task<MobileServiceUser> Authenticate(string type, object context = null, bool login = true);
        //Task<bool> Login();
        void StoreCredentials(string id = "", string accessToken = "", string dir = "");
        void SetAsDefaultCredentials();
        void CheckCredentials();
        Task<MobileServiceUser> GetCredentials(string path);

        Task<Users> GetCachedUser();

        void ClearCredentials();
        Task<object> InitFacebook();

        string GetVersion();

        Task<VersionInfo> CheckForUpdates();
        string[] FileTypes { get; set; }
        Users User { get; set; }

        CompanyUser CompanyUser { get; set; }

        Company Company { get; set; }

        MobileServiceUser AzureUser
        {
            get;
            set;
        }

        //LiveConnectClient LiveClient { get; set; }

        AzureMobileServices Azure { get; set; }
        string CalendarID { get; set; }

        //Task<LiveLoginResult> ConnectToLive(LiveAuthClient liveIdClient = null);


        //AzureMobileServicesDotNet Azure { get; set; }





    }
}
