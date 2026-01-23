---
title: REGEXMATCH
description: The `REGEXMATCH` function returns a boolean indicating whether the provided string matches the specified regular expression. Regular expressions are a concise and flexible notation for finding patterns of text.
ms.date: 11/10/2025
---

# `REGEXMATCH` - Query language in Cosmos DB (in Azure and Fabric)

The `REGEXMATCH` function returns a boolean indicating whether the provided string matches the specified regular expression. Regular expressions are a concise and flexible notation for finding patterns of text.

An Azure Cosmos DB system function that provides regular expression capabilities.

## Syntax

```cosmos-db
REGEXMATCH(<string_expr_1>, <string_expr_2>[, <string_expr_3>])
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr_1`** | A string expression to be searched. |
| **`string_expr_2`** | A string expression with a regular expression defined to use when searching `string_expr_1`. |
| **`string_expr_3`** | An optional string expression with the selected modifiers to use with the regular expression (`string_expr_2`). If not provided, the default is to run the regular expression match with no modifiers. |

## Return types

Returns a boolean expression.

## Examples

This section contains examples of how to use this query language construct.

### Regular expression matches with modifiers

In this example, the `REGEXMATCH` function is used to match various patterns and modifiers.

```cosmos-db
SELECT VALUE {
  noModifiers: REGEXMATCH("abcd", "ABC"),
  caseInsensitive: REGEXMATCH("abcd", "ABC", "i"),
  wildcardCharacter: REGEXMATCH("abcd", "ab.", ""),
  ignoreWhiteSpace: REGEXMATCH("abcd", "ab c", "x"),
  caseInsensitiveAndIgnoreWhiteSpace: REGEXMATCH("abcd", "aB c", "ix"),
  containNumberBetweenZeroAndNine: REGEXMATCH("03a", "[0-9]"),
  containPrefix: REGEXMATCH("salt3824908", "salt{1}"),
  containsFiveLetterWordStartingWithS: REGEXMATCH("shame", "s....", "i")
}
```

```json
[
  {
    "noModifiers": false,
    "caseInsensitive": true,
    "wildcardCharacter": true,
    "ignoreWhiteSpace": true,
    "caseInsensitiveAndIgnoreWhiteSpace": true,
    "containNumberBetweenZeroAndNine": true,
    "containPrefix": true,
    "containsFiveLetterWordStartingWithS": true
  }
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
