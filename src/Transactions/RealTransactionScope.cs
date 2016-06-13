using System.Transactions;

namespace DavidLievrouw.Transactions {
  public class RealTransactionScope : TransactionScope {
    readonly TransactionOptions _transactionOptions;
    readonly System.Transactions.TransactionScope _inner;

    internal RealTransactionScope(TransactionScopeOption scopeOption, TransactionOptions transactionOptions, TransactionScopeAsyncFlowOption asyncFlowOption) {
      _transactionOptions = transactionOptions;
      _inner = new System.Transactions.TransactionScope(scopeOption, transactionOptions, asyncFlowOption);
    }

    protected override void UnwindScope() {
      _inner.Dispose();
    }

    public override void Complete() {
      _inner.Complete();
    }

    internal TransactionOptions TransactionOptions => _transactionOptions;
  }
}