using System;
using SwitchDemo.Common.Interfaces;

namespace SwitchDemo.Common.Implementation
{
    internal class SomeNotMatchedAsNone<T>: IFilteredNone<T>
    {
        private T Value { get; }

        public SomeNotMatchedAsNone(T value)
        {
            Value = value;
        }

        public IActionable<T> Do(Action action) =>
            new ActionOnSomeNotResolved<T>(Value);

        public IMapped<T, TResult> MapTo<TResult>(Func<TResult> mapping) =>
            new MappingOnSomeNotResolved<T, TResult>(Value);

    }
}