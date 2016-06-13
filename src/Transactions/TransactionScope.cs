using System.Collections.Generic;

namespace DavidLievrouw.Transactions {
  public abstract class TransactionScope : ITransactionScope {
    static readonly Stack<ITransactionScope> ScopeStack = new Stack<ITransactionScope>();
    
    public static ITransactionScope Current => ScopeStack.Count == 0
      ? null
      : ScopeStack.Peek();

    public static int Depth => ScopeStack.Count;

    protected TransactionScope() {
      ScopeStack.Push(this);
    }

    public void Dispose() {
      if (ShouldUnwindScope()) UnwindScope();
      ScopeStack.Pop();
    }

    protected virtual bool ShouldUnwindScope() {
      return true;
    }

    protected abstract void UnwindScope();
    public abstract void Complete();
  }
}