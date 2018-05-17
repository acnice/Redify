using KnockKnock.Readify.Services;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace KnockKnock.Readify.Controllers
{
    public class RedifyAPIController : ApiController
    {
        private IAPIRepository apiRepository;

        public RedifyAPIController()
        {
            apiRepository = new ApiRepository();
        }

        /// <summary>
        /// Populates the nth Fibonacci number.
        /// </summary>
        [Route("api/Fibonacci")]
        [HttpGet]
        public async Task<IHttpActionResult> Fibonacci(int n)
        {
            if (!ModelState.IsValid)
            {
                //Throw Bad request if the request is not valid.
                return  BadRequest();
            }

            if (n > 92 || n < -92)
            {
                //If the nth position lay out of the scope then return a bad request error using custom message result.
                return new CustomMessageResult("no content", HttpStatusCode.BadRequest);
            }

            var result = await apiRepository.CalculateFibonacciNumber(n);

            return new CachedResult<long>(result, TimeSpan.FromSeconds(600), this);
        }

        /// <summary>
        /// Reverse order of the given word
        /// </summary>
        [Route("api/ReverseWords")]
        [HttpGet]
        public async Task<IHttpActionResult> ReverseWords(string sentence)
        {
            if (!ModelState.IsValid)
            {
                //Throw Bad request if the request is not valid.
                return BadRequest();
            }

            var result = await apiRepository.ReverseWords(sentence);
            return new CachedResult<string>(result, TimeSpan.FromSeconds(600), this);
        }


        /// <summary>
        /// Determine the shape of a triangle by side lengths.
        /// </summary>
        /// <returns></returns>
        [Route("api/TriangleType")]
        [HttpGet]
        public async Task<IHttpActionResult> TriangleType(int a, int b, int c)
        {
            if (!ModelState.IsValid)
            {
                //Throw Bad request if the request is not valid.
                return BadRequest();
            }

            var result = await apiRepository.DetermineTriangleType(a, b, c);
            return new CachedResult<string>(result, TimeSpan.FromSeconds(600), this);
        }

        /// <summary>
        /// My Token
        /// </summary>
        /// <returns></returns>
        [Route("api/Token")]
        [HttpGet]
        public async Task<IHttpActionResult> Token()
        {
            if (!ModelState.IsValid)
            {
                //Throw Bad request if the request is not valid.
                return BadRequest();
            }

            string tocken = await Task.FromResult("8af4e5ca-52f9-4509-8781-42c0f1fcbb42");
            return new CachedResult<string>(tocken, TimeSpan.FromSeconds(600), this);
        }
    }
}
