using System.Transactions;

namespace Transactions {
  public class RealTransactionScope : ITransactionScope {
    readonly System.Transactions.TransactionScope _inner;

    internal RealTransactionScope(TransactionScopeOption scopeOption, TransactionOptions transactionOptions, TransactionScopeAsyncFlowOption asyncFlowOption) {
      _inner = new System.Transactions.TransactionScope(scopeOption, transactionOptions, asyncFlowOption);
    }

    public void Dispose() {
      _inner.Dispose();
    }

    public void Complete() {
      _inner.Complete();
    }
  }
}