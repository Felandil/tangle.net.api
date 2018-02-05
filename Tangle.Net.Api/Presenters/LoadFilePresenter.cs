namespace Tangle.Net.Api.Presenters
{
  using Felandil.CleanArchitecture;

  using Tangle.Net.Api.Core.Usecase.LoadFile;
  using Tangle.Net.Api.Models;

  /// <summary>
  /// The load file presenter.
  /// </summary>
  public class LoadFilePresenter : UsecasePresenter<LoadFileResponse, LoadFileViewModel>
  {
    #region Public Methods and Operators

    /// <summary>
    /// The present.
    /// </summary>
    /// <returns>
    /// The <see cref="LoadFileViewModel"/>.
    /// </returns>
    public override LoadFileViewModel Present()
    {
      return new LoadFileViewModel { Data = this.Response.Data };
    }

    #endregion
  }
}