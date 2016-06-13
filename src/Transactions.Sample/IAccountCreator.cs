using System.Threading.Tasks;

namespace Transactions.Sample {
  public interface IAccountCreator {
    Task<Account> CreateNew(string name);
  }
}