using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace KnockKnock.Readify.Services
{
    /// <summary>
    /// Create custom message results
    /// </summary>
    public class CustomMessageResult : IHttpActionResult
    {
        public string Message { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }

        public CustomMessageResult(string message, HttpStatusCode httpStatusCode)
        {
            this.Message = message;
            this.HttpStatusCode = httpStatusCode;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode);
            response.Content = new StringContent(Message);
            return Task.FromResult(response);
        }
    }
}