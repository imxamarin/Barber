﻿using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using instabizschedulemobileclientService.DataObjects;
using instabizschedulemobileclientService.Models;

namespace instabizschedulemobileclientService.Controllers
{
    public class CompanyUserController : TableController<CompanyUser>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            instabizschedulemobileclientContext context = new instabizschedulemobileclientContext();
            DomainManager = new EntityDomainManager<CompanyUser>(context, Request);
        }

        // GET tables/CompanyUser
        public IQueryable<CompanyUser> GetAllCompanyUser()
        {
            return Query(); 
        }

        // GET tables/CompanyUser/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<CompanyUser> GetCompanyUser(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/CompanyUser/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<CompanyUser> PatchCompanyUser(string id, Delta<CompanyUser> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/CompanyUser
        public async Task<IHttpActionResult> PostCompanyUser(CompanyUser item)
        {
            CompanyUser current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/CompanyUser/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCompanyUser(string id)
        {
             return DeleteAsync(id);
        }
    }
}
