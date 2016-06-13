namespace DavidLievrouw.Transactions {
  public class TransactionScopeForTest : TransactionScope {
    public TransactionScopeForTest() {
      IsUnwound = false;
      IsComplete = false;
      ShouldUnwind = true;
    }

    public bool ShouldUnwind { get; set; }
    public bool IsUnwound { get; private set; }
    public bool IsComplete { get; private set; }

    protected override bool ShouldUnwindScope() {
      return ShouldUnwind;
    }

    protected override void UnwindScope() {
      IsUnwound = true;
    }

    public override void Complete() {
      IsComplete = true;
    }
  }
}