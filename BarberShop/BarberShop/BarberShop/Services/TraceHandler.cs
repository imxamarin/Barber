using InstaBiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BarberShop.Services
{
    public class TraceHandler : DelegatingHandler
    {
        Company c;

        public TraceHandler(Company cin)
        {
            c = cin;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri.Query == null || request.RequestUri.Query == "")
            {
                string param = string.Format("?cid={0}", c.Id);
                request.RequestUri = new Uri(request.RequestUri + param);
            }
            else
            {
                string param = string.Format("&cid={0}", c.Id);
                request.RequestUri = new Uri(request.RequestUri.ToString() + param);
            }

            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }
}
