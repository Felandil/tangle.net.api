namespace Tangle.Net.Api.Presenters
{
  using Felandil.CleanArchitecture;

  using Tangle.Net.Api.Core.Usecase.StoreFile;
  using Tangle.Net.Api.Models;

  /// <summary>
  /// The store file presenter.
  /// </summary>
  public class StoreFilePresenter : UsecasePresenter<StoreFileResponse, StoreFileViewModel>
  {
    #region Public Methods and Operators

    /// <summary>
    /// The present.
    /// </summary>
    /// <returns>
    /// The <see cref="StoreFileViewModel"/>.
    /// </returns>
    public override StoreFileViewModel Present()
    {
      return new StoreFileViewModel { TailTransactionHash = this.Response.TailTransactionHash };
    }

    #endregion
  }
}