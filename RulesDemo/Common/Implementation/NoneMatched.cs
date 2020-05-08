﻿using System;
using RulesDemo.Common.Interfaces;

namespace RulesDemo.Common.Implementation
{
    internal class NoneMatched<T>: IFilteredNone<T>, IFilteredNoneActionable<T>
    {
        public IActionable<T> Do(Action action) =>
            new ActionResolved<T>(action);

        public IMapped<T, TResult> MapTo<TResult>(Func<TResult> mapping) =>
            new MappingResolved<T, TResult>(mapping());
    }
}