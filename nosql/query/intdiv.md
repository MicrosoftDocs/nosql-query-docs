---
title: INTDIV
description: The `INTDIV` function returns the result of dividing the first integer value by the second.
ms.date: 07/02/2025
---

# `INTDIV` (NoSQL query)

The `INTDIV` function returns the result of dividing the first integer value by the second.

## Syntax

```nosql
INTDIV(<numeric_expr_1>, <numeric_expr_2>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr_1`** | The numerator numeric expression. |
| **`numeric_expr_2`** | The denominator numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Divide integer values

In this example, the `INTDIV` function is used to divide two numbers.

```nosql
SELECT VALUE {
  divide: INTDIV(10, 2),
  negativeResult: INTDIV(10, -2),
  positiveResult: INTDIV(-10, -2),
  resultOne: INTDIV(10, 10),
  divideZero: INTDIV(10, 0),
  divideDecimal: INTDIV(10, 0.1)
}
```

```json
[
  {
    "divide": 5,
    "negativeResult": -5,
    "positiveResult": 5,
    "resultOne": 1
  }
]
```
