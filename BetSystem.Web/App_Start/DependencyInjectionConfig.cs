[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BetSystem.Web.App_Start.DependencyInjectionConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BetSystem.Web.App_Start.DependencyInjectionConfig), "Stop")]

namespace BetSystem.Web.App_Start
{
    using AutoMapper;
    using BetSystem.Data;
    using BetSystem.Data.Contracts;
    using BetSystem.Data.Models;
    using BetSystem.Data.Repositories;
    using BetSystem.Services;
    using BetSystem.Services.Contracts;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public static class DependencyInjectionConfig
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
                //kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                //kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
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
            kernel.Bind<IDbContext>().To<MsSqlDbContext>().InRequestScope();
            //kernel.Bind<ISaveChanges>().To<SaveChanges>();

            kernel.Bind<IMapper>().ToMethod(ctx => Mapper.Instance).InSingletonScope();
            kernel.Bind<IEventService>().To<EventService>();
            kernel.Bind(typeof(IGenericRepository<Event>)).To(typeof(EventRepository));



        }
    }
}