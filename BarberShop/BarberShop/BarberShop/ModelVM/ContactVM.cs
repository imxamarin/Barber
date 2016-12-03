using GalaSoft.MvvmLight;
using InstaBiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBiz.PCL.ModelVM
{
    public class ContactVM: BaseVM
    {
        string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                //RaisePropertyChanged("Name");
            }
        }

        string jobtitle;
        public string JobTitle
        {
            get { return jobtitle; }
            set
            {
                jobtitle = value;
                //RaisePropertyChanged("JobTitle");
            }
        }

        string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                //RaisePropertyChanged("Phone");
            }
        }

        string altPhone;
        public string AltPhone
        {
            get { return altPhone; }
            set
            {
                altPhone = value;
                //RaisePropertyChanged("Phone");
            }
        }

        string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                //RaisePropertyChanged("Email");
            }
        }

        string info;
        public string Info
        {
            get { return info; }
            set
            {
                info = value;
                //RaisePropertyChanged("Info");
            }
        }

        string icon;
        public string Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                //RaisePropertyChanged("Icon");
            }
        }

        bool ischecked = false;
        public bool isChecked
        {
            get { return ischecked; }
            set
            {
                ischecked = value;
                //RaisePropertyChanged("isChecked");
            }
        }

        //Visibility editbutton;
        //public Visibility EditButton
        //{
        //    get { return editbutton; }
        //    set
        //    {
        //        editbutton = value;
        //        RaisePropertyChanged("EditButton");
        //    }
        //}

        Contact contacttag;
        public Contact ContactTag
        {
            get { return contacttag; }
            set
            {
                contacttag = value;
                //RaisePropertyChanged("ContactTag");
            }
        }

        public List<string> GetNumbers()
        {
            var list = new List<string>();
            if (!String.IsNullOrEmpty(ContactTag.Phone))
                list.Add(ContactTag.Phone);
            if (!String.IsNullOrEmpty(ContactTag.AltPhone))
                list.Add(ContactTag.AltPhone);

            return list;
        }
    }
}
