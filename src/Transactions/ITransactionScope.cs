using System;

namespace Transactions {
  public interface ITransactionScope : IDisposable {
    void Complete();
  }
}