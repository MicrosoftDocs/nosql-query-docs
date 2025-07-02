---
title: TAN
description: The `TAN` function returns the trigonometric tangent of the specified angle in radians.
ms.date: 07/02/2025
---

# `TAN` (NoSQL query)

The `TAN` function returns the trigonometric tangent of the specified angle in radians.

An Azure Cosmos DB for NoSQL system function that returns the trigonometric tangent of the specified angle.

## Syntax

```nosql
TAN(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Calculate tangent of angles

In this example, the `TAN` function is used to calculate the tangent of various angles.

```nosql
SELECT VALUE {
  tangentSquareRootPi: TAN(PI()/2),
  tangentArbitraryNumber: TAN(124.1332)
}
```

```json
[
  {
    "tangentSquareRootPi": 16331239353195370,
    "tangentArbitraryNumber": -24.80651023035602
  }
]
```

## Remarks

- This function doesn't utilize the index.
