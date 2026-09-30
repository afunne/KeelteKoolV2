using KeelteKoolV2.Data;
using KeelteKoolV2.xUnitTesting.Macros;
using KeelteKoolV2.xUnitTesting.Mock;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KeelteKoolV2.xUnitTesting
{
    public abstract class TestBase : IDisposable
    {
        protected ServiceProvider serviceProvider { get; set; }

        protected TestBase()
        {
            var services = new ServiceCollection();
            SetupServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        public virtual void SetupServices(IServiceCollection services)
        {
            //teenused mida testitakse tulevad siia
            services.AddScoped<IHostEnvironment, MockIHostEnvironment>();

            //iga test saab oma mälus oleva andmebaasi, et testid üksteist ei segaks
            var databaseName = "TEST_" + Guid.NewGuid();
            services.AddDbContext<KeelteKoolV2Context>
                (x =>
                {
                    x.UseInMemoryDatabase(databaseName);
                    x.ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                }
                );
            RegisterMacros(services);
        }

        private void RegisterMacros(IServiceCollection services)
        {
            var macroBaseType = typeof(IMacros);

            var macros = macroBaseType.Assembly.GetTypes()
                .Where(t => macroBaseType.IsAssignableFrom(t)
                && !t.IsInterface && !t.IsAbstract);
            foreach (var macro in macros)
            {
                services.AddSingleton(macro);
            }
        }

        public void Dispose()
        {
            serviceProvider.Dispose();
        }

        protected T Svc<T>() where T : notnull
        {
            return serviceProvider.GetRequiredService<T>();
        }
    }
}
