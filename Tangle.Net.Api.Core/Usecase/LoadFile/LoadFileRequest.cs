namespace Tangle.Net.Api.Core.Usecase.LoadFile
{
  using Felandil.CleanArchitecture;

  /// <summary>
  /// The load file request.
  /// </summary>
  public class LoadFileRequest : IRequestBoundry
  {
    #region Public Properties

    /// <summary>
    /// Gets or sets the bundle hash.
    /// </summary>
    public string TailTransactionHash { get; set; }

    #endregion
  }
}