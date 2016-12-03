using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBiz.PCL.ModelVM
{
    public class ServiceAppointmentVM : BaseVM
    {
        string clientID;
        public string ClientID
        {
            get { return clientID; }
            set
            {
                clientID = value;
                //RaisePropertyChanged("Description"); 
            }
        }


    }
}
