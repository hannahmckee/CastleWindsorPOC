using System;
using System.Web.Http;
using CastleWindsorPOC.Domain.Interfaces;

namespace CastleWindsorPOC.Controllers
{
    [RoutePrefix("watch")]
    public class WatchController : ApiController
    {
        private IWatchService _watchService;

        public WatchController(IWatchService watchService)
        {
            if (watchService == null)
            {
                throw new ArgumentNullException("watchService");
            }

            _watchService = watchService;
        }

        [HttpGet]
        [Route("time")]
        public IHttpActionResult GetTime()
        {
            return Ok(_watchService.GetTime());
        }
    }
}