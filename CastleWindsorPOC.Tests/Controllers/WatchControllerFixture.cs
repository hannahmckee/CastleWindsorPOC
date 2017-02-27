using System.Net;
using System.Threading;
using CastleWindsorPOC.Tests.Builders;
using CastleWindsorPOC.Tests.Mocks;
using NUnit.Framework;

namespace CastleWindsorPOC.Tests.Controllers
{
    [TestFixture]
    internal class WatchControllerFixture
    {
        [Test]
        public void ExceptionShouldBeThrownIfWatchServiceIsNull()
        {
            CustomAssertimes.ArgumentNullExceptionIsThrown(() =>
            {
                new WatchControllerBuilder()
                    .WithWatchService(null)
                    .Build();
            }, "watchService");
        }

        [Test]
        public void CorrectDateShouldBeReturned()
        {
            var mockWatchService = new MockWatchService()
                .WithCurrentDate("TestDate")
                .Build();

            var controller = new WatchControllerBuilder()
                .WithWatchService(mockWatchService.Object)
                .Build();

            var response = controller.GetTime().ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("\"TestDate\"", response.Content.ReadAsStringAsync().Result);
        }
    }
}
