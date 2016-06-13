using System;

namespace DavidLievrouw.Transactions {
  public interface ITransactionScope : IDisposable {
    void Complete();
  }
}