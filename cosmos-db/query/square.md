---
title: SQUARE
description: The `SQUARE` function returns the square of the specified numeric value.
ms.date: 11/10/2025
---

# `SQUARE` - Query language in Cosmos DB (in Azure and Fabric)

The `SQUARE` function returns the square of the specified numeric value.

The `SQUARE` function returns the square of a numeric value in Azure Cosmos DB for NoSQL.

## Syntax

```cosmos-db
SQUARE(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Return squares of numbers

In this example, the `SQUARE` function is used to return the squares of various numbers.

```cosmos-db
SELECT VALUE {
  squareZero: SQUARE(0),
  squareOne: SQUARE(1),
  squareTwo: SQUARE(2),
  squareThree: SQUARE(3),
  squareNull: SQUARE(null)
}
```

```json
[
  {
    "squareZero": 0,
    "squareOne": 1,
    "squareTwo": 4,
    "squareThree": 9
  }
]
```

## Remarks

- This function doesn't utilize the index.
