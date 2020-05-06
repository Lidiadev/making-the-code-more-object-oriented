using System;
using SwitchDemo.Common.Interfaces;

namespace SwitchDemo.Common.Implementation
{
    internal class SomeNotMatchedAsNoneForMapping<T, TResult>: IFilteredNoneMapped<T, TResult>
    {
        private T Value { get; }

        public SomeNotMatchedAsNoneForMapping(T value)
        {
            Value = value;
        }

        public IMapped<T, TResult> MapTo(Func<TResult> mapping) =>
            new MappingOnSomeNotResolved<T, TResult>(Value);

    }
}