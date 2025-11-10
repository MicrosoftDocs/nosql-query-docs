---
title: INTSUB
description: The `INTSUB` function returns the result of subtracting the second integer value from the first.
ms.date: 11/10/2025
---

# `INTSUB` - Query language in Cosmos DB (in Azure and Fabric)

The `INTSUB` function returns the result of subtracting the second integer value from the first.

## Syntax

```nosql
INTSUB(<numeric_expr_1>, <numeric_expr_2>)
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

### Subtract integer values

In this example, the `INTSUB` function is used to subtract two numbers.

```nosql
SELECT VALUE {
  negativeResult: INTSUB(25, 50),
  positiveResult: INTSUB(25, 15),
  subtractSameNumber: INTSUB(25, 25),
  subtractZero: INTSUB(25, 0),
  subtractDecimal: INTSUB(25, 2.5)
}
```

```json
[
  {
    "negativeResult": -25,
    "positiveResult": 10,
    "subtractSameNumber": 0,
    "subtractZero": 25
  }
]
```
