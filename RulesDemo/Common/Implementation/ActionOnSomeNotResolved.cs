using System;
using RulesDemo.Common.Interfaces;

namespace RulesDemo.Common.Implementation
{
    internal class ActionOnSomeNotResolved<T>: IActionable<T>
    {

        private T Value { get; }

        public ActionOnSomeNotResolved(T value)
        {
            Value = value;
        }

        public IFilteredActionable<T> When(Func<T, bool> predicate) =>
            predicate(Value) ? (IFilteredActionable<T>)new SomeMatched<T>(Value) : new SomeNotMatched<T>(Value);

        public IFilteredActionable<T> WhenSome() =>
            new SomeMatched<T>(Value);

        public IFilteredNoneActionable<T> WhenNone() =>
            new SomeNotMatched<T>(Value);

        public void Execute() { }

    }
}