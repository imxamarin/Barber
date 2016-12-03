using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaBiz.Model;
using Microsoft.WindowsAzure.MobileServices;
//using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using BarberShop.PCL.Model;
using BarberShop.PCL;
using System.Collections.ObjectModel;
using InstaBiz.PCL.ModelVM;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Diagnostics;
using BarberShop.Model;
using Newtonsoft.Json;

namespace BarberShop.Services
{

	public class AzureMobileServices
	{

		static bool OfflineMode = false;
		private static MobileServiceClient mobileService;
		private static MobileServiceClient MobileService {
			get {
				if (mobileService == null)
					Init ();

				return mobileService;
			}
			set {
				mobileService = value;
			}
		}


		public AzureMobileServices ()
		{
			Init ();



			PlatformAdapter.Current.Identity.CheckCredentials ();
			try {
				MobileService.CurrentUser = PlatformAdapter.Current.Identity.AzureUser;
			} catch (Exception ex) {

			}
		}

		public static void ResetMobileService ()
		{
			MobileServiceUser currentUser = null;

			if (MobileService != null) {
				currentUser = MobileService.CurrentUser;
			}
			var authHandler = new AuthHandler ();
			MobileService =
						new MobileServiceClient (
					"https://instabizschedulemobileclient.azurewebsites.net", new TraceHandler (Identity.Company), authHandler
					) {
							SerializerSettings = new MobileServiceJsonSerializerSettings () {
								CamelCasePropertyNames = true
							}
						};
			authHandler.Client = MobileService;

			if (currentUser != null)
				MobileService.CurrentUser = currentUser;
		}

		public static void Init ()
		{
			Identity.Company = new Company () { Id = "ad81c57d-5d88-44a5-a97b-ec5597026806" };

			var authHandler = new AuthHandler ();
			MobileService =
						new MobileServiceClient (
					"https://instabizschedulemobileclient.azurewebsites.net", new TraceHandler (Identity.Company), authHandler
					) {
							SerializerSettings = new MobileServiceJsonSerializerSettings () {
								CamelCasePropertyNames = true
							}
						};
			authHandler.Client = MobileService;
		}



		static public async Task InitLocalStoreAsync (string companyId = "localstore")
		{
			//if (!MobileService.SyncContext.IsInitialized)
			//{
			//    var store = new MobileServiceSQLiteStore(companyId + ".db");

			//    store.DefineTable<Company>();
			//    store.DefineTable<Users>();
			//    store.DefineTable<VersionInfo>();

			//    if (companyId != "localstore")
			//    {
			//        store.DefineTable<Client>();
			//        store.DefineTable<ClientPayment>();
			//        store.DefineTable<Employee>();
			//        store.DefineTable<Product>();
			//        store.DefineTable<ProductGroup>();
			//    }
			//    await MobileService.SyncContext.InitializeAsync(store, new SyncHandler(MobileService));
			//}
		}

		static DateTimeOffset? lastSync = null;
		static public async Task<bool> SyncAsync (bool force = false)
		{
			try {
				if (!OfflineMode) {
					if ((force) || (lastSync == null) || ((DateTimeOffset)lastSync).Subtract (DateTimeOffset.Now).TotalSeconds > 5) {
						lastSync = DateTimeOffset.Now;
						await MobileService.SyncContext.PushAsync ();
					}
				}
				return true;
			} catch (Exception ex) {
				//throw;
				return false;
			}
		}



		#region Appointments
		public static async Task<ServiceAppointment> AddAppointment (ServiceAppointment appointment)
		{
			try {
				appointment.CompanyID = PlatformAdapter.Current.Identity.Company.Id;
				await MobileService.GetTable<ServiceAppointment> ().InsertAsync (appointment);
				await SyncAsync (true);
			} catch {
				return null;
			}

			return appointment;
		}

		public static async Task<List<ServiceAppointment>> GetAppointments (bool forceUpdate = false)
		{
			bool shouldRepeat = false;
			do {
				try {
					var appointmentTable = MobileService.GetTable<ServiceAppointment> ();
					//if (forceUpdate && !OfflineMode)
					//{
					//    //await SyncAsync();
					//    await appointmentTable.PullAsync("allAppointments", appointmentTable.CreateQuery());
					//}

					List<ServiceAppointment> appointmentList = await appointmentTable.CreateQuery ().ToListAsync ();
					shouldRepeat = false;
					return appointmentList;
				} catch (Exception ex) {
					if (shouldRepeat) {
						shouldRepeat = false;
						return null;
					} else {
						ResetMobileService ();
						await InitLocalStoreAsync (PlatformAdapter.Current.Identity.Company.Id);
						shouldRepeat = true;
					}
				}
			} while (shouldRepeat);
			return null;
		}

