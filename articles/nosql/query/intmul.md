---
title: INTMUL
description: The `INTMUL` function returns the product of two integer values.
ms.date: 07/01/2025
---

# `INTMUL` (NoSQL query)

The `INTMUL` function returns the product of two integer values.

## Syntax

```nosql
INTMUL(<numeric_expr_1>, <numeric_expr_2>)
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

### Multiply integer values

In this example, the `INTMUL` function is used to multiply two numbers.

```nosql
SELECT VALUE {
  multiply: INTMUL(5, 2),
  negativeResult: INTMUL(5, -2),
  positiveResult: INTMUL(-5, -2),
  square: INTMUL(5, 5),
  cube: INTMUL(5, INTMUL(5, 5)),
  multiplyZero: INTMUL(5, 0),
  multiplyDecimal: INTMUL(5, 0.5)
}
```

```json
[
  {
    "multiply": 10,
    "negativeResult": -10,
    "positiveResult": 10,
    "square": 25,
    "cube": 125,
    "multiplyZero": 0
  }
]
```
