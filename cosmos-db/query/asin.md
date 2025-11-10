---
title: ASIN
description: The `ASIN` function calculates the trigonometric arcsine of the specified numeric value. The arcsine is the angle, in radians, whose sine is the specified numeric expression.
ms.date: 11/10/2025
---

# `ASIN` - Query language in Cosmos DB (in Azure and Fabric)

The `ASIN` function calculates the trigonometric arcsine of the specified numeric value. The arcsine is the angle, in radians, whose sine is the specified numeric expression.

## Syntax

```nosql
ASIN(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Arcsine of a value

In this example, the `ASIN` function is used to calculate the arcsine of -1.

```nosql
SELECT VALUE {
  arcsine: ACOS(-1)
}
```

```json
[
  {
    "arcsine": 3.141592653589793
  }
]
```

## Remarks

- This function doesn't utilize the index.
