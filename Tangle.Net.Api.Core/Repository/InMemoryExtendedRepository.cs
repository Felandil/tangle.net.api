namespace Tangle.Net.Api.Core.Repository
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  using Tangle.Net.Entity;
  using Tangle.Net.Repository;
  using Tangle.Net.Repository.DataTransfer;
  using Tangle.Net.Repository.Responses;

  /// <summary>
  /// The in memory extended repository.
  /// </summary>
  public class InMemoryExtendedRepository : IIotaExtendedRepository
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="InMemoryExtendedRepository"/> class.
    /// </summary>
    public InMemoryExtendedRepository()
    {
      this.CurrentTransactions = new List<Transaction>();
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the current transactions.
    /// </summary>
    private List<Transaction> CurrentTransactions { get; set; }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// The broadcast and store transactions.
    /// </summary>
    /// <param name="transactions">
    /// The transactions.
    /// </param>
    public void BroadcastAndStoreTransactions(List<TransactionTrytes> transactions)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// The find used addresses with transactions.
    /// </summary>
    /// <param name="seed">
    /// The seed.
    /// </param>
    /// <param name="securityLevel">
    /// The security level.
    /// </param>
    /// <param name="start">
    /// The start.
    /// </param>
    /// <returns>
    /// The <see cref="FindUsedAddressesResponse"/>.
    /// </returns>
    public FindUsedAddressesResponse FindUsedAddressesWithTransactions(Seed seed, int securityLevel, int start)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// The get account data.
    /// </summary>
    /// <param name="seed">
    /// The seed.
    /// </param>
    /// <param name="includeInclusionStates">
    /// The include inclusion states.
    /// </param>
    /// <param name="securityLevel">
    /// The security level.
    /// </param>
    /// <param name="addressStartIndex">
    /// The address start index.
    /// </param>
    /// <param name="addressStopIndex">
    /// The address stop index.
    /// </param>
    /// <returns>
    /// The <see cref="GetAccountDataResponse"/>.
    /// </returns>
    public GetAccountDataResponse GetAccountData(
      Seed seed, 
      bool includeInclusionStates, 
      int securityLevel, 
      int addressStartIndex, 
      int addressStopIndex = 0)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// The get bundle.
    /// </summary>
    /// <param name="transactionHash">
    /// The transaction hash.
    /// </param>
    /// <returns>
    /// The <see cref="Bundle"/>.
    /// </returns>
    public Bundle GetBundle(Hash transactionHash)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// The get bundles.
    /// </summary>
    /// <param name="transactionHashes">
    /// The transaction hashes.
    /// </param>
    /// <param name="includeInclusionStates">
    /// The include inclusion states.
    /// </param>
    /// <returns>
    /// The <see cref="List"/>.
    /// </returns>
    public List<Bundle> GetBundles(IEnumerable<Hash> transactionHashes, bool includeInclusionStates)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// The get inputs.
    /// </summary>
    /// <param name="seed">
    /// The seed.
    /// </param>
    /// <param name="threshold">
    /// The threshold.
    /// </param>
    /// <param name="securityLevel">
    /// The security level.
    /// </param>
    /// <param name="startIndex">
    /// The start index.
    /// </param>
    /// <param name="stopIndex">
    /// The stop index.
    /// </param>
    /// <returns>
    /// The <see cref="GetInputsResponse"/>.
    /// </returns>
    public GetInputsResponse GetInputs(Seed seed, long threshold, int securityLevel, int startIndex, int stopIndex = 0)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// The get latest inclusion.
    /// </summary>
    /// <param name="hashes">
    /// The hashes.
    /// </param>
    /// <returns>
    /// The <see cref="InclusionStates"/>.
    /// </returns>
    public InclusionStates GetLatestInclusion(List<Hash> hashes)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// The get new addresses.
    /// </summary>
    /// <param name="seed">
    /// The seed.
    /// </param>
    /// <param name="addressStartIndex">
    /// The address start index.
    /// </param>
    /// <param name="count">
    /// The count.
    /// </param>
    /// <param name="securityLevel">
    /// The security level.
    /// </param>
    /// <returns>
    /// The <see cref="List"/>.
    /// </returns>
    public List<Address> GetNewAddresses(Seed seed, int addressStartIndex, int count, int securityLevel)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// The get transfers.
    /// </summary>
    /// <param name="seed">
    /// The seed.
    /// </param>
    /// <param name="securityLevel">
    /// The security level.
    /// </param>
    /// <param name="includeInclusionStates">
    /// The include inclusion states.
    /// </param>
    /// <param name="addressStartIndex">
    /// The address start index.
    /// </param>
    /// <param name="addressStopIndex">
    /// The address stop index.
    /// </param>
    /// <returns>
    /// The <see cref="List"/>.
    /// </returns>
    public List<Bundle> GetTransfers(Seed seed, int securityLevel, bool includeInclusionStates, int addressStartIndex, int addressStopIndex = 0)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// The prepare transfer.
    /// </summary>
    /// <param name="seed">
    /// The seed.
    /// </param>
    /// <param name="bundle">
    /// The bundle.
    /// </param>
    /// <param name="securityLevel">
    /// The security level.
    /// </param>
    /// <param name="remainderAddress">
    /// The remainder address.
    /// </param>
    /// <param name="inputAddresses">
    /// The input addresses.
    /// </param>
    /// <returns>
    /// The <see cref="Bundle"/>.
    /// </returns>
    public Bundle PrepareTransfer(Seed seed, Bundle bundle, int securityLevel, Address remainderAddress = null, List<Address> inputAddresses = null)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// The replay bundle.
    /// </summary>
    /// <param name="transactionHash">
    /// The transaction hash.
    /// </param>
    /// <param name="depth">
    /// The depth.
    /// </param>
    /// <param name="minWeightMagnitude">
    /// The min weight magnitude.
    /// </param>
    /// <returns>
    /// The <see cref="List"/>.
    /// </returns>
    public List<TransactionTrytes> ReplayBundle(Hash transactionHash, int depth = 27, int minWeightMagnitude = 18)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// The send transfer.
    /// </summary>
    /// <param name="seed">
    /// The seed.
    /// </param>
    /// <param name="bundle">
    /// The bundle.
    /// </param>
    /// <param name="securityLevel">
    /// The security level.
    /// </param>
    /// <param name="depth">
    /// The depth.
    /// </param>
    /// <param name="minWeightMagnitude">
    /// The min weight magnitude.
    /// </param>
    /// <param name="remainderAddress">
    /// The remainder address.
    /// </param>
    /// <param name="inputAddresses">
    /// The input addresses.
    /// </param>
    /// <returns>
    /// The <see cref="Bundle"/>.
    /// </returns>
    public Bundle SendTransfer(
      Seed seed, 
      Bundle bundle, 
      int securityLevel, 
      int depth = 27, 
      int minWeightMagnitude = 18, 
      Address remainderAddress = null, 
      List<Address> inputAddresses = null)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// The send trytes.
    /// </summary>
    /// <param name="transactions">
    /// The transactions.
    /// </param>
    /// <param name="depth">
    /// The depth.
    /// </param>
    /// <param name="minWeightMagnitude">
    /// The min weight magnitude.
    /// </param>
    /// <returns>
    /// The <see cref="List"/>.
    /// </returns>
    public List<TransactionTrytes> SendTrytes(IEnumerable<Transaction> transactions, int depth = 27, int minWeightMagnitude = 18)
    {
      var collection = transactions as IList<Transaction> ?? transactions.ToList();
      this.CurrentTransactions.AddRange(collection);

      return collection.Select(t => t.ToTrytes()).ToList();
    }

    #endregion
  }
}