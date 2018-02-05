namespace Tangle.Net.Api.Ninject
{
  using System.Configuration;

  using Felandil.CleanArchitecture;

  using global::Ninject;
  using global::Ninject.Modules;

  using RestSharp;

  using Tangle.Net.Api.Core.Repository;
  using Tangle.Net.Api.Core.Usecase.LoadFile;
  using Tangle.Net.Api.Core.Usecase.StoreFile;
  using Tangle.Net.Api.Models;
  using Tangle.Net.Api.Presenters;
  using Tangle.Net.ProofOfWork;
  using Tangle.Net.Repository;

  /// <summary>
  /// The api ninject module.
  /// </summary>
  public class ApiNinjectModule : NinjectModule
  {
    #region Public Methods and Operators

    /// <summary>
    /// The load.
    /// </summary>
    public override void Load()
    {
      this.Bind<IRestClient>().ToConstructor(c => new RestClient("https://localhost:14265"));

      this.Bind<IPoWDiver>().To<CpuPowDiver>();
      this.Bind<PoWService>().To<PoWService>().WithConstructorArgument("powDiver", this.Kernel.Get<IPoWDiver>());

      this.Bind<IIotaExtendedRepository>().To<RestIotaRepository>()
        .WithConstructorArgument("client", this.Kernel.Get<IRestClient>())
        .WithConstructorArgument("powService", this.Kernel.Get<PoWService>());

      this.Bind<UsecasePresenter<StoreFileResponse, StoreFileViewModel>>().To<StoreFilePresenter>();
      this.Bind<StoreFileInteractor<StoreFileViewModel>>()
        .To<StoreFileInteractor<StoreFileViewModel>>()
        .WithConstructorArgument("presenter", this.Kernel.Get<UsecasePresenter<StoreFileResponse, StoreFileViewModel>>())
        .WithConstructorArgument("iotaRepository", this.Kernel.Get<IIotaExtendedRepository>());

      this.Bind<UsecasePresenter<LoadFileResponse, LoadFileViewModel>>().To<LoadFilePresenter>();
      this.Bind<LoadFileInteractor<LoadFileViewModel>>()
        .To<LoadFileInteractor<LoadFileViewModel>>()
        .WithConstructorArgument("presenter", this.Kernel.Get<UsecasePresenter<LoadFileResponse, LoadFileViewModel>>())
        .WithConstructorArgument("iotaRepository", this.Kernel.Get<IIotaExtendedRepository>());
    }

    #endregion
  }
}