using Autofac;
using GicBackend.Services.DbServices;
using GicBackend.Services.EmployeeServices;

namespace GicBackend.Services.AutofacServices
{
    public static class EmployeeRegistrar
    {
        public static ILifetimeScope GetModules()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance<IConfiguration>(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build());
            builder.RegisterType<DbHelper>().As<IDbHelper>();
            builder.RegisterType<EmployeeProvider>().As<IEmployeeProvider>();
            var container = builder.Build();
            return container.BeginLifetimeScope();
        }
    }
}
