namespace Tangle.Net.Api.Core.Usecase.StoreFile
{
  using Felandil.CleanArchitecture;

  using Tangle.Net.Entity;
  using Tangle.Net.Repository;
  using Tangle.Net.Utils;

  /// <summary>
  /// The store file interactor.
  /// </summary>
  /// <typeparam name="TViewModel">
  /// The view model
  /// </typeparam>
  public class StoreFileInteractor<TViewModel> : UsecaseInteractor<StoreFileRequest, StoreFileResponse, TViewModel>
    where TViewModel : IViewModel
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="StoreFileInteractor{TViewModel}"/> class.
    /// </summary>
    /// <param name="presenter">
    /// The presenter.
    /// </param>
    /// <param name="iotaRepository">
    /// The iota Repository.
    /// </param>
    public StoreFileInteractor(UsecasePresenter<StoreFileResponse, TViewModel> presenter, IIotaExtendedRepository iotaRepository)
      : base(presenter)
    {
      this.IotaRepository = iotaRepository;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the iota repository.
    /// </summary>
    private IIotaExtendedRepository IotaRepository { get; set; }

    #endregion

    #region Methods

    /// <summary>
    /// The action.
    /// </summary>
    /// <param name="request">
    /// The request.
    /// </param>
    /// <returns>
    /// The <see cref="StoreFileResponse"/>.
    /// </returns>
    protected override StoreFileResponse Action(StoreFileRequest request)
    {
      var message = request.Data.ToTrytes();
      var bundle = new Bundle();
      bundle.AddTransfer(
        new Transfer
          {
            Address = new Address(request.Address), 
            Message = message, 
            Tag = new Tag("CSHARPFILES"), 
            Timestamp = Timestamp.UnixSecondsTimestamp
          });

      bundle.Finalize();
      bundle.Sign();

      var sentTransactionTrytes = this.IotaRepository.SendTrytes(bundle.Transactions, 27, 14);
      var tailTransaction = Transaction.FromTrytes(sentTransactionTrytes[0]);

      return new StoreFileResponse { TailTransactionHash = tailTransaction.Hash.Value };
    }

    #endregion
  }
}