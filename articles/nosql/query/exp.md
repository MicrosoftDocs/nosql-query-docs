---
title: EXP
description: The `EXP` function calculates the exponential value of the specified numeric expression.
ms.date: 06/27/2025
---

# `EXP` (NoSQL query)

The `EXP` function calculates the exponential value of the specified numeric expression.

## Syntax

```nosql
EXP(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Exponential values

In this example, the `EXP` function is used to calculate e raised to various powers.

```nosql
SELECT VALUE {
  expontentialZero: EXP(0),
  exponentialTen: EXP(10),
  exponentialTwenty: EXP(20)
}
```

```json
[
  {
    "expontentialZero": 1,
    "exponentialTen": 22026.465794806718,
    "exponentialTwenty": 485165195.4097903
  }
]
```

## Remarks

- The constant `e` (`2.718281…`), is the base of natural logarithms.
- The exponent of a number is the constant `e` raised to the power of the number. For example, `EXP(1.0) = e^1.0 = 2.71828182845905` and `EXP(10) = e^10 = 22026.4657948067`.
- The exponential of the natural logarithm of a number is the number itself `EXP (LOG (n)) = n`. And the natural logarithm of the exponential of a number is the number itself `LOG (EXP (n)) = n`.
