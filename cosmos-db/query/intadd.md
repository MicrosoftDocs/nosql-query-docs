---
title: INTADD
description: The `INTADD` function returns the sum of two integer values.
ms.date: 11/10/2025
---

# `INTADD` - Query language in Cosmos DB (in Azure and Fabric)

The `INTADD` function returns the sum of two integer values.

## Syntax

```nosql
INTADD(<numeric_expr_1>, <numeric_expr_2>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr_1`** | The first numeric expression. |
| **`numeric_expr_2`** | The second numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Add integer values

In this example, the `INTADD` function is used to add two numbers.

```nosql
SELECT VALUE {
  addNumber: INTADD(20, 10),
  addZero: INTADD(20, 0),
  addDecimal: INTADD(20, 0.10)
}
```

```json
[
  {
    "addNumber": 30,
    "addZero": 20
  }
]
```
