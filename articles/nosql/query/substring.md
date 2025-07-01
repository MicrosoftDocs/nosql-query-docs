---
title: SUBSTRING
description: The `SUBSTRING` function returns part of a string expression starting at the specified position and of the specified length, or to the end of the string.
ms.date: 07/01/2025
---

# `SUBSTRING` (NoSQL query)

The `SUBSTRING` function returns part of a string expression starting at the specified position and of the specified length, or to the end of the string.

An Azure Cosmos DB for NoSQL system function that returns a portion of a string using a starting position and length.

## Syntax

```nosql
SUBSTRING(<string_expr>, <numeric_expr_1>, <numeric_expr_2>)
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr`** | A string expression. |
| **`numeric_expr_1`** | A numeric expression to denote the start character. |
| **`numeric_expr_2`** | A numeric expression to denote the maximum number of characters of `string_expr` to be returned. |

## Return types

Returns a string expression.

## Examples

This section contains examples of how to use this query language construct.

### Extract substrings from a string

In this example, the `SUBSTRING` function is used to return substrings with various lengths and starting positions.

```nosql
SELECT VALUE {
  substringPrefix: SUBSTRING("AdventureWorks", 0, 9),
  substringSuffix: SUBSTRING("AdventureWorks", 9, 5),
  substringTotalLength: SUBSTRING("AdventureWorks", 0, LENGTH("AdventureWorks")),
  substringEmptyString: SUBSTRING("AdventureWorks", 0, -1)
}
```

```json
[
  {
    "substringPrefix": "Adventure",
    "substringSuffix": "Works",
    "substringTotalLength": "AdventureWorks",
    "substringEmptyString": ""
  }
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
