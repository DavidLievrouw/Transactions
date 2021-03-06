﻿using System.Transactions;

namespace DavidLievrouw.Transactions {
  public interface ITransactionScopeFactory {
    ITransactionScope CreateScope();
    ITransactionScope CreateScope(TransactionScopeOption scopeOption);
    ITransactionScope CreateScope(TransactionScopeOption scopeOption, TransactionScopeAsyncFlowOption asyncFlowOption);
    ITransactionScope CreateScope(TransactionScopeOption scopeOption, TransactionOptions transactionOptions);
    ITransactionScope CreateScope(TransactionScopeOption scopeOption, TransactionOptions transactionOptions, TransactionScopeAsyncFlowOption asyncFlowOption);
  }
}
