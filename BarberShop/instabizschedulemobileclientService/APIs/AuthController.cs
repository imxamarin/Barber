using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using System.Net.Http;
using System.IdentityModel.Tokens;
using System.Net;
using System.Security.Claims;
using System;
using Microsoft.Azure.Mobile.Server.Login;
using instabizschedulemobileclientService.DataObjects;
using instabizschedulemobileclientService.Models;
using System.Linq;
using System.Configuration;
using Newtonsoft.Json;

namespace instabizschedulemobileclientService.Controllers
{
    //[MobileAppController]
    [Route(".auth/login/custom")]
    public class AuthController : ApiController
    {
        // GET api/Auth
        [HttpPost]
        public IHttpActionResult Post([FromBody]Users user)

        {
            // return error if password is not correct

            var validUser = this.IsPasswordValid(user.Email, user.Password);


            if (validUser == null)
            {
                //return null;
                return Unauthorized();

            }
            else
            {

                JwtSecurityToken token = this.GetAuthenticationTokenForUser(user.Email);
                validUser.AuthenticationToken = token.RawData;

                return Ok(new {
                    authenticationToken = token.RawData,
                    user = new { userId = user.Email }
                });

                //return Ok(new LoginResult() { Id = validUser.Id, Name = validUser.Name, Email = validUser.Email, MobileNumber = validUser.MobileNumber, Password = "", AuthenticationToken = validUser.AuthenticationToken, SaltedHash = "" });
                //return this.Request.CreateResponse(HttpStatusCode.OK, new LoginResult() { Id = validUser.Id, Name = validUser.Name, Email = validUser.Email, MobileNumber = validUser.MobileNumber, Password = "", AuthenticationToken = validUser.AuthenticationToken, SaltedHash = "" });
            }
        }



        private Users IsPasswordValid(string username, string password)
        {
            // this is where we would do checks agains a database

            var context = new instabizschedulemobileclientContext();
            var userMatch = context.Users.Where(x => x.Email == username).FirstOrDefault();

            if (userMatch == null)
                return null;
            else
            {
                bool isValid = AuthHelper.VerifyHash(password, "SHA512", userMatch.SaltedHash);

                if (isValid)
                    return userMatch;
                else
                    return null;
            }
        }


        private JwtSecurityToken GetAuthenticationTokenForUser(string username)

        {

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username)
            };



            var signingKey = GetSigningKey();
            var audience = "https://instabizschedulemobileclient.azurewebsites.net/"; // audience must match the url of the site
            var issuer = "https://instabizschedulemobileclient.azurewebsites.net"; // audience must match the url of the site



            JwtSecurityToken token = AppServiceLoginHandler.CreateToken(
                claims,
                signingKey,
                audience,
                issuer,
                TimeSpan.FromHours(24)
                );            

            

            return token;

        }


        private static string GetSigningKey()
        {
            string key =
                Environment.GetEnvironmentVariable("WEBSITE_AUTH_SIGNING_KEY");

            if (string.IsNullOrWhiteSpace(key))
                key = ConfigurationManager.AppSettings["SigningKey"];

            return key;
        }
    }


    public class LoginResult
    {
        [JsonProperty(PropertyName = "authenticationToken")]
        public string AuthenticationToken { get; set; }

        [JsonProperty(PropertyName = "user")]
        public LoginResultUser User { get; set; }
    }

    public class LoginResultUser
    {
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }
    }
}
