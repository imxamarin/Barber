using InstaBiz.Model;


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace InstaBiz.PCL.ModelVM
{
    public class EmployeeVM : BaseVM
    {

        string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        string jobAddress;
        public string JobAddress
        {
            get { return jobAddress; }
            set
            {
                jobAddress = value;
                RaisePropertyChanged("JobAddress");
            }
        }


        string firstname;
        public string FirstName
        {
            get { return firstname; }
            set
            {
                firstname = value;
                RaisePropertyChanged("FirstName");
            }
        }

        string lastname;
        public string LastName
        {
            get { return lastname; }
            set
            {
                lastname = value;
                RaisePropertyChanged("LastName");
            }
        }

        string position;
        public string Position
        {
            get { return position; }
            set
            {
                position = value;
                RaisePropertyChanged("Position");
            }
        }

        string wage;
        public string Wage
        {
            get { return wage; }
            set
            {
                wage = value;
                RaisePropertyChanged("Wage");
            }
        }

        string contact;
        public string Contact
        {
            get { return contact; }
            set
            {
                contact = value;
                RaisePropertyChanged("Contact");
            }
        }



        DateTime? delayedpunchin;
        public DateTime? DelayedPunchin
        {
            get { return delayedpunchin; }
            set
            {
                delayedpunchin = value;
                RaisePropertyChanged("DelayedPunchin");
            }
        }





        bool needspunchin = false;
        public bool NeedsPunchIn
        {
            get { return needspunchin; }
            set
            {
                needspunchin = value;
                RaisePropertyChanged("NeedsPunchIn");
            }

        }
        Employee employeeTag;
        public Employee EmployeeTag
        {
            get { return employeeTag; }
            set
            {
                employeeTag = value;
                RaisePropertyChanged("EmployeeTag");
            }
        }

        List<EmployeeVM> emptags;
        public List<EmployeeVM> EmpTags
        {
            get { return emptags; }
            set
            {
                emptags = value;
                RaisePropertyChanged("EmpTags");
            }
        }



        decimal regularhours;
        public decimal RegularHours
        {
            get { return regularhours; }
            set
            {
                regularhours = value;
                RaisePropertyChanged("RegularHours");
            }
        }

        decimal overtimehours;
        public decimal OvertimeHours
        {
            get { return overtimehours; }
            set
            {
                overtimehours = value;
                RaisePropertyChanged("OvertimeHours");
            }
        }

        decimal regularpay;
        public decimal RegularPay
        {
            get { return regularpay; }
            set
            {
                regularpay = value;
                RaisePropertyChanged("RegularPay");
            }
        }

        decimal overtimepay;
        public decimal OvertimePay
        {
            get { return overtimepay; }
            set
            {
                overtimepay = value;
                RaisePropertyChanged("OvertimePay");
            }
        }

       

        string lifetime;
        public string LifeTime
        {
            get { return lifetime; }
            set
            {
                lifetime = value;
                RaisePropertyChanged("LifeTime");
            }
        }

        string yeartodate;
        public string YearToDate
        {
            get { return yeartodate; }
            set
            {
                yeartodate = value;
                RaisePropertyChanged("YearToDate");
            }
        }

        string unpaid;
        public string Unpaid
        {
            get { return unpaid; }
            set
            {
                unpaid = value;
                RaisePropertyChanged("Unpaid");
            }
        }
        public List<EmployeeVM> EmployeeTags { get; internal set; }



    }
}