		#endregion













		static public async Task<List<Employee>> GetPunchClockEmployees (string companyIdsSeparatedByDash)
		{
			try {
				var dic = new Dictionary<string, string> ();
				dic.Add ("cid", companyIdsSeparatedByDash);

				var returnStuff = await MobileService.InvokeApiAsync<Dictionary<string, string>, List<Employee>> ("GetPunchClockEmployees", dic);

				return returnStuff;
			} catch (Exception ex) {
				return null;
			}
		}





		#region Users

		static public async Task<bool> LoginUser (Users user)
		{
			try {
				await MobileService.LoginAsync ("custom", JObject.FromObject (user));


				//var validUser = await MobileService.InvokeApiAsync<LoginAuth, LoginResult>("Auth", user);



				return true;

				//MobileService.CurrentUser = new MobileServiceUser(validUser.Id);                
				//MobileService.CurrentUser.MobileServiceAuthenticationToken = validUser.AuthenticationToken;

				//if (validUser == null)
				//    return false;

				//else
				//{
				//    var authUser = new LoginAuth() { Id = validUser.Id, Name = validUser.Name, Email = validUser.Email, MobileNumber = validUser.MobileNumber, Password = "", AuthenticationToken = validUser.AuthenticationToken, SaltedHash = "" };


				//    Identity.User = authUser;

				//    return true;
				//}
			} catch (Exception ex) {
				Debug.WriteLine (ex.ToString ());
				return false;
			}
		}

		static public async Task<bool> CreateNewUser (Users newUser)
		{
			try {

				var result = await MobileService.InvokeApiAsync<Users, bool> ("CreateNewUser", newUser);
				return result;
				//if (result.IsSuccessStatusCode)
				//return true;
				//else {
				//	//Display HTTP error
				//	return false;
				//}
			} catch (Exception ex) {
				Debug.WriteLine (ex.ToString ());
				return false;
			}
		}

		//      static public async Task<bool> AddUser (Users user)
		//{
		//	try {
		//		var userTable = MobileService.GetTable<Users> ();
		//		await userTable.InsertAsync (user);
		//		await SyncAsync (true);
		//		return true;
		//	} catch (Exception ex) {
		//		Debug.WriteLine (ex.ToString ());
		//		return false;
		//	}
		//}
		static public async Task<bool> UpdateUser (Users user)
		{
			try {
				var userTable = MobileService.GetTable<Users> ();

				user.LastLogged = DateTimeOffset.Now;



				await userTable.UpdateAsync (user);

				await SyncAsync (true);
				return true;
			} catch (MobileServiceInvalidOperationException ex) {
				throw;
			} catch (Exception ex) {
				throw;
				//return false;
			}
		}
		static public async Task<List<Users>> GetUsersFromServer ()
		{
			bool keepTrying = true;
			bool triedAgain = false;
			while (keepTrying) {
				try {
					var userTable = MobileService.GetTable<Users> ();
					//await userTable.PurgeAsync(true);

					//await userTable.PullAsync("me", userTable.CreateQuery());

					var users = await userTable.CreateQuery ().ToListAsync ();

					return users;
				} catch (Exception ex) {
					if (triedAgain)
						keepTrying = false;
					triedAgain = true;
				}
			}
			PlatformAdapter.Current.Identity.ClearCredentials ();
			return null;
		}

		static public async Task<List<Users>> GetUserLocal ()
		{
			try {
				var userTable = MobileService.GetTable<Users> ();


				var users = await userTable.CreateQuery ().ToListAsync ();

				return users;
			} catch { }
			return null;
		}
		static public async Task<List<Users>> GetUserWithAuthID (string version = null, string osversion = null)
		{
			try {
				var dic = new Dictionary<string, string> ();

				dic.Add ("version", version);
				dic.Add ("osversion", osversion);

				List<Users> user = await MobileService.InvokeApiAsync<Dictionary<string, string>, List<Users>> ("GetUserWithAuthID", dic);

				if (user.Count > 0) {
					try {
						await MobileService.GetTable<Users> ().UpdateAsync (user [0]);
					} catch {

					}
					await MobileService.GetTable<Users> ().InsertAsync (user [0]);
				}
				return user;

				//return await MobileService.InvokeApiAsync<List<UsersVM>>("GetUserWithAuthID");
			} catch (Exception ex) {
				return null;
			}
		}

