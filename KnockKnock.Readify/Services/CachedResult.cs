using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace KnockKnock.Readify.Services
{
    public class CachedResult<T> : OkNegotiatedContentResult<T>
    {
        public CachedResult(T content, TimeSpan howLong, ApiController controller) : base(content, controller)
        {
            HowLong = howLong;
        }

        public CachedResult(T content, IContentNegotiator contentNegotiator, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
        : base(content, contentNegotiator, request, formatters) { }

        public TimeSpan HowLong { get; private set; }


        public override async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = await base.ExecuteAsync(cancellationToken);
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                Public = false,
                MaxAge = HowLong
            };

            return response;
        }
    }
}