---
title: LENGTH
description: The `LENGTH` function returns the number of characters in the specified string expression.
ms.date: 06/30/2025
---

# `LENGTH` (NoSQL query)

The `LENGTH` function returns the number of characters in the specified string expression.

An Azure Cosmos DB for NoSQL system function that returns the numeric length of a string expression.

## Syntax

```nosql
LENGTH(<string_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr`** | A string expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Get length of string

In this example, the `LENGTH` function is used to return the length of a static string.

```nosql
SELECT VALUE {
  stringValue: LENGTH("AdventureWorks"),
  emptyString: LENGTH("")
}
```

```json
[
  {
    "stringValue": 14,
    "emptyString": 0
  }
]
```

## Remarks

- This function doesn't utilize the index.