		static public async Task<JObject> GetUserInfo ()
		{
			try {
				var userInfo = await MobileService.InvokeApiAsync<JObject> ("GetUserInfo", HttpMethod.Get, null);

				return userInfo;
				//return await MobileService.InvokeApiAsync<List<UsersVM>>("GetUserWithAuthID");
			} catch (Exception ex) {
				return null;
			}
		}




		#endregion


		#region Clients


		public static async Task<Client> AddClient (Client client)
		{
			try {
				await MobileService.GetTable<Client> ().InsertAsync (client);
				await SyncAsync (true);
			} catch {
				return null;
			}

			return client;
		}

		public static async Task<Client> UpdateClient (Client client)
		{
			try {
				await MobileService.GetTable<Client> ().UpdateAsync (client);
				await SyncAsync (true);
			} catch {
				return null;
			}

			return client;
		}

		public static async Task<Client> GetClient (string clientId, bool forceUpdate = false)
		{
			if (clientId == null)
				return null;
			try {
				Client client = null;
				bool keepTrying = true;
				while (keepTrying) {
					var clientTable = MobileService.GetTable<Client> ();
					//if (forceUpdate && !OfflineMode)
					//{
					//    //await SyncAsync();
					//    await clientTable.PullAsync("allClients", clientTable.CreateQuery());
					//}

					client = await clientTable.LookupAsync (clientId);
					if (client != null)
						keepTrying = false;
					else if (!forceUpdate)
						forceUpdate = true;
					else
						keepTrying = false;
				}

				return client;
			} catch { }
			return null;
		}

		public static async Task<List<Client>> GetClients (bool forceUpdate = false)
		{
			bool shouldRepeat = false;
			do {
				try {
					var clientTable = MobileService.GetTable<Client> ();
					//if (forceUpdate && !OfflineMode)
					//{
					//    //await SyncAsync();
					//    await clientTable.PullAsync("allClients", clientTable.CreateQuery());
					//}

					List<Client> jobList = await clientTable.CreateQuery ().ToListAsync ();
					shouldRepeat = false;
					return jobList;
				} catch (Exception ex) {
					if (shouldRepeat) {
						shouldRepeat = false;
						return null;
					} else {
						ResetMobileService ();
						await InitLocalStoreAsync (Identity.Company.Id);
						shouldRepeat = true;
					}
				}
			} while (shouldRepeat);
			return null;
		}

		public static async Task<List<ClientPayment>> GetClientPaymentHistory (string clientId, bool forceUpdate = false)
		{
			try {
				var clientPaymentTable = MobileService.GetTable<ClientPayment> ();
				//if (forceUpdate && !OfflineMode)
				//{
				//    //await SyncAsync();
				//    await clientPaymentTable.PullAsync("cPay-" + clientId, clientPaymentTable.Where(x => x.ClientID == clientId));
				//}

				List<ClientPayment> paymentList = await clientPaymentTable.Where (x => x.ClientID == clientId).ToListAsync ();
				return paymentList;
				;
			} catch { }
			return null;

		}

		static public async Task<List<ClientVM>> GetAllClientVMs (bool forceUpdate = false)
		{
			try {
				List<Client> clientList = await GetClients (forceUpdate);

				List<ClientVM> returnList = new List<ClientVM> ();
				foreach (var client in clientList) {
					returnList.Add (client.ToVM ());
				}




				return returnList;

				//var dic = new Dictionary<string, string>();
				////dic.Add("cid", companyid);

				////dic.Add("filter", "month");
				////dic.Add("filterid", month);
				//List<ClientVM> results = await MyApp.MobileService.InvokeApiAsync<Dictionary<string, string>, List<ClientModel>>("GetClientCollection", dic);

				//List<Task<BitmapImage>> tasklist = new List<Task<BitmapImage>>();
				//foreach (ClientVM c in results)
				//{
				//    c.StatusColor = Application.Current.Resources["SummaryBackground"] as SolidColorBrush;
				//    client temp = new client();
				//    temp.ClientID_ = c.ClientID;

				//    tasklist.Add(temp.GetDisplayPic());
				//}

				//BitmapImage[] images = await Task.WhenAll(tasklist);

				//int count = 0;
				//foreach (ClientVM c in results)
				//{
				//    if (images[count] == null)
				//    {
				//        if (c.Company != null && c.Company != "")
				//            c.Image = MyApp.clientcompany;
				//        else
				//            c.Image = MyApp.clienticonlight;
				//    }
				//    else
				//        c.Image = images[count];
				//    count++;
				//}

				//return results;
			} catch (Exception ex) {
				return null;
			}
		}

