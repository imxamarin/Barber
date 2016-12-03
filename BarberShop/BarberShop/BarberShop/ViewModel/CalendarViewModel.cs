using System;
using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace BarberShop
{
    public class CalenderViewModel : INotifyPropertyChanged
    {




        #region Variables
        public ICommand DateIChosse { get; set; }
        public ICommand AlphaBttn { get; set; }
        public ICommand BetaBttn { get; set; }
        public ICommand GammaBttn { get; set; }
        public ICommand BookBttn { get; set; }
        DateTime propertyMin;
        DateTime propertyMax;
        bool selectedBtn;
        private string DateOftheDay;
        private string today;
        public event PropertyChangedEventHandler PropertyChanged;
        private Nullable<DateTime> myDateTimeProperty = null;
        DateTime _myDate;
        private Color bgColor;
        private Color bgSeColor;

        #endregion

        public ObservableCollection<CmCell> ListBar { get; set; }
        #region Date Selected
        public DateTime MyDate
        {
            get { return _myDate; }
            set
            {
                _myDate = value;
                OnPropertyChange("MyDate");

            }
        }



        public Nullable<DateTime> MyDateTimeProperty
        {
            get
            {
                if (myDateTimeProperty == null)
                {
                    myDateTimeProperty = DateTime.Today;
                }
                return myDateTimeProperty;
            }
            set
            {
                myDateTimeProperty = value;
                OnPropertyChange("MyDateTimeProperty");
            }
        }



        public DateTime PropertyMin
        {
            get
            {
                return propertyMin;
            }

            set
            {
                propertyMin = value;
                OnPropertyChange("PropertyMin");
            }
        }



        public DateTime PropertyMax
        {
            get
            {
                return propertyMax;
            }

            set
            {
                propertyMax = value;
                OnPropertyChange("PropertyMax");
            }
        }





        public string DateofDay
        {

            get { return DateOftheDay; }
            set
            {

                DateOftheDay = value;
                OnPropertyChange("DateofDay");
            }
        }

        public string Today
        {

            get { return today; }
            set
            {

                today = value;
                OnPropertyChange("Today");
            }
        }
        #endregion






        public void OnPropertyChange(String pop)
        {

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pop));
            }
        }




        public CalenderViewModel()
        {
            DateofDay = DateTime.Now.ToDate();
            Today = DateTime.Now.DayOfWeek.ToString();
            PropertyMin = DateTime.Now;
            PropertyMax = DateTime.Now.AddMonths(1);
            DateIChosse = new Command(DoThisOnThat);

            ListBar = new ObservableCollection<CmCell> {

                new CmCell
                    {
                        Logo = "cut_line_up.png",
                        Price = 22,
                        Dollar = "$",
                        Treatments = "Cut"
                    }, new CmCell
                    {
                        Logo = "etc1.png",
                        Price = 27,
                        Dollar = "$",
                        Treatments = "Cut and Line"
                    }, new CmCell
                    {
                        Logo = "etc2.png",
                        Price = 35,
                        Dollar = "$",
                        Treatments = "Hot Towel Shave"
                    },
                    new CmCell
                    {
                        Logo = "etc3.png",
                        Price = 35,
                        Dollar = "$",
                        Treatments = "Etc"
                    }

            };



        }


        void DoThisOnThat()
        {

        }
    }
}