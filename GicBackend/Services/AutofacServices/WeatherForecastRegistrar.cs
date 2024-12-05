using Autofac;
using GicBackend.DataObjects;
using GicBackend.Services.DbServices;

namespace GicBackend.Services.AutofacServices
{
    public static class WeatherForecastRegistrar
    {
        public static ILifetimeScope GetModules(Type recordType)
        {
            var builder = new ContainerBuilder();
            RegisterGenericModules(builder);
            RegisterSpecificModules(builder, recordType);
            var container = builder.Build();
            return container.BeginLifetimeScope();
        }

        private static void RegisterGenericModules(ContainerBuilder builder)
        {
            builder.RegisterInstance<IConfiguration>(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build());
            builder.RegisterType<DbHelper>().As<IDbHelper>();
            builder.RegisterType<RecordInserter>().As<IRecordInserter>();
        }
        private static void RegisterSpecificModules(ContainerBuilder builder, Type recordType)
        {
            if (recordType == typeof(Cafe))
            {
                builder.RegisterType<CafeSeeder>().As<IDbSeeder>();
            }
            else if (recordType == typeof(Employee))
            {
                builder.RegisterType<EmployeeSeeder>().As<IDbSeeder>();
            }
        }
    }
}
