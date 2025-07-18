
using MachineCognitis.StringExtensions;

namespace StringExtensions.Tests.NonNullable
{
    [TestClass]
    public sealed class StringEnumerableExtensionsTests
    {
        private static string[] Single(params string[] items) => items;

        #region After

        [TestMethod]
        public void After_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.After(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void After_EmptySeparator_ReturnsEmpty()
        {
            var values = new List<string> { "apple,banana" };
            var result = values.After("", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void After_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.After(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void After_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "one,two", "", "three,four" };
            var result = values.After(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "two", "four" }, result);
        }

        [TestMethod]
        public void After_SingleValue_SeparatorFound_ReturnsCorrectSegments()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.After(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "b", "c" }, result);
        }

        [TestMethod]
        public void After_MultipleValues_EachProcessedIndividually()
        {
            var values = new List<string> { "a,b", "x,y,z" };
            var result = values.After(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "b", "y", "z" }, result);
        }

        [TestMethod]
        public void After_SeparatorAtStartOfEntry_ReturnsTrailingSegments()
        {
            var values = new List<string> { ",start,end" };
            var result = values.After(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "start", "end" }, result);
        }

        [TestMethod]
        public void After_SeparatorAtEndOfEntry_ReturnsEmptyTrailingSegment()
        {
            var values = new List<string> { "alpha,beta," };
            var result = values.After(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "beta", "" }, result);
        }

        [TestMethod]
        public void After_ConsecutiveSeparators_ReturnsEmptyBetween()
        {
            var values = new List<string> { "a,,b" };
            var result = values.After(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", "b" }, result);
        }

        [TestMethod]
        public void After_MultiCharacterSeparator_WorksCorrectly()
        {
            var values = new List<string> { "key==value==extra" };
            var result = values.After("==", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "value", "extra" }, result);
        }

        [TestMethod]
        public void After_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.After("b", StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "-C" }, result);
        }

        [TestMethod]
        public void After_CaseSensitiveComparison_DoesNotMatchLowerSeparator()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.After("b", StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        #endregion

        #region OptionallyAfter

        [TestMethod]
        public void OptionallyAfter_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.OptionallyAfter(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfter_EmptySeparator_ReturnsEmpty()
        {
            var values = new List<string> { "apple,banana" };
            var result = values.OptionallyAfter("", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfter_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.OptionallyAfter(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfter_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "one,two", "", "three,four" };
            var result = values.OptionallyAfter(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "two", "four" }, result);
        }

        [TestMethod]
        public void OptionallyAfter_SingleValue_SeparatorFound_ReturnsSegments()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.OptionallyAfter(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "b", "c" }, result);
        }

        [TestMethod]
        public void OptionallyAfter_MultipleValues_ProcessesIndividually()
        {
            var values = new List<string> { "a,b", "x-y" };
            var result = values.OptionallyAfter(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "b", "x-y" }, result);
        }

        [TestMethod]
        public void OptionallyAfter_SeparatorAtStart_ReturnsTrailingSegments()
        {
            var values = new List<string> { ",start,end" };
            var result = values.OptionallyAfter(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "start", "end" }, result);
        }

        [TestMethod]
        public void OptionallyAfter_SeparatorAtEnd_ReturnsEmptySegment()
        {
            var values = new List<string> { "alpha,beta," };
            var result = values.OptionallyAfter(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "beta", "" }, result);
        }

        [TestMethod]
        public void OptionallyAfter_ConsecutiveSeparators_ProducesEmpty()
        {
            var values = new List<string> { "a,,b" };
            var result = values.OptionallyAfter(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", "b" }, result);
        }

        [TestMethod]
        public void OptionallyAfter_MultiCharacterSeparator_WorksCorrectly()
        {
            var values = new List<string> { "key==value==extra" };
            var result = values.OptionallyAfter("==", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "value", "extra" }, result);
        }

        [TestMethod]
        public void OptionallyAfter_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.OptionallyAfter("b", StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "-C" }, result);
        }

        [TestMethod]
        public void OptionallyAfter_CaseSensitiveComparison_NoMatchReturnsOriginal()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.OptionallyAfter("b", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region AfterNth

        [TestMethod]
        public void AfterNth_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.AfterNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNth_EmptySeparator_ReturnsEmpty()
        {
            var values = new List<string> { "apple,banana" };
            var result = values.AfterNth("", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNth_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.AfterNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNth_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "one,two,three" };
            var result = values.AfterNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "three" }, result);
        }

        [TestMethod]
        public void AfterNth_SingleValue_ValidNth_ReturnsCorrectSegment()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.AfterNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "c" }, result);
        }

        [TestMethod]
        public void AfterNth_MultipleValues_EachProcessedIndividually()
        {
            var values = new List<string> { "a,b,c", "x,y,z" };
            var result = values.AfterNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "c", "z" }, result);
        }

        [TestMethod]
        public void AfterNth_SeparatorAtEnd_ReturnsEmptySegment()
        {
            var values = new List<string> { "x,y,z," };
            var result = values.AfterNth(",", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void AfterNth_TooFewSeparators_ReturnsNothing()
        {
            var values = new List<string> { "a,b" };
            var result = values.AfterNth(",", 3, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void AfterNth_MultiCharacterSeparator_WorksCorrectly()
        {
            var values = new List<string> { "key==value==extra" };
            var result = values.AfterNth("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "extra" }, result);
        }

        [TestMethod]
        public void AfterNth_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.AfterNth("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "-C" }, result);
        }

        [TestMethod]
        public void AfterNth_CaseSensitiveComparison_NoMatch()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.AfterNth("b", 1, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        #endregion

        #region OptionallyAfterNth

        [TestMethod]
        public void OptionallyAfterNth_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.OptionallyAfterNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfterNth_EmptySeparator_ReturnsEmpty()
        {
            var values = new List<string> { "apple,banana" };
            var result = values.OptionallyAfterNth("", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfterNth_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.OptionallyAfterNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfterNth_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "one,two,three" };
            var result = values.OptionallyAfterNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "three" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNth_ValidNth_ReturnsCorrectSegment()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.OptionallyAfterNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "c" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNth_TooFewSeparators_ReturnsOriginal()
        {
            var values = new List<string> { "a,b" };
            var result = values.OptionallyAfterNth(",", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNth_SeparatorAtEnd_ReturnsEmptySegment()
        {
            var values = new List<string> { "x,y,z," };
            var result = values.OptionallyAfterNth(",", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNth_MultiCharacterSeparator_WorksCorrectly()
        {
            var values = new List<string> { "key==value==extra" };
            var result = values.OptionallyAfterNth("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "extra" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNth_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.OptionallyAfterNth("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "-C" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNth_CaseSensitiveComparison_NoMatch_ReturnsOriginal()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.OptionallyAfterNth("b", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region AfterNthToLast

        [TestMethod]
        public void AfterNthToLast_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.AfterNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNthToLast_EmptySeparator_ReturnsEmpty()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.AfterNthToLast("", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNthToLast_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.AfterNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNthToLast_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "one,two,three" };
            var result = values.AfterNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "two,three" }, result);
        }

        [TestMethod]
        public void AfterNthToLast_SingleValue_ValidNthToLast_ReturnsCorrectSegment()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.AfterNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "b,c" }, result);
        }

        [TestMethod]
        public void AfterNthToLast_MultipleValues_EachProcessedIndividually()
        {
            var values = new List<string> { "a,b,c", "x,y,z" };
            var result = values.AfterNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "b,c", "y,z" }, result);
        }

        [TestMethod]
        public void AfterNthToLast_SeparatorAtEnd_ReturnsEmptySegment()
        {
            var values = new List<string> { "x,y,z," };
            var result = values.AfterNthToLast(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void AfterNthToLast_TooFewSeparators_ReturnsNothing()
        {
            var values = new List<string> { "a,b" };
            var result = values.AfterNthToLast(",", 3, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void AfterNthToLast_MultiCharacterSeparator_WorksCorrectly()
        {
            var values = new List<string> { "key==value==extra" };
            var result = values.AfterNthToLast("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "value==extra" }, result);
        }

        [TestMethod]
        public void AfterNthToLast_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.AfterNthToLast("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "-C" }, result);
        }

        [TestMethod]
        public void AfterNthToLast_CaseSensitiveComparison_NoMatch()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.AfterNthToLast("b", 1, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        #endregion

        #region OptionallyAfterNthToLast

        [TestMethod]
        public void OptionallyAfterNthToLast_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.OptionallyAfterNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_EmptySeparator_ReturnsEmpty()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.OptionallyAfterNthToLast("", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.OptionallyAfterNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "one,two,three" };
            var result = values.OptionallyAfterNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "two,three" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_SingleValue_ValidNthToLast_ReturnsCorrectSegment()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.OptionallyAfterNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "b,c" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_MultipleValues_EachProcessedIndividually()
        {
            var values = new List<string> { "a,b,c", "x,y,z" };
            var result = values.OptionallyAfterNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "b,c", "y,z" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_SeparatorAtEnd_ReturnsEmptySegment()
        {
            var values = new List<string> { "x,y,z," };
            var result = values.OptionallyAfterNthToLast(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_TooFewSeparators_ReturnsOriginal()
        {
            var values = new List<string> { "a,b" };
            var result = values.OptionallyAfterNthToLast(",", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_MultiCharacterSeparator_WorksCorrectly()
        {
            var values = new List<string> { "key==value==extra" };
            var result = values.OptionallyAfterNthToLast("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "value==extra" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.OptionallyAfterNthToLast("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "-C" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_CaseSensitiveComparison_NoMatch_ReturnsOriginal()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.OptionallyAfterNthToLast("b", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region Before

        [TestMethod]
        public void Before_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.Before(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Before_EmptySeparator_ReturnsEmpty()
        {
            var values = new List<string> { "apple,banana" };
            var result = values.Before("", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Before_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.Before(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Before_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "x,y" };
            var result = values.Before(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "x" }, result);
        }

        [TestMethod]
        public void Before_SeparatorInValue_ReturnsSegments()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.Before(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "b" }, result);
        }

        [TestMethod]
        public void Before_MultipleValues_EachProcessedIndividually()
        {
            var values = new List<string> { "a,b", "x,y,z" };
            var result = values.Before(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "x", "y" }, result);
        }

        [TestMethod]
        public void Before_ConsecutiveSeparators_ReturnsEmptyBetween()
        {
            var values = new List<string> { "a,,b" };
            var result = values.Before(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "", }, result);
        }

        [TestMethod]
        public void Before_MultiCharacterSeparator_WorksCorrectly()
        {
            var values = new List<string> { "key==value==extra" };
            var result = values.Before("==", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key", "value" }, result);
        }

        [TestMethod]
        public void Before_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.Before("b", StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-" }, result);
        }

        [TestMethod]
        public void Before_CaseSensitiveComparison_DoesNotMatchLowerSeparator()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.Before("b", StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        #endregion

        #region OptionallyBefore

        [TestMethod]
        public void OptionallyBefore_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.OptionallyBefore(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBefore_EmptySeparator_ReturnsEmpty()
        {
            var values = new List<string> { "apple,banana" };
            var result = values.OptionallyBefore("", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBefore_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.OptionallyBefore(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBefore_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "x,y" };
            var result = values.OptionallyBefore(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "x" }, result);
        }

        [TestMethod]
        public void OptionallyBefore_SeparatorInValue_ReturnsSegments()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.OptionallyBefore(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "b" }, result);
        }

        [TestMethod]
        public void OptionallyBefore_SeparatorNotInValue_ReturnsOriginal()
        {
            var values = new List<string> { "abc" };
            var result = values.OptionallyBefore(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "abc" }, result);
        }

        [TestMethod]
        public void OptionallyBefore_MultiCharacterSeparator_WorksCorrectly()
        {
            var values = new List<string> { "key==value==extra" };
            var result = values.OptionallyBefore("==", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key", "value" }, result);
        }

        [TestMethod]
        public void OptionallyBefore_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.OptionallyBefore("b", StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-" }, result);
        }

        [TestMethod]
        public void OptionallyBefore_CaseSensitiveComparison_DoesNotMatchLowerSeparator_ReturnsOriginal()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.OptionallyBefore("b", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region BeforeNth

        [TestMethod]
        public void BeforeNth_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.BeforeNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNth_EmptySeparator_ReturnsEmpty()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.BeforeNth("", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNth_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.BeforeNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNth_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "one,two,three" };
            var result = values.BeforeNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one,two" }, result);
        }

        [TestMethod]
        public void BeforeNth_SingleValue_ValidNth_ReturnsExpected()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.BeforeNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b" }, result);
        }

        [TestMethod]
        public void BeforeNth_MultipleValues_EachProcessedIndividually()
        {
            var values = new List<string> { "a,b,c", "x,y,z" };
            var result = values.BeforeNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b", "x,y" }, result);
        }

        [TestMethod]
        public void BeforeNth_TooFewSeparators_ReturnsNothing()
        {
            var values = new List<string> { "a,b" };
            var result = values.BeforeNth(",", 3, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void BeforeNth_MultiCharacterSeparator_WorksCorrectly()
        {
            var values = new List<string> { "key==value==extra" };
            var result = values.BeforeNth("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key==value" }, result);
        }

        [TestMethod]
        public void BeforeNth_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.BeforeNth("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-" }, result);
        }

        [TestMethod]
        public void BeforeNth_CaseSensitiveComparison_NoMatch()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.BeforeNth("b", 1, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        #endregion

        #region OptionallyBeforeNth

        [TestMethod]
        public void OptionallyBeforeNth_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.OptionallyBeforeNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBeforeNth_EmptySeparator_ReturnsEmpty()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.OptionallyBeforeNth("", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBeforeNth_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.OptionallyBeforeNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBeforeNth_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "one,two,three" };
            var result = values.OptionallyBeforeNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one,two" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNth_ValidNth_ReturnsExpected()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.OptionallyBeforeNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNth_TooFewSeparators_ReturnsOriginal()
        {
            var values = new List<string> { "a,b" };
            var result = values.OptionallyBeforeNth(",", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNth_MultiCharacterSeparator_WorksCorrectly()
        {
            var values = new List<string> { "key==value==extra" };
            var result = values.OptionallyBeforeNth("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key==value" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNth_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.OptionallyBeforeNth("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNth_CaseSensitiveComparison_NoMatch_ReturnsOriginal()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.OptionallyBeforeNth("b", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region BeforeNthToLast

        [TestMethod]
        public void BeforeNthToLast_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.BeforeNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNthToLast_EmptySeparator_ReturnsEmpty()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.BeforeNthToLast("", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNthToLast_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.BeforeNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNthToLast_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "one,two,three" };
            var result = values.BeforeNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one" }, result);
        }

        [TestMethod]
        public void BeforeNthToLast_SingleValue_ValidNthToLast_ReturnsExpected()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.BeforeNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a" }, result);
        }

        [TestMethod]
        public void BeforeNthToLast_MultipleValues_EachProcessedIndividually()
        {
            var values = new List<string> { "a,b,c", "x,y,z" };
            var result = values.BeforeNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "x" }, result);
        }

        [TestMethod]
        public void BeforeNthToLast_TooFewSeparators_ReturnsNothing()
        {
            var values = new List<string> { "a,b" };
            var result = values.BeforeNthToLast(",", 3, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void BeforeNthToLast_MultiCharacterSeparator_WorksCorrectly()
        {
            var values = new List<string> { "key==value==extra" };
            var result = values.BeforeNthToLast("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key" }, result);
        }

        [TestMethod]
        public void BeforeNthToLast_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.BeforeNthToLast("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-" }, result);
        }

        [TestMethod]
        public void BeforeNthToLast_CaseSensitiveComparison_NoMatch()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.BeforeNthToLast("b", 1, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        #endregion

        #region OptionallyBeforeNthToLast

        [TestMethod]
        public void OptionallyBeforeNthToLast_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.OptionallyBeforeNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_EmptySeparator_ReturnsEmpty()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.OptionallyBeforeNthToLast("", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.OptionallyBeforeNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "one,two,three" };
            var result = values.OptionallyBeforeNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_SingleValue_ValidNthToLast_ReturnsExpected()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.OptionallyBeforeNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_MultipleValues_EachProcessedIndividually()
        {
            var values = new List<string> { "a,b,c", "x,y,z" };
            var result = values.OptionallyBeforeNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "x" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_TooFewSeparators_ReturnsOriginal()
        {
            var values = new List<string> { "a,b" };
            var result = values.OptionallyBeforeNthToLast(",", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_MultiCharacterSeparator_WorksCorrectly()
        {
            var values = new List<string> { "key==value==extra" };
            var result = values.OptionallyBeforeNthToLast("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.OptionallyBeforeNthToLast("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_CaseSensitiveComparison_NoMatch_ReturnsOriginal()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.OptionallyBeforeNthToLast("b", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region Between

        [TestMethod]
        public void Between_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.Between("{", "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Between_NullPrefix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.Between(null, "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Between_NullSuffix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.Between("{", null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Between_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.Between("{", "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Between_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "Hello {name}" };
            var result = values.Between("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "name" }, result);
        }

        [TestMethod]
        public void Between_SingleValue_OnePair_ReturnsContent()
        {
            var values = new List<string> { "Welcome {guest}!" };
            var result = values.Between("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "guest" }, result);
        }

        [TestMethod]
        public void Between_MultipleValues_ReturnsAllMatches()
        {
            var values = new List<string> { "Hello {name}", "Your {role} is active" };
            var result = values.Between("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "name", "role" }, result);
        }

        [TestMethod]
        public void Between_ConsecutivePairs_ReturnsEachMatch()
        {
            var values = new List<string> { "{a}{b}{c}" };
            var result = values.Between("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "b", "c" }, result);
        }

        [TestMethod]
        public void Between_MultiCharacterDelimiters_WorksCorrectly()
        {
            var values = new List<string> { "<<one>> and <<two>>" };
            var result = values.Between("<<", ">>", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one", "two" }, result);
        }

        [TestMethod]
        public void Between_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "Start[Name]End" };
            var result = values.Between("[name", "]", StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void Between_CaseSensitiveComparison_NoMatch()
        {
            var values = new List<string> { "Start[Name]End" };
            var result = values.Between("[name", "]", StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        #endregion

        #region OptionallyBetween

        [TestMethod]
        public void OptionallyBetween_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.OptionallyBetween("{", "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetween_NullPrefix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.OptionallyBetween(null, "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetween_NullSuffix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.OptionallyBetween("{", null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetween_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.OptionallyBetween("{", "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetween_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "Hello {name}" };
            var result = values.OptionallyBetween("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "name" }, result);
        }

        [TestMethod]
        public void OptionallyBetween_SingleValue_OnePair_ReturnsContent()
        {
            var values = new List<string> { "Welcome {guest}!" };
            var result = values.OptionallyBetween("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "guest" }, result);
        }

        [TestMethod]
        public void OptionallyBetween_SeparatorNotFound_ReturnsOriginal()
        {
            var values = new List<string> { "No delimiters here" };
            var result = values.OptionallyBetween("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "No delimiters here" }, result);
        }

        [TestMethod]
        public void OptionallyBetween_MultipleValues_ReturnsAllMatchesOrOriginals()
        {
            var values = new List<string> { "Hello {name}", "No brackets", "Your {role}" };
            var result = values.OptionallyBetween("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "name", "No brackets", "role" }, result);
        }

        [TestMethod]
        public void OptionallyBetween_MultiCharacterDelimiters_WorksCorrectly()
        {
            var values = new List<string> { "<<one>> and <<two>>", "no match" };
            var result = values.OptionallyBetween("<<", ">>", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one", "two", "no match" }, result);
        }

        [TestMethod]
        public void OptionallyBetween_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "Start[Name]End" };
            var result = values.OptionallyBetween("[name", "]", StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void OptionallyBetween_CaseSensitiveComparison_NoMatch_ReturnsOriginal()
        {
            var values = new List<string> { "Start[Name]End" };
            var result = values.OptionallyBetween("[name", "]", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start[Name]End" }, result);
        }

        #endregion

        #region BetweenNth

        [TestMethod]
        public void BetweenNth_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.BetweenNth("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNth_NullPrefix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.BetweenNth(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNth_NullSuffix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.BetweenNth("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNth_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.BetweenNth("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNth_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "Hello {name} {role}" };
            var result = values.BetweenNth("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "role" }, result);
        }

        [TestMethod]
        public void BetweenNth_SingleValue_ValidNth_ReturnsExpected()
        {
            var values = new List<string> { "Welcome {guest} {admin}" };
            var result = values.BetweenNth("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "admin" }, result);
        }

        [TestMethod]
        public void BetweenNth_MultipleValues_EachProcessedIndividually()
        {
            var values = new List<string> { "Hello {name} {role}", "User {id} {type}" };
            var result = values.BetweenNth("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "role", "type" }, result);
        }

        [TestMethod]
        public void BetweenNth_TooFewPairs_ReturnsNothing()
        {
            var values = new List<string> { "Only {one}" };
            var result = values.BetweenNth("{", "}", 2, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void BetweenNth_MultiCharacterDelimiters_WorksCorrectly()
        {
            var values = new List<string> { "<<one>> <<two>> <<three>>" };
            var result = values.BetweenNth("<<", ">>", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "three" }, result);
        }

        [TestMethod]
        public void BetweenNth_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "Start[Name][Role]" };
            var result = values.BetweenNth("[role", "]", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void BetweenNth_CaseSensitiveComparison_NoMatch()
        {
            var values = new List<string> { "Start[Name][Role]" };
            var result = values.BetweenNth("[role", "]", 1, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        #endregion

        #region OptionallyBetweenNth

        [TestMethod]
        public void OptionallyBetweenNth_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.OptionallyBetweenNth("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetweenNth_NullPrefix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.OptionallyBetweenNth(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetweenNth_NullSuffix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.OptionallyBetweenNth("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetweenNth_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.OptionallyBetweenNth("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetweenNth_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "Hello {name} {role}" };
            var result = values.OptionallyBetweenNth("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "role" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNth_ValidNth_ReturnsExpected()
        {
            var values = new List<string> { "Welcome {guest} {admin}" };
            var result = values.OptionallyBetweenNth("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "admin" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNth_TooFewPairs_ReturnsOriginal()
        {
            var values = new List<string> { "Only {one}" };
            var result = values.OptionallyBetweenNth("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Only {one}" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNth_MultiCharacterDelimiters_WorksCorrectly()
        {
            var values = new List<string> { "<<one>> <<two>> <<three>>" };
            var result = values.OptionallyBetweenNth("<<", ">>", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "three" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNth_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "Start[Name][Role]" };
            var result = values.OptionallyBetweenNth("[role", "]", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNth_CaseSensitiveComparison_NoMatch_ReturnsOriginal()
        {
            var values = new List<string> { "Start[Name][Role]" };
            var result = values.OptionallyBetweenNth("[role", "]", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start[Name][Role]" }, result);
        }

        #endregion

        #region BetweenNthToLast

        [TestMethod]
        public void BetweenNthToLast_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.BetweenNthToLast("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNthToLast_NullPrefix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.BetweenNthToLast(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNthToLast_NullSuffix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.BetweenNthToLast("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNthToLast_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.BetweenNthToLast("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNthToLast_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "Hello {name} {role}" };
            var result = values.BetweenNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "name" }, result);
        }

        [TestMethod]
        public void BetweenNthToLast_SingleValue_ValidNthToLast_ReturnsExpected()
        {
            var values = new List<string> { "Welcome {guest} {admin}" };
            var result = values.BetweenNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "guest" }, result);
        }

        [TestMethod]
        public void BetweenNthToLast_MultipleValues_EachProcessedIndividually()
        {
            var values = new List<string> { "Hello {name} {role}", "User {id} {type}" };
            var result = values.BetweenNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "name", "id" }, result);
        }

        [TestMethod]
        public void BetweenNthToLast_TooFewPairs_ReturnsNothing()
        {
            var values = new List<string> { "Only {one}" };
            var result = values.BetweenNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void BetweenNthToLast_MultiCharacterDelimiters_WorksCorrectly()
        {
            var values = new List<string> { "<<one>> <<two>> <<three>>" };
            var result = values.BetweenNthToLast("<<", ">>", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "two" }, result);
        }

        [TestMethod]
        public void BetweenNthToLast_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "Start[Name][Role]" };
            var result = values.BetweenNthToLast("[role", "]", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void BetweenNthToLast_CaseSensitiveComparison_NoMatch()
        {
            var values = new List<string> { "Start[Name][Role]" };
            var result = values.BetweenNthToLast("[role", "]", 1, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        #endregion

        #region OptionallyBetweenNthToLast

        [TestMethod]
        public void OptionallyBetweenNthToLast_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.OptionallyBetweenNthToLast("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_NullPrefix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.OptionallyBetweenNthToLast(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_NullSuffix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.OptionallyBetweenNthToLast("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.OptionallyBetweenNthToLast("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "Hello {name} {role}" };
            var result = values.OptionallyBetweenNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "name" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_SingleValue_ValidNthToLast_ReturnsExpected()
        {
            var values = new List<string> { "Welcome {guest} {admin}" };
            var result = values.OptionallyBetweenNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "guest" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_TooFewPairs_ReturnsOriginal()
        {
            var values = new List<string> { "Only {one}" };
            var result = values.OptionallyBetweenNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Only {one}" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_MultiCharacterDelimiters_WorksCorrectly()
        {
            var values = new List<string> { "<<one>> <<two>> <<three>>" };
            var result = values.OptionallyBetweenNthToLast("<<", ">>", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "two" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "Start[Name][Role]" };
            var result = values.OptionallyBetweenNthToLast("[role", "]", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_CaseSensitiveComparison_NoMatch_ReturnsOriginal()
        {
            var values = new List<string> { "Start[Name][Role]" };
            var result = values.OptionallyBetweenNthToLast("[role", "]", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start[Name][Role]" }, result);
        }

        #endregion

        #region Outside

        [TestMethod]
        public void Outside_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.Outside("{", "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Outside_NullPrefix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.Outside(null, "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Outside_NullSuffix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.Outside("{", null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Outside_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.Outside("{", "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Outside_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "Hello {name}" };
            var result = values.Outside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello ", "" }, result);
        }

        [TestMethod]
        public void Outside_SingleValue_OnePair_ReturnsOutsideParts()
        {
            var values = new List<string> { "Welcome {guest}!" };
            var result = values.Outside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Welcome ", "!" }, result);
        }

        [TestMethod]
        public void Outside_MultipleValues_ReturnsAllOutsideParts()
        {
            var values = new List<string> { "Hello {name}", "Your {role} is active" };
            var result = values.Outside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello ", "", "Your ", " is active" }, result);
        }

        [TestMethod]
        public void Outside_ConsecutivePairs_ReturnsOutsideSegments()
        {
            var values = new List<string> { "{a}{b}{c}" };
            var result = values.Outside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", "", "", "" }, result);
        }

        [TestMethod]
        public void Outside_MultiCharacterDelimiters_WorksCorrectly()
        {
            var values = new List<string> { "<<one>> and <<two>>" };
            var result = values.Outside("<<", ">>", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", " and ", "" }, result);
        }

        [TestMethod]
        public void Outside_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "Start[Name]End" };
            var result = values.Outside("[name", "]", StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start", "End" }, result);
        }

        [TestMethod]
        public void Outside_CaseSensitiveComparison_NoMatch()
        {
            var values = new List<string> { "Start[Name]End" };
            var result = values.Outside("[name", "]", StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        #endregion

        #region OptionallyOutside

        [TestMethod]
        public void OptionallyOutside_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.OptionallyOutside("{", "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutside_NullPrefix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.OptionallyOutside(null, "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutside_NullSuffix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.OptionallyOutside("{", null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutside_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.OptionallyOutside("{", "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutside_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "Hello {name}" };
            var result = values.OptionallyOutside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello ", "" }, result);
        }

        [TestMethod]
        public void OptionallyOutside_SingleValue_OnePair_ReturnsOutsideParts()
        {
            var values = new List<string> { "Welcome {guest}!" };
            var result = values.OptionallyOutside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Welcome ", "!" }, result);
        }

        [TestMethod]
        public void OptionallyOutside_SeparatorNotFound_ReturnsOriginal()
        {
            var values = new List<string> { "No delimiters here" };
            var result = values.OptionallyOutside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "No delimiters here" }, result);
        }

        [TestMethod]
        public void OptionallyOutside_MultipleValues_ReturnsOutsideOrOriginal()
        {
            var values = new List<string> { "Hello {name}", "No brackets", "Your {role}" };
            var result = values.OptionallyOutside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello ", "", "No brackets", "Your ", "" }, result);
        }

        [TestMethod]
        public void OptionallyOutside_MultiCharacterDelimiters_WorksCorrectly()
        {
            var values = new List<string> { "<<one>> and <<two>>", "no match" };
            var result = values.OptionallyOutside("<<", ">>", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", " and ", "", "no match" }, result);
        }

        [TestMethod]
        public void OptionallyOutside_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "Start[Name]End" };
            var result = values.OptionallyOutside("[name", "]", StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start", "End" }, result);
        }

        [TestMethod]
        public void OptionallyOutside_CaseSensitiveComparison_NoMatch_ReturnsOriginal()
        {
            var values = new List<string> { "Start[Name]End" };
            var result = values.OptionallyOutside("[name", "]", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start[Name]End" }, result);
        }

        #endregion

        #region OutsideNth

        [TestMethod]
        public void OutsideNth_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.OutsideNth("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNth_NullPrefix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.OutsideNth(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNth_NullSuffix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.OutsideNth("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNth_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.OutsideNth("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNth_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "Hello {name} {role}" };
            var result = values.OutsideNth("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello {name} ", "" }, result);
        }

        [TestMethod]
        public void OutsideNth_SingleValue_ValidNth_ReturnsOutsideParts()
        {
            var values = new List<string> { "Welcome {guest} {admin}" };
            var result = values.OutsideNth("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Welcome {guest} ", "" }, result);
        }

        [TestMethod]
        public void OutsideNth_MultipleValues_EachProcessedIndividually()
        {
            var values = new List<string> { "Hello {name} {role}", "User {id} {type}" };
            var result = values.OutsideNth("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello {name} ", "", "User {id} ", "" }, result);
        }

        [TestMethod]
        public void OutsideNth_TooFewPairs_ReturnsNothing()
        {
            var values = new List<string> { "Only {one}" };
            var result = values.OutsideNth("{", "}", 2, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void OutsideNth_MultiCharacterDelimiters_WorksCorrectly()
        {
            var values = new List<string> { "<<one>> <<two>> <<three>>" };
            var result = values.OutsideNth("<<", ">>", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "<<one>> <<two>> ", "" }, result);
        }

        [TestMethod]
        public void OutsideNth_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "Start[Name][Role]" };
            var result = values.OutsideNth("[role", "]", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start[Name]", "" }, result);
        }

        [TestMethod]
        public void OutsideNth_CaseSensitiveComparison_NoMatch()
        {
            var values = new List<string> { "Start[Name][Role]" };
            var result = values.OutsideNth("[role", "]", 1, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        #endregion

        #region OptionallyOutsideNth

        [TestMethod]
        public void OptionallyOutsideNth_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.OptionallyOutsideNth("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutsideNth_NullPrefix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.OptionallyOutsideNth(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutsideNth_NullSuffix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.OptionallyOutsideNth("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutsideNth_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.OptionallyOutsideNth("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutsideNth_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "Hello {name} {role}" };
            var result = values.OptionallyOutsideNth("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello {name} ", "" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNth_SingleValue_ValidNth_ReturnsOutsideParts()
        {
            var values = new List<string> { "Welcome {guest} {admin}" };
            var result = values.OptionallyOutsideNth("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Welcome {guest} ", "" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNth_TooFewPairs_ReturnsOriginal()
        {
            var values = new List<string> { "Only {one}" };
            var result = values.OptionallyOutsideNth("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Only {one}" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNth_MultiCharacterDelimiters_WorksCorrectly()
        {
            var values = new List<string> { "<<one>> <<two>> <<three>>" };
            var result = values.OptionallyOutsideNth("<<", ">>", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "<<one>> <<two>> ", "" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNth_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "Start[Name][Role]" };
            var result = values.OptionallyOutsideNth("[role", "]", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start[Name]", "" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNth_CaseSensitiveComparison_NoMatch_ReturnsOriginal()
        {
            var values = new List<string> { "Start[Name][Role]" };
            var result = values.OptionallyOutsideNth("[role", "]", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start[Name][Role]" }, result);
        }

        #endregion

        #region OutsideNthToLast

        [TestMethod]
        public void OutsideNthToLast_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.OutsideNthToLast("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNthToLast_NullPrefix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.OutsideNthToLast(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNthToLast_NullSuffix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.OutsideNthToLast("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNthToLast_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.OutsideNthToLast("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNthToLast_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "Hello {name} {role}" };
            var result = values.OutsideNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello ", " {role}" }, result);
        }

        [TestMethod]
        public void OutsideNthToLast_SingleValue_ValidNthToLast_ReturnsExpected()
        {
            var values = new List<string> { "Welcome {guest} {admin}" };
            var result = values.OutsideNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Welcome ", " {admin}" }, result);
        }

        [TestMethod]
        public void OutsideNthToLast_MultipleValues_EachProcessedIndividually()
        {
            var values = new List<string> { "Hello {name} {role}", "User {id} {type}" };
            var result = values.OutsideNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello ", " {role}", "User ", " {type}" }, result);
        }

        [TestMethod]
        public void OutsideNthToLast_TooFewPairs_ReturnsNothing()
        {
            var values = new List<string> { "Only {one}" };
            var result = values.OutsideNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void OutsideNthToLast_MultiCharacterDelimiters_WorksCorrectly()
        {
            var values = new List<string> { "<<one>> <<two>> <<three>>" };
            var result = values.OutsideNthToLast("<<", ">>", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "<<one>> ", " <<three>>" }, result);
        }

        [TestMethod]
        public void OutsideNthToLast_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "Start[Name][Role]" };
            var result = values.OutsideNthToLast("[role", "]", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start[Name]", "" }, result);
        }

        [TestMethod]
        public void OutsideNthToLast_CaseSensitiveComparison_NoMatch()
        {
            var values = new List<string> { "Start[Name][Role]" };
            var result = values.OutsideNthToLast("[role", "]", 1, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        #endregion

        #region OptionallyOutsideNthToLast

        [TestMethod]
        public void OptionallyOutsideNthToLast_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.OptionallyOutsideNthToLast("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_NullPrefix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.OptionallyOutsideNthToLast(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_NullSuffix_ReturnsEmpty()
        {
            var values = new List<string> { "Hello {name}" };
            var result = values.OptionallyOutsideNthToLast("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.OptionallyOutsideNthToLast("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "Hello {name} {role}" };
            var result = values.OptionallyOutsideNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello ", " {role}" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_SingleValue_ValidNthToLast_ReturnsExpected()
        {
            var values = new List<string> { "Welcome {guest} {admin}" };
            var result = values.OptionallyOutsideNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Welcome ", " {admin}" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_TooFewPairs_ReturnsOriginal()
        {
            var values = new List<string> { "Only {one}" };
            var result = values.OptionallyOutsideNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Only {one}" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_MultiCharacterDelimiters_WorksCorrectly()
        {
            var values = new List<string> { "<<one>> <<two>> <<three>>" };
            var result = values.OptionallyOutsideNthToLast("<<", ">>", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "<<one>> ", " <<three>>" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "Start[Name][Role]" };
            var result = values.OptionallyOutsideNthToLast("[role", "]", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start[Name]", "" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_CaseSensitiveComparison_NoMatch_ReturnsOriginal()
        {
            var values = new List<string> { "Start[Name][Role]" };
            var result = values.OptionallyOutsideNthToLast("[role", "]", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start[Name][Role]" }, result);
        }

        #endregion

        #region SplitAt

        [TestMethod]
        public void SplitAt_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.SplitAt(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAt_EmptySeparator_ReturnsEmpty()
        {
            var values = new List<string> { "apple,banana" };
            var result = values.SplitAt("", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAt_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.SplitAt(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAt_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "one,two" };
            var result = values.SplitAt(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one", "two" }, result);
        }

        [TestMethod]
        public void SplitAt_SingleValue_SeparatorFound_ReturnsSegments()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.SplitAt(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "b", "c" }, result);
        }

        [TestMethod]
        public void SplitAt_MultipleValues_EachProcessedIndividually()
        {
            var values = new List<string> { "a,b", "x,y,z" };
            var result = values.SplitAt(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "b", "x", "y", "z" }, result);
        }

        [TestMethod]
        public void SplitAt_ConsecutiveSeparators_ReturnsEmptyBetween()
        {
            var values = new List<string> { "a,,b" };
            var result = values.SplitAt(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "", "b" }, result);
        }

        [TestMethod]
        public void SplitAt_MultiCharacterSeparator_WorksCorrectly()
        {
            var values = new List<string> { "key==value==extra" };
            var result = values.SplitAt("==", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key", "value", "extra" }, result);
        }

        [TestMethod]
        public void SplitAt_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.SplitAt("b", StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-", "-C" }, result);
        }

        [TestMethod]
        public void SplitAt_CaseSensitiveComparison_NoMatch()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.SplitAt("b", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region OptionallySplitAt

        [TestMethod]
        public void OptionallySplitAt_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.OptionallySplitAt(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAt_EmptySeparator_ReturnsEmpty()
        {
            var values = new List<string> { "apple,banana" };
            var result = values.OptionallySplitAt("", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAt_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.OptionallySplitAt(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAt_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "one,two" };
            var result = values.OptionallySplitAt(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one", "two" }, result);
        }

        [TestMethod]
        public void OptionallySplitAt_SingleValue_SeparatorFound_ReturnsSegments()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.OptionallySplitAt(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "b", "c" }, result);
        }

        [TestMethod]
        public void OptionallySplitAt_SeparatorNotFound_ReturnsOriginal()
        {
            var values = new List<string> { "abc" };
            var result = values.OptionallySplitAt(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "abc" }, result);
        }

        [TestMethod]
        public void OptionallySplitAt_MultiCharacterSeparator_WorksCorrectly()
        {
            var values = new List<string> { "key==value==extra" };
            var result = values.OptionallySplitAt("==", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key", "value", "extra" }, result);
        }

        [TestMethod]
        public void OptionallySplitAt_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.OptionallySplitAt("b", StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-", "-C" }, result);
        }

        [TestMethod]
        public void OptionallySplitAt_CaseSensitiveComparison_NoMatch_ReturnsOriginal()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.OptionallySplitAt("b", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region SplitAtNth

        [TestMethod]
        public void SplitAtNth_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.SplitAtNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAtNth_EmptySeparator_ReturnsEmpty()
        {
            var values = new List<string> { "apple,banana" };
            var result = values.SplitAtNth("", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAtNth_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.SplitAtNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAtNth_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "one,two,three" };
            var result = values.SplitAtNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one,two", "three" }, result);
        }

        [TestMethod]
        public void SplitAtNth_SingleValue_ValidNth_ReturnsSplit()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.SplitAtNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b", "c" }, result);
        }

        [TestMethod]
        public void SplitAtNth_MultipleValues_EachProcessedIndividually()
        {
            var values = new List<string> { "a,b,c", "x,y,z" };
            var result = values.SplitAtNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b", "c", "x,y", "z" }, result);
        }

        [TestMethod]
        public void SplitAtNth_TooFewSeparators_ReturnsNothing()
        {
            var values = new List<string> { "a,b" };
            var result = values.SplitAtNth(",", 3, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void SplitAtNth_MultiCharacterSeparator_WorksCorrectly()
        {
            var values = new List<string> { "key==value==extra" };
            var result = values.SplitAtNth("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key==value", "extra" }, result);
        }

        [TestMethod]
        public void SplitAtNth_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.SplitAtNth("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-", "-C" }, result);
        }

        [TestMethod]
        public void SplitAtNth_CaseSensitiveComparison_NoMatch()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.SplitAtNth("b", 1, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        #endregion

        #region OptionallySplitAtNth

        [TestMethod]
        public void OptionallySplitAtNth_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.OptionallySplitAtNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAtNth_EmptySeparator_ReturnsEmpty()
        {
            var values = new List<string> { "apple,banana" };
            var result = values.OptionallySplitAtNth("", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAtNth_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.OptionallySplitAtNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAtNth_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "one,two,three" };
            var result = values.OptionallySplitAtNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one,two", "three" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNth_SingleValue_ValidNth_ReturnsSplit()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.OptionallySplitAtNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b", "c" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNth_TooFewSeparators_ReturnsOriginal()
        {
            var values = new List<string> { "a,b" };
            var result = values.OptionallySplitAtNth(",", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNth_MultiCharacterSeparator_WorksCorrectly()
        {
            var values = new List<string> { "key==value==extra" };
            var result = values.OptionallySplitAtNth("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key==value", "extra" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNth_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.OptionallySplitAtNth("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-", "-C" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNth_CaseSensitiveComparison_NoMatch_ReturnsOriginal()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.OptionallySplitAtNth("b", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region SplitAtNthToLast

        [TestMethod]
        public void SplitAtNthToLast_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.SplitAtNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAtNthToLast_EmptySeparator_ReturnsEmpty()
        {
            var values = new List<string> { "apple,banana" };
            var result = values.SplitAtNthToLast("", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAtNthToLast_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.SplitAtNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAtNthToLast_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "one,two,three" };
            var result = values.SplitAtNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one", "two,three" }, result);
        }

        [TestMethod]
        public void SplitAtNthToLast_SingleValue_ValidNthToLast_ReturnsSplit()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.SplitAtNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "b,c" }, result);
        }

        [TestMethod]
        public void SplitAtNthToLast_MultipleValues_EachProcessedIndividually()
        {
            var values = new List<string> { "a,b,c", "x,y,z" };
            var result = values.SplitAtNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "b,c", "x", "y,z" }, result);
        }

        [TestMethod]
        public void SplitAtNthToLast_TooFewSeparators_ReturnsNothing()
        {
            var values = new List<string> { "a,b" };
            var result = values.SplitAtNthToLast(",", 3, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void SplitAtNthToLast_MultiCharacterSeparator_WorksCorrectly()
        {
            var values = new List<string> { "key==value==extra" };
            var result = values.SplitAtNthToLast("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key", "value==extra" }, result);
        }

        [TestMethod]
        public void SplitAtNthToLast_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.SplitAtNthToLast("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-", "-C" }, result);
        }

        [TestMethod]
        public void SplitAtNthToLast_CaseSensitiveComparison_NoMatch()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.SplitAtNthToLast("b", 1, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        #endregion

        #region OptionallySplitAtNthToLast

        [TestMethod]
        public void OptionallySplitAtNthToLast_NullValues_ReturnsEmpty()
        {
            IEnumerable<string> values = null;
            var result = values.OptionallySplitAtNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_EmptySeparator_ReturnsEmpty()
        {
            var values = new List<string> { "apple,banana" };
            var result = values.OptionallySplitAtNthToLast("", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_EmptyCollection_ReturnsEmpty()
        {
            var values = Enumerable.Empty<string>();
            var result = values.OptionallySplitAtNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_EmptyStringEntry_IsIgnored()
        {
            var values = new List<string> { "", "one,two,three" };
            var result = values.OptionallySplitAtNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one", "two,three" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_SingleValue_ValidNthToLast_ReturnsSplit()
        {
            var values = new List<string> { "a,b,c" };
            var result = values.OptionallySplitAtNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "b,c" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_TooFewSeparators_ReturnsOriginal()
        {
            var values = new List<string> { "a,b" };
            var result = values.OptionallySplitAtNthToLast(",", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_MultiCharacterSeparator_WorksCorrectly()
        {
            var values = new List<string> { "key==value==extra" };
            var result = values.OptionallySplitAtNthToLast("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key", "value==extra" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_CaseInsensitiveComparison_Works()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.OptionallySplitAtNthToLast("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-", "-C" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_CaseSensitiveComparison_NoMatch_ReturnsOriginal()
        {
            var values = new List<string> { "A-B-C" };
            var result = values.OptionallySplitAtNthToLast("b", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region Trim

        [TestMethod]
        public void Trim_RemovesPrefixAndSuffix()
        {
            var input = Single("***hello***", "*hello*", "plain");
            var result = input.Trim("*", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "hello", "hello", "plain" }, result);
        }

        #endregion

        #region TrimMaxCount

        [TestMethod]
        public void TrimMaxCount_LimitsTrimCount()
        {
            var input = Single("xxhellooxx", "xhello", "plain");
            var result = input.TrimMaxCount("x", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "hellooxx", "hello", "plain" }, result);
        }

        #endregion

        #region TrimEnd

        [TestMethod]
        public void TrimEnd_TrimsSuffixOnly()
        {
            var input = Single("test...", "check..");
            var result = input.TrimEnd(".", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "test", "check" }, result);
        }

        #endregion

        #region TrimEndMaxCount

        [TestMethod]
        public void TrimEndMaxCount_TrimsUpToMax()
        {
            var input = Single("end///", "cut//");
            var result = input.TrimEndMaxCount("/", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "end/", "cut" }, result);
        }

        #endregion

        #region TrimStart

        [TestMethod]
        public void TrimStart_TrimsFromStartOnly()
        {
            var input = Single("###start###", "##start");
            var result = input.TrimStart("#", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "start###", "start" }, result);
        }

        #endregion

        #region TrimStartMaxCount

        [TestMethod]
        public void TrimStartMaxCount_TrimsLimitedStart()
        {
            var input = Single("!!!bang", "!bang");
            var result = input.TrimStartMaxCount("!", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "!bang", "bang" }, result);
        }

        #endregion

        #region NotEmpty

        [TestMethod]
        public void NotEmpty_FiltersOutEmptyStrings()
        {
            var input = Single("hello", "", "world", "", "");
            var result = input.NotEmpty().ToList();
            CollectionAssert.AreEqual(new List<string> { "hello", "world" }, result);
        }

        #endregion

        #region Reverse

        [TestMethod]
        public void Reverse_ReversesEachString()
        {
            var input = Single("abc", "123");
            var result = input.Reverse().ToList();
            CollectionAssert.AreEqual(new List<string> { "cba", "321" }, result);
        }
    }

    #endregion

}
