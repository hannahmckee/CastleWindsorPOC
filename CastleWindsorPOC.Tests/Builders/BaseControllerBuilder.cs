using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;

namespace CastleWindsorPOC.Tests.Builders
{
    internal abstract class BaseControllerBuilder<T> where T: BaseControllerBuilder<T>, new()
    {
        protected HttpConfiguration _configuration;
        protected HttpRouteData _routeData;
        protected HttpRequestMessage _requestMessage;

        protected BaseControllerBuilder()
        {
            _configuration = new HttpConfiguration();
            _routeData = new HttpRouteData(new HttpRoute());
            _requestMessage = new HttpRequestMessage();
        }

        protected T WithHttpConfiguration(HttpConfiguration configuraion)
        {
            _configuration = configuraion;
            return (T)this;
        }

        protected T WithHttpRouteData(HttpRouteData routeData)
        {
            _routeData = routeData;
            return (T)this;
        }

        protected T WithHttpRequestMessage(HttpRequestMessage requestMessage)
        {
            _requestMessage = requestMessage;
            return (T)this;
        }

        protected Y BuildControllerProperties<Y>(Y controller) where Y : ApiController
        {
            controller.ControllerContext = new HttpControllerContext(_configuration, _routeData, _requestMessage);
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = _configuration;

            return controller;
        }
    }
}
