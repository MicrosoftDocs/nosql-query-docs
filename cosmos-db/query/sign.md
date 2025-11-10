---
title: SIGN
description: The `SIGN` function returns the positive (+1), zero (0), or negative (-1) sign of the specified numeric expression.
ms.date: 11/10/2025
---

# `SIGN` (NoSQL query)

The `SIGN` function returns the positive (+1), zero (0), or negative (-1) sign of the specified numeric expression.

The `SIGN` function returns the sign of a numeric value in Azure Cosmos DB for NoSQL.

## Syntax

```nosql
SIGN(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Return sign of numbers

In this example, the `SIGN` function is used to return the sign of various numbers from -2 to 2.

```nosql
SELECT VALUE {
  signNegativeTwo: SIGN(-2),
  signNegativeOne: SIGN(-1),
  signZero: SIGN(0),
  signOne: SIGN(1),
  signTwo: SIGN(2)
}
```

```json
[
  {
    "signNegativeTwo": -1,
    "signNegativeOne": -1,
    "signZero": 0,
    "signOne": 1,
    "signTwo": 1
  }
]
```

## Remarks

- This function doesn't utilize the index.
