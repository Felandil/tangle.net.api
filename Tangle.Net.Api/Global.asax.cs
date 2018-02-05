namespace Tangle.Net.Api
{
  using System.Web;
  using System.Web.Http;

  /// <summary>
  /// The web api application.
  /// </summary>
  public class WebApiApplication : HttpApplication
  {
    #region Methods

    /// <summary>
    /// The application_ start.
    /// </summary>
    protected void Application_Start()
    {
      GlobalConfiguration.Configure(RegisterRoutes);
      GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
    }

    /// <summary>
    /// The register routes.
    /// </summary>
    /// <param name="configuration">
    /// The configuration.
    /// </param>
    private static void RegisterRoutes(HttpConfiguration configuration)
    {
      configuration.MapHttpAttributeRoutes();
    }

    #endregion
  }
}