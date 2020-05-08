using System;
using RulesDemo.Common.Interfaces;

namespace RulesDemo.Common.Implementation
{
    internal class SomeNotMatchedForMapping<T, TResult>: IFilteredMapped<T, TResult>
    {
        private T Value;

        public SomeNotMatchedForMapping(T value)
        {
            Value = value;
        }

        public IMapped<T, TResult> MapTo(Func<T, TResult> mapping) =>
            new MappingOnSomeNotResolved<T, TResult>(Value);
    }
}