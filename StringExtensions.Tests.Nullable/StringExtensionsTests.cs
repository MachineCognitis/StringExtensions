
using MachineCognitis.StringExtensions;

namespace StringExtensions.Tests.Nullable
{
    [TestClass]
    public sealed class StringExtensionsTests
    {

        #region After

        [TestMethod]
        public void After_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.After(string.Empty, StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void After_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.After(",", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void After_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".After(string.Empty, StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void After_SeparatorNotInValue_ReturnsEmpty()
        {
            var result = "apple banana".After(",", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
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
        public void After_SeparatorAtEnd_ReturnsEmpty()
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

        #region Before

        [TestMethod]
        public void Before_EmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = string.Empty.Before(string.Empty, StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void Before_EmptyValue_WithSeparator_ReturnsEmpty()
        {
            var result = string.Empty.Before(",", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void Before_NonEmptyValue_EmptySeparator_ReturnsEmpty()
        {
            var result = "apple,banana".Before(string.Empty, StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void Before_SeparatorNotInValue_ReturnsEmpty()
        {
            var result = "apple banana".Before(",", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void Before_SeparatorInValue_ReturnsSubstrings()
        {
            var result = "one,two,three".Before(",", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "one", "two" }, new List<string>(result));
        }

        [TestMethod]
        public void Before_SeparatorAtStart_ReturnsEmptyStringAtFirst()
        {
            var result = ",start,mid,end".Before(",", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "", "start", "mid" }, new List<string>(result));
        }

        [TestMethod]
        public void Before_SeparatorAtEnd_ReturnsAllButLastSegment()
        {
            var result = "end1,end2,".Before(",", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "end1", "end2" }, new List<string>(result));
        }

        [TestMethod]
        public void Before_MultiCharacterSeparator_WorksAsExpected()
        {
            var result = "key==value==extra".Before("==", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "key", "value" }, new List<string>(result));
        }

        [TestMethod]
        public void Before_ConsecutiveSeparators_ReturnsEmptyBetween()
        {
            var result = "a,,b".Before(",", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "a", "" }, new List<string>(result));
        }

        [TestMethod]
        public void Before_CaseInsensitiveComparison_MatchesLowerSeparator()
        {
            var result = "A-B-C".Before("b", StringComparison.OrdinalIgnoreCase);
            CollectionAssert.AreEqual(new List<string> { "A-" }, new List<string>(result));
        }

        [TestMethod]
        public void Before_CaseSensitiveComparison_DoesNotMatchLowerSeparator()
        {
            var result = "A-B-C".Before("b", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        #endregion

        #region Between

        [TestMethod]
        public void Between_EmptyValue_EmptyPrefixSuffix_ReturnsEmpty()
        {
            var result = string.Empty.Between(string.Empty, string.Empty, StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void Between_EmptyValue_WithPrefixSuffix_ReturnsEmpty()
        {
            var result = string.Empty.Between("[", "]", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void Between_ValueWith_EmptyPrefixSuffix_ReturnsEmpty()
        {
            var result = "Some text [here]".Between(string.Empty, string.Empty, StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void Between_PrefixNotInValue_ReturnsEmpty()
        {
            var result = "Some text [here]".Between("(", "]", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void Between_SuffixNotInValue_ReturnsEmpty()
        {
            var result = "Some text [here]".Between("[", ")", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void Between_PrefixAndSuffixInValue_ReturnsMatches()
        {
            var result = "Get [this] and [that] please.".Between("[", "]", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "this", "that" }, new List<string>(result));
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
        public void Between_MultiCharDelimiters_ReturnsExpected()
        {
            var result = "start<<value1>>middle<<value2>>end".Between("<<", ">>", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "value1", "value2" }, new List<string>(result));
        }

        [TestMethod]
        public void Between_ConsecutivePrefixesOrSuffixes_ReturnsEmptyBetween()
        {
            var result = "<<a><><<b>>".Between("<", ">", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "<a", "", "<b" }, new List<string>(result));
        }

        [TestMethod]
        public void Between_OrdinalIgnoreCase_WorksAsExpected()
        {
            // Prefix/suffix in input are lowercase, parameters are mixed-case
            var result = "Start<l[Data]L> and <l[Result]L>".Between("<L[", "]L>", StringComparison.OrdinalIgnoreCase);

            CollectionAssert.AreEqual(new List<string> { "Data", "Result" }, new List<string>(result));
        }

        [TestMethod]
        public void Between_Ordinal_MismatchedCase_NoMatch()
        {
            // Same input, but comparison is case-sensitive, so prefix/suffix won't match
            var result = "Start<l[Data]L> and <l[Result]L>".Between("<L[", "]L>", StringComparison.Ordinal);

            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        #endregion

        #region Outside

        [TestMethod]
        public void Outside_EmptyValue_EmptyPrefixSuffix_ReturnsEmpty()
        {
            var result = string.Empty.Outside(string.Empty, string.Empty, StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void Outside_EmptyValue_WithPrefixSuffix_ReturnsEmpty()
        {
            var result = string.Empty.Outside("[", "]", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void Outside_ValueWith_EmptyPrefixSuffix_ReturnsEmpty()
        {
            var result = "Some text [here]".Outside(string.Empty, string.Empty, StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void Outside_PrefixNotInValue_ReturnsEmpty()
        {
            var result = "Some text [here]".Outside("(", "]", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void Outside_SuffixNotInValue_ReturnsEmpty()
        {
            var result = "Some text [here]".Outside("[", ")", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void Outside_PrefixAndSuffixInValue_ReturnsOutsideSegments()
        {
            var result = "Get [this] and [that] please.".Outside("[", "]", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "Get ", " and ", " please." }, new List<string>(result));
        }

        [TestMethod]
        public void Outside_PrefixAtStartOfValue_ReturnsTailOnly()
        {
            var result = "[start] and then some".Outside("[", "]", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "", " and then some" }, new List<string>(result));
        }

        [TestMethod]
        public void Outside_SuffixAtEndOfValue_ReturnsStartOnly()
        {
            var result = "final is [this one]".Outside("[", "]", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "final is ", "" }, new List<string>(result));
        }

        [TestMethod]
        public void Outside_MultiCharDelimiters_ReturnsOutsideContent()
        {
            var result = "start<<value1>>middle<<value2>>end".Outside("<<", ">>", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "start", "middle", "end" }, new List<string>(result));
        }

        [TestMethod]
        public void Outside_ConsecutivePrefixesOrSuffixes_ReturnsOutsideParts()
        {
            var result = "<<a><><<b>>".Outside("<", ">", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "", "", "", ">" }, new List<string>(result));
        }

        [TestMethod]
        public void Outside_OrdinalIgnoreCase_WorksAsExpected()
        {
            var result = "Start<l[Data]L> and <l[Result]L>".Outside("<L[", "]L>", StringComparison.OrdinalIgnoreCase);
            CollectionAssert.AreEqual(new List<string> { "Start", " and ", "" }, new List<string>(result));
        }

        [TestMethod]
        public void Outside_Ordinal_MismatchedCase_NoMatch()
        {
            var result = "Start<l[Data]L> and <l[Result]L>".Outside("<L[", "]L>", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        #endregion

        #region SplitAt

        [TestMethod]
        public void SplitAt_SeparatorBetweenWords_ReturnsSegments()
        {
            var result = "one|two|three".SplitAt("|", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "one", "two", "three" }, new List<string>(result));
        }

        [TestMethod]
        public void SplitAt_EmptyValue_ReturnsEmpty()
        {
            var result = "".SplitAt("|", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void SplitAt_EmptySeparator_ReturnsEmpty()
        {
            var result = "a|b|c".SplitAt("", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string>(), new List<string>(result));
        }

        [TestMethod]
        public void SplitAt_SeparatorAtStartAndEnd_ReturnsEmptySegments()
        {
            var result = "|start|middle|end|".SplitAt("|", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "", "start", "middle", "end", "" }, new List<string>(result));
        }

        [TestMethod]
        public void SplitAt_ConsecutiveSeparators_ReturnsEmptySegmentsBetween()
        {
            var result = "a||b|||c".SplitAt("|", StringComparison.Ordinal);
            CollectionAssert.AreEqual(new List<string> { "a", "", "b", "", "", "c" }, new List<string>(result));
        }

        [TestMethod]
        public void SplitAt_CaseInsensitiveComparison_MatchesSeparator()
        {
            var result = "WordSEPwordSEPWord".SplitAt("sep", StringComparison.OrdinalIgnoreCase);
            CollectionAssert.AreEqual(new List<string> { "Word", "word", "Word" }, new List<string>(result));
        }

        #endregion

    }
}
