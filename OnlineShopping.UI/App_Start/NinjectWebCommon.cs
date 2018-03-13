[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(OnlineShopping.UI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(OnlineShopping.UI.App_Start.NinjectWebCommon), "Stop")]

namespace OnlineShopping.UI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Moq;
    using Bll.Abstract;
    using System.Collections.Generic;
    using Bll.Entites;
    using Bll.Concrete;

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
            //Mock<InterfaceProductRepository> mock = new Mock<InterfaceProductRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>
            //{
            //    new Product {ProductName = "Football", Price = 600 },
            //    new Product {ProductName = "T-Shirt", Price = 400 },
            //    new Product {ProductName = "Shoes", Price = 1500 },
            //    new Product {ProductName = "Beer", Price = 550 }

            //});
            //kernel.Bind<InterfaceProductRepository>().ToConstant(mock.Object);

            kernel.Bind<InterfaceProductRepository>().To<EFProductRepository>();

            kernel.Bind<InterfaceOrderProcessor>().To<EmailOrderProcessor>();

            kernel.Bind<InterfaceAdmistrator>().To<FormsAuthentication>();

        }        
    }
}
