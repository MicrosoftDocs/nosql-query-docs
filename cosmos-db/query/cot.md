---
title: COT
description: The `COT` function calculates the trigonometric cotangent of the specified angle in radians.
ms.date: 11/10/2025
---

# `COT` - Query language in Cosmos DB (in Azure and Fabric)

The `COT` function calculates the trigonometric cotangent of the specified angle in radians.

## Syntax

```nosql
COT(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Cotangent of a value

In this example, the `COT` function is used to calculate the cotangent of 124.1332 radians.

```nosql
SELECT VALUE {
  cotangent: COT(124.1332)
}
```

```json
[
  {
    "cotangent": -0.040311998371148884
  }
]
```

## Remarks

- This function doesn't utilize the index.
