---
title: INTBITLEFTSHIFT
description: The `INTBITLEFTSHIFT` function returns the result of a bitwise left shift operation on an integer value.
ms.date: 07/01/2025
---

# `INTBITLEFTSHIFT` (NoSQL query)

The `INTBITLEFTSHIFT` function returns the result of a bitwise left shift operation on an integer value.

## Syntax

```nosql
INTBITLEFTSHIFT(<numeric_expr_1>, <numeric_expr_2>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr_1`** | The numeric expression to shift. |
| **`numeric_expr_2`** | The number of bits to shift. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Bitwise left shift

In this example, the `INTBITLEFTSHIFT` function is used to perform a bitwise left shift operation.

```nosql
SELECT VALUE {
  shiftInteger: INTBITLEFTSHIFT(16, 4),
  shiftDecimal: INTBITLEFTSHIFT(16, 0.4)
}
```

```json
[
  {
    "shiftInteger": 256
  }
]
```
