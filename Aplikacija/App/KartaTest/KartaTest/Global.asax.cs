using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Hangfire;
using Hangfire.SqlServer;
using KartaTest.Klase;

namespace KartaTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private IEnumerable<IDisposable> GetHangfireServers()
        {
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage("Server=.\\SQLEXPRESS; Database=HangfireTest; Integrated Security=True;", new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true
                });
            RecurringJob.RemoveIfExists("Prvi");
            RecurringJob.RemoveIfExists("Drugi");
            RecurringJob.RemoveIfExists("Treci");
            RecurringJob.RemoveIfExists("Cetverti");
            RecurringJob.RemoveIfExists("Peti");
            RecurringJob.RemoveIfExists("Sesti");
            RecurringJob.RemoveIfExists("Sedmi");
            RecurringJob.RemoveIfExists("Osmi");
            yield return new BackgroundJobServer();
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            HangfireAspNet.Use(GetHangfireServers);
            ApiDohvatPrognoza dohvat = new ApiDohvatPrognoza();
            var dretvaId = BackgroundJob.Enqueue(() => dohvat.ApiPriprema());
           
        }
        protected void Application_End(object sender, EventArgs e)
        {
            
        }
    }
}
