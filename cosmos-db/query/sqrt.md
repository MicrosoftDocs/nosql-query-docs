---
title: SQRT
description: The `SQRT` function returns the square root of the specified numeric value.
ms.date: 11/10/2025
---

# `SQRT` - Query language in Cosmos DB (in Azure and Fabric)

The `SQRT` function returns the square root of the specified numeric value.

An Azure Cosmos DB for NoSQL system function that returns the square root of the specified numeric value.

## Syntax

```cosmos-db
SQRT(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Calculate square roots

In this example, the `SQRT` function is used to return the square roots of various numeric values.

```cosmos-db
SELECT VALUE {
  sqrtZero: SQRT(0),
  sqrtOne: SQRT(1),
  sqrtFour: SQRT(4),
  sqrtPrime: SQRT(17),
  sqrtTwentyFive: SQRT(25)
}
```

```json
[
  {
    "sqrtZero": 0,
    "sqrtOne": 1,
    "sqrtFour": 2,
    "sqrtPrime": 4.123105625617661,
    "sqrtTwentyFive": 5
  }
]
```

## Remarks

- This function doesn't utilize the index.
