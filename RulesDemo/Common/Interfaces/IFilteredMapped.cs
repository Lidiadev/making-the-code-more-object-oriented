using System;

namespace RulesDemo.Common.Interfaces
{
    public interface IFilteredMapped<T, TResult>
    {
        IMapped<T, TResult> MapTo(Func<T, TResult> mapping);
    }
}