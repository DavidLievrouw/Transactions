using System.Transactions;

namespace DavidLievrouw.Transactions {
  public class RealTransactionScopeFactory : ITransactionScopeFactory {
    static readonly TransactionOptions DefaultTransactionOptions = new TransactionOptions {
      IsolationLevel = IsolationLevel.ReadCommitted,
      Timeout = TransactionManager.DefaultTimeout
    };

    public ITransactionScope CreateScope() {
      return CreateScope(TransactionScopeOption.Required, DefaultTransactionOptions, TransactionScopeAsyncFlowOption.Suppress);
    }

    public ITransactionScope CreateScope(TransactionScopeOption scopeOption) {
      return CreateScope(scopeOption, DefaultTransactionOptions, TransactionScopeAsyncFlowOption.Suppress);
    }

    public ITransactionScope CreateScope(TransactionScopeOption scopeOption, TransactionScopeAsyncFlowOption asyncFlowOption) {
      return CreateScope(scopeOption, DefaultTransactionOptions, asyncFlowOption);
    }

    public ITransactionScope CreateScope(TransactionScopeOption scopeOption, TransactionOptions transactionOptions) {
      return CreateScope(scopeOption, transactionOptions, TransactionScopeAsyncFlowOption.Suppress);
    }

    public ITransactionScope CreateScope(TransactionScopeOption scopeOption, TransactionOptions transactionOptions, TransactionScopeAsyncFlowOption asyncFlowOption) {
      return new RealTransactionScope(scopeOption, transactionOptions, asyncFlowOption);
    }
  }
}