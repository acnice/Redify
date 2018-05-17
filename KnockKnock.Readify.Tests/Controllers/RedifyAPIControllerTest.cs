using KnockKnock.Readify.Controllers;
using KnockKnock.Readify.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace KnockKnock.Readify.Tests.Controllers
{
    [TestClass]
    public class RedifyAPIControllerTest
    {
        private RedifyAPIController controller;

        public RedifyAPIControllerTest()
        {
            controller = new RedifyAPIController();
        }

        [TestMethod]
        public async Task FibonacciPositiveTest()
        {
            var result = await controller.Fibonacci(0) as OkNegotiatedContentResult<long>;
            Assert.AreEqual(0, result.Content);

            result = await controller.Fibonacci(1) as OkNegotiatedContentResult<long>;
            Assert.AreEqual(1, result.Content);

            result = await controller.Fibonacci(2) as OkNegotiatedContentResult<long>;
            Assert.AreEqual(1, result.Content);

            result = await controller.Fibonacci(9) as OkNegotiatedContentResult<long>;
            Assert.AreEqual(34, result.Content);

            result = await controller.Fibonacci(92) as OkNegotiatedContentResult<long>;
            Assert.AreEqual(7540113804746369024, result.Content);
        }

        [TestMethod]
        public async Task FibonacciNegativeTest()
        {
            var result = await controller.Fibonacci(-1) as OkNegotiatedContentResult<long>;
            Assert.AreEqual(1, result.Content);

            result = await controller.Fibonacci(-2) as OkNegotiatedContentResult<long>;
            Assert.AreEqual(-1, result.Content);

            result = await controller.Fibonacci(-3) as OkNegotiatedContentResult<long>;
            Assert.AreEqual(2, result.Content);

           result = await controller.Fibonacci(-92) as OkNegotiatedContentResult<long>;
           Assert.AreEqual(-7540113804746369024, result.Content);
        }

        [TestMethod]
        public async Task FibonacciInvalidInputTest()
        {
            var NoContentResult = await controller.Fibonacci(93) as IHttpActionResult;
            Assert.IsInstanceOfType(NoContentResult, typeof(CustomMessageResult));
            Assert.AreEqual("no content", ((CustomMessageResult)NoContentResult).Message);
            Assert.AreEqual(HttpStatusCode.BadRequest, ((CustomMessageResult)NoContentResult).HttpStatusCode);
        }

        [TestMethod]
        public async Task RevereWordsTest()
        {
            var result = await controller.ReverseWords("abc") as OkNegotiatedContentResult<string>; ;
            Assert.AreEqual("cba", result.Content);

            result = await controller.ReverseWords("") as OkNegotiatedContentResult<string>; ;
            Assert.AreEqual("", result.Content);

            result = await controller.ReverseWords("  abc") as OkNegotiatedContentResult<string>; ;
            Assert.AreEqual("  cba", result.Content);

            result = await controller.ReverseWords("abc  ") as OkNegotiatedContentResult<string>; ;
            Assert.AreEqual("cba  ", result.Content);

            result = await controller.ReverseWords("  abc  ") as OkNegotiatedContentResult<string>; ;
            Assert.AreEqual("  cba  ", result.Content);
        }

        [TestMethod]
        public async Task TrangleTest()
        {
            var result = await controller.TriangleType(1,1,3) as OkNegotiatedContentResult<string>; ;
            Assert.AreEqual("Error", result.Content);

            result = await controller.TriangleType(3, 3, 3) as OkNegotiatedContentResult<string>; ;
            Assert.AreEqual("Equilateral", result.Content);

            result = await controller.TriangleType(3, 2, 3) as OkNegotiatedContentResult<string>; ;
            Assert.AreEqual("Isosceles", result.Content);

            result = await controller.TriangleType(3, 4, 5) as OkNegotiatedContentResult<string>; ;
            Assert.AreEqual("Scalene", result.Content);
        }
    }
}
