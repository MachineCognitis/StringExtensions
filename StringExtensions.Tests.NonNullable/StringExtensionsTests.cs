
using MachineCognitis.StringExtensions;

namespace StringExtensions.Tests.NonNullable
{
    [TestClass]
    public sealed class StringExtensionsTests
    {

        #region After

        [TestMethod]
        public void After_EmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = string.Empty.After(null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void After_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.After(string.Empty, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void After_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.After(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void After_NonEmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = "apple,banana".After(null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void After_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".After(string.Empty, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void After_SeparatorNotInValue_ReturnsEmpty()
        {
            var result = "apple banana".After(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void After_SeparatorInValue_ReturnsSubstrings()
        {
            var result = "one,two,three".After(",", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "two", "three" }, new List<string>(result));
        }

        [TestMethod]
        public void After_SeparatorAtStart_ReturnsFirstSubstring()
        {
            var result = ",start,mid,end".After(",", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "start", "mid", "end" }, new List<string>(result));
        }

        [TestMethod]
        public void After_SeparatorAtEnd_ReturnsEmptySegment()
        {
            var result = "end1,end2,".After(",", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>() { "end2", "" }, new List<string>(result));
        }

        [TestMethod]
        public void After_MultiCharacterSeparator_WorksAsExpected()
        {
            var result = "key==value==extra".After("==", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "value", "extra" }, new List<string>(result));
        }

        [TestMethod]
        public void After_ConsecutiveSeparators_ReturnsEmptyBetween()
        {
            var result = "a,,b".After(",", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "", "b" }, new List<string>(result));
        }

        [TestMethod]
        public void After_CaseInsensitiveComparison_MatchesLowerSeparator()
        {
            var result = "A-B-C".After("b", StringComparison.OrdinalIgnoreCase);
            CollectionAssert.AreEqual(new List<string> { "-C" }, new List<string>(result));
        }

        [TestMethod]
        public void After_CaseSensitiveComparison_DoesNotMatchLowerSeparator()
        {
            var result = "A-B-C".After("b", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        #endregion

        #region OptionallyAfter

        [TestMethod]
        public void OptionallyAfter_EmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyAfter(null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfter_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyAfter(string.Empty, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfter_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyAfter(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfter_NonEmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = "apple,banana".OptionallyAfter(null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfter_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".OptionallyAfter(string.Empty, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfter_SeparatorNotInValue_ReturnsOriginal()
        {
            var result = "apple banana".OptionallyAfter(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "apple banana" }, result);
        }

        [TestMethod]
        public void OptionallyAfter_SeparatorInValue_ReturnsSubstrings()
        {
            var result = "one,two,three".OptionallyAfter(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "two", "three" }, result);
        }

        [TestMethod]
        public void OptionallyAfter_SeparatorAtStart_ReturnsAllAfterStart()
        {
            var result = ",start,mid,end".OptionallyAfter(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "start", "mid", "end" }, result);
        }

        [TestMethod]
        public void OptionallyAfter_SeparatorAtEnd_ReturnsEmptySegment()
        {
            var result = "end1,end2,".OptionallyAfter(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "end2", "" }, result);
        }

        [TestMethod]
        public void OptionallyAfter_MultiCharacterSeparator_WorksAsExpected()
        {
            var result = "key==value==extra".OptionallyAfter("==", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "value", "extra" }, result);
        }

        [TestMethod]
        public void OptionallyAfter_ConsecutiveSeparators_ReturnsEmptyBetween()
        {
            var result = "a,,b".OptionallyAfter(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", "b" }, result);
        }

        [TestMethod]
        public void OptionallyAfter_CaseInsensitiveComparison_MatchesLowerSeparator()
        {
            var result = "A-B-C".OptionallyAfter("b", StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "-C" }, result);
        }

        [TestMethod]
        public void OptionallyAfter_CaseSensitiveComparison_DoesNotMatchLowerSeparator_ReturnsOriginal()
        {
            var result = "A-B-C".OptionallyAfter("b", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region AfterNth

        [TestMethod]
        public void AfterNth_EmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = string.Empty.AfterNth(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNth_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.AfterNth(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNth_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.AfterNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNth_NonEmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = "apple,banana".AfterNth(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNth_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".AfterNth(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNth_SeparatorNotInValue_ReturnsEmpty()
        {
            var result = "apple banana".AfterNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNth_SeparatorFound_BeforeNth_ReturnsMatch()
        {
            var result = "one,two,three".AfterNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "three" }, result);
        }

        [TestMethod]
        public void AfterNth_NthEqualsSeparatorCount_ReturnsLastSegment()
        {
            var result = "a,b,c".AfterNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "c" }, result);
        }

        [TestMethod]
        public void AfterNth_NthGreaterThanSeparatorCount_ReturnsEmpty()
        {
            var result = "a,b".AfterNth(",", 3, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNth_SeparatorAtEnd_ReturnsEmpty()
        {
            var result = "x,y,".AfterNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void AfterNth_MultiCharacterSeparator_WorksAsExpected()
        {
            var result = "key==value==extra".AfterNth("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "extra" }, result);
        }

        [TestMethod]
        public void AfterNth_CaseInsensitiveComparison_Works()
        {
            var result = "A-B-C".AfterNth("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "-C" }, result);
        }

        [TestMethod]
        public void AfterNth_CaseSensitiveComparison_DoesNotMatchLowerSeparator()
        {
            var result = "A-B-C".AfterNth("b", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        #endregion

        #region OptionallyAfterNth

        [TestMethod]
        public void OptionallyAfterNth_EmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyAfterNth(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfterNth_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyAfterNth(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfterNth_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyAfterNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfterNth_NonEmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = "apple,banana".OptionallyAfterNth(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfterNth_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".OptionallyAfterNth(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfterNth_SeparatorNotInValue_ReturnsOriginal()
        {
            var result = "apple banana".OptionallyAfterNth(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "apple banana" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNth_SeparatorFound_BeforeNth_ReturnsMatch()
        {
            var result = "one,two,three".OptionallyAfterNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "three" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNth_NthEqualsSeparatorCount_ReturnsLastSegment()
        {
            var result = "a,b,c".OptionallyAfterNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "c" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNth_NthGreaterThanSeparatorCount_ReturnsOriginal()
        {
            var result = "a,b".OptionallyAfterNth(",", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNth_SeparatorAtEnd_ReturnsEmptySegment()
        {
            var result = "x,y,".OptionallyAfterNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNth_MultiCharacterSeparator_WorksAsExpected()
        {
            var result = "key==value==extra".OptionallyAfterNth("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "extra" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNth_CaseInsensitiveComparison_Works()
        {
            var result = "A-B-C".OptionallyAfterNth("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "-C" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNth_CaseSensitiveComparison_DoesNotMatchLowerSeparator_ReturnsOriginal()
        {
            var result = "A-B-C".OptionallyAfterNth("b", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region AfterNthToLast

        [TestMethod]
        public void AfterNthToLast_EmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = string.Empty.AfterNthToLast(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNthToLast_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.AfterNthToLast(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNthToLast_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.AfterNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNthToLast_NonEmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = "apple,banana".AfterNthToLast(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNthToLast_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".AfterNthToLast(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNthToLast_SeparatorNotInValue_ReturnsEmpty()
        {
            var result = "apple banana".AfterNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNthToLast_SeparatorFound_ReturnsMatchFromEnd()
        {
            var result = "one,two,three".AfterNthToLast(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "three" }, result);
        }

        [TestMethod]
        public void AfterNthToLast_NthEqualsTotal_ReturnsFullAfterFirst()
        {
            var result = "a,b,c".AfterNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "b,c" }, result);
        }

        [TestMethod]
        public void AfterNthToLast_NthGreaterThanTotal_ReturnsEmpty()
        {
            var result = "a,b".AfterNthToLast(",", 3, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AfterNthToLast_SeparatorAtEnd_ReturnsEmptySegment()
        {
            var result = "x,y,".AfterNthToLast(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void AfterNthToLast_MultiCharacterSeparator_WorksAsExpected()
        {
            var result = "key==value==extra".AfterNthToLast("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "value==extra" }, result);
        }

        [TestMethod]
        public void AfterNthToLast_CaseInsensitiveComparison_Works()
        {
            var result = "A-B-C".AfterNthToLast("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "-C" }, result);
        }

        [TestMethod]
        public void AfterNthToLast_CaseSensitiveComparison_DoesNotMatchLowerSeparator()
        {
            var result = "A-B-C".AfterNthToLast("b", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        #endregion

        #region OptionallyAfterNthToLast

        [TestMethod]
        public void OptionallyAfterNthToLast_EmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyAfterNthToLast(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyAfterNthToLast(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyAfterNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_NonEmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = "apple,banana".OptionallyAfterNthToLast(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".OptionallyAfterNthToLast(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_SeparatorNotInValue_ReturnsOriginal()
        {
            var result = "apple banana".OptionallyAfterNthToLast(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "apple banana" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_SeparatorFound_ReturnsMatchFromEnd()
        {
            var result = "one,two,three".OptionallyAfterNthToLast(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "three" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_NthEqualsTotal_ReturnsFullAfterFirst()
        {
            var result = "a,b,c".OptionallyAfterNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "b,c" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_NthGreaterThanTotal_ReturnsOriginal()
        {
            var result = "a,b".OptionallyAfterNthToLast(",", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_SeparatorAtEnd_ReturnsEmptySegment()
        {
            var result = "x,y,".OptionallyAfterNthToLast(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_MultiCharacterSeparator_WorksAsExpected()
        {
            var result = "key==value==extra".OptionallyAfterNthToLast("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "value==extra" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_CaseInsensitiveComparison_Works()
        {
            var result = "A-B-C".OptionallyAfterNthToLast("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "-C" }, result);
        }

        [TestMethod]
        public void OptionallyAfterNthToLast_CaseSensitiveComparison_DoesNotMatchLowerSeparator_ReturnsOriginal()
        {
            var result = "A-B-C".OptionallyAfterNthToLast("b", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region Before

        [TestMethod]
        public void Before_EmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = string.Empty.Before(null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Before_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.Before(string.Empty, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Before_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.Before(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Before_NonEmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = "apple,banana".Before(null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Before_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".Before(string.Empty, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Before_SeparatorNotInValue_ReturnsEmpty()
        {
            var result = "apple banana".Before(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Before_SeparatorInValue_ReturnsSubstrings()
        {
            var result = "one,two,three".Before(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one", "two" }, result);
        }

        [TestMethod]
        public void Before_SeparatorAtStart_ReturnsEmptySegmentFirst()
        {
            var result = ",start,mid,end".Before(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", "start", "mid" }, result);
        }

        [TestMethod]
        public void Before_SeparatorAtEnd_IgnoresTrailingSeparator()
        {
            var result = "end1,end2,".Before(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "end1", "end2" }, result);
        }

        [TestMethod]
        public void Before_MultiCharacterSeparator_WorksAsExpected()
        {
            var result = "key==value==extra".Before("==", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key", "value" }, result);
        }

        [TestMethod]
        public void Before_ConsecutiveSeparators_ReturnsEmptyBetween()
        {
            var result = "a,,b".Before(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "" }, result);
        }

        [TestMethod]
        public void Before_CaseInsensitiveComparison_Works()
        {
            var result = "A-B-C".Before("b", StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-" }, result);
        }

        [TestMethod]
        public void Before_CaseSensitiveComparison_DoesNotMatchLowerSeparator()
        {
            var result = "A-B-C".Before("b", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        #endregion

        #region OptionallyBefore

        [TestMethod]
        public void OptionallyBefore_EmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyBefore(null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBefore_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyBefore(string.Empty, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBefore_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyBefore(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBefore_NonEmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = "apple,banana".OptionallyBefore(null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBefore_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".OptionallyBefore(string.Empty, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBefore_SeparatorNotInValue_ReturnsOriginal()
        {
            var result = "apple banana".OptionallyBefore(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "apple banana" }, result);
        }

        [TestMethod]
        public void OptionallyBefore_SeparatorInValue_ReturnsSubstrings()
        {
            var result = "one,two,three".OptionallyBefore(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one", "two" }, result);
        }

        [TestMethod]
        public void OptionallyBefore_SeparatorAtStart_ReturnsEmptySegment()
        {
            var result = ",start,mid,end".OptionallyBefore(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", "start", "mid" }, result);
        }

        [TestMethod]
        public void OptionallyBefore_SeparatorAtEnd_IgnoresTrailingSeparator()
        {
            var result = "end1,end2,".OptionallyBefore(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "end1", "end2" }, result);
        }

        [TestMethod]
        public void OptionallyBefore_MultiCharacterSeparator_WorksAsExpected()
        {
            var result = "key==value==extra".OptionallyBefore("==", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key", "value" }, result);
        }

        [TestMethod]
        public void OptionallyBefore_ConsecutiveSeparators_ReturnsEmptyBetween()
        {
            var result = "a,,b".OptionallyBefore(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "" }, result);
        }

        [TestMethod]
        public void OptionallyBefore_CaseInsensitiveComparison_Works()
        {
            var result = "A-B-C".OptionallyBefore("b", StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-" }, result);
        }

        [TestMethod]
        public void OptionallyBefore_CaseSensitiveComparison_DoesNotMatchLowerSeparator_ReturnsOriginal()
        {
            var result = "A-B-C".OptionallyBefore("b", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region BeforeNth

        [TestMethod]
        public void BeforeNth_EmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = string.Empty.BeforeNth(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNth_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.BeforeNth(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNth_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.BeforeNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNth_NonEmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = "apple,banana".BeforeNth(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNth_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".BeforeNth(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNth_SeparatorNotInValue_ReturnsEmpty()
        {
            var result = "apple banana".BeforeNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNth_SeparatorFound_BeforeNth_ReturnsSubstring()
        {
            var result = "one,two,three".BeforeNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one,two" }, result);
        }

        [TestMethod]
        public void BeforeNth_NthEqualsSeparatorCount_ReturnsExpected()
        {
            var result = "a,b,c".BeforeNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b" }, result);
        }

        [TestMethod]
        public void BeforeNth_NthGreaterThanSeparatorCount_ReturnsEmpty()
        {
            var result = "a,b".BeforeNth(",", 3, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNth_SeparatorAtStart_ReturnsEmpty()
        {
            var result = ",start,mid,end".BeforeNth(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void BeforeNth_MultiCharacterSeparator_WorksAsExpected()
        {
            var result = "key==value==extra".BeforeNth("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key==value" }, result);
        }

        [TestMethod]
        public void BeforeNth_CaseInsensitiveComparison_Works()
        {
            var result = "A-B-C".BeforeNth("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-" }, result);
        }

        [TestMethod]
        public void BeforeNth_CaseSensitiveComparison_DoesNotMatchLowerSeparator()
        {
            var result = "A-B-C".BeforeNth("b", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        #endregion

        #region OptionallyBeforeNth

        [TestMethod]
        public void OptionallyBeforeNth_EmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyBeforeNth(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBeforeNth_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyBeforeNth(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBeforeNth_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyBeforeNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBeforeNth_NonEmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = "apple,banana".OptionallyBeforeNth(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBeforeNth_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".OptionallyBeforeNth(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBeforeNth_SeparatorNotInValue_ReturnsOriginal()
        {
            var result = "apple banana".OptionallyBeforeNth(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "apple banana" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNth_SeparatorFound_BeforeNth_ReturnsExpected()
        {
            var result = "one,two,three".OptionallyBeforeNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one,two" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNth_NthEqualsSeparatorCount_ReturnsExpected()
        {
            var result = "a,b,c".OptionallyBeforeNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNth_NthGreaterThanSeparatorCount_ReturnsOriginal()
        {
            var result = "a,b".OptionallyBeforeNth(",", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNth_SeparatorAtStart_ReturnsEmpty()
        {
            var result = ",start,mid,end".OptionallyBeforeNth(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNth_MultiCharacterSeparator_WorksAsExpected()
        {
            var result = "key==value==extra".OptionallyBeforeNth("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key==value" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNth_CaseInsensitiveComparison_Works()
        {
            var result = "A-B-C".OptionallyBeforeNth("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNth_CaseSensitiveComparison_DoesNotMatchLowerSeparator_ReturnsOriginal()
        {
            var result = "A-B-C".OptionallyBeforeNth("b", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region BeforeNthToLast

        [TestMethod]
        public void BeforeNthToLast_EmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = string.Empty.BeforeNthToLast(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNthToLast_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.BeforeNthToLast(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNthToLast_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.BeforeNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNthToLast_NonEmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = "apple,banana".BeforeNthToLast(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNthToLast_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".BeforeNthToLast(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNthToLast_SeparatorNotInValue_ReturnsEmpty()
        {
            var result = "apple banana".BeforeNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNthToLast_NthEqualsSeparatorCount_ReturnsExpected()
        {
            var result = "one,two,three".BeforeNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one" }, result);
        }

        [TestMethod]
        public void BeforeNthToLast_SeparatorAtEnd_ReturnsExpected()
        {
            var result = "x,y,z,".BeforeNthToLast(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "x,y,z" }, result);
        }

        [TestMethod]
        public void BeforeNthToLast_NthGreaterThanSeparatorCount_ReturnsEmpty()
        {
            var result = "a,b".BeforeNthToLast(",", 3, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BeforeNthToLast_MultiCharacterSeparator_WorksAsExpected()
        {
            var result = "key==value==extra".BeforeNthToLast("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key" }, result);
        }

        [TestMethod]
        public void BeforeNthToLast_CaseInsensitiveComparison_Works()
        {
            var result = "A-B-C".BeforeNthToLast("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-" }, result);
        }

        [TestMethod]
        public void BeforeNthToLast_CaseSensitiveComparison_DoesNotMatchLowerSeparator()
        {
            var result = "A-B-C".BeforeNthToLast("b", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        #endregion

        #region OptionallyBeforeNthToLast

        [TestMethod]
        public void OptionallyBeforeNthToLast_EmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyBeforeNthToLast(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyBeforeNthToLast(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyBeforeNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_NonEmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = "apple,banana".OptionallyBeforeNthToLast(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".OptionallyBeforeNthToLast(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_SeparatorNotInValue_ReturnsOriginal()
        {
            var result = "apple banana".OptionallyBeforeNthToLast(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "apple banana" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_SeparatorFound_ReturnsMatchFromEnd()
        {
            var result = "one,two,three".OptionallyBeforeNthToLast(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one,two" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_NthEqualsTotal_ReturnsBeforeFirstSeparator()
        {
            var result = "a,b,c".OptionallyBeforeNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_NthGreaterThanTotal_ReturnsOriginal()
        {
            var result = "a,b".OptionallyBeforeNthToLast(",", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_SeparatorAtStart_ReturnsEmpty()
        {
            var result = ",start,mid,end".OptionallyBeforeNthToLast(",", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_MultiCharacterSeparator_WorksAsExpected()
        {
            var result = "key==value==extra".OptionallyBeforeNthToLast("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_CaseInsensitiveComparison_Works()
        {
            var result = "A-B-C".OptionallyBeforeNthToLast("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-" }, result);
        }

        [TestMethod]
        public void OptionallyBeforeNthToLast_CaseSensitiveComparison_DoesNotMatchLowerSeparator_ReturnsOriginal()
        {
            var result = "A-B-C".OptionallyBeforeNthToLast("b", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region Between

        [TestMethod]
        public void Between_EmptyValue_NullPrefix_ReturnsEmpty()
        {
            var result = string.Empty.Between(null, "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Between_EmptyValue_NullSuffix_ReturnsEmpty()
        {
            var result = string.Empty.Between("{", null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Between_EmptyValue_EmptyPrefixSuffix_ReturnsEmpty()
        {
            var result = string.Empty.Between("", "", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Between_NonEmpty_NullPrefix_ReturnsEmpty()
        {
            var result = "Hello {name}".Between(null, "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Between_NonEmpty_NullSuffix_ReturnsEmpty()
        {
            var result = "Hello {name}".Between("{", null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Between_PrefixSuffixNotFound_ReturnsEmpty()
        {
            var result = "This has no delimiters".Between("{", "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Between_OnlyPrefixFound_ReturnsEmpty()
        {
            var result = "Hello {name".Between("{", "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Between_OnePair_ReturnsInnerText()
        {
            var result = "Hello {name}".Between("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "name" }, result);
        }

        [TestMethod]
        public void Between_MultiplePairs_ReturnsAllSegments()
        {
            var result = "Hello {first}, your ID is {id}".Between("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "first", "id" }, result);
        }

        [TestMethod]
        public void Between_PrefixAndSuffixTouch_ReturnsEmpty()
        {
            var result = "a{}b{c}d".Between("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", "c" }, result);
        }

        [TestMethod]
        public void Between_PrefixSuffixWithMultipleChars_Works()
        {
            var result = "key<<value>>end<<x>>".Between("<<", ">>", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "value", "x" }, result);
        }

        [TestMethod]
        public void Between_CaseInsensitiveComparison_Works()
        {
            var result = "BEFORE[start]AFTER".Between("START", "]", StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result); // Empty between 'start]' since prefix and suffix are adjacent
        }

        [TestMethod]
        public void Between_CaseSensitiveComparison_NoMatch()
        {
            var result = "Hello {Name}".Between("{name", "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Between_PrefixNotInValue_ReturnsEmpty()
        {
            var result = "Some text [here]".Between("(", "]", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Between_SuffixNotInValue_ReturnsEmpty()
        {
            var result = "Some text [here]".Between("[", ")", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Between_PrefixAtStartOfValue_ReturnsFirstSegment()
        {
            var result = "[start] and then some".Between("[", "]", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "start" }, new List<string>(result));
        }

        [TestMethod]
        public void Between_SuffixAtEndOfValue_ReturnsLastSegment()
        {
            var result = "final is [this one]".Between("[", "]", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "this one" }, new List<string>(result));
        }

        [TestMethod]
        public void Between_ConsecutivePrefixesOrSuffixes_ReturnsEmptyBetween()
        {
            var result = "<<a><><<b>>".Between("<", ">", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "<a", "", "<b" }, new List<string>(result));
        }

        #endregion

        #region OptionallyBetween

        [TestMethod]
        public void OptionallyBetween_EmptyValue_NullPrefix_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyBetween(null, "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetween_EmptyValue_NullSuffix_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyBetween("{", null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetween_EmptyValue_EmptyPrefixSuffix_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyBetween("", "", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetween_NonEmpty_NullPrefix_ReturnsEmpty()
        {
            var result = "Hello {name}".OptionallyBetween(null, "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetween_NonEmpty_NullSuffix_ReturnsEmpty()
        {
            var result = "Hello {name}".OptionallyBetween("{", null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetween_PrefixSuffixNotFound_ReturnsOriginal()
        {
            var result = "This has no delimiters".OptionallyBetween("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "This has no delimiters" }, result);
        }

        [TestMethod]
        public void OptionallyBetween_OnlyPrefixFound_ReturnsOriginal()
        {
            var result = "Hello {name".OptionallyBetween("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello {name" }, result);
        }

        [TestMethod]
        public void OptionallyBetween_OnePair_ReturnsInnerText()
        {
            var result = "Hello {name}".OptionallyBetween("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "name" }, result);
        }

        [TestMethod]
        public void OptionallyBetween_MultiplePairs_ReturnsAllSegments()
        {
            var result = "Hello {first}, your ID is {id}".OptionallyBetween("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "first", "id" }, result);
        }

        [TestMethod]
        public void OptionallyBetween_PrefixAndSuffixTouch_ReturnsEmpty()
        {
            var result = "a{}b{c}d".OptionallyBetween("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", "c" }, result);
        }

        [TestMethod]
        public void OptionallyBetween_PrefixSuffixWithMultipleChars_Works()
        {
            var result = "key<<value>>end<<x>>".OptionallyBetween("<<", ">>", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "value", "x" }, result);
        }

        [TestMethod]
        public void OptionallyBetween_CaseInsensitiveComparison_Works()
        {
            var result = "BEFORE[start]AFTER".OptionallyBetween("START", "]", StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void OptionallyBetween_CaseSensitiveComparison_NoMatch_ReturnsOriginal()
        {
            var result = "Hello {Name}".OptionallyBetween("{name", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello {Name}" }, result);
        }

        [TestMethod]
        public void OptionallyBetween_PrefixNotInValue_ReturnsOriginal()
        {
            var result = "Some text [here]".OptionallyBetween("(", "]", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Some text [here]" }, result);
        }

        [TestMethod]
        public void OptionallyBetween_SuffixNotInValue_ReturnsOriginal()
        {
            var result = "Some text [here]".OptionallyBetween("[", ")", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Some text [here]" }, result);
        }

        [TestMethod]
        public void OptionallyBetween_PrefixAtStartOfValue_ReturnsFirstSegment()
        {
            var result = "[start] and then some".OptionallyBetween("[", "]", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "start" }, result);
        }

        [TestMethod]
        public void OptionallyBetween_SuffixAtEndOfValue_ReturnsLastSegment()
        {
            var result = "final is [this one]".OptionallyBetween("[", "]", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "this one" }, result);
        }

        [TestMethod]
        public void OptionallyBetween_ConsecutivePrefixesOrSuffixes_ReturnsEmptyBetween()
        {
            var result = "<<a><><<b>>".OptionallyBetween("<", ">", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "<a", "", "<b" }, result);
        }

        #endregion

        #region BetweenNth

        [TestMethod]
        public void BetweenNth_EmptyValue_NullPrefix_ReturnsEmpty()
        {
            var result = string.Empty.BetweenNth(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNth_EmptyValue_NullSuffix_ReturnsEmpty()
        {
            var result = string.Empty.BetweenNth("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNth_EmptyValue_EmptyPrefixSuffix_ReturnsEmpty()
        {
            var result = string.Empty.BetweenNth("", "", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNth_NonEmpty_NullPrefix_ReturnsEmpty()
        {
            var result = "Hello {name}".BetweenNth(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNth_NonEmpty_NullSuffix_ReturnsEmpty()
        {
            var result = "Hello {name}".BetweenNth("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNth_PrefixSuffixNotFound_ReturnsEmpty()
        {
            var result = "This has no delimiters".BetweenNth("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNth_OnlyPrefixFound_ReturnsEmpty()
        {
            var result = "Hello {name".BetweenNth("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNth_OnePair_ReturnsFirstIfNthIsOne()
        {
            var result = "Hello {name}".BetweenNth("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "name" }, result);
        }

        [TestMethod]
        public void BetweenNth_TwoPairs_ReturnsSecondIfNthIsTwo()
        {
            var result = "Hello {first}, ID is {second}".BetweenNth("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "second" }, result);
        }

        [TestMethod]
        public void BetweenNth_TwoPairs_ReturnsEmptyIfNthIsGreaterThanTotal()
        {
            var result = "Hello {first}, ID is {second}".BetweenNth("{", "}", 3, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNth_PrefixAndSuffixTouch_ReturnsEmpty()
        {
            var result = "x{}y".BetweenNth("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void BetweenNth_MultiCharacterPrefixSuffix_WorksCorrectly()
        {
            var result = "<<a>><<b>>".BetweenNth("<<", ">>", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "b" }, result);
        }

        [TestMethod]
        public void BetweenNth_CaseInsensitiveComparison_Works()
        {
            var result = "BEFORE[start]AFTER[done]".BetweenNth("START", "]", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void BetweenNth_CaseSensitiveComparison_DoesNotMatchLowerPrefix()
        {
            var result = "Hello {Name}".BetweenNth("{name", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNth_PrefixNotInValue_ReturnsEmpty()
        {
            var result = "Some text [here]".BetweenNth("(", "]", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNth_SuffixNotInValue_ReturnsEmpty()
        {
            var result = "Some text [here]".BetweenNth("[", ")", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNth_FirstPairAtStartOfValue_ReturnsIfNthIsOne()
        {
            var result = "[start] and then some".BetweenNth("[", "]", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "start" }, result);
        }

        [TestMethod]
        public void BetweenNth_LastPairAtEndOfValue_ReturnsCorrectly()
        {
            var result = "start [mid] end [final]".BetweenNth("[", "]", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "final" }, result);
        }

        [TestMethod]
        public void BetweenNth_ConsecutivePairs_ReturnsCorrectNth()
        {
            var result = "<<a><><<b>>".BetweenNth("<", ">", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "<b" }, result);
        }

        #endregion

        #region OptionallyBetweenNth

        [TestMethod]
        public void OptionallyBetweenNth_EmptyValue_NullPrefix_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyBetweenNth(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetweenNth_EmptyValue_NullSuffix_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyBetweenNth("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetweenNth_EmptyValue_EmptyPrefixSuffix_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyBetweenNth("", "", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetweenNth_NonEmpty_NullPrefix_ReturnsEmpty()
        {
            var result = "Hello {name}".OptionallyBetweenNth(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetweenNth_NonEmpty_NullSuffix_ReturnsEmpty()
        {
            var result = "Hello {name}".OptionallyBetweenNth("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetweenNth_PrefixSuffixNotFound_ReturnsOriginal()
        {
            var result = "This has no delimiters".OptionallyBetweenNth("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "This has no delimiters" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNth_OnlyPrefixFound_ReturnsOriginal()
        {
            var result = "Hello {name".OptionallyBetweenNth("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello {name" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNth_OnePair_ReturnsInnerTextIfNthIsOne()
        {
            var result = "Hello {name}".OptionallyBetweenNth("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "name" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNth_TwoPairs_ReturnsSecondIfNthIsTwo()
        {
            var result = "Hello {first}, ID is {second}".OptionallyBetweenNth("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "second" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNth_TwoPairs_ReturnsOriginalIfNthTooHigh()
        {
            var result = "Hello {first}, ID is {second}".OptionallyBetweenNth("{", "}", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello {first}, ID is {second}" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNth_PrefixSuffixTouch_ReturnsEmptySegment()
        {
            var result = "x{}y".OptionallyBetweenNth("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNth_MultiCharacterPrefixSuffix_WorksCorrectly()
        {
            var result = "<<a>><<b>>".OptionallyBetweenNth("<<", ">>", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "b" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNth_CaseInsensitiveComparison_Works()
        {
            var result = "BEFORE[start]AFTER[done]".OptionallyBetweenNth("START", "]", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNth_CaseSensitiveComparison_DoesNotMatchLowerPrefix_ReturnsOriginal()
        {
            var result = "Hello {Name}".OptionallyBetweenNth("{name", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello {Name}" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNth_FirstPairAtStartOfValue_ReturnsIfNthIsOne()
        {
            var result = "[start] then more".OptionallyBetweenNth("[", "]", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "start" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNth_LastPairAtEndOfValue_ReturnsCorrectly()
        {
            var result = "start [mid] end [final]".OptionallyBetweenNth("[", "]", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "final" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNth_ConsecutivePairs_ReturnsCorrectNth()
        {
            var result = "<<a><><<b>>".OptionallyBetweenNth("<", ">", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "<b" }, result);
        }

        #endregion

        #region BetweenNthToLast

        [TestMethod]
        public void BetweenNthToLast_EmptyValue_NullPrefix_ReturnsEmpty()
        {
            var result = string.Empty.BetweenNthToLast(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNthToLast_EmptyValue_NullSuffix_ReturnsEmpty()
        {
            var result = string.Empty.BetweenNthToLast("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNthToLast_EmptyValue_EmptyPrefixSuffix_ReturnsEmpty()
        {
            var result = string.Empty.BetweenNthToLast("", "", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNthToLast_NonEmptyValue_NullPrefix_ReturnsEmpty()
        {
            var result = "Hello {name}".BetweenNthToLast(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNthToLast_NonEmptyValue_NullSuffix_ReturnsEmpty()
        {
            var result = "Hello {name}".BetweenNthToLast("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNthToLast_PrefixSuffixNotFound_ReturnsEmpty()
        {
            var result = "This has no delimiters".BetweenNthToLast("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNthToLast_OnlyPrefixFound_ReturnsEmpty()
        {
            var result = "Hello {name".BetweenNthToLast("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNthToLast_OnePair_ReturnsMatchIfNIsOne()
        {
            var result = "Hello {name}".BetweenNthToLast("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "name" }, result);
        }

        [TestMethod]
        public void BetweenNthToLast_TwoPairs_ReturnsFirstIfNIsTwo()
        {
            var result = "Hello {first}, ID is {second}".BetweenNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "first" }, result);
        }

        [TestMethod]
        public void BetweenNthToLast_TwoPairs_ReturnsEmptyIfNTooHigh()
        {
            var result = "Hello {first}, ID is {second}".BetweenNthToLast("{", "}", 3, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNthToLast_PrefixAndSuffixTouch_ReturnsEmptySegment()
        {
            var result = "a{}b{c}d".BetweenNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void BetweenNthToLast_MultiCharacterDelimiters_WorksCorrectly()
        {
            var result = "start<<x>>middle<<y>>end".BetweenNthToLast("<<", ">>", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "x" }, result);
        }

        [TestMethod]
        public void BetweenNthToLast_CaseInsensitiveComparison_Works()
        {
            var result = "before[NAME]after[name]".BetweenNthToLast("NAME", "]", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void BetweenNthToLast_CaseSensitiveComparison_DoesNotMatchLowerPrefix()
        {
            var result = "Hello {Name}".BetweenNthToLast("{name", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void BetweenNthToLast_FirstPairAtStart_WorksIfNIsTotal()
        {
            var result = "[start] and then [end]".BetweenNthToLast("[", "]", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "start" }, result);
        }

        [TestMethod]
        public void BetweenNthToLast_LastPairAtEnd_ReturnsFinalMatch()
        {
            var result = "start [mid] end [final]".BetweenNthToLast("[", "]", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "final" }, result);
        }

        [TestMethod]
        public void BetweenNthToLast_ConsecutiveMatches_ReturnsCorrectNthFromEnd()
        {
            var result = "<<a><><<b>>".BetweenNthToLast("<", ">", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        #endregion

        #region OptionallyBetweenNthToLast

        [TestMethod]
        public void OptionallyBetweenNthToLast_EmptyValue_NullPrefix_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyBetweenNthToLast(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_EmptyValue_NullSuffix_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyBetweenNthToLast("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_EmptyValue_EmptyPrefixSuffix_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyBetweenNthToLast("", "", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_NonEmptyValue_NullPrefix_ReturnsEmpty()
        {
            var result = "Hello {name}".OptionallyBetweenNthToLast(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_NonEmptyValue_NullSuffix_ReturnsEmpty()
        {
            var result = "Hello {name}".OptionallyBetweenNthToLast("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_PrefixSuffixNotFound_ReturnsOriginal()
        {
            var result = "no delimiters here".OptionallyBetweenNthToLast("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "no delimiters here" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_OnlyPrefixFound_ReturnsOriginal()
        {
            var result = "Hello {name".OptionallyBetweenNthToLast("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello {name" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_OnePair_ReturnsMatchIfNIsOne()
        {
            var result = "Hello {name}".OptionallyBetweenNthToLast("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "name" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_TwoPairs_ReturnsFirstIfNIsTwo()
        {
            var result = "Hello {first}, ID is {second}".OptionallyBetweenNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "first" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_TwoPairs_ReturnsOriginalIfNTooHigh()
        {
            var result = "Hello {first}, ID is {second}".OptionallyBetweenNthToLast("{", "}", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello {first}, ID is {second}" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_PrefixAndSuffixTouch_ReturnsEmptySegment()
        {
            var result = "a{}b{c}d".OptionallyBetweenNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_MultiCharDelimiters_ReturnsCorrectSegment()
        {
            var result = "start<<x>>middle<<y>>end".OptionallyBetweenNthToLast("<<", ">>", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "x" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_CaseInsensitive_WorksCorrectly()
        {
            var result = "before[NAME]after[name]".OptionallyBetweenNthToLast("NAME", "]", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_CaseSensitive_NoMatch_ReturnsOriginal()
        {
            var result = "Hello {Name}".OptionallyBetweenNthToLast("{name", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello {Name}" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_FirstPairAtStart_WorksWhenNEqualsTotal()
        {
            var result = "[start] and then [end]".OptionallyBetweenNthToLast("[", "]", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "start" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_LastPairAtEnd_ReturnsFinalMatch()
        {
            var result = "start [mid] end [final]".OptionallyBetweenNthToLast("[", "]", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "final" }, result);
        }

        [TestMethod]
        public void OptionallyBetweenNthToLast_ConsecutivePairs_ReturnsCorrectNthFromEnd()
        {
            var result = "<<a><><<b>>".OptionallyBetweenNthToLast("<", ">", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "" }, result);
        }

        #endregion

        #region Outside

        [TestMethod]
        public void Outside_EmptyValue_NullPrefix_ReturnsEmpty()
        {
            var result = string.Empty.Outside(null, "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Outside_EmptyValue_NullSuffix_ReturnsEmpty()
        {
            var result = string.Empty.Outside("{", null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Outside_EmptyValue_EmptyPrefixSuffix_ReturnsEmpty()
        {
            var result = string.Empty.Outside("", "", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Outside_NonEmptyValue_NullPrefix_ReturnsEmpty()
        {
            var result = "Hello {name}".Outside(null, "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Outside_NonEmptyValue_NullSuffix_ReturnsEmpty()
        {
            var result = "Hello {name}".Outside("{", null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Outside_NoPrefixSuffix_ReturnsEmpty()
        {
            var result = "Some normal text.".Outside("{", "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Outside_PrefixOnly_ReturnsEmpty()
        {
            var result = "Hello {name".Outside("{", "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Outside_SinglePair_ReturnsOutsideParts()
        {
            var result = "Hello {name}!".Outside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello ", "!" }, result);
        }

        [TestMethod]
        public void Outside_MultiplePairs_ReturnsAllOutsideSegments()
        {
            var result = "Start {one} middle {two} end.".Outside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start ", " middle ", " end." }, result);
        }

        [TestMethod]
        public void Outside_PrefixAndSuffixTouch_YieldsEmpty()
        {
            var result = "a{}b{c}d".Outside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "b", "d" }, result);
        }

        [TestMethod]
        public void Outside_MultiCharacterDelimiters_WorkCorrectly()
        {
            var result = "val<<one>>gap<<two>>tail".Outside("<<", ">>", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "val", "gap", "tail" }, result);
        }

        [TestMethod]
        public void Outside_CaseInsensitiveComparison_Works()
        {
            var result = "Start[DATA]End[data]Again".Outside("data", "]", StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start[", "End[", "Again" }, result);
        }

        [TestMethod]
        public void Outside_CaseSensitiveComparison_NoMatch()
        {
            var result = "Hello {Name}".Outside("{name", "}", StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Outside_PrefixAtStart_YieldsEmptyThenSuffixTail()
        {
            var result = "{start}tail".Outside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", "tail" }, result);
        }

        [TestMethod]
        public void Outside_SuffixAtEnd_YieldsPrefixHeadAndEmpty()
        {
            var result = "head{value}".Outside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "head", "" }, result);
        }

        [TestMethod]
        public void Outside_OnlyOnePairAtEnd_ReturnsHeadAndEnd()
        {
            var result = "before{value}after".Outside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "before", "after" }, result);
        }

        #endregion

        #region OptionallyOutside

        [TestMethod]
        public void OptionallyOutside_EmptyValue_NullPrefix_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyOutside(null, "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutside_EmptyValue_NullSuffix_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyOutside("{", null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutside_EmptyValue_EmptyPrefixSuffix_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyOutside("", "", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutside_NonEmpty_NullPrefix_ReturnsEmpty()
        {
            var result = "Hello {name}".OptionallyOutside(null, "}", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutside_NonEmpty_NullSuffix_ReturnsEmpty()
        {
            var result = "Hello {name}".OptionallyOutside("{", null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutside_PrefixSuffixNotFound_ReturnsOriginal()
        {
            var result = "This has no delimiters".OptionallyOutside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "This has no delimiters" }, result);
        }

        [TestMethod]
        public void OptionallyOutside_OnlyPrefixFound_ReturnsOriginal()
        {
            var result = "Hello {name".OptionallyOutside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello {name" }, result);
        }

        [TestMethod]
        public void OptionallyOutside_OnePair_ReturnsOutsideParts()
        {
            var result = "Hello {name}!".OptionallyOutside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello ", "!" }, result);
        }

        [TestMethod]
        public void OptionallyOutside_MultiplePairs_ReturnsAllOutsideSegments()
        {
            var result = "Start {one} mid {two} end.".OptionallyOutside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start ", " mid ", " end." }, result);
        }

        [TestMethod]
        public void OptionallyOutside_PrefixAndSuffixTouch_YieldsEmptySegment()
        {
            var result = "a{}b{c}d".OptionallyOutside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "b", "d" }, result);
        }

        [TestMethod]
        public void OptionallyOutside_MultiCharacterDelimiters_WorkCorrectly()
        {
            var result = "val<<one>>gap<<two>>tail".OptionallyOutside("<<", ">>", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "val", "gap", "tail" }, result);
        }

        [TestMethod]
        public void OptionallyOutside_CaseInsensitiveComparison_Works()
        {
            var result = "Start[DATA]End[data]Again".OptionallyOutside("data", "]", StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start[", "End[", "Again" }, result);
        }

        [TestMethod]
        public void OptionallyOutside_CaseSensitive_NoMatch_ReturnsOriginal()
        {
            var result = "Hello {Name}".OptionallyOutside("{name", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello {Name}" }, result);
        }

        [TestMethod]
        public void OptionallyOutside_PrefixAtStart_YieldsEmptyThenTail()
        {
            var result = "{start}tail".OptionallyOutside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", "tail" }, result);
        }

        [TestMethod]
        public void OptionallyOutside_SuffixAtEnd_YieldsHeadAndEmpty()
        {
            var result = "head{value}".OptionallyOutside("{", "}", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "head", "" }, result);
        }

        [TestMethod]
        public void OptionallyOutside_ConsecutivePairs_ReturnsAllOutsideSegments()
        {
            var result = "<<a><><<b>>".OptionallyOutside("<", ">", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", "", "", ">" }, result);
        }

        #endregion

        #region OutsideNth

        [TestMethod]
        public void OutsideNth_EmptyValue_NullPrefix_ReturnsEmpty()
        {
            var result = string.Empty.OutsideNth(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNth_EmptyValue_NullSuffix_ReturnsEmpty()
        {
            var result = string.Empty.OutsideNth("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNth_EmptyValue_EmptyPrefixSuffix_ReturnsEmpty()
        {
            var result = string.Empty.OutsideNth("", "", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNth_NonEmptyValue_NullPrefix_ReturnsEmpty()
        {
            var result = "Hello {name}".OutsideNth(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNth_NonEmptyValue_NullSuffix_ReturnsEmpty()
        {
            var result = "Hello {name}".OutsideNth("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNth_PrefixSuffixNotFound_ReturnsEmpty()
        {
            var result = "No delimiters".OutsideNth("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNth_OnlyPrefixFound_ReturnsEmpty()
        {
            var result = "Hello {name".OutsideNth("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNth_OnePair_ReturnsOutsideIfNIsOne()
        {
            var result = "Welcome {guest}!".OutsideNth("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Welcome ", "!" }, result);
        }

        [TestMethod]
        public void OutsideNth_TwoPairs_ReturnsOnlyNthOutside()
        {
            var result = "Start {one} middle {two} end".OutsideNth("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start {one} middle ", " end" }, result);
        }

        [TestMethod]
        public void OutsideNth_TwoPairs_NTooHigh_ReturnsEmpty()
        {
            var result = "Here {first} and {second}".OutsideNth("{", "}", 3, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNth_TouchingDelimiters_ReturnsEmptyBetween()
        {
            var result = "a{}b{c}d".OutsideNth("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a{}b", "d" }, result);
        }

        [TestMethod]
        public void OutsideNth_MultiCharDelimiters_ReturnsCorrectSegment()
        {
            var result = "<<a>>middle<<b>>end".OutsideNth("<<", ">>", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "<<a>>middle", "end" }, result);
        }

        [TestMethod]
        public void OutsideNth_CaseInsensitiveComparison_Works()
        {
            var result = "Start[Name]Mid[Data]End".OutsideNth("name", "]", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start[", "Mid[Data]End" }, result);
        }

        [TestMethod]
        public void OutsideNth_CaseSensitive_NoMatch_ReturnsEmpty()
        {
            var result = "Hello {Name}".OutsideNth("{name", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNth_FirstPairAtStart_ReturnsTailOnly()
        {
            var result = "[start] then more text".OutsideNth("[", "]", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", " then more text" }, result);
        }

        [TestMethod]
        public void OutsideNth_LastPairAtEnd_ReturnsHeadOnly()
        {
            var result = "header {section} tail".OutsideNth("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "header ", " tail" }, result);
        }

        [TestMethod]
        public void OutsideNth_ConsecutivePairs_ReturnsCorrectTailAfterNth()
        {
            var result = "<<a><><<b>>end".OutsideNth("<", ">", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "<<a><>", ">end" }, result);
        }

        #endregion

        #region OptionallyOutsideNth

        [TestMethod]
        public void OptionallyOutsideNth_EmptyValue_NullPrefix_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyOutsideNth(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutsideNth_EmptyValue_NullSuffix_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyOutsideNth("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutsideNth_EmptyValue_EmptyPrefixSuffix_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyOutsideNth("", "", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutsideNth_NonEmptyValue_NullPrefix_ReturnsEmpty()
        {
            var result = "Hello {name}".OptionallyOutsideNth(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutsideNth_NonEmptyValue_NullSuffix_ReturnsEmpty()
        {
            var result = "Hello {name}".OptionallyOutsideNth("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutsideNth_PrefixSuffixNotFound_ReturnsOriginal()
        {
            var result = "No delimiters".OptionallyOutsideNth("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "No delimiters" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNth_OnlyPrefixFound_ReturnsOriginal()
        {
            var result = "Hello {name".OptionallyOutsideNth("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello {name" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNth_OnePair_ReturnsOutsideSegments()
        {
            var result = "Welcome {guest}!".OptionallyOutsideNth("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Welcome ", "!" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNth_TwoPairs_ReturnsOnlyOutsideAroundNth()
        {
            var result = "Start {one} middle {two} end".OptionallyOutsideNth("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start {one} middle ", " end" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNth_NTooHigh_ReturnsOriginal()
        {
            var result = "Here {first} and {second}".OptionallyOutsideNth("{", "}", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Here {first} and {second}" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNth_TouchingDelimiters_ReturnsEmptySegments()
        {
            var result = "a{}b{c}d".OptionallyOutsideNth("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a{}b", "d" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNth_MultiCharDelimiters_WorksCorrectly()
        {
            var result = "<<a>>middle<<b>>end".OptionallyOutsideNth("<<", ">>", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "<<a>>middle", "end" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNth_CaseInsensitiveComparison_Works()
        {
            var result = "Start[Name]Mid[Data]End".OptionallyOutsideNth("name", "]", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start[", "Mid[Data]End" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNth_CaseSensitiveComparison_NoMatch_ReturnsOriginal()
        {
            var result = "Hello {Name}".OptionallyOutsideNth("{name", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello {Name}" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNth_FirstPairAtStart_ReturnsTail()
        {
            var result = "[start] then more text".OptionallyOutsideNth("[", "]", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", " then more text" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNth_LastPairAtEnd_ReturnsHead()
        {
            var result = "header {section} tail".OptionallyOutsideNth("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "header ", " tail" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNth_ConsecutivePairs_ReturnsContentAfterNth()
        {
            var result = "<<a><><<b>>end".OptionallyOutsideNth("<", ">", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "<<a><>", ">end" }, result);
        }

        #endregion

        #region OutsideNthToLast

        [TestMethod]
        public void OutsideNthToLast_EmptyValue_NullPrefix_ReturnsEmpty()
        {
            var result = string.Empty.OutsideNthToLast(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNthToLast_EmptyValue_NullSuffix_ReturnsEmpty()
        {
            var result = string.Empty.OutsideNthToLast("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNthToLast_EmptyValue_EmptyPrefixSuffix_ReturnsEmpty()
        {
            var result = string.Empty.OutsideNthToLast("", "", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNthToLast_NonEmptyValue_NullPrefix_ReturnsEmpty()
        {
            var result = "Hello {name}".OutsideNthToLast(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNthToLast_NonEmptyValue_NullSuffix_ReturnsEmpty()
        {
            var result = "Hello {name}".OutsideNthToLast("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNthToLast_PrefixSuffixNotFound_ReturnsEmpty()
        {
            var result = "No delimiters".OutsideNthToLast("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNthToLast_OnlyPrefixFound_ReturnsEmpty()
        {
            var result = "Hello {name".OutsideNthToLast("{", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNthToLast_OnePair_ReturnsOutsideIfNIsOne()
        {
            var result = "Welcome {guest}!".OutsideNthToLast("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Welcome ", "!" }, result);
        }

        [TestMethod]
        public void OutsideNthToLast_TwoPairs_ReturnsOutsideBeforeNthToLast()
        {
            var result = "Start {one} middle {two} end".OutsideNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start ", " middle {two} end" }, result);
        }

        [TestMethod]
        public void OutsideNthToLast_NTooHigh_ReturnsEmpty()
        {
            var result = "Here {first} and {second}".OutsideNthToLast("{", "}", 3, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNthToLast_TouchingDelimiters_ReturnsCorrect()
        {
            var result = "a{}b{c}d".OutsideNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "b{c}d" }, result);
        }

        [TestMethod]
        public void OutsideNthToLast_MultiCharDelimiters_ReturnsCorrectSegment()
        {
            var result = "<<a>>middle<<b>>end".OutsideNthToLast("<<", ">>", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", "middle<<b>>end" }, result);
        }

        [TestMethod]
        public void OutsideNthToLast_CaseInsensitive_WorksCorrectly()
        {
            var result = "Start[Name]Mid[Data]End".OutsideNthToLast("name", "]", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start[", "End" }, result);
        }

        [TestMethod]
        public void OutsideNthToLast_CaseSensitive_NoMatch_ReturnsEmpty()
        {
            var result = "Hello {Name}".OutsideNthToLast("{name", "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OutsideNthToLast_FirstPairAtStart_ReturnsTailOnly()
        {
            var result = "[start] then more text".OutsideNthToLast("[", "]", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", " then more text" }, result);
        }

        [TestMethod]
        public void OutsideNthToLast_LastPairAtEnd_ReturnsHeadOnly()
        {
            var result = "header {section} tail".OutsideNthToLast("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "header ", " tail" }, result);
        }

        [TestMethod]
        public void OutsideNthToLast_ConsecutivePairs_ReturnsCorrectTailAfterReverseNth()
        {
            var result = "<<a><><<b>>end".OutsideNthToLast("<", ">", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "<", "<><<b>>end" }, result);
        }

        #endregion

        #region OptionallyOutsideNthToLast

        [TestMethod]
        public void OptionallyOutsideNthToLast_EmptyValue_NullPrefix_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyOutsideNthToLast(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_EmptyValue_NullSuffix_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyOutsideNthToLast("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_EmptyValue_EmptyPrefixSuffix_ReturnsEmpty()
        {
            var result = string.Empty.OptionallyOutsideNthToLast("", "", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_NonEmptyValue_NullPrefix_ReturnsEmpty()
        {
            var result = "Hello {name}".OptionallyOutsideNthToLast(null, "}", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_NonEmptyValue_NullSuffix_ReturnsEmpty()
        {
            var result = "Hello {name}".OptionallyOutsideNthToLast("{", null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_PrefixSuffixNotFound_ReturnsOriginal()
        {
            var result = "No delimiters".OptionallyOutsideNthToLast("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "No delimiters" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_OnlyPrefixFound_ReturnsOriginal()
        {
            var result = "Hello {name".OptionallyOutsideNthToLast("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello {name" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_OnePair_ReturnsOutsideIfNIsOne()
        {
            var result = "Welcome {guest}!".OptionallyOutsideNthToLast("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Welcome ", "!" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_TwoPairs_ReturnsOuterSlicesAroundNthToLast()
        {
            var result = "Start {one} middle {two} end".OptionallyOutsideNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start ", " middle {two} end" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_NTooHigh_ReturnsOriginal()
        {
            var result = "Here {first} and {second}".OptionallyOutsideNthToLast("{", "}", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Here {first} and {second}" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_TouchingDelimiters_ReturnsCorrect()
        {
            var result = "a{}b{c}d".OptionallyOutsideNthToLast("{", "}", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "b{c}d" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_MultiCharDelimiters_ReturnsCorrectSegment()
        {
            var result = "<<a>>middle<<b>>end".OptionallyOutsideNthToLast("<<", ">>", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", "middle<<b>>end" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_CaseInsensitive_WorksCorrectly()
        {
            var result = "Start[Name]Mid[Data]End".OptionallyOutsideNthToLast("name", "]", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "Start[", "End" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_CaseSensitive_NoMatch_ReturnsOriginal()
        {
            var result = "Hello {Name}".OptionallyOutsideNthToLast("{name", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "Hello {Name}" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_FirstPairAtStart_ReturnsTailOnly()
        {
            var result = "[start] then more text".OptionallyOutsideNthToLast("[", "]", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", " then more text" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_LastPairAtEnd_ReturnsHeadOnly()
        {
            var result = "header {section} tail".OptionallyOutsideNthToLast("{", "}", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "header ", " tail" }, result);
        }

        [TestMethod]
        public void OptionallyOutsideNthToLast_ConsecutivePairs_ReturnsCorrectTailAfterReverseNth()
        {
            var result = "<<a><><<b>>end".OptionallyOutsideNthToLast("<", ">", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "<", "<><<b>>end" }, result);
        }

        #endregion

        #region SplitAt

        [TestMethod]
        public void SplitAt_EmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = string.Empty.SplitAt(null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAt_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.SplitAt(string.Empty, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAt_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.SplitAt(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAt_NonEmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = "apple,banana".SplitAt(null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAt_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".SplitAt(string.Empty, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAt_SeparatorNotInValue_ReturnsWholeString()
        {
            var result = "apple banana".SplitAt(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "apple banana" }, result);
        }

        [TestMethod]
        public void SplitAt_SeparatorInValue_ReturnsSplitSegments()
        {
            var result = "one,two,three".SplitAt(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one", "two", "three" }, result);
        }

        [TestMethod]
        public void SplitAt_SeparatorAtStart_ReturnsEmptyFirstSegment()
        {
            var result = ",start,mid,end".SplitAt(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", "start", "mid", "end" }, result);
        }

        [TestMethod]
        public void SplitAt_SeparatorAtEnd_ReturnsTrailingEmptySegment()
        {
            var result = "end1,end2,".SplitAt(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "end1", "end2", "" }, result);
        }

        [TestMethod]
        public void SplitAt_MultiCharacterSeparator_WorksAsExpected()
        {
            var result = "key==value==extra".SplitAt("==", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key", "value", "extra" }, result);
        }

        [TestMethod]
        public void SplitAt_ConsecutiveSeparators_ReturnsEmptySegments()
        {
            var result = "a,,b".SplitAt(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "", "b" }, result);
        }

        [TestMethod]
        public void SplitAt_CaseInsensitiveComparison_MatchesLowerSeparator()
        {
            var result = "A-B-C".SplitAt("b", StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-", "-C" }, result);
        }

        [TestMethod]
        public void SplitAt_CaseSensitiveComparison_DoesNotMatchLowerSeparator_ReturnsWhole()
        {
            var result = "A-B-C".SplitAt("b", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region OptionallySplitAt

        [TestMethod]
        public void OptionallySplitAt_EmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallySplitAt(null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAt_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallySplitAt(string.Empty, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAt_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallySplitAt(",", StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAt_NonEmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = "apple,banana".OptionallySplitAt(null, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAt_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".OptionallySplitAt(string.Empty, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAt_SeparatorNotFound_ReturnsOriginal()
        {
            var result = "apple banana".OptionallySplitAt(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "apple banana" }, result);
        }

        [TestMethod]
        public void OptionallySplitAt_SeparatorPresent_ReturnsSplitSegments()
        {
            var result = "one,two,three".OptionallySplitAt(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one", "two", "three" }, result);
        }

        [TestMethod]
        public void OptionallySplitAt_SeparatorAtStart_ReturnsLeadingEmptySegment()
        {
            var result = ",start,mid,end".OptionallySplitAt(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", "start", "mid", "end" }, result);
        }

        [TestMethod]
        public void OptionallySplitAt_SeparatorAtEnd_ReturnsTrailingEmptySegment()
        {
            var result = "end1,end2,".OptionallySplitAt(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "end1", "end2", "" }, result);
        }

        [TestMethod]
        public void OptionallySplitAt_MultiCharacterSeparator_WorksAsExpected()
        {
            var result = "key==value==extra".OptionallySplitAt("==", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key", "value", "extra" }, result);
        }

        [TestMethod]
        public void OptionallySplitAt_ConsecutiveSeparators_ProducesEmptySegment()
        {
            var result = "a,,b".OptionallySplitAt(",", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "", "b" }, result);
        }

        [TestMethod]
        public void OptionallySplitAt_CaseInsensitiveMatch_WorksCorrectly()
        {
            var result = "A-B-C".OptionallySplitAt("b", StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-", "-C" }, result);
        }

        [TestMethod]
        public void OptionallySplitAt_CaseSensitiveMismatch_ReturnsOriginal()
        {
            var result = "A-B-C".OptionallySplitAt("b", StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region SplitAtNth

        [TestMethod]
        public void SplitAtNth_EmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = string.Empty.SplitAtNth(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAtNth_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.SplitAtNth(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAtNth_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.SplitAtNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAtNth_NonEmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = "apple,banana".SplitAtNth(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAtNth_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".SplitAtNth(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAtNth_SeparatorNotInValue_ReturnsEmpty()
        {
            var result = "apple banana".SplitAtNth(",", 1, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void SplitAtNth_NLessThanTotal_ReturnsTwoSegments()
        {
            var result = "one,two,three".SplitAtNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one,two", "three" }, result);
        }

        [TestMethod]
        public void SplitAtNth_NEqualsSeparatorCount_ReturnsSplitAtLastSeparator()
        {
            var result = "a,b,c".SplitAtNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b", "c" }, result);
        }

        [TestMethod]
        public void SplitAtNth_NGreaterThanSeparatorCount_ReturnsEmpty()
        {
            var result = "a,b".SplitAtNth(",", 3, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void SplitAtNth_SeparatorAtStart_ReturnsSplitAfterFirst()
        {
            var result = ",start,mid,end".SplitAtNth(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", "start,mid,end" }, result);
        }

        [TestMethod]
        public void SplitAtNth_SeparatorAtEnd_ReturnsTrailingEmptySegment()
        {
            var result = "x,y,z,".SplitAtNth(",", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "x,y,z", "" }, result);
        }

        [TestMethod]
        public void SplitAtNth_MultiCharacterSeparator_WorksCorrectly()
        {
            var result = "key==value==extra".SplitAtNth("==", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key", "value==extra" }, result);
        }

        [TestMethod]
        public void SplitAtNth_CaseInsensitive_MatchLowercaseSeparator()
        {
            var result = "A-B-C".SplitAtNth("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-", "-C" }, result);
        }

        [TestMethod]
        public void SplitAtNth_CaseSensitive_DoesNotMatchLowerSeparator()
        {
            var result = "A-B-C".SplitAtNth("b", 1, StringComparison.Ordinal).ToList();
            Assert.AreEqual(0, result.Count);
        }

        #endregion

        #region OptionallySplitAtNth

        [TestMethod]
        public void OptionallySplitAtNth_EmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallySplitAtNth(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAtNth_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallySplitAtNth(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAtNth_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallySplitAtNth(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAtNth_NonEmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = "apple,banana".OptionallySplitAtNth(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAtNth_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".OptionallySplitAtNth(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAtNth_SeparatorNotInValue_ReturnsOriginal()
        {
            var result = "apple banana".OptionallySplitAtNth(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "apple banana" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNth_SeparatorFound_SplitsAtNth()
        {
            var result = "one,two,three".OptionallySplitAtNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one,two", "three" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNth_NthEqualsCount_SplitsAtFinalSeparator()
        {
            var result = "a,b,c".OptionallySplitAtNth(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b", "c" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNth_NthGreaterThanCount_ReturnsOriginal()
        {
            var result = "a,b".OptionallySplitAtNth(",", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNth_SeparatorAtStart_ReturnsSplit()
        {
            var result = ",start,mid,end".OptionallySplitAtNth(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", "start,mid,end" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNth_MultiCharacterSeparator_WorksCorrectly()
        {
            var result = "key==value==extra".OptionallySplitAtNth("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key==value", "extra" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNth_CaseInsensitiveComparison_Works()
        {
            var result = "A-B-C".OptionallySplitAtNth("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-", "-C" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNth_CaseSensitive_NoMatch_ReturnsOriginal()
        {
            var result = "A-B-C".OptionallySplitAtNth("b", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region SplitAtNthToLast

        [TestMethod]
        public void SplitAtNthToLast_EmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = string.Empty.SplitAtNthToLast(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAtNthToLast_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.SplitAtNthToLast(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAtNthToLast_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.SplitAtNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAtNthToLast_NonEmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = "apple,banana".SplitAtNthToLast(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAtNthToLast_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".SplitAtNthToLast(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAtNthToLast_SeparatorNotInValue_ReturnsEmpty()
        {
            var result = "apple banana".SplitAtNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAtNthToLast_NthEqualsTotal_ReturnsSplitBeforeSecondOccurrence()
        {
            var result = "one,two,three".SplitAtNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one", "two,three" }, result);
        }

        [TestMethod]
        public void SplitAtNthToLast_SeparatorAtEnd_ReturnsTrailingEmptySegment()
        {
            var result = "x,y,z,".SplitAtNthToLast(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "x,y,z", "" }, result);
        }

        [TestMethod]
        public void SplitAtNthToLast_NthGreaterThanCount_ReturnsEmpty()
        {
            var result = "a,b".SplitAtNthToLast(",", 3, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void SplitAtNthToLast_MultiCharacterSeparator_WorksCorrectly()
        {
            var result = "key==value==extra".SplitAtNthToLast("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key", "value==extra" }, result);
        }

        [TestMethod]
        public void SplitAtNthToLast_CaseInsensitiveComparison_Works()
        {
            var result = "A-B-C".SplitAtNthToLast("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-", "-C" }, result);
        }

        [TestMethod]
        public void SplitAtNthToLast_CaseSensitive_NoMatch_ReturnsEmpty()
        {
            var result = "A-B-C".SplitAtNthToLast("b", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        #endregion

        #region OptionallySplitAtNthToLast

        [TestMethod]
        public void OptionallySplitAtNthToLast_EmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallySplitAtNthToLast(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallySplitAtNthToLast(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.OptionallySplitAtNthToLast(",", 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_NonEmptyValue_NullSeparator_ReturnsEmpty()
        {
            var result = "apple,banana".OptionallySplitAtNthToLast(null, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".OptionallySplitAtNthToLast(string.Empty, 1, StringComparison.Ordinal);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_SeparatorNotInValue_ReturnsOriginal()
        {
            var result = "apple banana".OptionallySplitAtNthToLast(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "apple banana" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_SeparatorFound_ReturnsSplit()
        {
            var result = "one,two,three".OptionallySplitAtNthToLast(",", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "one,two", "three" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_NthEqualsTotal_ReturnsSplitBeforeFirst()
        {
            var result = "a,b,c".OptionallySplitAtNthToLast(",", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a", "b,c" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_NthGreaterThanTotal_ReturnsOriginal()
        {
            var result = "a,b".OptionallySplitAtNthToLast(",", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "a,b" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_SeparatorAtStart_ReturnsEmptyPrefix()
        {
            var result = ",start,mid,end".OptionallySplitAtNthToLast(",", 3, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "", "start,mid,end" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_MultiCharacterSeparator_WorksCorrectly()
        {
            var result = "key==value==extra".OptionallySplitAtNthToLast("==", 2, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "key", "value==extra" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_CaseInsensitiveComparison_Works()
        {
            var result = "A-B-C".OptionallySplitAtNthToLast("b", 1, StringComparison.OrdinalIgnoreCase).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-", "-C" }, result);
        }

        [TestMethod]
        public void OptionallySplitAtNthToLast_CaseSensitiveComparison_DoesNotMatchLowerSeparator_ReturnsOriginal()
        {
            var result = "A-B-C".OptionallySplitAtNthToLast("b", 1, StringComparison.Ordinal).ToList();
            CollectionAssert.AreEqual(new List<string> { "A-B-C" }, result);
        }

        #endregion

        #region Trim

        [TestMethod]
        public void Trim_LeadingAndTrailingSubstring_Removed()
        {
            var result = "##content##".Trim("##", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "content" }, new List<string>(result));
        }

        [TestMethod]
        public void Trim_TrimValueNotPresent_ReturnsOriginal()
        {
            var result = "text".Trim("--", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "text" }, new List<string>(result));
        }

        [TestMethod]
        public void Trim_TrimValueIsNull_ReturnsOriginal()
        {
            var result = "keep".Trim(null, StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "keep" }, new List<string>(result));
        }

        [TestMethod]
        public void Trim_TrimValueIsEmpty_ReturnsOriginal()
        {
            var result = "keep".Trim("", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "keep" }, new List<string>(result));
        }

        [TestMethod]
        public void Trim_ValueIsEmpty_ReturnsEmpty()
        {
            var result = "".Trim("##", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "" }, new List<string>(result));
        }

        [TestMethod]
        public void Trim_OnlyTrimValue_RemovesAll_ReturnsEmpty()
        {
            var result = "!!!".Trim("!", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "" }, new List<string>(result));
        }

        [TestMethod]
        public void Trim_CaseInsensitive_RemovesCorrectly()
        {
            var result = "abcXYZabc".Trim("ABC", StringComparison.OrdinalIgnoreCase);
            CollectionAssert.AreEqual(new List<string> { "XYZ" }, new List<string>(result));
        }

        #endregion

        #region TrimMaxCount

        [TestMethod]
        public void TrimMax_TrimsEvenlyFromBothSides()
        {
            var result = ">>trimmed<<".TrimMaxCount(">>", 1, StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "trimmed<<" }, new List<string>(result));
        }

        [TestMethod]
        public void TrimMax_TrimsFromBothSides_Respects()
        {
            var result = "%%keep%%".TrimMaxCount("%%", 2, StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "keep" }, new List<string>(result));
        }

        [TestMethod]
        public void TrimMax_NotEnoughToTrimFully()
        {
            var result = "--cut--".TrimMaxCount("--", 1, StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "cut--" }, new List<string>(result));
        }

        [TestMethod]
        public void TrimMax_CaseInsensitiveMatch()
        {
            var result = "ABCabcABC".TrimMaxCount("abc", 2, StringComparison.OrdinalIgnoreCase);
            CollectionAssert.AreEqual(new List<string> { "ABC" }, new List<string>(result));
        }

        [TestMethod]
        public void TrimMax_EmptyValue_ReturnsEmpty()
        {
            var result = "".TrimMaxCount("x", 3, StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "" }, new List<string>(result));
        }

        [TestMethod]
        public void TrimMax_EmptyTrimValue_ReturnsOriginal()
        {
            var result = "unchanged".TrimMaxCount("", 5, StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "unchanged" }, new List<string>(result));
        }

        #endregion

        #region TrimEnd

        [TestMethod]
        public void TrimEnd_SubstringAtEnd_Removed()
        {
            var result = "log$$$".TrimEnd("$$$", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "log" }, new List<string>(result));
        }

        [TestMethod]
        public void TrimEnd_MultipleEndMatches_RemovedAll()
        {
            var result = "core####".TrimEnd("##", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "core" }, new List<string>(result));
        }

        [TestMethod]
        public void TrimEnd_TrimValueNotPresent_ReturnsOriginal()
        {
            var result = "unchanged".TrimEnd("==", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "unchanged" }, new List<string>(result));
        }

        #endregion

        #region TrimEndMaxCount

        [TestMethod]
        public void TrimEndMax_TrimsUpTo()
        {
            var result = "log---".TrimEndMaxCount("-", 2, StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "log-" }, new List<string>(result));
        }

        [TestMethod]
        public void TrimEndMax_ZeroLimit_DoesNotTrim()
        {
            var result = "test@@".TrimEndMaxCount("@", 0, StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "test@@" }, new List<string>(result));
        }

        #endregion

        #region TrimStart

        [TestMethod]
        public void TrimStart_SubstringAtStart_Removed()
        {
            var result = ">>text>>".TrimStart(">>", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "text>>" }, new List<string>(result));
        }

        [TestMethod]
        public void TrimStart_MultipleStartMatches_RemovedAll()
        {
            var result = "123123data".TrimStart("123", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "data" }, new List<string>(result));
        }

        [TestMethod]
        public void TrimStart_TrimValueNotPresent_ReturnsOriginal()
        {
            var result = "hello".TrimStart("---", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "hello" }, new List<string>(result));
        }

        [TestMethod]
        public void TrimStartAndEnd_EmptyTrimValue_ReturnsOriginal()
        {
            var resultStart = "unchanged".TrimStart("", StringComparison.Ordinal);
            var resultEnd = "unchanged".TrimEnd("", StringComparison.Ordinal);

            CollectionAssert.AreEqual(new List<string> { "unchanged" }, new List<string>(resultStart));
            CollectionAssert.AreEqual(new List<string> { "unchanged" }, new List<string>(resultEnd));
        }

        [TestMethod]
        public void TrimStartAndEnd_ValueIsEmpty_ReturnsEmpty()
        {
            var resultStart = "".TrimStart("trim", StringComparison.Ordinal);
            var resultEnd = "".TrimEnd("trim", StringComparison.Ordinal);

            CollectionAssert.AreEqual(new List<string> { "" }, new List<string>(resultStart));
            CollectionAssert.AreEqual(new List<string> { "" }, new List<string>(resultEnd));
        }

        [TestMethod]
        public void TrimStartAndEnd_CaseInsensitive_MatchesTrimValue()
        {
            var resultStart = "TRIMdata".TrimStart("trim", StringComparison.OrdinalIgnoreCase);
            var resultEnd = "dataTRIM".TrimEnd("trim", StringComparison.OrdinalIgnoreCase);

            CollectionAssert.AreEqual(new List<string> { "data" }, new List<string>(resultStart));
            CollectionAssert.AreEqual(new List<string> { "data" }, new List<string>(resultEnd));
        }

        #endregion

        #region TrimStartMaxCount

        [TestMethod]
        public void TrimStartMax_TrimsUpTo()
        {
            var result = "xxxtitle".TrimStartMaxCount("x", 2, StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "xtitle" }, new List<string>(result));
        }

        [TestMethod]
        public void TrimStartMax_TrimValueNotPresent_ReturnsOriginal()
        {
            var result = "data".TrimStartMaxCount("z", 3, StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "data" }, new List<string>(result));
        }

        #endregion

        #region NotEmpty

        [TestMethod]
        public void NotEmpty_NonEmptyString_ReturnsSingleItem()
        {
            var result = "value".NotEmpty();
            CollectionAssert.AreEqual(new List<string> { "value" }, new List<string>(result));
        }

        [TestMethod]
        public void NotEmpty_EmptyString_ReturnsEmpty()
        {
            var result = "".NotEmpty();
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void NotEmpty_WhitespaceString_ReturnsItem()
        {
            var result = "   ".NotEmpty();
            CollectionAssert.AreEqual(new List<string> { "   " }, new List<string>(result));
        }

        [TestMethod]
        public void NotEmpty_SymbolsAndNumbers_ReturnsItem()
        {
            var result = "#123!".NotEmpty();
            CollectionAssert.AreEqual(new List<string> { "#123!" }, new List<string>(result));
        }

        #endregion

        #region Reverse

        [TestMethod]
        public void Reverse_RegularString_ReturnsReversed()
        {
            var result = "hello".Reverse();
            CollectionAssert.AreEqual(new List<string> { "olleh" }, new List<string>(result));
        }

        [TestMethod]
        public void Reverse_EmptyString_ReturnsEmptyEnumerable()
        {
            var result = "".Reverse();
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void Reverse_SingleCharacter_ReturnsSameCharacter()
        {
            var result = "x".Reverse();
            CollectionAssert.AreEqual(new List<string> { "x" }, new List<string>(result));
        }

        [TestMethod]
        public void Reverse_Palindrome_ReturnsSameString()
        {
            var result = "racecar".Reverse();
            CollectionAssert.AreEqual(new List<string> { "racecar" }, new List<string>(result));
        }

        [TestMethod]
        public void Reverse_WithSymbolsAndSpaces_ReversesCorrectly()
        {
            var result = "A man!".Reverse();
            CollectionAssert.AreEqual(new List<string> { "!nam A" }, new List<string>(result));
        }

        #endregion








    }
}
