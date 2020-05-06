﻿using SwitchDemo.Common.Implementation;
using SwitchDemo.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwitchDemo.Common
{
    public class Option<T> : IOption<T>
    {
        private IEnumerable<T> Content { get; }

        private Option(IEnumerable<T> content)
        {
            Content = content;
        }

        public static IOption<T> Some(T value) 
            => new Option<T>(new[] { value });

        public static IOption<T> None() 
            => new Option<T>(new T[0]);

        public IFiltered<T> When(Func<T, bool> predicate)
            => Content
                .Select(item => WhenSome(item, predicate))
                .DefaultIfEmpty(new NoneNotMatchedAsSome<T>())
                .Single();

        private IFiltered<T> WhenSome(T value, Func<T, bool> predicate)
            => predicate(value)
                ? (IFiltered<T>)new SomeMatched<T>(value) 
                : (IFiltered<T>)new SomeNotMatched<T>(value);

        public IFiltered<T> WhenSome()
           => Content
                .Select<T, IFiltered<T>>(item => new SomeMatched<T>(item))
                .DefaultIfEmpty(new NoneNotMatchedAsSome<T>())
                .Single();

        public IFilteredNone<T> WhenNone()
            => Content
                .Select<T, IFilteredNone<T>>(item => new SomeNotMatchedAsNone<T>(item))
                .DefaultIfEmpty(new NoneMatched<T>())
                .Single();
    }
}
