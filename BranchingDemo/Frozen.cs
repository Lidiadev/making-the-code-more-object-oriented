using System;

namespace BranchingDemo
{
    public class Frozen : IAccountState
    {
        private Action OnUnfreeze { get; }

        public Frozen(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            OnUnfreeze();
            addToBalance();

            return new Active(OnUnfreeze);
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            OnUnfreeze();
            subtractFromBalance();

            return new Active(OnUnfreeze);
        }

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => this;

        public IAccountState Close() => new Closed();
    }
}
