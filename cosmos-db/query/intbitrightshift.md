---
title: INTBITRIGHTSHIFT
description: The `INTBITRIGHTSHIFT` function returns the result of a bitwise right shift operation on an integer value.
ms.date: 11/10/2025
---

# `INTBITRIGHTSHIFT` - Query language in Cosmos DB (in Azure and Fabric)

The `INTBITRIGHTSHIFT` function returns the result of a bitwise right shift operation on an integer value.

## Syntax

```cosmos-db
INTBITRIGHTSHIFT(<numeric_expr_1>, <numeric_expr_2>)
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

### Bitwise right shift

In this example, the `INTBITRIGHTSHIFT` function is used to perform a bitwise right shift operation.

```cosmos-db
SELECT VALUE {
  shiftInteger: INTBITRIGHTSHIFT(16, 4),
  shiftDecimal: INTBITRIGHTSHIFT(16, 0.4)
}
```

```json
[
  {
    "shiftInteger": 1
  }
]
```
