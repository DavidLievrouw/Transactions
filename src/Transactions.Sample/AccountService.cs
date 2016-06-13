using System.Threading.Tasks;

namespace Transactions.Sample {
  public class AccountService : IAccountService {
    public async Task CreateAccount(string name) {
      await Task.Delay(500); // Dummy work
    }

    public async Task MarkAccountAsValid(string accountName) {
      await Task.Delay(500); // Dummy work
    }
  }
}
