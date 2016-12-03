using InstaBiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBiz.PCL.ModelVM
{
    public class CompanyVM
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

       

        bool isselected;
        public bool isSelected
        {
            get { return isselected; }
            set
            {
                isselected = value;
                //RaisePropertyChanged("isSelected");
            }
        }

        bool isselected2;
        public bool isSelected2
        {
            get { return isselected2; }
            set
            {
                isselected2 = value;
                //RaisePropertyChanged("isSelected2");
            }
        }

        bool ispending;
        public bool isPending
        {
            get { return ispending; }
            set
            {
                ispending = value;
                //RaisePropertyChanged("isPending");
            }
        }

        Company tag;
        public Company Tag
        {
            get { return tag; }
            set
            {
                tag = value;
                //RaisePropertyChanged("Tag");
            }
        }



        CompanyUser companyusertag;
        public CompanyUser CompanyUserTag
        {
            get { return companyusertag; }
            set
            {
                companyusertag = value;
                //RaisePropertyChanged("CompanyUserTag");
            }
        }
    }
}
