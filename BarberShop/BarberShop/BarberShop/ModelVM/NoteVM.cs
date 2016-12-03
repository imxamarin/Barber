using GalaSoft.MvvmLight;
using InstaBiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBiz.PCL.ModelVM
{
    public class NoteVM : ObservableObject
    {
        string message = null;
        public string Message
        {
            get { return message; }

            set { message = value; this.RaisePropertyChanged("Message"); }
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

        //string userName;
        //public string UserName
        //{
        //    get { return userName; }
        //    set
        //    {
        //        userName = value;
        //        RaisePropertyChanged("UserName");
        //    }
        //}

        string cdatectime;
        public string CDateCTime
        {
            get { return cdatectime; }
            set
            {
                cdatectime = value;
                RaisePropertyChanged("CDateCTime");
            }
        }

        Note notetag = null;
        public Note NoteTag
        {
            get { return notetag; }

            set { notetag = value; this.RaisePropertyChanged("NoteTag"); }
        }
    }
}
