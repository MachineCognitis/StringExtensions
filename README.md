# StringExtensions

## Features

1. Rich and intuitive set of functions for manipulating strings that extends the
   common `Substring()`, `IndexOf()`, `Replace()` and `Split()` functions.

2. String extensions that accept and return `IEnumerable<string>` making it super easy
   to iterate over collections of strings.

3. Support for regular expressions for handling more complicated cases.

## Functions Summary

RENDU : MS TESTS pour StringEnumerableExtensions

Core 

[`Optionally`]`After`[First|Nth|NthToLast|Last][Regex](string separator, StringComparison comparisonType = StringComparison.Ordinal)
Regex n'a pas de stringComparison.

-After()
-Before()
-Between()
-Outside()
-SplitAt()

Replace()
ReplaceAfter()
ReplaceBefore()
ReplaceBetween()
ReplaceOutside()
ReplaceAt()
-Reverse()

-NotEmpty()

Substr()
Left()
Right()
Truncate()
PadLeft()?
PadRight()?

IsEmpty()
IsNullOrEmpty()
IsNullOrWhiteSpace()

Join()

-Trim()
-TrimStart()
-TrimStartOnce()
-TrimEnd()
-TrimEndOnce()



To string only
IndexesOf()
RangesOf()

```

Often when coding, we need to extract, find, or replace parts of a string to extract target values.
Achieving this using common functions such as `Substring()`, `IndexOf()`, `Replace()`, `Split()`, etc.,
or regular expressions can be complicated and unintuitive.
We define a number of string extensions that are more intuitive for achieving this.
Our goal here is not performance, but ease of use, and self-documentation.

For example, let's say we have a list of names of infamous couples.

```
s = "[Clyde Barrow & Bonnie Parker], [Romeo Montague & Juliet Capulet]"
```

and we want to extract their last names.
We would do it as follows using the string extensions.

```
s.Between("[", "]").SplitAt(" & ").After(" ")
```

The `Between()` function yields a list of the substrings of `s` that appear between square brackets.
Then that list is processed by the `Split()` function that splits strings around `" & "`, yielding
a new list of strings consisting of the individual full names. Finally, the `After()` function
processes the list of names returning for each name the substrings following the space character,
yielding the desired last names.

```
Between("[", "]") => { "Clyde Barrow & Bonnie Parker", "Romeo Montague & Juliet Capulet" }
Split(" & ") => { "Clyde Barrow", "Bonnie Parker", "Romeo Montague", "Juliet Capulet" }
After(" ") => { "Barrow", "Parker", "Montague", "Capulet" }
```

Functions like  `Between()`, `Split()`, `After()` and others can be applied to both strings and lists
of strings. When applied to a list of strings, they process each string in the list, concatenating their
individual result lists into a single list of strings. This is what the functions `Split()` and `After()`
do in the above example.

When a function does not find any substring, it returns an empty list. Sometimes, however, a pattern
may be optionally present, and in that case, instead of an empty list, we would like the original
string to be returned for further processing. For example, consider the following list of `dd` tags
where a description can be optionally embedded into an `a` tag.

```
s = { "<dd>Desc1</dd>", "<dd><a href='#link2'>Desc2</a></dd>", "<dd>Desc3</dd>" }
```

We can extract descriptions as follows.

```
s.Between("<dd", "/dd>").OptionallyBetween("><a ", "/a><").Between(">", "<")
```

with the following intermediate results.

```
Between("<dd", "/dd>") => { ">Desc1<", "><a href='#link2'>Desc2</a><", ">Desc3<" }
OptionallyBetween("><a ", "/a><") => { ">Desc1<", " href='#link2'>Desc2<", ">Desc3<" }
Between(">", "<") => { "Desc1", "Desc2", "Desc3" }
```

Most functions can be prefixed with `Optionally` to achieve the same behavior.





```
<company>
    <department name="Engineering" director="Alice Johnson">
        <employee name="David Smith" role="Software Engineer" />
        <employee name="Emma Brown" role="Data Scientist" />
    </department>
    <department name="Human Resources" director="Michael Davis" />
</company>
```


