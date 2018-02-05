namespace Tangle.Net.Api.Core.Usecase.StoreFile
{
  using System.Collections.Generic;

  using Felandil.CleanArchitecture;

  /// <summary>
  /// The store file request.
  /// </summary>
  public class StoreFileRequest : IRequestBoundry
  {
    #region Public Properties

    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    public IEnumerable<byte> Data { get; set; }

    #endregion
  }
}