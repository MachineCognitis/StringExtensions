using System;
using System.Collections.Generic;
using System.Linq;

namespace MachineCognitis.StringExtensions
{
    public static class StringExtensions
    {

        #region After

        public static IEnumerable<string> After(this string value, string separator, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(separator))
                yield break;

            int currentIndex = 0;
            int separatorIndex;

            while ((separatorIndex = value.IndexOf(separator, currentIndex, comparison)) >= 0)
            {
                int afterStart = separatorIndex + separator.Length;
                if (afterStart == value.Length)
                {
                    yield return string.Empty;
                    yield break;
                }

                int nextSeparator = value.IndexOf(separator, afterStart, comparison);
                int endIndex = nextSeparator >= 0 ? nextSeparator : value.Length;

                yield return value[afterStart..endIndex];

                currentIndex = endIndex;

                // Break if we've reached or passed the end
                if (nextSeparator < 0)
                    break;
            }
        }

        public static IEnumerable<string> OptionallyAfter(this string value, string separator, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(separator))
                yield break;

            int currentIndex = 0;
            int separatorIndex;

            while ((separatorIndex = value.IndexOf(separator, currentIndex, comparison)) >= 0)
            {
                int afterStart = separatorIndex + separator.Length;
                if (afterStart == value.Length)
                {
                    yield return string.Empty;
                    yield break;
                }

                int nextSeparator = value.IndexOf(separator, afterStart, comparison);
                int endIndex = nextSeparator >= 0 ? nextSeparator : value.Length;

                yield return value[afterStart..endIndex];

                currentIndex = endIndex;

                // Break if we've reached or passed the end
                if (nextSeparator < 0)
                    break;
            }