		#endregion

		#region Employees
		public static async Task<Employee> AddEmployee (Employee employee)
		{
			try {
				employee.CompanyID = PlatformAdapter.Current.Identity.Company.Id;
				await MobileService.GetTable<Employee> ().InsertAsync (employee);
				await SyncAsync (true);
			} catch {
				return null;
			}

			return employee;
		}

		public static async Task<Employee> UpdateEmployee (Employee employee)
		{
			try {
				await MobileService.GetTable<Employee> ().UpdateAsync (employee);
				await SyncAsync (true);
			} catch {
				return null;
			}

			return employee;
		}


		public static async Task<Employee> GetEmployee (string employeeId, bool forceUpdate = false)
		{
			try {
				Employee employee = null;
				bool keepTrying = true;
				while (keepTrying) {
					var employeeTable = MobileService.GetTable<Employee> ();
					//if (forceUpdate && !OfflineMode)
					//{
					//    //await SyncAsync();
					//    await employeeTable.PullAsync("allEmployees", employeeTable.CreateQuery());
					//}

					employee = await employeeTable.LookupAsync (employeeId);
					if (employee != null)
						keepTrying = false;
					else if (!forceUpdate)
						forceUpdate = true;
					else
						keepTrying = false;
				}

				return employee;
			} catch { }
			return null;
		}


		public static async Task<List<Employee>> GetEmployees (bool forceUpdate = false)
		{
			bool shouldRepeat = false;
			do {
				try {
					var employeeTable = MobileService.GetTable<Employee> ();
					//if (forceUpdate && !OfflineMode)
					//{
					//    //await SyncAsync();
					//    await employeeTable.PullAsync("allEmployees", employeeTable.CreateQuery());
					//}

					List<Employee> employeeList = await employeeTable.CreateQuery ().ToListAsync ();
					shouldRepeat = false;
					return employeeList;
				} catch (Exception ex) {
					if (shouldRepeat) {
						shouldRepeat = false;
						return null;
					} else {
						ResetMobileService ();
						await InitLocalStoreAsync (PlatformAdapter.Current.Identity.Company.Id);
						shouldRepeat = true;
					}
				}
			} while (shouldRepeat);
			return null;



		}

		public static async Task<List<EmployeeVM>> GetEmployeeVMs (bool forceUpdate = false)
		{
			try {
				//var employeeTable = MobileService.GetTable<Employee>();
				//if (forceUpdate)
				//{
				//    await SyncAsync();
				//    await employeeTable.PullAsync("allEmployees", employeeTable.CreateQuery());
				//}

				//List<Employee> jobList = await employeeTable.CreateQuery().ToListAsync();
				////return jobList;

				List<Employee> jobList = await GetEmployees (forceUpdate);

				List<Task<EmployeeVM>> TaskList = new List<Task<EmployeeVM>> ();
				List<EmployeeVM> returnList = new List<EmployeeVM> ();
				foreach (var job in jobList) {
					returnList.Add (job.ToVM ());
				}




				return returnList;
			} catch { }
			return null;
		}



		#endregion

		#region Contacts
		public static async Task<Contact> AddContact (Contact contact)
		{
			try {
				await MobileService.GetTable<Contact> ().InsertAsync (contact);
				await SyncAsync (true);
			} catch {
				return null;
			}

			return contact;
		}
		public static async Task<Contact> UpdateContact (Contact contact)
		{
			try {
				await MobileService.GetTable<Contact> ().UpdateAsync (contact);
				await SyncAsync (true);
			} catch {
				return null;
			}

			return contact;
		}

		public static async Task<Contact> DeleteContact (Contact contact, bool forceSync = true)
		{
			try {
				await MobileService.GetTable<Contact> ().DeleteAsync (contact);
				if (forceSync)
					await SyncAsync (true);
			} catch {
				return null;
			}

			return contact;
		}

