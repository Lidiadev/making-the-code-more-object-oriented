using System;
using RulesDemo.Common.Interfaces;

namespace RulesDemo.Common.Implementation
{
    internal class MappingOnSomeNotResolved<T, TResult>: IMapped<T, TResult>
    {

        private T Value { get; }

        public MappingOnSomeNotResolved(T value)
        {
            Value = value;
        }

        public IFilteredMapped<T, TResult> When(Func<T, bool> predicate) =>
            predicate(Value)
                ? (IFilteredMapped<T, TResult>)new SomeMatchedForMapping<T, TResult>(Value)
                : new SomeNotMatchedForMapping<T, TResult>(Value);

        public IFilteredMapped<T, TResult> WhenSome() =>
            new SomeMatchedForMapping<T, TResult>(Value);

        public IFilteredNoneMapped<T, TResult> WhenNone() =>
            new SomeNotMatchedAsNoneForMapping<T, TResult>(Value);

        public TResult Map()
        {
            throw new InvalidOperationException();
        }
    }
}