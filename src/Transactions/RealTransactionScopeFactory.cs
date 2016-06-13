using System.Transactions;

namespace Transactions {
  public class RealTransactionScopeFactory : ITransactionScopeFactory {
    public ITransactionScope CreateScope() {
      return CreateScope(TransactionScopeOption.Required, new TransactionOptions(), TransactionScopeAsyncFlowOption.Suppress);
    }

    public ITransactionScope CreateScope(TransactionScopeOption scopeOption) {
      return CreateScope(scopeOption, new TransactionOptions(), TransactionScopeAsyncFlowOption.Suppress);
    }

    public ITransactionScope CreateScope(TransactionScopeOption scopeOption, TransactionScopeAsyncFlowOption asyncFlowOption) {
      return CreateScope(scopeOption, new TransactionOptions(), asyncFlowOption);
    }

    public ITransactionScope CreateScope(TransactionScopeOption scopeOption, TransactionOptions transactionOptions) {
      return CreateScope(scopeOption, transactionOptions, TransactionScopeAsyncFlowOption.Suppress);
    }

    public ITransactionScope CreateScope(TransactionScopeOption scopeOption, TransactionOptions transactionOptions, TransactionScopeAsyncFlowOption asyncFlowOption) {
      return new RealTransactionScope(scopeOption, transactionOptions, asyncFlowOption);
    }
  }
}