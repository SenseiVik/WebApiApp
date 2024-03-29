[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApiApp.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebApiApp.App_Start.NinjectWebCommon), "Stop")]

namespace WebApiApp.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using System.Web.Http;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Ninject.Web.WebApi;
    using WebApiApp.BOL.DTO;
    using WebApiApp.BOL.Service.Interfaces;
    using WebApiApp.BOL.Service.Mappers;
    using WebApiApp.BOL.Service.Services;
    using WebApiApp.DAL.Context;
    using WebApiApp.DAL.Entities;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEntityService<DateRangeDTO>>().To<DateRangeDTOService>();
            kernel.Bind<IEntityService<LogDTO>>().To<LogDTOService>();
            kernel.Bind<IMapper<Log, LogDTO>>().To<LogMapper>();
            kernel.Bind<IMapper<DateRange, DateRangeDTO>>().To<DateRangeMapper>();
            kernel.Bind<DbContext>().To<WebApiAppContext>();
        }        
    }
}