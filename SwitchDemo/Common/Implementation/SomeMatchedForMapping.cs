using System;
using SwitchDemo.Common.Interfaces;

namespace SwitchDemo.Common.Implementation
{
    internal class SomeMatchedForMapping<T, TResult> : IFilteredMapped<T, TResult>
    {
        private T Value;

        public SomeMatchedForMapping(T value)
        {
            Value = value;
        }

        public IMapped<T, TResult> MapTo(Func<T, TResult> mapping) =>
            new MappingResolved<T, TResult>(mapping(Value));
    }
}