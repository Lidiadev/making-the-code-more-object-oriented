using System;

namespace RulesDemo.Common.Interfaces
{
    public interface IFilteredActionable<T>
    {
        IActionable<T> Do(Action<T> action);
    }
}