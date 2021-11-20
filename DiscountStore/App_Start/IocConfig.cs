using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;

namespace DiscountStore
{
    public static class IocConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}
