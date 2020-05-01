using System;

namespace BranchingDemo
{
    public class Closed : IAccountState
    {
        public IAccountState Close() => this;

        public IAccountState Deposit(Action addToBalance) => this;

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => this;

        public IAccountState Withdraw(Action subtractFromBalance) => this;
    }
}
