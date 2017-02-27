using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace CastleWindsorPOC.DependencyResolution
{
    internal sealed class WindsorDependencyScope : IDependencyScope
    {
        private readonly IWindsorContainer _container;
        private readonly IDisposable _scope;

        public WindsorDependencyScope(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            _container = container;
            _scope = container.BeginScope();
        }

        public object GetService(Type serviceType)
        {
            return _container.Kernel.HasComponent(serviceType)
                ? _container.Resolve(serviceType)
                : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ResolveAll(serviceType)
                .Cast<object>().ToArray();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}