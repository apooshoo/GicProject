using Autofac;
using GicBackend.Services.CafeServices;
using GicBackend.Services.DbServices;

namespace GicBackend.Services.AutofacServices
{
    public static class CafeRegistrar
    {
        public static ILifetimeScope GetModules()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance<IConfiguration>(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build());
            builder.RegisterType<DbHelper>().As<IDbHelper>();
            builder.RegisterType<CafeProvider>().As<ICafeProvider>();
            var container = builder.Build();
            return container.BeginLifetimeScope();
        }
    }
}
