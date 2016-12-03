using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using instabizschedulemobileclientService.DataObjects;
using instabizschedulemobileclientService.Models;
using System.Web.UI.WebControls;


namespace instabizschedulemobileclientService.Controllers
{
	public class ProductController : TableController<Product>
	{
		instabizschedulemobileclientContext context;
		protected override void Initialize (HttpControllerContext controllerContext)
		{
			base.Initialize (controllerContext);
			context = new instabizschedulemobileclientContext ();
			DomainManager = new EntityDomainManager<Product> (context, Request);


		}


		public void InsertProductData ()
		{
			Product psi = new Product ();
			psi.CompanyID = "D01";
			psi.Name = "Delta";
			psi.UnitPrice = 45.0M;
			psi.DisplayID = "E23";
			psi.Details = "loop";
			psi.ProductCost = 47.4M;
			context.Product.Add (psi);
			context.SaveChanges ();
		}

		// GET tables/Product
		public IQueryable<Product> GetAllProduct ()
		{
			return Query ();
		}

		// GET tables/Product/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public SingleResult<Product> GetProduct (string id)
		{
			return Lookup (id);
		}

		// PATCH tables/Product/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public Task<Product> PatchProduct (string id, Delta<Product> patch)
		{
			return UpdateAsync (id, patch);
		}

		// POST tables/Product
		public async Task<IHttpActionResult> PostProduct (Product item)
		{
			Product current = await InsertAsync (item);
			return CreatedAtRoute ("Tables", new { id = current.Id }, current);
		}

		// DELETE tables/Product/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public Task DeleteProduct (string id)
		{
			return DeleteAsync (id);
		}
	}
}