            if (currentIndex == 0)
                yield return value;
        }

        public static IEnumerable<string> AfterNth(this string value, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            int index = 0;

            for (int i = 0; i < n; i++)
            {
                index = value.IndexOf(separator, index, comparison);
                if (index < 0)
                    yield break;

                index += separator.Length;
            }

            if (index <= value.Length)
                yield return value[index..];
        }

        public static IEnumerable<string> OptionallyAfterNth(this string value, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            int index = 0;

            for (int i = 0; i < n; i++)
            {
                index = value.IndexOf(separator, index, comparison);
                if (index < 0)
                {
                    yield return value;
                    yield break;
                }

                index += separator.Length;
            }

            if (index <= value.Length)
                yield return value[index..];
        }

        public static IEnumerable<string> AfterNthToLast(this string value, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            int index = value.Length;
            int count = 0;

            while (index >= 0)
            {
                index = value.LastIndexOf(separator, index - 1, comparison);
                if (index < 0)
                    break;

                count++;
                if (count == n)
                {
                    int start = index + separator.Length;
                    if (start < value.Length)
                        yield return value[start..];
                    else
                        yield return "";
                    yield break;
                }
            }
        }

        public static IEnumerable<string> OptionallyAfterNthToLast(this string value, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            int index = value.Length;
            int count = 0;

            while (index >= 0)
            {
                index = value.LastIndexOf(separator, index - 1, comparison);
                if (index < 0)
                    break;

                count++;
                if (count == n)
                {
                    int start = index + separator.Length;
                    yield return start < value.Length ? value[start..] : "";
                    yield break;
                }
            }

            yield return value;
        }

        #endregion

        #region Before

        public static IEnumerable<string> Before(this string value, string separator, StringComparison stringComparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(separator))
                yield break;

            int start = 0;
            int index;

            while ((index = value.IndexOf(separator, start, stringComparison)) >= 0)
            {
                yield return value[start..index];
                start = index + separator.Length;
            }
        }

        public static IEnumerable<string> OptionallyBefore(this string value, string separator, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(separator))
                yield break;

            int start = 0;
            int index;

            while ((index = value.IndexOf(separator, start, comparison)) >= 0)
            {
                yield return value[start..index];
                start = index + separator.Length;
            }

            if (start == 0)
                yield return value;
        }

        public static IEnumerable<string> BeforeNth(this string value, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            int count = 0;
            int start = 0;
            int index;

            while ((index = value.IndexOf(separator, start, comparison)) >= 0)
            {
                count++;
                if (count == n)
                {
                    yield return value[..index];
                    yield break;
                }

                start = index + separator.Length;
            }
        }

        public static IEnumerable<string> OptionallyBeforeNth(this string value, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            int count = 0;
            int start = 0;
            int index;

            while ((index = value.IndexOf(separator, start, comparison)) >= 0)
            {
                count++;
                if (count == n)
                {
                    yield return value[..index];
                    yield break;
                }

                start = index + separator.Length;
            }

            if (index == -1)
                yield return value;
        }

        public static IEnumerable<string> BeforeNthToLast(this string value, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            int index = value.Length;
            int count = 0;

            while (index >= 0)
            {
                index = value.LastIndexOf(separator, index - 1, comparison);
                if (index < 0)
                    break;

                count++;
                if (count == n)
                {
                    yield return value[..index];
                    yield break;
                }
            }
        }

        public static IEnumerable<string> OptionallyBeforeNthToLast(this string value, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            int index = value.Length;
            int count = 0;

            while (index >= 0)
            {
                index = value.LastIndexOf(separator, index - 1, comparison);
                if (index < 0)
                    break;

                count++;
                if (count == n)
                {
                    yield return value[..index];
                    yield break;
                }
            }

            if (index == -1)
                yield return value;
        }

        #endregion

        #region Between

        public static IEnumerable<string> Between(this string value, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix))
                yield break;

            int currentIndex = 0;

            while (true)
            {
                int prefixIndex = value.IndexOf(prefix, currentIndex, comparison);
                if (prefixIndex < 0)
                    yield break;

                int start = prefixIndex + prefix.Length;
                int suffixIndex = value.IndexOf(suffix, start, comparison);
                if (suffixIndex < 0)
                    yield break;

                yield return value[start..suffixIndex];
                currentIndex = suffixIndex + suffix.Length;
            }
        }

        public static IEnumerable<string> OptionallyBetween(this string value, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix))
                yield break;

            int currentIndex = 0;

            while (true)
            {
                int prefixIndex = value.IndexOf(prefix, currentIndex, comparison);
                if (prefixIndex < 0)
                    break;

                int start = prefixIndex + prefix.Length;
                int suffixIndex = value.IndexOf(suffix, start, comparison);
                if (suffixIndex < 0)
                    break;

                yield return value[start..suffixIndex];
                currentIndex = suffixIndex + suffix.Length;
            }

            if (currentIndex == 0)
                yield return value;
        }

        public static IEnumerable<string> BetweenNth(this string value, string prefix, string suffix, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix) || n <= 0)
                yield break;

            int count = 0;
            int currentIndex = 0;

            while (true)
            {
                int prefixIndex = value.IndexOf(prefix, currentIndex, comparison);
                if (prefixIndex < 0) break;

                int start = prefixIndex + prefix.Length;
                int suffixIndex = value.IndexOf(suffix, start, comparison);
                if (suffixIndex < 0) break;

                count++;
                if (count == n)
                {
                    yield return value[start..suffixIndex];
                    yield break;
                }

                currentIndex = suffixIndex + suffix.Length;
            }
        }

        public static IEnumerable<string> OptionallyBetweenNth(this string value, string prefix, string suffix, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix) || n <= 0)
                yield break;

            int count = 0;
            int currentIndex = 0;

            while (true)
            {
                int prefixIndex = value.IndexOf(prefix, currentIndex, comparison);
                if (prefixIndex < 0) break;

                int start = prefixIndex + prefix.Length;
                int suffixIndex = value.IndexOf(suffix, start, comparison);
                if (suffixIndex < 0) break;

                count++;
                if (count == n)
                {
                    yield return value[start..suffixIndex];
                    yield break;
                }

                currentIndex = suffixIndex + suffix.Length;
            }

            if (count < n)
                yield return value;
        }

        public static IEnumerable<string> BetweenNthToLast(this string value, string prefix, string suffix, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix) || n <= 0)
                yield break;

            int count = 0;
            int searchStart = value.Length;

            while (searchStart > 0)
            {
                int suffixIndex = value.LastIndexOf(suffix, searchStart - 1, comparison);
                if (suffixIndex < 0)
                    yield break;

                int prefixIndex = value.LastIndexOf(prefix, suffixIndex - 1, comparison);
                if (prefixIndex < 0 || prefixIndex + prefix.Length > suffixIndex)
                {
                    searchStart = suffixIndex;
                    continue;
                }

                count++;
                if (count == n)
                {
                    int start = prefixIndex + prefix.Length;
                    yield return value[start..suffixIndex];
                    yield break;
                }

                searchStart = prefixIndex;
            }
        }

        public static IEnumerable<string> OptionallyBetweenNthToLast(this string value, string prefix, string suffix, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix) || n <= 0)
                yield break;

            int count = 0;
            int searchStart = value.Length;

            while (searchStart > 0)
            {
                int suffixIndex = value.LastIndexOf(suffix, searchStart - 1, comparison);
                if (suffixIndex < 0)
                    break;

                int prefixIndex = value.LastIndexOf(prefix, suffixIndex - 1, comparison);
                if (prefixIndex < 0 || prefixIndex + prefix.Length > suffixIndex)
                {
                    searchStart = suffixIndex;
                    continue;
                }

                count++;
                if (count == n)
                {
                    int start = prefixIndex + prefix.Length;
                    yield return value[start..suffixIndex];
                    yield break;
                }

                searchStart = prefixIndex;
            }

            if (count < n)
                yield return value;
        }

        #endregion

        #region Outside

        public static IEnumerable<string> Outside(this string value, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix))
                yield break;

            int currentIndex = 0;
            bool hasMatch = false;

            while (currentIndex < value.Length)
            {
                int prefixIndex = value.IndexOf(prefix, currentIndex, comparison);
                if (prefixIndex < 0)
                    break;

                int suffixIndex = value.IndexOf(suffix, prefixIndex + prefix.Length, comparison);
                if (suffixIndex < 0)
                    break;

                yield return prefixIndex == currentIndex
                    ? ""
                    : value[currentIndex..prefixIndex];

                currentIndex = suffixIndex + suffix.Length;
                hasMatch = true;
            }

            if (hasMatch)
                yield return currentIndex == value.Length ? "" : value[currentIndex..];
        }

        public static IEnumerable<string> OptionallyOutside(this string value, string prefix, string suffix, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix))
                yield break;

            int currentIndex = 0;
            bool hasMatch = false;

            while (currentIndex < value.Length)
            {
                int prefixIndex = value.IndexOf(prefix, currentIndex, comparison);
                if (prefixIndex < 0)
                    break;

                int suffixIndex = value.IndexOf(suffix, prefixIndex + prefix.Length, comparison);
                if (suffixIndex < 0)
                    break;

                yield return prefixIndex == currentIndex
                    ? ""
                    : value[currentIndex..prefixIndex];

                currentIndex = suffixIndex + suffix.Length;
                hasMatch = true;
            }

            if (hasMatch)
                yield return currentIndex == value.Length ? "" : value[currentIndex..];
            else
                yield return value;
        }

        public static IEnumerable<string> OutsideNth(this string value, string prefix, string suffix, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix) || n <= 0)
                yield break;

            int currentIndex = 0;
            int count = 0;

            while (currentIndex < value.Length)
            {
                int prefixIndex = value.IndexOf(prefix, currentIndex, comparison);
                if (prefixIndex < 0) break;

                int suffixIndex = value.IndexOf(suffix, prefixIndex + prefix.Length, comparison);
                if (suffixIndex < 0) break;

                count++;

                if (count == n)
                {
                    yield return value[..prefixIndex];
                    yield return value[(suffixIndex + suffix.Length)..];
                    yield break;
                }

                currentIndex = suffixIndex + suffix.Length;
            }
        }

        public static IEnumerable<string> OptionallyOutsideNth(this string value, string prefix, string suffix, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix) || n <= 0)
                yield break;

            int currentIndex = 0;
            int count = 0;

            while (currentIndex < value.Length)
            {
                int prefixIndex = value.IndexOf(prefix, currentIndex, comparison);
                if (prefixIndex < 0) break;

                int suffixIndex = value.IndexOf(suffix, prefixIndex + prefix.Length, comparison);
                if (suffixIndex < 0) break;

                count++;

                if (count == n)
                {
                    yield return value[..prefixIndex];
                    yield return value[(suffixIndex + suffix.Length)..];
                    yield break;
                }

                currentIndex = suffixIndex + suffix.Length;
            }

            if (count < n)
                yield return value;
        }

        public static IEnumerable<string> OutsideNthToLast(this string value, string prefix, string suffix, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix) || n <= 0)
                yield break;

            int count = 0;
            int searchStart = value.Length;

            while (searchStart > 0)
            {
                int suffixIndex = value.LastIndexOf(suffix, searchStart - 1, comparison);
                if (suffixIndex < 0)
                    yield break;

                int prefixIndex = value.LastIndexOf(prefix, suffixIndex - 1, comparison);
                if (prefixIndex < 0 || prefixIndex + prefix.Length > suffixIndex)
                {
                    searchStart = suffixIndex;
                    continue;
                }

                count++;
                if (count == n)
                {
                    int suffixEnd = suffixIndex + suffix.Length;
                    yield return prefixIndex > 0 ? value[..prefixIndex] : "";
                    yield return suffixEnd < value.Length ? value[suffixEnd..] : "";
                    yield break;
                }

                searchStart = prefixIndex;
            }
        }

        public static IEnumerable<string> OptionallyOutsideNthToLast(this string value, string prefix, string suffix, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix) || n <= 0)
                yield break;

            int count = 0;
            int searchStart = value.Length;

            while (searchStart > 0)
            {
                int suffixIndex = value.LastIndexOf(suffix, searchStart - 1, comparison);
                if (suffixIndex < 0)
                    break;

                int prefixIndex = value.LastIndexOf(prefix, suffixIndex - 1, comparison);
                if (prefixIndex < 0 || prefixIndex + prefix.Length > suffixIndex)
                {
                    searchStart = suffixIndex;
                    continue;
                }

                count++;
                if (count == n)
                {
                    int suffixEnd = suffixIndex + suffix.Length;
                    yield return prefixIndex > 0 ? value[..prefixIndex] : "";
                    yield return suffixEnd < value.Length ? value[suffixEnd..] : "";
                    yield break;
                }

                searchStart = prefixIndex;
            }

            if (count < n)
                yield return value;
        }

        #endregion

        #region SplitAt

        public static IEnumerable<string> SplitAt(this string value, string separator, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(separator))
                yield break;

            int currentIndex = 0;

            while (true)
            {
                int separatorIndex = value.IndexOf(separator, currentIndex, comparison);
                if (separatorIndex < 0)
                {
                    yield return value[currentIndex..];
                    yield break;
                }

                yield return value[currentIndex..separatorIndex];
                currentIndex = separatorIndex + separator.Length;
            }
        }

        public static IEnumerable<string> OptionallySplitAt(this string value, string separator, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(separator))
                yield break;

            int currentIndex = 0;

            while (true)
            {
                int separatorIndex = value.IndexOf(separator, currentIndex, comparison);
                if (separatorIndex < 0)
                {
                    yield return value[currentIndex..];
                    yield break;
                }

                yield return value[currentIndex..separatorIndex];
                currentIndex = separatorIndex + separator.Length;
            }
        }

        public static IEnumerable<string> SplitAtNth(this string value, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            int index = 0;
            int count = 0;

            while (true)
            {
                int matchIndex = value.IndexOf(separator, index, comparison);
                if (matchIndex < 0)
                    break;

                count++;

                if (count == n)
                {
                    yield return value[..matchIndex];
                    int start = matchIndex + separator.Length;
                    if (start < value.Length)
                        yield return value[start..];
                    else
                        yield return "";
                    yield break;
                }

                index = matchIndex + separator.Length;
            }
        }

        public static IEnumerable<string> OptionallySplitAtNth(this string value, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            int index = 0;
            int count = 0;

            while (true)
            {
                int matchIndex = value.IndexOf(separator, index, comparison);
                if (matchIndex < 0)
                    break;

                count++;

                if (count == n)
                {
                    yield return value[..matchIndex];
                    int start = matchIndex + separator.Length;
                    if (start < value.Length)
                        yield return value[start..];
                    else
                        yield return "";
                    yield break;
                }

                index = matchIndex + separator.Length;
            }

            if (count < n)
                yield return value;
        }

        public static IEnumerable<string> SplitAtNthToLast(this string value, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            int searchStart = value.Length;
            int count = 0;

            while (searchStart > 0)
            {
                int index = value.LastIndexOf(separator, searchStart - 1, comparison);
                if (index < 0)
                    yield break;

                count++;
                if (count == n)
                {
                    yield return index > 0 ? value[..index] : "";

                    int afterStart = index + separator.Length;
                    yield return afterStart < value.Length ? value[afterStart..] : "";
                    yield break;
                }

                searchStart = index;
            }
        }

        public static IEnumerable<string> OptionallySplitAtNthToLast(this string value, string separator, int n, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(separator) || n <= 0)
                yield break;

            int searchStart = value.Length;
            int count = 0;

            while (searchStart > 0)
            {
                int index = value.LastIndexOf(separator, searchStart - 1, comparison);
                if (index < 0)
                    break;

                count++;
                if (count == n)
                {
                    yield return index > 0 ? value[..index] : "";

                    int afterStart = index + separator.Length;
                    yield return afterStart < value.Length ? value[afterStart..] : "";
                    yield break;
                }

                searchStart = index;
            }

            if (count < n)
                yield return value;
        }

        #endregion

        #region Trim

        public static IEnumerable<string> Trim(this string value, string trimValue, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(trimValue))
            {
                yield return value ?? "";
                yield break;
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

        public static IEnumerable<string> TrimMaxCount(this string value, string trimValue, int maxCount, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(trimValue) || maxCount <= 0)
            {
                yield return value ?? "";
                yield break;
            }

            ReadOnlySpan<char> span = value;
            int remaining = maxCount;

            // Leading
            while (span.StartsWith(trimValue, comparison) && remaining > 0)
            {
                span = span[trimValue.Length..];
                remaining--;
            }

            // Trailing
            while (span.EndsWith(trimValue, comparison) && remaining > 0)
            {
                span = span[..^trimValue.Length];
                remaining--;
            }

            yield return span.ToString();
        }

        public static IEnumerable<string> TrimEnd(this string value, string trimValue, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(trimValue))
            {
                yield return value ?? "";
                yield break;
            }

            ReadOnlySpan<char> span = value;
            int trimLen = trimValue.Length;

            while (span.EndsWith(trimValue, comparison))
            {
                span = span[..^trimLen];
            }

            yield return span.ToString();
        }

        public static IEnumerable<string> TrimEndMaxCount(this string value, string trimValue, int maxCount, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(trimValue) || maxCount <= 0)
            {
                yield return value ?? "";
                yield break;
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

        public static IEnumerable<string> TrimStart(this string value, string trimValue, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(trimValue))
            {
                yield return value ?? "";
                yield break;
            }

            ReadOnlySpan<char> span = value;
            int trimLen = trimValue.Length;

            while (span.StartsWith(trimValue, comparison))
            {
                span = span[trimLen..];
            }

            yield return span.ToString();
        }

        public static IEnumerable<string> TrimStartMaxCount(this string value, string trimValue, int maxCount, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(trimValue) || maxCount <= 0)
            {
                yield return value ?? "";
                yield break;
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

        #endregion

        public static IEnumerable<string> NotEmpty(this string value)
        {
            if (value.Length == 0)
                return Enumerable.Empty<string>();

            return new[] { value };
        }

        public static IEnumerable<string> Reverse(this string value)
        {
            if (value.Length == 0)
                yield break;

            char[] chars = value.ToCharArray();
            Array.Reverse(chars);
            yield return new string(chars);
        }

        // Extensions for IEnumerable<string>

        //public static IEnumerable<string> Replace(this string value, string oldValue, string newValue, StringComparison comparison = StringComparison.Ordinal)
        //{

        //}


    }
}
