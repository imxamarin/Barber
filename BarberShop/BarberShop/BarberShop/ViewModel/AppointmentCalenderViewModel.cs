using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using BarberShop.Services;
using BarberShop.PCL.Model;

namespace BarberShop
{
	public class AppointmentCalenderViewModel : ViewModelBase
	{
		#region	Variables
		double timeButtonWidth;
		double bookButtonWidth;
		DateTime minimumDate;
		DateTime maximumDate;
		ICommand bookingButton;
		ICommand appointmentConfirm;
		string alphaBtnTime;
		string betaBtnTime;
		string deltaBtnTime;
		INavigation navigation;
		#endregion

		#region	Properties

		public INavigation Navigation {
			get {
				return navigation;
			}

			set {
				navigation = value;
				RaisePropertyChanged ("Navigation");
			}
		}

		public ObservableCollection<CmCell> ListBar { get; set; }
		public ObservableCollection<String> AvaliableTimes {
			get;
			set;
		}
		public DateTime MinimumDate {
			get {
				return minimumDate;
			}

			set {
				minimumDate = value;
				RaisePropertyChanged ("MinimumDate");
			}
		}

		public DateTime MaximumDate {
			get {
				return maximumDate;
			}

			set {
				maximumDate = value;
				RaisePropertyChanged ("MaximumDate");
			}
		}

		public ICommand BookingButton {
			get {
				return bookingButton;
			}

			set {
				bookingButton = value;
				RaisePropertyChanged ("BookingButton");
			}
		}


		public ICommand AppointmentConfirm {
			get {
				return appointmentConfirm;
			}

			set {
				appointmentConfirm = value;
			}
		}

		public double BookButtonWidth {
			get {
				return bookButtonWidth;
			}

			set {
				bookButtonWidth = value;
				RaisePropertyChanged ("BookButtonWidth");
			}
		}

		public double TimeButtonWidth {
			get {
				return timeButtonWidth;
			}

			set {
				timeButtonWidth = value;
				RaisePropertyChanged ("TimeButtonWidth");
			}
		}

		public string AlphaBtnTime {
			get {
				return alphaBtnTime;
			}

			set {
				alphaBtnTime = value;
				RaisePropertyChanged ("AlphaBtnTime");
			}
		}

		public string BetaBtnTime {
			get {
				return betaBtnTime;
			}

			set {
				betaBtnTime = value;
				RaisePropertyChanged ("BetaBtnTime");
			}
		}

		public string DeltaBtnTime {
			get {
				return deltaBtnTime;
			}

			set {
				deltaBtnTime = value;
				RaisePropertyChanged ("DeltaBtnTime");
			}
		}

		#endregion

		public AppointmentCalenderViewModel ()
		{

			SetUpDefaultValues ();
			BookingButton = new Command (ConfirmBooking);
			AppointmentConfirm = new Command (ConfirmAppointment);


		}

		#region LocalCalls
		void SetUpDefaultValues ()
		{
			ListBar = new ObservableCollection<CmCell> ();
			TimeButtonWidth = Application.Current.MainPage.Width / 3.13;
			BookButtonWidth = Application.Current.MainPage.Width / 2;
			AvaliableTimes = new ObservableCollection<string> ();
			AvaliableTimes.Add ("02:00PM");
			AvaliableTimes.Add ("05:00PM");
			AvaliableTimes.Add ("08:00PM");
			AlphaBtnTime = AvaliableTimes [0];
			BetaBtnTime = AvaliableTimes [1];
			DeltaBtnTime = AvaliableTimes [2];
			MinimumDate = DateTime.Now.Date;
			MaximumDate = DateTime.Now.AddMonths (1);
			ListBar.Add (new CmCell {
				Logo = "cut_line_up.png",
				Price = 22, Dollar = "$", Treatments = "Cut"
			});
			RaisePropertyChanged ("MinimumDate");
			RaisePropertyChanged ("MaximumDate");
			RaisePropertyChanged ("TimeBtnWidth");
			RaisePropertyChanged ("BookBtnWidth");
		}

		async void ConfirmAppointment ()
		{
			try {
				var Reslut = await Application.Current.MainPage.DisplayAlert ("APPOINTMENT SECHDULE", "Change Sechdule", "Prooceed", "Cancel");
				if (Reslut) {
					await Application.Current.MainPage.DisplayAlert ("Deleted", "Deleted", "Ok");
				}
			} catch (Exception ex) {
				await Navigation.PushModalAsync (new NavigationPage (new DefaultExPage (ex)));
			}

		}

		async void ConfirmBooking ()
		{
			try {

				await Navigation.PopModalAsync ();
				await Navigation.PushModalAsync (new Confirmation ());
			} catch (Exception ex) {

				await Navigation.PushModalAsync (new NavigationPage (new DefaultExPage (ex)));
			}
		}

		#endregion

		#region OnlineAzureBooking

		public async void GetAppointmentsFromServer ()
		{
			try {
				var AppointmentTask = AzureMobileServices.GetAppointments ();
				var AppointmentList = await AppointmentTask;

				foreach (var item in AppointmentList) {
					var appointmentStartTime = item.StartTime;
					var appointmentEndTime = item.EndTime;
					var ClientDetail = item.ClientID;
				}
			} catch (Exception ex) {

			}
		}

		public async void SetAppointmentFromServer ()
		{
			try {

				var appointment = new ServiceAppointment ();
				appointment.StartTime = new DateTimeOffset ().Add (DateTime.Now.TimeOfDay);
				appointment.EndTime = new DateTimeOffset ().Add (DateTime.Now.TimeOfDay);
				appointment.CompanyID = "SomeIDWillBePasted";
				appointment.ClientID = "SomeClientID";
				var InsertAppointment = AzureMobileServices.AddAppointment (appointment);
				var datas = await InsertAppointment;


			} catch (Exception ex) {

			}
		}

		#endregion


	}
}
