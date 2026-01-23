---
title: RIGHT
description: The `RIGHT` function returns the right part of a string up to the specified number of characters.
ms.date: 11/10/2025
---

# `RIGHT` - Query language in Cosmos DB (in Azure and Fabric)

The `RIGHT` function returns the right part of a string up to the specified number of characters.

An Azure Cosmos DB system function that returns a substring from the right side of a string.

## Syntax

```cosmos-db
RIGHT(<string_expr>, <numeric_expr>)
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

### Get right part of string

In this example, the `RIGHT` function is used to return the right part of the string `AdventureWorks` for various length values.

```cosmos-db
SELECT VALUE {
  lastZero: RIGHT("AdventureWorks", 0),
  lastOne: RIGHT("AdventureWorks", 1),
  lastFive: RIGHT("AdventureWorks", 5),
  fullLength: RIGHT("AdventureWorks", LENGTH("AdventureWorks")),
  beyondMaxLength: RIGHT("AdventureWorks", 100)
}
```

```json
[
  {
    "lastZero": "",
    "lastOne": "s",
    "lastFive": "Works",
    "fullLength": "AdventureWorks",
    "beyondMaxLength": "AdventureWorks"
  }
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
