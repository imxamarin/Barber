using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Diagnostics;
namespace BarberShop
{
	public static class ServicesCall
	{
		public static async Task<List<LoginRootObject>> CallingServer (String UserName, String Password)
		{

			List<LoginRootObject> rootsobject = new List<LoginRootObject> ();
			var client = new HttpClient ();
			var EnCodeUserName = ValidationCheck.DoTheEncryption (UserName);
			var EnCodePassword = ValidationCheck.DoTheEncryption (Password);
			string Jsonstr = string.Format ("http://trigmasolutions.com/jornalero/api/Jornalero/TestLogin/{0}", true);
			Uri PostManUrl = new Uri (Jsonstr);
			var response = await client.GetAsync (PostManUrl);
			var earthquakesJson = response.Content.ReadAsStringAsync ().Result;
			rootsobject = JsonConvert.DeserializeObject<List<LoginRootObject>> (earthquakesJson);
			response.Dispose ();
			return rootsobject;
		}


		public static async Task<bool> GetingResponce ()
		{
			var client = new HttpClient ();
			string Jsonstr = string.Format ("http://trigmasolutions.com/barbar/api/GetProducts");
			bool code = false;
			Uri PostManUrl = new Uri (Jsonstr);
			var response = await client.GetAsync (PostManUrl);
			var earthquakesJson = response.Content.ReadAsStringAsync ().Result;
			var rootsobject = JsonConvert.DeserializeObject<List<CmCell>> (earthquakesJson);
			foreach (var item in rootsobject) {
				code = item.statusCode;
			}
			return code;

		}

		public static async Task<List<LoginRootObject>> CallingServer (String Name, String UserName, String MobileNumber, String Password)
		{

			List<LoginRootObject> rootsobject = new List<LoginRootObject> ();
			var client = new HttpClient ();
			var EnCodeUserName = ValidationCheck.DoTheEncryption (UserName);
			var EnCodePassword = ValidationCheck.DoTheEncryption (Password);
			string Jsonstr = string.Format ("http://trigmasolutions.com/jornalero/api/Jornalero/TestLogin/{0}", true);
			Uri PostManUrl = new Uri (Jsonstr);
			var response = await client.GetAsync (PostManUrl);
			var earthquakesJson = response.Content.ReadAsStringAsync ().Result;
			rootsobject = JsonConvert.DeserializeObject<List<LoginRootObject>> (earthquakesJson);
			response.Dispose ();
			return rootsobject;
		}
		public static async Task<List<LoginRootObject>> CallingServer (String UserName)
		{
			List<LoginRootObject> rootsobject = new List<LoginRootObject> ();
			var client = new HttpClient ();
			var EnCodeUserName = ValidationCheck.DoTheEncryption (UserName);
			string Jsonstr = string.Format ("http://trigmasolutions.com/jornalero/api/Jornalero/TestLogin/{0}", true);
			Uri PostManUrl = new Uri (Jsonstr);
			var response = await client.GetAsync (PostManUrl);
			var earthquakesJson = response.Content.ReadAsStringAsync ().Result;
			rootsobject = JsonConvert.DeserializeObject<List<LoginRootObject>> (earthquakesJson);
			response.Dispose ();
			return rootsobject;
		}
		public static async Task<string> ForgetPassword (String Email)
		{
			var JsonData = JsonConvert.SerializeObject (Email);
			var client = new HttpClient ();
			client.BaseAddress = new Uri ("http://trigmasolutions.com/barber/api/ForgetPass");
			var content = new StringContent (JsonData);
			var reslit = await client.PostAsync ("http://trigmasolutions.com/barber/api/SignUp", content);
			var result = await reslit.Content.ReadAsStringAsync ();
			return result;

		}
		public static async Task<string> CallingServer (List<LoginRootObject> rs, bool typeofWork)
		{
			if (typeofWork == true) {
				var JsonData = JsonConvert.SerializeObject (rs);
				var Client = new HttpClient ();
				Client.BaseAddress = new Uri ("http://trigmasolutions.com/barbar/api/SignUp");
				var content = new StringContent (JsonData, Encoding.UTF8);
				var resilt = await Client.PostAsync ("http://trigmasolutions.com/barbar/api/SignUp", content);
				var result = await resilt.Content.ReadAsStringAsync ();
				return result;
			} else {
				var JsonData = JsonConvert.SerializeObject (rs);
				var Client = new HttpClient ();
				Client.BaseAddress = new Uri ("http://trigmasolutions.com/barbar/api/UserLogin");
				var content = new StringContent (JsonData, Encoding.UTF8);
				var resilt = await Client.PostAsync ("http://trigmasolutions.com/barbar/api/UserLogin", content);
				var result = await resilt.Content.ReadAsStringAsync ();
				return result;
			}
		}


		public static async Task<List<CmCell>> GetProducts ()
		{
			List<CmCell> rootsobject = new List<CmCell> ();
			var client = new HttpClient ();
			try {
				string Jsonstr = string.Format ("http://trigmasolutions.com/barbar/api/GetProducts");

				Uri PostManUrl = new Uri (Jsonstr);
				var response = await client.GetAsync (PostManUrl);
				var earthquakesJson = response.Content.ReadAsStringAsync ().Result;
				rootsobject = JsonConvert.DeserializeObject<List<CmCell>> (earthquakesJson);
				response.Dispose ();
				if (rootsobject.Count >= 1) {
					return rootsobject;
				} else {
					return new List<CmCell> ();
				}
			} catch (Exception ex) {

				return new List<CmCell> ();
			}

		}



		public static async Task<string> SetAppointmentTime (DateTime dts)
		{
			List<DateTime> dtsi = new List<DateTime> ();
			dtsi.Add (dts);


			try {
				var JsonData = JsonConvert.SerializeObject (dtsi);
				var Client = new HttpClient ();
				Client.BaseAddress = new Uri ("http://trigmasolutions.com/barbar/api/SignUp");
				var content = new StringContent (JsonData, Encoding.UTF8);
				var resilt = await Client.PostAsync ("http://trigmasolutions.com/barbar/api/SignUp", content);
				var result = await resilt.Content.ReadAsStringAsync ();
				return result;

			} catch (Exception ex) {

				return "Something went wrong";
			}


		}


	}
}
