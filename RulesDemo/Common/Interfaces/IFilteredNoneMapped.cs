using System;

namespace RulesDemo.Common.Interfaces
{
    public interface IFilteredNoneMapped<T, TResult>
    {
        IMapped<T, TResult> MapTo(Func<TResult> mapping);
    }
}