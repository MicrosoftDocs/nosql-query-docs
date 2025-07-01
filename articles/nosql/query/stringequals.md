---
title: STRINGEQUALS
description: The `STRINGEQUALS` function returns a boolean indicating whether the first string expression matches the second.
ms.date: 07/01/2025
---

# `STRINGEQUALS` (NoSQL query)

The `STRINGEQUALS` function returns a boolean indicating whether the first string expression matches the second.

An Azure Cosmos DB for NoSQL system function that returns a boolean indicating whether two strings are equivalent.

## Syntax

```nosql
STRINGEQUALS(<string_expr_1>, <string_expr_2> [, <boolean_expr>])
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr_1`** | The first string expression to compare. |
| **`string_expr_2`** | The second string expression to compare. |
| **`boolean_expr`** | An optional boolean expression for ignoring case. When set to `true`, this function performs a case-insensitive search. If not specified, the default value is `false`. |

## Return types

Returns a boolean expression.

## Examples

This section contains examples of how to use this query language construct.

### Compare string equality

In this example, the `STRINGEQUALS` function is used to check if two strings are equal, with and without case sensitivity.

```nosql
SELECT VALUE {
  compareSameCase: STRINGEQUALS("AdventureWorks", "AdventureWorks"),
  compareDifferentCase: STRINGEQUALS("AdventureWorks", "adventureworks"),
  compareIgnoreCase: STRINGEQUALS("AdventureWorks", "adventureworks", true)
}
```

```json
[
  {
    "compareSameCase": true,
    "compareDifferentCase": false,
    "compareIgnoreCase": true
  }
]
```

## Remarks

- This function performs an index seek.
