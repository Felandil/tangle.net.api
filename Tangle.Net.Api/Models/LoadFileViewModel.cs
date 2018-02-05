namespace Tangle.Net.Api.Models
{
  using System.Collections.Generic;

  using Felandil.CleanArchitecture;

  /// <summary>
  /// The load file view model.
  /// </summary>
  public class LoadFileViewModel : IViewModel
  {
    #region Public Properties

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    public IEnumerable<byte> Data { get; set; }

    #endregion
  }
}