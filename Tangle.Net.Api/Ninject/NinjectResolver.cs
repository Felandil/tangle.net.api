namespace Tangle.Net.Api.Ninject
{
  using System.Web.Http.Dependencies;

  using global::Ninject;

  /// <summary>
  /// The ninject resolver.
  /// </summary>
  public class NinjectResolver : NinjectScope, IDependencyResolver
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="NinjectResolver"/> class.
    /// </summary>
    /// <param name="kernel">
    /// The kernel.
    /// </param>
    public NinjectResolver(IKernel kernel)
      : base(kernel)
    {
      this.Kernel = kernel;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the kernel.
    /// </summary>
    private IKernel Kernel { get; set; }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// The begin scope.
    /// </summary>
    /// <returns>
    /// The <see cref="IDependencyScope"/>.
    /// </returns>
    public IDependencyScope BeginScope()
    {
      return new NinjectScope(this.Kernel.BeginBlock());
    }

    #endregion
  }
}