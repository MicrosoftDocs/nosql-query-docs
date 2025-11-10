---
title: STARTSWITH
description: The `STARTSWITH` function returns a boolean value indicating whether the first string expression starts with the second.
ms.date: 11/10/2025
---

# `STARTSWITH` - Query language in Cosmos DB (in Azure and Fabric)

The `STARTSWITH` function returns a boolean value indicating whether the first string expression starts with the second.

An Azure Cosmos DB for NoSQL system function that returns a boolean indicating whether one string expression starts with another.

## Syntax

```nosql
STARTSWITH(<string_expr_1>, <string_expr_2> [, <bool_expr>])
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr_1`** | A string expression. |
| **`string_expr_2`** | A string expression to be compared to the beginning of `string_expr_1`. |
| **`bool_expr`** | Optional value for ignoring case. When set to `true`, `STARTSWITH` does a case-insensitive search. When unspecified, this default value is `false`. |

## Return types

Returns a boolean expression.

## Examples

This section contains examples of how to use this query language construct.

### Check if string starts with another string

In this example, the `STARTSWITH` function is used to check if a string starts with a given prefix, with and without case sensitivity.

```nosql
SELECT VALUE {
  startsWithWrongPrefix: STARTSWITH("AdventureWorks", "Works"),
  startsWithCorrectPrefix: STARTSWITH("AdventureWorks", "Adventure"),
  startsWithPrefixWrongCase: STARTSWITH("AdventureWorks", "adventure"),
  startsWithPrefixCaseInsensitive: STARTSWITH("AdventureWorks", "adventure", true)
}
```

```json
[
  {
    "startsWithWrongPrefix": false,
    "startsWithCorrectPrefix": true,
    "startsWithPrefixWrongCase": false,
    "startsWithPrefixCaseInsensitive": true
  }
]
```

## Remarks

- This function performs a precise index scan.
