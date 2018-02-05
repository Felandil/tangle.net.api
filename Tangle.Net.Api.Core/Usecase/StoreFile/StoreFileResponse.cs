namespace Tangle.Net.Api.Core.Usecase.StoreFile
{
  using Felandil.CleanArchitecture;

  /// <summary>
  /// The store file response.
  /// </summary>
  public class StoreFileResponse : IResponseBoundry
  {
    #region Public Properties

    /// <summary>
    /// Gets or sets the bundle hash.
    /// </summary>
    public string TailTransactionHash { get; set; }

    #endregion
  }
}