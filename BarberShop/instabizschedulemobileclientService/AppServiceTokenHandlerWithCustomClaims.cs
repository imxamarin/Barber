using Microsoft.Azure.Mobile.Server.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Security.Claims;
using System.Dynamic;

namespace instabizschedulemobileclientService
{
    public class AppServiceTokenHandlerWithCustomClaims : AppServiceTokenHandler
    {
        public AppServiceTokenHandlerWithCustomClaims(HttpConfiguration config)
        : base(config)
        {

        }



        public override bool TryValidateLoginToken(
        string token,
        string signingKey,
        IEnumerable<string> validAudiences,
        IEnumerable<string> validIssuers,
        out ClaimsPrincipal claimsPrincipal)
        {
            var validated = base.TryValidateLoginToken(token, signingKey, validAudiences, validIssuers, out claimsPrincipal);

            //if (validated)
            //{
            //    //// this is your custom role provider class which would lookup user roles by user id
            //    //var myRoleProvider = new MyRoleProvider();

            //    // get user id (sid)
            //    string sid = claimsPrincipal.With(u => u.FindFirst(ClaimTypes.NameIdentifier)).With(u => u.Value);

            //    // get user roles (from database, for example)
            //    var roles = myRoleProvider.GetUserRolesBySid(sid);
            //    foreach (var role in roles)
            //    {
            //        ((ClaimsIdentity)claimsPrincipal.Identity).AddClaim(new Claim(ClaimTypes.Role, role));
            //    }
            //}

            return validated;
        }
    }
}