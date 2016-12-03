﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;
using instabizschedulemobileclientService.DataObjects;

namespace instabizschedulemobileclientService.Models
{
	public class instabizschedulemobileclientContext : DbContext
	{
		// You can add custom code to this file. Changes will not be overwritten.
		// 
		// If you want Entity Framework to alter your database
		// automatically whenever you change your model schema, please use data migrations.
		// For more information refer to the documentation:
		// http://msdn.microsoft.com/en-us/data/jj591621.aspx

		private const string connectionStringName = "Name=MS_TableConnectionString";

		public instabizschedulemobileclientContext () : base (connectionStringName)
		{
        }



		protected override void OnModelCreating (DbModelBuilder modelBuilder)
		{
            modelBuilder.HasDefaultSchema("InstaBiz");

            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

		public System.Data.Entity.DbSet<instabizschedulemobileclientService.DataObjects.Company> Company { get; set; }
        public System.Data.Entity.DbSet<instabizschedulemobileclientService.DataObjects.Product> Product { get; set; }

        public System.Data.Entity.DbSet<instabizschedulemobileclientService.DataObjects.CompanyUser> CompanyUsers { get; set; }

        public System.Data.Entity.DbSet<instabizschedulemobileclientService.DataObjects.Users> Users { get; set; }
    }

}
