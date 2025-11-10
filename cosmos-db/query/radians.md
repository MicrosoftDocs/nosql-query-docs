---
title: RADIANS
description: The `RADIANS` function returns the corresponding angle in radians for an angle specified in degrees.
ms.date: 11/10/2025
---

# `RADIANS` - Query language in Cosmos DB (in Azure and Fabric)

The `RADIANS` function returns the corresponding angle in radians for an angle specified in degrees.

## Syntax

```nosql
RADIANS(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Convert degrees to radians

In this example, the `RADIANS` function is used to convert degree values to radians.

```nosql
SELECT VALUE {
  degrees90ToRadians: RADIANS(90),
  degrees180ToRadians: RADIANS(180),
  degrees270ToRadians: RADIANS(270),
  degrees360ToRadians: RADIANS(360)
}
```

```json
[
  {
    "degrees90ToRadians": 1.5707963267948966,
    "degrees180ToRadians": 3.141592653589793,
    "degrees270ToRadians": 4.71238898038469,
    "degrees360ToRadians": 6.283185307179586
  }
]
```
