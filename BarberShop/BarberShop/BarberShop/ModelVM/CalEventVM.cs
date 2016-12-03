using GalaSoft.MvvmLight;
using InstaBiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBiz.PCL.ModelVM
{
    public class CalEventVM : ObservableObject
    {
        CalEvent tag = null;
        public CalEvent Tag
        {
            get { return tag; }

            set { tag = value; this.RaisePropertyChanged("Tag"); }
        }

        string permissions;
        public string Permissions
        {
            get { return permissions; }
            set
            {
                permissions = value;
                RaisePropertyChanged("Permissions");
            }
        }

        string message = null;
        public string Message
        {
            get { return message; }

            set { message = value; this.RaisePropertyChanged("Message"); }
        }

        string location = null;
        public string Location
        {
            get { return location; }

            set { location = value; this.RaisePropertyChanged("Location"); }
        }
    }
}
