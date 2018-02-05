namespace Tangle.Net.Api.Core.Usecase.LoadFile
{
  using System.Collections.Generic;

  using Felandil.CleanArchitecture;

  /// <summary>
  /// The load file response.
  /// </summary>
  public class LoadFileResponse : IResponseBoundry
  {
    #region Public Properties

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    public IEnumerable<byte> Data { get; set; }

    #endregion
  }
}