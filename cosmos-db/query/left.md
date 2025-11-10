---
title: LEFT
description: The `LEFT` function returns the left part of a string up to the specified number of characters.
ms.date: 11/10/2025
---

# `LEFT` (NoSQL query)

The `LEFT` function returns the left part of a string up to the specified number of characters.

An Azure Cosmos DB for NoSQL system function that returns a substring from the left side of a string.

## Syntax

```nosql
LEFT(<string_expr>, <numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr`** | A string expression. |
| **`numeric_expr`** | A numeric expression specifying the number of characters to extract from `string_expr`. |

## Return types

Returns a string expression.

## Examples

This section contains examples of how to use this query language construct.

### Get left part of string

In this example, the `LEFT` function is used to return the left part of the string `AdventureWorks` for various length values.

```nosql
SELECT VALUE {
  firstZero: LEFT("AdventureWorks", 0),
  firstOne: LEFT("AdventureWorks", 1),
  firstFive: LEFT("AdventureWorks", 5),
  fullLength: LEFT("AdventureWorks", LENGTH("AdventureWorks")),
  beyondMaxLength: LEFT("AdventureWorks", 100)
}
```

```json
[
  {
    "firstZero": "",
    "firstOne": "A",
    "firstFive": "Adven",
    "fullLength": "AdventureWorks",
    "beyondMaxLength": "AdventureWorks"
  }
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
