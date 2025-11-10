---
title: INTMOD
description: The `INTMOD` function returns the remainder of dividing the first integer value by the second.
ms.date: 11/10/2025
---

# `INTMOD` - Query language in Cosmos DB (in Azure and Fabric)

The `INTMOD` function returns the remainder of dividing the first integer value by the second.

## Syntax

```nosql
INTMOD(<numeric_expr_1>, <numeric_expr_2>)
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

### Modulo of integer values

In this example, the `INTMOD` function is used to return the remainder of two numbers.

```nosql
SELECT VALUE {
  mod: INTMOD(12, 5),
  positiveResult: INTMOD(12, -5),
  negativeResult: INTMOD(-12, -5),
  resultZero: INTMOD(15, 5),
  modZero: INTMOD(12, 0),
  modDecimal: INTMOD(12, 0.2)
}
```

```json
[
  {
    "mod": 2,
    "positiveResult": 2,
    "negativeResult": -2,
    "resultZero": 0
  }
]
```
