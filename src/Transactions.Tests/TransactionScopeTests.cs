using NUnit.Framework;

namespace Transactions {
  [TestFixture]
  public class TransactionScopeTests {
    [Test]
    public void UponCreation_SetsAmbientContext() {
      using (var ctx = new TransactionScopeForTest()) {
        Assert.That(TransactionScope.Current, Is.EqualTo(ctx));
      }
    }

    [Test]
    public void UponCreation_AddsItemToAmbientContextStack() {
      Assert.That(TransactionScope.Depth, Is.Zero);
      using (var ctx1 = new TransactionScopeForTest()) {
        Assert.That(TransactionScope.Depth, Is.EqualTo(1));
        using (var ctx2 = new TransactionScopeForTest()) {
          Assert.That(TransactionScope.Depth, Is.EqualTo(2));
          Assert.That(TransactionScope.Current, Is.EqualTo(ctx2));
        }
      }
    }

    [Test]
    public void UponDispose_Unwinds() {
      TransactionScopeForTest sut;
      using (sut = new TransactionScopeForTest()) {
        Assert.That(sut.IsUnwound, Is.False);
      }
      Assert.That(sut.IsUnwound, Is.True);
    }

    [Test]
    public void UponDispose_DoesNotUnwindIfSpecified() {
      TransactionScopeForTest sut;
      using (sut = new TransactionScopeForTest()) {
        sut.ShouldUnwind = false;
        Assert.That(sut.IsUnwound, Is.False);
      }
      Assert.That(sut.IsUnwound, Is.False);
    }

    [Test]
    public void UponDispose_RemovesItemFromAmbientContextStack() {
      using (var ctx1 = new TransactionScopeForTest()) {
        using (var ctx2 = new TransactionScopeForTest()) {
          Assert.That(TransactionScope.Depth, Is.EqualTo(2));
        }
        Assert.That(TransactionScope.Depth, Is.EqualTo(1));
      }
      Assert.That(TransactionScope.Depth, Is.Zero);
    }
  }
}