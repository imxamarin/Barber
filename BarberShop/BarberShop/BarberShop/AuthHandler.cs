
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace BarberShop
{
    class AuthHandler : DelegatingHandler
    {
        static private bool InvokeLogin = false;
        static private bool Refreshed = false;
        public IMobileServiceClient Client { get; set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (this.Client == null)
            {
                throw new InvalidOperationException("Make sure to set the 'Client' property in this handler before using it.");
            }

            // Cloning the request, in case we need to send it again
            var clonedRequest = await CloneRequest(request);
            var response = await base.SendAsync(clonedRequest, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // Oh no! user is not logged in - we got a 401
                // Log them in, this time hardcoded with MicrosoftAccount but you would
                // trigger the login presentation in your application
                try
                {

                    if (InvokeLogin == false)
                    {
                        Refreshed = false;
                        InvokeLogin = true;

                        JObject refreshJson = (JObject)await this.Client.InvokeApiAsync(
               "/.auth/refresh",
               HttpMethod.Get,
               null);

                        string newToken = refreshJson["authenticationToken"].Value<string>();

                        Client.CurrentUser.MobileServiceAuthenticationToken = newToken;
                        PlatformAdapter.Current.Identity.AzureUser.MobileServiceAuthenticationToken = newToken;
                        Refreshed = true;

                        clonedRequest = await CloneRequest(request);

                        //refreshed = await AzureMobileServices.RefreshToken();

                        //PlatformAdapter.Current.Identity.AzureUser.MobileServiceAuthenticationToken = newToken;
                        PlatformAdapter.Current.Identity.SetAsDefaultCredentials();

                        clonedRequest.Headers.Remove("X-ZUMO-AUTH");
                        // Set the authentication header
                        clonedRequest.Headers.Add("X-ZUMO-AUTH", newToken);

                        // Resend the request
                        response = await base.SendAsync(clonedRequest, cancellationToken);
                    }

                    if (!Refreshed)
                    {
                        //AzureMobileServices.ResetMobileService();
                        var user = await this.Client.LoginAsync(MobileServiceAuthenticationProvider.MicrosoftAccount, null);
                        // we're now logged in again.

                        // Clone the request
                        clonedRequest = await CloneRequest(request);


                        PlatformAdapter.Current.Identity.AzureUser.UserId = user.UserId;
                        PlatformAdapter.Current.Identity.AzureUser.MobileServiceAuthenticationToken = user.MobileServiceAuthenticationToken;
                        PlatformAdapter.Current.Identity.SetAsDefaultCredentials();

                        clonedRequest.Headers.Remove("X-ZUMO-AUTH");
                        // Set the authentication header
                        clonedRequest.Headers.Add("X-ZUMO-AUTH", user.MobileServiceAuthenticationToken);

                        // Resend the request
                        response = await base.SendAsync(clonedRequest, cancellationToken);
                        InvokeLogin = false;
                        Refreshed = true;
                    }
                }
                catch (InvalidOperationException)
                {
                    // user cancelled auth, so let’s return the original response
                    InvokeLogin = false;
                    return response;
                }
                catch (Exception ex)
                {
                    InvokeLogin = false;
                    return null;
                }
            }

            return response;
        }

        private async Task<HttpRequestMessage> CloneRequest(HttpRequestMessage request)
        {
            var result = new HttpRequestMessage(request.Method, request.RequestUri);
            foreach (var header in request.Headers)
            {
                result.Headers.Add(header.Key, header.Value);
            }

            if (request.Content != null && request.Content.Headers.ContentType != null)
            {
                var requestBody = await request.Content.ReadAsStringAsync();
                var mediaType = request.Content.Headers.ContentType.MediaType;
                result.Content = new StringContent(requestBody, Encoding.UTF8, mediaType);
                foreach (var header in request.Content.Headers)
                {
                    if (!header.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
                    {
                        result.Content.Headers.Add(header.Key, header.Value);
                    }
                }
            }

            return result;
        }
    }
}
