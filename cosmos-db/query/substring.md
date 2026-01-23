---
title: SUBSTRING
description: The `SUBSTRING` function returns part of a string expression starting at the specified position and of the specified length.
ms.date: 01/23/2026
---

# `SUBSTRING` - Query language in Cosmos DB (in Azure and Fabric)

The `SUBSTRING` function returns part of a string expression starting at the specified position and of the specified length.

An Azure Cosmos DB for NoSQL system function that returns a portion of a string using a starting position and length.

## Syntax

```cosmos-db
SUBSTRING(<string_expr>, <numeric_expr_1>, <numeric_expr_2>)
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr`** | A string expression. |
| **`numeric_expr_1`** | A zero-based numeric expression to denote the start character. A value of `0` refers to the first character. |
| **`numeric_expr_2`** | A numeric expression to denote the maximum number of characters of `string_expr` to be returned. |

## Return types

Returns a string expression.

## Examples

This section contains examples of how to use this query language construct.

### Extract substrings from a string

In this example, the `SUBSTRING` function is used to return substrings with various lengths and starting positions.

```cosmos-db
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

- This function uses zero-based indexing, meaning `0` refers to the first character in the string.
- If `numeric_expr_2` (length) is negative, the function returns an empty string.
- To return a substring to the end of the string, use the `LENGTH` function to calculate the remaining characters (for example, `SUBSTRING(str, start, LENGTH(str) - start)`).
- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
