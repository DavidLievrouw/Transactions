using System.Transactions;
using NUnit.Framework;

namespace DavidLievrouw.Transactions {
  [TestFixture]
  public class RealTransactionScopeFactoryTests {
    ITransactionScope _scope;
    RealTransactionScopeFactory _sut;

    [SetUp]
    public void SetUp() {
      _sut = new RealTransactionScopeFactory();
    }

    [TearDown]
    public void TearDown() {
      _scope?.Dispose();
    }

    [Test]
    public void Create_ProducesTransactionScope() {
      _scope = _sut.CreateScope();
      Assert.That(_scope, Is.Not.Null);
      Assert.That(_scope, Is.InstanceOf<ITransactionScope>());
    }

    [Test]
    public void CreateWithOption_ProducesTransactionScope() {
      _scope = _sut.CreateScope(TransactionScopeOption.Required);
      Assert.That(_scope, Is.Not.Null);
      Assert.That(_scope, Is.InstanceOf<ITransactionScope>());
    }

    [Test]
    public void CreateWithOptionAndAsyncFlow_ProducesTransactionScope() {
      _scope = _sut.CreateScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);
      Assert.That(_scope, Is.Not.Null);
      Assert.That(_scope, Is.InstanceOf<ITransactionScope>());
    }

    [Test]
    public void CreateWithOptionAndTranOptions_ProducesTransactionScope() {
      _scope = _sut.CreateScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable });
      Assert.That(_scope, Is.Not.Null);
      Assert.That(_scope, Is.InstanceOf<ITransactionScope>());
    }

    [Test]
    public void CreateWithOptionAndTranOptionsAndAsyncFlow_ProducesTransactionScope() {
      _scope = _sut.CreateScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }, TransactionScopeAsyncFlowOption.Enabled);
      Assert.That(_scope, Is.Not.Null);
      Assert.That(_scope, Is.InstanceOf<ITransactionScope>());
    }
  }
}