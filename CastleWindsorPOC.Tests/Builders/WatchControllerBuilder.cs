using CastleWindsorPOC.Controllers;
using CastleWindsorPOC.Domain.Interfaces;
using Moq;

namespace CastleWindsorPOC.Tests.Builders
{
    internal sealed class WatchControllerBuilder : BaseControllerBuilder<WatchControllerBuilder>
    {
        private IWatchService _watchService;

        public WatchControllerBuilder()
        {
            _watchService = new Mock<IWatchService>().Object;
        }

        public WatchControllerBuilder WithWatchService(IWatchService watchService)
        {
            _watchService = watchService;
            return this;
        }

        public WatchController Build()
        {
            var controller = new WatchController(_watchService);
            controller = BuildControllerProperties(controller);

            return controller;
        }
    }
}
