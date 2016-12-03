using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using System.Net.Http;
using instabizschedulemobileclientService.Models;
using System;
using instabizschedulemobileclientService.DataObjects;
using System.Threading.Tasks;

namespace instabizschedulemobileclientService.Controllers
{
    [MobileAppController]
    public class CreateNewUserController : ApiController
    {
        // GET api/CreateNewUser
        public bool Post(Users user)
        {
            string hash = AuthHelper.ComputeHash(user.Password, "SHA512", null);

            Users loginUser = new Users() { Id = Guid.NewGuid().ToString(), FirstName = user.FirstName, LastName= user.LastName, MobileNumber = user.MobileNumber, Email = user.Email, SaltedHash = hash, Password = ""};

            var context = new instabizschedulemobileclientContext();

            context.Users.Add(loginUser);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            var request = System.Web.HttpContext.Current.Request;
            var companyId = request.QueryString["cid"];


            context.CompanyUsers.Add(new CompanyUser() { Id = Guid.NewGuid().ToString(), AuthenticationID = user.Email, CompanyID = companyId, Email = user.Email, UserID = loginUser.Id, AccessLevel = Types.Enums.AccessLevel.User });

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;// InternalServerError(ex);
            }
            return true;// Ok();

        }
    }
}
