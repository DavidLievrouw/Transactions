using System;
using System.Threading.Tasks;
using System.Transactions;
using DavidLievrouw.Transactions;

namespace Transactions.Sample {
  public class AccountCreator : IAccountCreator {
    readonly IAccountService _accountService;
    readonly ITransactionScopeFactory _transactionScopeFactory;

    public AccountCreator(IAccountService accountService, ITransactionScopeFactory transactionScopeFactory) {
      if (accountService == null) throw new ArgumentNullException(nameof(accountService));
      if (transactionScopeFactory == null) throw new ArgumentNullException(nameof(transactionScopeFactory));
      _accountService = accountService;
      _transactionScopeFactory = transactionScopeFactory;
    }

    public async Task<Account> CreateNew(string name) {
      using (var scope = _transactionScopeFactory.CreateScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled)) {
        await _accountService.CreateAccount(name);
        await _accountService.MarkAccountAsValid(name);
        scope.Complete();
      }
      return new Account { Name = name };
    }
  }
}
