﻿using System;
using RulesDemo.Common.Interfaces;

namespace RulesDemo.Common.Implementation
{
    internal class NoneNotMatchedForMapping<T, TResult> : IFilteredNoneMapped<T, TResult>, IFilteredMapped<T, TResult>
    {
        public IMapped<T, TResult> MapTo(Func<TResult> mapping) =>
            new MappingOnNoneNotResolved<T, TResult>();

        public IMapped<T, TResult> MapTo(Func<T, TResult> mapping) =>
            new MappingOnNoneNotResolved<T, TResult>();
    }
}