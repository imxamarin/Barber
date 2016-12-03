using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace instabizschedulemobileclientService.DataObjects
{
	public class Product : EntityData
	{
		public string DisplayID { get; set; }
		public string Name { get; set; }
		public string Details { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal ProductCost { get; set; }
		public string CompanyID { get; set; }
		public virtual Company Company { get; set; }

	}
}