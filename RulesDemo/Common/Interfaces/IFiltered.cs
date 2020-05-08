using System;

namespace RulesDemo.Common.Interfaces
{
    public interface IFiltered<T>: IFilteredActionable<T>
    {
        IMapped<T, TResult> MapTo<TResult>(Func<T, TResult> mapping);
    }
}