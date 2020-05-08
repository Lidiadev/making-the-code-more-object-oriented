using System;
using RulesDemo.Common.Interfaces;

namespace RulesDemo.Common.Implementation
{
    internal class SomeMatched<T>: IFiltered<T>
    {
        private T Value { get; }

        public SomeMatched(T value)
        {
            Value = value;
        }

        public IActionable<T> Do(Action<T> action) =>
            new ActionResolved<T>(() => action(Value));

        public IMapped<T, TResult> MapTo<TResult>(Func<T, TResult> mapping) =>
            new MappingResolved<T, TResult>(mapping(Value));
    }
}