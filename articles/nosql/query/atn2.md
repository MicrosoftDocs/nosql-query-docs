---
title: ATN2
description: The `ATN2` function calculates the principal value of the arctangent of `y/x`, expressed in radians.
ms.date: 07/02/2025
---

# `ATN2` (NoSQL query)

The `ATN2` function calculates the principal value of the arctangent of `y/x`, expressed in radians.

## Syntax

```nosql
ATN2(<numeric_expr_y>, <numeric_expr_x>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr_y`** | A numeric expression for the `y` component. |
| **`numeric_expr_x`** | A numeric expression for the `x` component. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Arctangent for y/x

In this example, the `ATN2` function is used to calculate the arctangent for the specified `x` and `y` components.

```nosql
SELECT VALUE {
  arctangentInRadians: ATN2(35.175643, 129.44)
}
```

```json
[
  {
    "arctangentInRadians": 0.265344532064832
  }
]
```

## Remarks

- This function doesn't utilize the index.
