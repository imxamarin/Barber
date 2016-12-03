﻿using System;
using System.Collections.Generic;
using System.Linq;
using BarberShop.iOS;
using Xamarin.Auth;
using Xamarin.Forms;

[assembly: Dependency (typeof (IOSSecuredDataProvider))]
namespace BarberShop.iOS
{
	public class IOSSecuredDataProvider : ISecuredDataProvider
	{
		public void Store (string userId, string providerName, IDictionary<string, string> data)
		{
			Clear (providerName);
			var accountStore = AccountStore.Create ();
			var account = new Account (userId, data);
			accountStore.Save (account, providerName);
		}

		public void Clear (string providerName)
		{
			var accountStore = AccountStore.Create ();
			var accounts = accountStore.FindAccountsForService (providerName);
			foreach (var account in accounts) {
				accountStore.Delete (account, providerName);
			}
		}

		public Dictionary<string, string> Retreive (string providerName)
		{
			var accountStore = AccountStore.Create ();
			var accounts = accountStore.FindAccountsForService (providerName).FirstOrDefault ();

			return (accounts != null) ? accounts.Properties : new Dictionary<string, string> ();
		}
	}
}