		public static async Task<Contact> GetContact (string contactId, bool forceUpdate = false)
		{
			try {
				var contactTable = MobileService.GetTable<Contact> ();
				//if (forceUpdate && !OfflineMode)
				//{
				//    //await SyncAsync();
				//    await contactTable.PullAsync("allContacts", contactTable.CreateQuery());
				//}

				Contact contact = await contactTable.LookupAsync (contactId);

				return contact;
			} catch { }
			return null;
		}

		#endregion

		#region Notes
		public static async Task<Note> AddNote (Note note)
		{
			try {
				if (note.ParentID == null)
					note.ParentID = "";

				if (note.Permissions == null)
					note.Permissions = "Office";

				note.UserID = PlatformAdapter.Current.Identity.User.Id;
				note.UserName = PlatformAdapter.Current.Identity.User.FirstName + " " + PlatformAdapter.Current.Identity.User.LastLogged;// PlatformAdapter.Current.Identity.User.FirstName + " " + PlatformAdapter.Current.Identity.User.LastName;
				note.CDateTime = DateTimeOffset.Now;

				await MobileService.GetTable<Note> ().InsertAsync (note);
				await SyncAsync (true);
			} catch (Exception ex) {
				return null;
			}

			return note;
		}
		public static async Task<Note> UpdateNote (Note note)
		{
			try {
				await MobileService.GetTable<Note> ().UpdateAsync (note);
				await SyncAsync (true);
			} catch {
				return null;
			}

			return note;
		}


		public static async Task<Note> DeleteNote (Note note, bool forceSync = true)
		{
			try {
				await MobileService.GetTable<Note> ().DeleteAsync (note);
				if (forceSync)
					await SyncAsync (true);
			} catch {
				return null;
			}

			return note;
		}


		#endregion

		#region Other
		public async static Task<ClientPayment> AddClientPayment (ClientPayment clientPayment)//, bool forceSync = false
		{
			try {
				await MobileService.GetTable<ClientPayment> ().InsertAsync (clientPayment);
				//if(forceSync)
				await SyncAsync (true);
			} catch {
				return null;
			}

			return clientPayment;
		}

		#endregion

		public static async Task<ObservableCollection<UserFeedbackVM>> GetFeedbackVMs (bool forceUpdate = false)
		{
			ObservableCollection<UserFeedbackVM> returnList = new ObservableCollection<UserFeedbackVM> ();

			var feedback = await AzureMobileServices.GetFeedback (forceUpdate);

			foreach (var item in feedback) {
				UserFeedbackVM vm = new UserFeedbackVM ();

				vm.Type = item.Type;
				vm.UserID = item.UserID;
				vm.Message = item.Message;

				returnList.Add (vm);
			}

			return returnList;
		}

		public static async Task<List<UserFeedback>> GetFeedback (bool forceUpdate = false)
		{
			bool shouldRepeat = false;
			do {
				try {
					var clientTable = MobileService.GetTable<UserFeedback> ();
					//if (forceUpdate && !OfflineMode)
					//{
					//    //await SyncAsync();
					//    await clientTable.PullAsync("allFeedback", clientTable.CreateQuery());
					//}

					List<UserFeedback> jobList = await clientTable.CreateQuery ().ToListAsync ();
					shouldRepeat = false;
					return jobList;
				} catch (Exception ex) {
					if (shouldRepeat) {
						shouldRepeat = false;
						return null;
					} else {
						ResetMobileService ();
						await InitLocalStoreAsync (PlatformAdapter.Current.Identity.Company.Id);
						shouldRepeat = true;
					}
				}
			} while (shouldRepeat);
			return null;
		}


		public static async Task<UserFeedback> AddFeedback (UserFeedback client)
		{
			try {
				await MobileService.GetTable<UserFeedback> ().InsertAsync (client);
				await SyncAsync (true);
			} catch (Exception ex) {
				return null;
			}

			return client;
		}




		//string companyId, bool forceUpdate = false
		public static async Task<List<Product>> GetProducts ()
		{

			try {
				var productTable = MobileService.GetTable<Product> ();

				//if (forceUpdate && !OfflineMode)
				//{
				//    //await SyncAsync();
				//    await productTable.PullAsync("products-" + companyId, productTable.Where(x => x.SuppID == companyId));
				//}
				var productList = await productTable.ToListAsync ();
				return productList;
			} catch (Exception ex) {

			}
			return null;
		}

	}
}







