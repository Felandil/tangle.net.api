using Tangle.Net.Api;

using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace Tangle.Net.Api
{
  using System;
  using System.Collections.Generic;
  using System.Web;
  using System.Web.Http;

  using global::Ninject;
  using global::Ninject.Modules;
  using global::Ninject.Web.Common;
  using global::Ninject.Web.Common.WebHost;

  using Microsoft.Web.Infrastructure.DynamicModuleHelper;

  using Ninject;

  /// <summary>
  /// The ninject web common.
  /// </summary>
  public static class NinjectWebCommon
  {
    #region Static Fields

    /// <summary>
    /// The bootstrapper.
    /// </summary>
    private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// Starts the application
    /// </summary>
    public static void Start()
    {
      DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
      DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
      Bootstrapper.Initialize(CreateKernel);
    }

    /// <summary>
    /// Stops the application.
    /// </summary>
    public static void Stop()
    {
      Bootstrapper.ShutDown();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Creates the kernel that will manage your application.
    /// </summary>
    /// <returns>The created kernel.</returns>
    private static IKernel CreateKernel()
    {
      var kernel = new StandardKernel();
      kernel.Settings.AllowNullInjection = true;

      try
      {
        kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
        kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

        RegisterServices(kernel);
        GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
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
    /// <param name="kernel">
    /// The kernel.
    /// </param>
    private static void RegisterServices(IKernel kernel)
    {
      var modules = new List<NinjectModule> { new ApiNinjectModule() };
      kernel.Load(modules);
    }

    #endregion
  }
}