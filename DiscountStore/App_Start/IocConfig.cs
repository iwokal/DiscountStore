using Autofac;
using Autofac.Integration.WebApi;
using DiscountStore.Areas.Cart.Services;
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
            builder.RegisterType<CartService>().As<ICartService>();
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}
