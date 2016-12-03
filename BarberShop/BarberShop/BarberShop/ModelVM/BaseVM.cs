using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBiz.PCL.ModelVM
{
    public class BaseVM : ObservableObject
    {
        string id;
        public string Id
        {
            get { return id; }
            set { id = value; RaisePropertyChanged("Id"); }
        }

        string collectiontitle;
        public string CollectionTitle
        {
            get { return collectiontitle; }
            set { collectiontitle = value; RaisePropertyChanged("CollectionTitle"); }
        }

        string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged("Title");
            }
        }


        string subtitle;
        public string Subtitle
        {
            get { return subtitle; }
            set
            {
                subtitle = value;
                RaisePropertyChanged("Subtitle");
            }
        }


        string subtitle2;
        public string Subtitle2
        {
            get { return subtitle2; }
            set
            {
                subtitle2 = value;
                RaisePropertyChanged("Subtitle2");
            }
        }

        string subtitle3;
        public string Subtitle3
        {
            get { return subtitle3; }
            set
            {
                subtitle3 = value;
                RaisePropertyChanged("Subtitle3");
            }
        }

        string subtitle4;
        public string Subtitle4
        {
            get { return subtitle4; }
            set
            {
                subtitle4 = value;
                RaisePropertyChanged("Subtitle4");
            }
        }
        
    }
}
