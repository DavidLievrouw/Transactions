using System.Threading.Tasks;

namespace Transactions.Sample {
  public interface IAccountService {
    Task CreateAccount(string name);
    Task MarkAccountAsValid(string accountName);
  }
}