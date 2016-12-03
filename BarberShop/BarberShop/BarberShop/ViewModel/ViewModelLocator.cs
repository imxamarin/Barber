/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:BarberShop"
                           x:Key="Locator" />
  </Application.Resources>

  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace BarberShop.ViewModel
{
	/// <summary>
	/// This class contains static references to all the view models in the
	/// application and provides an entry point for the bindings.
	/// </summary>
	public class ViewModelLocator
	{
		/// <summary>
		/// Initializes a new instance of the ViewModelLocator class.
		/// </summary>
		public ViewModelLocator ()
		{
			ServiceLocator.SetLocatorProvider (() => SimpleIoc.Default);
			SimpleIoc.Default.Reset ();
			SimpleIoc.Default.Register<LoginPageViewModel> ();
			SimpleIoc.Default.Register<SignUpViewModel> ();
			SimpleIoc.Default.Register<ForgetPasswordViewModel> ();
			SimpleIoc.Default.Register<GalleryViewModel> ();
			SimpleIoc.Default.Register<LocationAvaliableViewModel> ();
			SimpleIoc.Default.Register<ServiceOfferViewModel> ();
			SimpleIoc.Default.Register<SideMasterViewModel> ();
			SimpleIoc.Default.Register<ConfirmationViewModel> ();
			SimpleIoc.Default.Register<InstaViewModel> ();
			SimpleIoc.Default.Register<UserProfileViewModel> ();
			SimpleIoc.Default.Register<AppointmentCalenderViewModel> ();
			SimpleIoc.Default.Register<AppointmentViewModel> ();
			var a = SimpleIoc.Default.IsRegistered<UserProfileViewModel> ();
			var av = SimpleIoc.Default.IsRegistered<SignUpViewModel> ();
			var ac = SimpleIoc.Default.IsRegistered<LoginPageViewModel> ();
		}



		public LoginPageViewModel LoginPage {
			get {
				return ServiceLocator.Current.GetInstance<LoginPageViewModel> ();
			}
		}

		public AppointmentViewModel HomePage {
			get {
				return ServiceLocator.Current.GetInstance<AppointmentViewModel> ();
			}
		}

		public ForgetPasswordViewModel ForgetPassword {
			get {
				return ServiceLocator.Current.GetInstance<ForgetPasswordViewModel> ();
			}
		}
		public GalleryViewModel Gallery {
			get {
				return ServiceLocator.Current.GetInstance<GalleryViewModel> ();
			}
		}

		public LocationAvaliableViewModel LocationAvaliabe {
			get {
				return ServiceLocator.Current.GetInstance<LocationAvaliableViewModel> ();
			}
		}

		public ServiceOfferViewModel ServiceOffer {
			get {
				return ServiceLocator.Current.GetInstance<ServiceOfferViewModel> ();
			}
		}

		public SignUpViewModel SignUpPage {
			get {
				return ServiceLocator.Current.GetInstance<SignUpViewModel> ();
			}
		}

		public SideMasterViewModel SideHamPage {


			get {
				return ServiceLocator.Current.GetInstance<SideMasterViewModel> ();
			}
		}

		public ConfirmationViewModel ConfirmPage {
			get {
				return ServiceLocator.Current.GetInstance<ConfirmationViewModel> ();
			}
		}

		public InstaViewModel InstaPage {
			get {
				return ServiceLocator.Current.GetInstance<InstaViewModel> ();
			}
		}

		public UserProfileViewModel USSR {
			get {
				return ServiceLocator.Current.GetInstance<UserProfileViewModel> ();
			}
		}

		public AppointmentCalenderViewModel BookAppointment {
			get {
				return ServiceLocator.Current.GetInstance<AppointmentCalenderViewModel> ();
			}
		}

		public static void Cleanup ()
		{
			// TODO Clear the ViewModels
		}
	}
}