---
title: INDEX-OF
description: The `INDEX_OF` function returns the index of the first occurrence of a string.
ms.date: 06/30/2025
---

# `INDEX-OF` (NoSQL query)

The `INDEX_OF` function returns the index of the first occurrence of a string.

## Syntax

```nosql
INDEX_OF(<string_expr_1>, <string_expr_2> [, <numeric_expr>])
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr_1`** | A string expression that is the target of the search. |
| **`string_expr_2`** | A string expression with the substring that is the source of the search (or to search for). |
| **`numeric_expr`** | An optional numeric expression that indicates where, in `string_expr_1`, to start the search. If not specified, the default value is `0`. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Find index of substring

In this example, the `INDEX_OF` function is used to find the index of various substrings.

```nosql
SELECT VALUE {
  indexOfFirstLetter: INDEX_OF("AdventureWorks", "A"),
  indexOfLastLetter: INDEX_OF("AdventureWorks", "s"),
  indexOfPrefix: INDEX_OF("AdventureWorks", "Adventure"),
  indexOfSuffix: INDEX_OF("AdventureWorks", "Works"),
  indexOfSubstring: INDEX_OF("AdventureWorks", "tureW"),
  indexOfNonMatch: INDEX_OF("AdventureWorks", "Cosmos"),
  indexOfCustomStartMatch: INDEX_OF("AdventureWorks", "Works", 5),
  indexOfCustomStartNoMatch: INDEX_OF("AdventureWorks", "Adventure", 5),
  indexOfCaseSensitive: INDEX_OF("AdventureWorks", "aD")
}
```

```json
[
  {
    "indexOfFirstLetter": 0,
    "indexOfLastLetter": 13,
    "indexOfPrefix": 0,
    "indexOfSuffix": 9,
    "indexOfSubstring": 5,
    "indexOfNonMatch": -1,
    "indexOfCustomStartMatch": 9,
    "indexOfCustomStartNoMatch": -1,
    "indexOfCaseSensitive": -1
  }
]
```
