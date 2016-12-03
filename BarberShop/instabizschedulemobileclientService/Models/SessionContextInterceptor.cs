using Microsoft.Azure.Mobile.Server.Authentication;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.SqlClient;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace instabizschedulemobileclientService.Models
{
    public class SessionContextInterceptor : IDbCommandInterceptor
    {
        public string id { get; set; }
        async private Task SetSessionContext(DbCommand command)
        {
            try
            {
                if (System.Web.HttpContext.Current != null)
                {
                    string authToken = HttpContext.Current.Request.Headers["x-zumo-auth"];
                    IPrincipal user = HttpContext.Current.User;
                    HttpRequestMessage req = new HttpRequestMessage();
                    req.Headers.Add("x-zumo-auth", authToken);

                    var request = System.Web.HttpContext.Current.Request;


                    if (authToken != null)
                    {
                        var token = new JwtSecurityToken(authToken);

                        var userId = token.Claims.FirstOrDefault(m => m.Type == "sub").Value;

                        //MicrosoftAccountCredentials microsoftAccount = Task.Run(() => user.GetAppServiceIdentityAsync<MicrosoftAccountCredentials>(req)).Result;
                        //var userId = microsoftAccount.Provider + ":" + microsoftAccount.Claims["urn:microsoftaccount:id"].ToString();

                        var companyId = request.QueryString["cid"];

                        if (userId != null && companyId != null)
                        {
                            //Change below to add the CompanyID
                            //Set SESSION_CONTEXT to current UserId before executing queries
                            var sql = "EXEC sp_set_session_context @key=N'UserId', @value=@UserId; EXEC sp_set_session_context @key=N'CompanyId', @value=@CompanyId;";
                            command.CommandText = sql + command.CommandText;
                            command.Parameters.Insert(0, new SqlParameter("@UserId", userId));
                            command.Parameters.Insert(1, new SqlParameter("@CompanyId", companyId));
                        }
                        else if (userId != null)
                        {
                            var sql = "EXEC sp_set_session_context @key=N'UserId', @value=@UserId;";
                            command.CommandText = sql + command.CommandText;
                            command.Parameters.Insert(0, new SqlParameter("@UserId", userId));
                        }
                    }
                }
            }
            catch (System.NullReferenceException)
            {
                // If no user is logged in, leave SESSION_CONTEXT null (all rows will be filtered)
            }
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            this.SetSessionContext(command);
        }
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {

        }
        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            try
            {
                this.SetSessionContext(command);
            }
            catch (Exception ex)
            {

            }
        }
        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {

        }
        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            this.SetSessionContext(command);
        }
        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {

        }
    }

    public class SessionContextConfiguration : DbConfiguration
    {
        public SessionContextConfiguration()
        {
            //var current = System.Web.HttpContext.Current;
            //var request = current.Request;


            //This line adds the interceptor
            AddInterceptor(new SessionContextInterceptor());
        }
    }
}