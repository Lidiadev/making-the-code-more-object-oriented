using System;

namespace RulesDemo.Common.Interfaces
{
    public interface IFilteredNoneActionable<T>
    {
        IActionable<T> Do(Action action);
    }
}