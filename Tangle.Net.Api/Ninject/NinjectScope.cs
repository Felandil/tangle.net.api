namespace Tangle.Net.Api.Ninject
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web.Http.Dependencies;

  using global::Ninject.Parameters;
  using global::Ninject.Syntax;

  /// <summary>
  /// The ninject scope.
  /// </summary>
  public class NinjectScope : IDependencyScope
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="NinjectScope"/> class.
    /// </summary>
    /// <param name="kernel">
    /// The kernel.
    /// </param>
    public NinjectScope(IResolutionRoot kernel)
    {
      this.ResolutionRoot = kernel;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the resolution root.
    /// </summary>
    private IResolutionRoot ResolutionRoot { get; set; }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// The dispose.
    /// </summary>
    public void Dispose()
    {
      var disposable = (IDisposable)this.ResolutionRoot;
      if (disposable != null)
      {
        disposable.Dispose();
      }

      this.ResolutionRoot = null;
    }

    /// <summary>
    /// The get service.
    /// </summary>
    /// <param name="serviceType">
    /// The service type.
    /// </param>
    /// <returns>
    /// The <see cref="object"/>.
    /// </returns>
    public object GetService(Type serviceType)
    {
      var request = this.ResolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
      return this.ResolutionRoot.Resolve(request).SingleOrDefault();
    }

    /// <summary>
    /// The get services.
    /// </summary>
    /// <param name="serviceType">
    /// The service type.
    /// </param>
    /// <returns>
    /// The <see cref="IEnumerable"/>.
    /// </returns>
    public IEnumerable<object> GetServices(Type serviceType)
    {
      var request = this.ResolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
      return this.ResolutionRoot.Resolve(request).ToList();
    }

    #endregion
  }
}