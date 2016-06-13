# Transactions

This is a library that provides a simple abstraction on top of System.Transactions namespace. This makes it possible to unit test classes for transaction usage.

## Example usage
```cs
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
  
  public interface IAccountCreator {
    Task<Account> CreateNew(string name);
  }
  
  public class AccountService : IAccountService {
    public async Task CreateAccount(string name) {
      await ... // Do the work
    }

    public async Task MarkAccountAsValid(string accountName) {
      await ... // Do the work
    }
  }

  public interface IAccountService {
    Task CreateAccount(string name);
    Task MarkAccountAsValid(string accountName);
  }
  
  public class Account {
    public string Name { get; set; }
  }
```

## Change log

v1.0.1 - 2016-06-13
- Initial release.