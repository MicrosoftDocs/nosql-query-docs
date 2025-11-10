---
title: IS_FINITE_NUMBER
description: The `IS_FINITE_NUMBER` function returns a boolean indicating if a number is a finite number (not infinite).
ms.date: 11/10/2025
---

# `IS_FINITE_NUMBER` - Query language in Cosmos DB (in Azure and Fabric)

The `IS_FINITE_NUMBER` function returns a boolean indicating if a number is a finite number (not infinite).

An Azure Cosmos DB for NoSQL system function that returns a boolean indicating if a number is a countable (finite) number.

## Syntax

```nosql
IS_FINITE_NUMBER(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a boolean.

## Examples

This section contains examples of how to use this query language construct.

### Check if number is finite

In this example, the `IS_FINITE_NUMBER` function is demonstrated with various static values.

```nosql
SELECT VALUE {
  finiteValue: IS_FINITE_NUMBER(1234.567),
  infiniteValue: IS_FINITE_NUMBER(8.9 / 0.0),
  nanValue: IS_FINITE_NUMBER(SQRT(-1.0))
}
```

```json
[
  {
    "finiteValue": true,
    "infiniteValue": false,
    "nanValue": false
  }
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
