using System;

namespace BranchingDemo
{
    public class Account
    {
        private decimal Balance { get; set; }

        private IAccountState State { get; set; }

        public Account(Action onUnfreeze)
        {
            State = new NotVerified(onUnfreeze);
        }

        public void Deposit(decimal amount)
        {
            State = State.Deposit(() => Balance += amount);
        }

        public void Withdraw(decimal amount)
        {
            State = State.Withdraw(() => Balance -= amount);
        }

        public void HolderVerified()
        {
            State = State.HolderVerified();
        }

        public void Close()
        {
            State = State.Close();
        }

        public void Freeze()
        {
            State = State.Freeze();
        }
    }
}
