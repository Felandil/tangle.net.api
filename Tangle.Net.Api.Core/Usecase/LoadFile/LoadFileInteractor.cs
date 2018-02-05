namespace Tangle.Net.Api.Core.Usecase.LoadFile
{
  using System.Linq;

  using Felandil.CleanArchitecture;

  using Tangle.Net.Entity;
  using Tangle.Net.Repository;

  /// <summary>
  /// The load file interactor.
  /// </summary>
  /// <typeparam name="TViewModel">
  /// The view Model
  /// </typeparam>
  public class LoadFileInteractor<TViewModel> : UsecaseInteractor<LoadFileRequest, LoadFileResponse, TViewModel>
    where TViewModel : IViewModel
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="LoadFileInteractor{TViewModel}"/> class.
    /// </summary>
    /// <param name="presenter">
    /// The presenter.
    /// </param>
    /// <param name="repository">
    /// The repository.
    /// </param>
    public LoadFileInteractor(UsecasePresenter<LoadFileResponse, TViewModel> presenter, IIotaExtendedRepository repository)
      : base(presenter)
    {
      this.Repository = repository;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the repository.
    /// </summary>
    private IIotaExtendedRepository Repository { get; set; }

    #endregion

    #region Methods

    /// <summary>
    /// The action.
    /// </summary>
    /// <param name="request">
    /// The request.
    /// </param>
    /// <returns>
    /// The <see cref="LoadFileResponse"/>.
    /// </returns>
    protected override LoadFileResponse Action(LoadFileRequest request)
    {
      var bundle = this.Repository.GetBundle(new Hash(request.TailTransactionHash));
      bundle.Validate();

      var dataAsTrytes = new TryteString(bundle.Transactions.Aggregate(string.Empty, (current, transaction) => current + transaction.Fragment.Value));

      return new LoadFileResponse { Data = dataAsTrytes.ToBytes() };
    }

    #endregion
  }
}