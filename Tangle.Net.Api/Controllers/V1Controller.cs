namespace Tangle.Net.Api.Controllers
{
  using System.Linq;
  using System.Net;
  using System.Net.Http;
  using System.Net.Http.Headers;
  using System.Threading.Tasks;
  using System.Web.Http;

  using Tangle.Net.Api.Core.Usecase.LoadFile;
  using Tangle.Net.Api.Core.Usecase.StoreFile;
  using Tangle.Net.Api.Models;

  /// <summary>
  /// The v 1 controller.
  /// </summary>
  public class V1Controller : ApiController
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="V1Controller"/> class.
    /// </summary>
    /// <param name="storeFileInteractor">
    /// The store file interactor.
    /// </param>
    /// <param name="loadFileInteractor">
    /// The load File Interactor.
    /// </param>
    public V1Controller(StoreFileInteractor<StoreFileViewModel> storeFileInteractor, LoadFileInteractor<LoadFileViewModel> loadFileInteractor)
    {
      this.StoreFileInteractor = storeFileInteractor;
      this.LoadFileInteractor = loadFileInteractor;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the load file interactor.
    /// </summary>
    private LoadFileInteractor<LoadFileViewModel> LoadFileInteractor { get; set; }

    /// <summary>
    /// Gets or sets the store file interactor.
    /// </summary>
    private StoreFileInteractor<StoreFileViewModel> StoreFileInteractor { get; set; }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// The load file from tangle.
    /// </summary>
    /// <param name="tailTransactionHash">
    /// The tail transaction hash.
    /// </param>
    /// <returns>
    /// The <see cref="Task"/>.
    /// </returns>
    [HttpGet]
    [Route("v1/files/{tailTransactionHash}")]
    public async Task<HttpResponseMessage> LoadFileFromTangle([FromUri] string tailTransactionHash)
    {
      this.LoadFileInteractor.Execute(new LoadFileRequest { TailTransactionHash = tailTransactionHash });
      var data = this.LoadFileInteractor.Presenter.Present().Data;

      var result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(data.ToArray()) };
      result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = tailTransactionHash + ".jpg" };
      result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

      return result;
    }

    /// <summary>
    /// The get articles by category.
    /// </summary>
    /// <param name="address">
    /// The address.
    /// </param>
    /// <returns>
    /// The <see cref="IHttpActionResult"/>.
    /// </returns>
    [HttpPost]
    [Route("v1/store/{address}")]
    public async Task<IHttpActionResult> StoreFileOnTangle([FromUri] string address)
    {
      var data = await this.Request.Content.ReadAsByteArrayAsync();
      this.StoreFileInteractor.Execute(new StoreFileRequest { Address = address, Data = data });
      return this.Ok(this.StoreFileInteractor.Presenter.Present());
    }

    #endregion
  }
}