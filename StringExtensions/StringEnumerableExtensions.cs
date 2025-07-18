using System;
using System.Collections.Generic;

namespace MachineCognitis.StringExtensions
{
    public static class StringEnumerableExtensions
    {

        #region After

        public static IEnumerable<string> After(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(separator))
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var segment in value.After(separator, comparison))
                    yield return segment;
            }
        }

        public static IEnumerable<string> OptionallyAfter(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(separator))
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var item in value.OptionallyAfter(separator, comparison))
                    yield return item;
            }
        }

        public static IEnumerable<string> AfterNth(this IEnumerable<string> values, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var item in value.AfterNth(separator, n, comparison))
                    yield return item;
            }
        }

        public static IEnumerable<string> AfterFirst(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => AfterNth(values, separator, 1, comparison);

        public static IEnumerable<string> AfterSecond(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => AfterNth(values, separator, 2, comparison);

        public static IEnumerable<string> AfterThird(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => AfterNth(values, separator, 3, comparison);

        public static IEnumerable<string> AfterFourth(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => AfterNth(values, separator, 4, comparison);

        public static IEnumerable<string> AfterFifth(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => AfterNth(values, separator, 5, comparison);

        public static IEnumerable<string> OptionallyAfterNth(this IEnumerable<string> values, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var item in value.OptionallyAfterNth(separator, n, comparison))
                    yield return item;
            }
        }

        public static IEnumerable<string> OptionallyAfterFirst(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyAfterNth(values, separator, 1, comparison);

        public static IEnumerable<string> OptionallyAfterSecond(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyAfterNth(values, separator, 2, comparison);

        public static IEnumerable<string> OptionallyAfterThird(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyAfterNth(values, separator, 3, comparison);

        public static IEnumerable<string> OptionallyAfterFourth(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyAfterNth(values, separator, 4, comparison);

        public static IEnumerable<string> OptionallyAfterFifth(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyAfterNth(values, separator, 5, comparison);

        public static IEnumerable<string> AfterNthToLast(this IEnumerable<string> values, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var item in value.AfterNthToLast(separator, n, comparison))
                    yield return item;
            }
        }

        public static IEnumerable<string> AfterLast(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => AfterNthToLast(values, separator, 1, comparison);

        public static IEnumerable<string> AfterSecondToLast(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => AfterNthToLast(values, separator, 2, comparison);

        public static IEnumerable<string> OptionallyAfterNthToLast(this IEnumerable<string> values, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var item in value.OptionallyAfterNthToLast(separator, n, comparison))
                    yield return item;
            }
        }

        public static IEnumerable<string> OptionallyAfterLast(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyAfterNthToLast(values, separator, 1, comparison);

        public static IEnumerable<string> OptionallyAfterSecondToLast(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyAfterNthToLast(values, separator, 2, comparison);

        #endregion

        #region Before

        public static IEnumerable<string> Before(this IEnumerable<string> values, string separator, StringComparison stringComparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(separator))
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                int start = 0;
                int index;

                while ((index = value.IndexOf(separator, start, stringComparison)) >= 0)
                {
                    yield return value[start..index];
                    start = index + separator.Length;
                }
            }
        }

        public static IEnumerable<string> OptionallyBefore(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(separator))
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                int index = value.IndexOf(separator, comparison);
                if (index < 0)
                {
                    yield return value;
                    continue;
                }

                int start = 0;
                while (index >= 0)
                {
                    yield return value[start..index];
                    start = index + separator.Length;
                    index = value.IndexOf(separator, start, comparison);
                }
            }
        }

        public static IEnumerable<string> BeforeNth(this IEnumerable<string> values, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                int count = 0;
                int start = 0;

                while (true)
                {
                    int index = value.IndexOf(separator, start, comparison);
                    if (index < 0)
                        break;

                    count++;
                    if (count == n)
                    {
                        yield return value[..index];
                        break;
                    }

                    start = index + separator.Length;
                }
            }
        }

        public static IEnumerable<string> BeforeFirst(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => BeforeNth(values, separator, 1, comparison);

        public static IEnumerable<string> BeforeSecond(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => BeforeNth(values, separator, 2, comparison);

        public static IEnumerable<string> BeforeThird(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => BeforeNth(values, separator, 3, comparison);

        public static IEnumerable<string> BeforeFourth(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => BeforeNth(values, separator, 4, comparison);

        public static IEnumerable<string> BeforeFifth(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => BeforeNth(values, separator, 5, comparison);

        public static IEnumerable<string> OptionallyBeforeNth(this IEnumerable<string> values, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                int count = 0;
                int start = 0;

                while (true)
                {
                    int index = value.IndexOf(separator, start, comparison);
                    if (index < 0)
                    {
                        yield return value;
                        break;
                    }

                    count++;
                    if (count == n)
                    {
                        yield return value[..index];
                        break;
                    }

                    start = index + separator.Length;
                }
            }
        }

        public static IEnumerable<string> OptionallyBeforeFirst(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyBeforeNth(values, separator, 1, comparison);

        public static IEnumerable<string> OptionallyBeforeSecond(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyBeforeNth(values, separator, 2, comparison);

        public static IEnumerable<string> OptionallyBeforeThird(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyBeforeNth(values, separator, 3, comparison);

        public static IEnumerable<string> OptionallyBeforeFourth(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyBeforeNth(values, separator, 4, comparison);

        public static IEnumerable<string> OptionallyBeforeFifth(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyBeforeNth(values, separator, 5, comparison);

        public static IEnumerable<string> BeforeNthToLast(this IEnumerable<string> values, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                int count = 0;
                int searchStart = value.Length;

                while (searchStart > 0)
                {
                    int index = value.LastIndexOf(separator, searchStart - 1, comparison);
                    if (index < 0)
                        break;

                    count++;
                    if (count == n)
                    {
                        yield return value[..index];
                        break;
                    }

                    searchStart = index;
                }
            }
        }

        public static IEnumerable<string> BeforeLast(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => BeforeNthToLast(values, separator, 1, comparison);

        public static IEnumerable<string> BeforeSecondToLast(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => BeforeNthToLast(values, separator, 2, comparison);

        public static IEnumerable<string> OptionallyBeforeNthToLast(this IEnumerable<string> values, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                int count = 0;
                int searchStart = value.Length;

                while (searchStart > 0)
                {
                    int index = value.LastIndexOf(separator, searchStart - 1, comparison);
                    if (index < 0)
                    {
                        yield return value;
                        break;
                    }

                    count++;
                    if (count == n)
                    {
                        yield return value[..index];
                        break;
                    }

                    searchStart = index;
                }
            }
        }

        public static IEnumerable<string> OptionallyBeforeLast(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyBeforeNthToLast(values, separator, 1, comparison);

        public static IEnumerable<string> OptionallyBeforeSecondToLast(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyBeforeNthToLast(values, separator, 2, comparison);

        #endregion

        #region Between

        public static IEnumerable<string> Between(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix))
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var segment in value.Between(prefix, suffix, comparison))
                    yield return segment;
            }
        }

        public static IEnumerable<string> OptionallyBetween(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix))
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var segment in value.OptionallyBetween(prefix, suffix, comparison))
                    yield return segment;
            }
        }

        public static IEnumerable<string> BetweenNth(this IEnumerable<string> values, string prefix, string suffix, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var segment in value.BetweenNth(prefix, suffix, n, comparison))
                    yield return segment;
            }
        }

        public static IEnumerable<string> BetweenFirst(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => BetweenNth(values, prefix, suffix, 1, comparison);

        public static IEnumerable<string> BetweenSecond(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => BetweenNth(values, prefix, suffix, 2, comparison);

        public static IEnumerable<string> BetweenThird(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => BetweenNth(values, prefix, suffix, 3, comparison);

        public static IEnumerable<string> BetweenFourth(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => BetweenNth(values, prefix, suffix, 4, comparison);

        public static IEnumerable<string> BetweenFifth(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => BetweenNth(values, prefix, suffix, 5, comparison);

        public static IEnumerable<string> OptionallyBetweenNth(this IEnumerable<string> values, string prefix, string suffix, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var segment in value.OptionallyBetweenNth(prefix, suffix, n, comparison))
                    yield return segment;
            }
        }

        public static IEnumerable<string> OptionallyBetweenFirst(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyBetweenNth(values, prefix, suffix, 1, comparison);

        public static IEnumerable<string> OptionallyBetweenSecond(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyBetweenNth(values, prefix, suffix, 2, comparison);

        public static IEnumerable<string> OptionallyBetweenThird(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyBetweenNth(values, prefix, suffix, 3, comparison);

        public static IEnumerable<string> OptionallyBetweenFourth(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyBetweenNth(values, prefix, suffix, 4, comparison);

        public static IEnumerable<string> OptionallyBetweenFifth(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyBetweenNth(values, prefix, suffix, 5, comparison);

        public static IEnumerable<string> BetweenNthToLast(this IEnumerable<string> values, string prefix, string suffix, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var segment in value.BetweenNthToLast(prefix, suffix, n, comparison))
                    yield return segment;
            }
        }

        public static IEnumerable<string> BetweenLast(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => BetweenNthToLast(values, prefix, suffix, 1, comparison);

        public static IEnumerable<string> BetweenSecondToLast(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => BetweenNthToLast(values, prefix, suffix, 2, comparison);

        public static IEnumerable<string> OptionallyBetweenNthToLast(this IEnumerable<string> values, string prefix, string suffix, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var segment in value.OptionallyBetweenNthToLast(prefix, suffix, n, comparison))
                    yield return segment;
            }
        }

        public static IEnumerable<string> OptionallyBetweenLast(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyBetweenNthToLast(values, prefix, suffix, 1, comparison);

        public static IEnumerable<string> OptionallyBetweenSecondToLast(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyBetweenNthToLast(values, prefix, suffix, 2, comparison);

        #endregion

        #region Outside

        public static IEnumerable<string> Outside(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix))
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var segment in value.Outside(prefix, suffix, comparison))
                    yield return segment;
            }
        }

        public static IEnumerable<string> OptionallyOutside(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix))
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var segment in value.OptionallyOutside(prefix, suffix, comparison))
                    yield return segment;
            }
        }

        public static IEnumerable<string> OutsideNth(this IEnumerable<string> values, string prefix, string suffix, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var segment in value.OutsideNth(prefix, suffix, n, comparison))
                    yield return segment;
            }
        }

        public static IEnumerable<string> OutsideFirst(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OutsideNth(values, prefix, suffix, 1, comparison);

        public static IEnumerable<string> OutsideSecond(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OutsideNth(values, prefix, suffix, 2, comparison);

        public static IEnumerable<string> OutsideThird(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OutsideNth(values, prefix, suffix, 3, comparison);

        public static IEnumerable<string> OutsideFourth(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OutsideNth(values, prefix, suffix, 4, comparison);

        public static IEnumerable<string> OutsideFifth(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OutsideNth(values, prefix, suffix, 5, comparison);

        public static IEnumerable<string> OptionallyOutsideNth(this IEnumerable<string> values, string prefix, string suffix, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var segment in value.OptionallyOutsideNth(prefix, suffix, n, comparison))
                    yield return segment;
            }
        }

        public static IEnumerable<string> OptionallyOutsideFirst(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyOutsideNth(values, prefix, suffix, 1, comparison);

        public static IEnumerable<string> OptionallyOutsideSecond(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyOutsideNth(values, prefix, suffix, 2, comparison);

        public static IEnumerable<string> OptionallyOutsideThird(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyOutsideNth(values, prefix, suffix, 3, comparison);

        public static IEnumerable<string> OptionallyOutsideFourth(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyOutsideNth(values, prefix, suffix, 4, comparison);

        public static IEnumerable<string> OptionallyOutsideFifth(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyOutsideNth(values, prefix, suffix, 5, comparison);

        public static IEnumerable<string> OutsideNthToLast(this IEnumerable<string> values, string prefix, string suffix, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var segment in value.OutsideNthToLast(prefix, suffix, n, comparison))
                    yield return segment;
            }
        }

        public static IEnumerable<string> OutsideLast(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OutsideNthToLast(values, prefix, suffix, 1, comparison);

        public static IEnumerable<string> OutsideSecondToLast(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OutsideNthToLast(values, prefix, suffix, 2, comparison);

        public static IEnumerable<string> OptionallyOutsideNthToLast(this IEnumerable<string> values, string prefix, string suffix, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var segment in value.OptionallyOutsideNthToLast(prefix, suffix, n, comparison))
                    yield return segment;
            }
        }

        public static IEnumerable<string> OptionallyOutsideLast(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyOutsideNthToLast(values, prefix, suffix, 1, comparison);

        public static IEnumerable<string> OptionallyOutsideSecondToLast(this IEnumerable<string> values, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
            => OptionallyOutsideNthToLast(values, prefix, suffix, 2, comparison);

        #endregion

        #region SplitAt

        public static IEnumerable<string> SplitAt(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(separator))
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var segment in value.SplitAt(separator, comparison))
                    yield return segment;
            }
        }

        public static IEnumerable<string> OptionallySplitAt(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(separator))
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var segment in value.OptionallySplitAt(separator, comparison))
                    yield return segment;
            }
        }

        public static IEnumerable<string> SplitAtNth(this IEnumerable<string> values, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var segment in value.SplitAtNth(separator, n, comparison))
                    yield return segment;
            }
        }

        public static IEnumerable<string> SplitAtFirst(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => SplitAtNth(values, separator, 1, comparison);

        public static IEnumerable<string> SplitAtSecond(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => SplitAtNth(values, separator, 2, comparison);

        public static IEnumerable<string> SplitAtThird(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => SplitAtNth(values, separator, 3, comparison);

        public static IEnumerable<string> SplitAtFourth(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => SplitAtNth(values, separator, 4, comparison);

        public static IEnumerable<string> SplitAtFifth(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => SplitAtNth(values, separator, 5, comparison);

        public static IEnumerable<string> OptionallySplitAtNth(this IEnumerable<string> values, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var segment in value.OptionallySplitAtNth(separator, n, comparison))
                    yield return segment;
            }
        }

        public static IEnumerable<string> OptionallySplitAtFirst(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallySplitAtNth(values, separator, 1, comparison);

        public static IEnumerable<string> OptionallySplitAtSecond(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallySplitAtNth(values, separator, 2, comparison);

        public static IEnumerable<string> OptionallySplitAtThird(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallySplitAtNth(values, separator, 3, comparison);

        public static IEnumerable<string> OptionallySplitAtFourth(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallySplitAtNth(values, separator, 4, comparison);

        public static IEnumerable<string> OptionallySplitAtFifth(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallySplitAtNth(values, separator, 5, comparison);

        public static IEnumerable<string> SplitAtNthToLast(this IEnumerable<string> values, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var segment in value.SplitAtNthToLast(separator, n, comparison))
                    yield return segment;
            }
        }

        public static IEnumerable<string> SplitAtLast(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => SplitAtNthToLast(values, separator, 1, comparison);

        public static IEnumerable<string> SplitAtSecondToLast(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => SplitAtNthToLast(values, separator, 2, comparison);

        public static IEnumerable<string> OptionallySplitAtNthToLast(this IEnumerable<string> values, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                foreach (var segment in value.OptionallySplitAtNthToLast(separator, n, comparison))
                    yield return segment;
            }
        }

        public static IEnumerable<string> OptionallySplitAtLast(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallySplitAtNthToLast(values, separator, 1, comparison);

        public static IEnumerable<string> OptionallySplitAtSecondToLast(this IEnumerable<string> values, string separator, StringComparison comparison = StringComparison.Ordinal)
            => OptionallySplitAtNthToLast(values, separator, 2, comparison);

        #endregion

        #region Trim

        public static IEnumerable<string> Trim(this IEnumerable<string> values, string trimValue, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(trimValue))
                {
                    yield return value ?? "";
                    continue;
                }

                ReadOnlySpan<char> span = value;
                int trimLen = trimValue.Length;

                while (span.StartsWith(trimValue, comparison))
                {
                    span = span[trimLen..];
                }

                while (span.EndsWith(trimValue, comparison))
                {
                    span = span[..^trimLen];
                }

                yield return span.ToString();
            }
        }

        public static IEnumerable<string> TrimMaxCount(this IEnumerable<string> values, string trimValue, int maxCount, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(trimValue) || maxCount <= 0)
                {
                    yield return value ?? "";
                    continue;
                }

                ReadOnlySpan<char> span = value;
                int remaining = maxCount;

                // Trim from the start
                while (span.StartsWith(trimValue, comparison) && remaining > 0)
                {
                    span = span[trimValue.Length..];
                    remaining--;
                }

                // Trim from the end
                while (span.EndsWith(trimValue, comparison) && remaining > 0)
                {
                    span = span[..^trimValue.Length];
                    remaining--;
                }

                yield return span.ToString();
            }
        }

        public static IEnumerable<string> TrimEnd(this IEnumerable<string> values, string trimValue, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(trimValue))
                {
                    yield return value ?? "";
                    continue;
                }

                ReadOnlySpan<char> span = value;
                int trimLen = trimValue.Length;

                while (span.EndsWith(trimValue, comparison))
                {
                    span = span[..^trimLen];
                }

                yield return span.ToString();
            }
        }

        public static IEnumerable<string> TrimEndMaxCount(this IEnumerable<string> values, string trimValue, int maxCount, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(trimValue) || maxCount <= 0)
                {
                    yield return value ?? "";
                    continue;
                }

                ReadOnlySpan<char> span = value;
                int trimmed = 0;

                while (span.EndsWith(trimValue, comparison) && trimmed < maxCount)
                {
                    span = span[..^trimValue.Length];
                    trimmed++;
                }

                yield return span.ToString();
            }
        }

        public static IEnumerable<string> TrimStart(this IEnumerable<string> values, string trimValue, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(trimValue))
                {
                    yield return value ?? "";
                    continue;
                }

                ReadOnlySpan<char> span = value;
                int trimLen = trimValue.Length;

                while (span.StartsWith(trimValue, comparison))
                {
                    span = span[trimLen..];
                }

                yield return span.ToString();
            }
        }

        public static IEnumerable<string> TrimStartMaxCount(this IEnumerable<string> values, string trimValue, int maxCount, StringComparison comparison = StringComparison.Ordinal)
        {
            if (values == null)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(trimValue) || maxCount <= 0)
                {
                    yield return value ?? "";
                    continue;
                }

                ReadOnlySpan<char> span = value;
                int trimmed = 0;

                while (span.StartsWith(trimValue, comparison) && trimmed < maxCount)
                {
                    span = span[trimValue.Length..];
                    trimmed++;
                }

                yield return span.ToString();
            }
        }

        #endregion

        public static IEnumerable<string> NotEmpty(this IEnumerable<string> values)
        {
            if (values == null)
                yield break;

            foreach (var value in values)
            {
                if (!string.IsNullOrEmpty(value))
                    yield return value;
            }
        }

        public static IEnumerable<string> Reverse(this IEnumerable<string> values)
        {
            if (values == null)
                yield break;

            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value))
                    continue;

                char[] chars = value.ToCharArray();
                Array.Reverse(chars);
                yield return new string(chars);
            }
        }

    }
}
