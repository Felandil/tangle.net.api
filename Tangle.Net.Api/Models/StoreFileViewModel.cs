namespace Tangle.Net.Api.Models
{
  using Felandil.CleanArchitecture;

  /// <summary>
  /// The view model base.
  /// </summary>
  public class StoreFileViewModel : IViewModel
  {
    public string TailTransactionHash { get; set; }
  }
}