using InstaBiz.Model;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBiz.PCL.ModelVM
{
    public class ClientVM : BaseVM
    {
        int clientNumber;
        public int ClientNumber
        {
            get { return clientNumber; }
            set
            {
                clientNumber = value;
                //RaisePropertyChanged("SecondaryName");
            }
        }



        string secondaryname;
        public string SecondaryName
        {
            get { return secondaryname; }
            set
            {
                secondaryname = value;
                //RaisePropertyChanged("SecondaryName");
            }
        }

        string company;
        public string Company
        {
            get { return company; }
            set
            {
                company = value;
                //RaisePropertyChanged("Company");
            }
        }

        string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                //RaisePropertyChanged("Company");
            }
        }

        string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                //RaisePropertyChanged("Company");
            }
        }

        string mobilePhone;
        public string MobilePhone
        {
            get { return mobilePhone; }
            set
            {
                mobilePhone = value;
                //RaisePropertyChanged("Company");
            }
        }

        string businessPhone;
        public string BusinessPhone
        {
            get { return businessPhone; }
            set
            {
                businessPhone = value;
                //RaisePropertyChanged("Company");
            }
        }

        string homePhone;
        public string HomePhone
        {
            get { return homePhone; }
            set
            {
                homePhone = value;
                //RaisePropertyChanged("Company");
            }
        }



        string contact;
        public string Contact
        {
            get { return contact; }
            set
            {
                contact = value;
                //RaisePropertyChanged("Contact");
            }
        }

        string activejobs;
        public string ActiveJobs
        {
            get { return activejobs; }
            set
            {
                activejobs = value;
                //RaisePropertyChanged("ActiveJobs");
            }
        }

        string totalinvoiced;
        public string TotalInvoiced
        {
            get { return totalinvoiced; }
            set
            {
                totalinvoiced = value;
                //RaisePropertyChanged("TotalInvoiced");
            }
        }

        string totalpaid;
        public string TotalPaid
        {
            get { return totalpaid; }
            set
            {
                totalpaid = value;
                //RaisePropertyChanged("TotalPaid");
            }
        }



        string balance;
        public string Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                //RaisePropertyChanged("Balance");
            }
        }


        string current;
        public string Current
        {
            get { return current; }
            set
            {
                current = value;
                //RaisePropertyChanged("Current");
            }
        }

        string z30;
        public string Z30
        {
            get { return z30; }
            set
            {
                z30 = value;
                //RaisePropertyChanged("Z30");
            }
        }

        string z60;
        public string Z60
        {
            get { return z60; }
            set
            {
                z60 = value;
                //RaisePropertyChanged("Z60");
            }
        }

        string z90;
        public string Z90
        {
            get { return z90; }
            set
            {
                z90 = value;
                //RaisePropertyChanged("Z90");
            }
        }

        string zplus;
        public string ZPlus
        {
            get { return zplus; }
            set
            {
                zplus = value;
                //RaisePropertyChanged("ZPlus");
            }
        }

        string uninvoiced;
        public string Uninvoiced
        {
            get { return uninvoiced; }
            set
            {
                uninvoiced = value;
                //RaisePropertyChanged("ZPlus");
            }
        }

        string lastsent;
        public string LastSent
        {
            get { return lastsent; }
            set
            {
                lastsent = value;
                //RaisePropertyChanged("LastSent");
            }
        }

        string nextstatement;
        public string NextStatement
        {
            get { return nextstatement; }
            set
            {
                nextstatement = value;
                //RaisePropertyChanged("NextStatement");
            }
        }

        string nextstatementdays;
        public string NextStatementDays
        {
            get { return nextstatementdays; }
            set
            {
                nextstatementdays = value;
                //RaisePropertyChanged("NextStatementDays");
            }
        }

        DateTime nextstatementdate;
        public DateTime NextStatementDate
        {
            get { return nextstatementdate; }
            set
            {
                nextstatementdate = value;
                //RaisePropertyChanged("NextStatementDate");
            }
        }

        string statementcolor;
        public string StatementColor
        {
            get { return statementcolor; }
            set
            {
                statementcolor = value;
                //RaisePropertyChanged("StatementColor");
            }
        }

        Client clienttag;
        public Client ClientTag
        {
            get { return clienttag; }
            set
            {
                clienttag = value;
                //RaisePropertyChanged("ClientTag");
            }
        }


    }
}
