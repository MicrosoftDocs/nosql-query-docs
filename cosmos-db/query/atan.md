---
title: ATAN
description: The `ATAN` function calculates the trigonometric arctangent of the specified numeric value. The arctangent is the angle, in radians, whose tangent is the specified numeric expression.
ms.date: 11/10/2025
---

# `ATAN` - Query language in Cosmos DB (in Azure and Fabric)

The `ATAN` function calculates the trigonometric arctangent of the specified numeric value. The arctangent is the angle, in radians, whose tangent is the specified numeric expression.

## Syntax

```cosmos-db
ATAN(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Arctangent of a value

In this example, the `ATAN` function is used to calculate the arctangent of -45.01.

```cosmos-db
SELECT VALUE {
  arctangent: ATAN(-45.01)
}
```

```json
[
  {
    "arctangent": -1.5485826962062663
  }
]
```

## Remarks

- This function doesn't utilize the index.
