---
title: INTBITAND
description: The `INTBITAND` function returns a comparison of the bits of each operand using an inclusive AND operator.
ms.date: 11/10/2025
---

# `INTBITAND` - Query language in Cosmos DB (in Azure and Fabric)

The `INTBITAND` function returns a comparison of the bits of each operand using an inclusive AND operator.

## Syntax

```cosmos-db
INTBITAND(<int_expr_1>, <int_expr_2>)
```

## Arguments

| | Description |
| --- | --- |
| **`int_expr_1`** | An integer expression, which is used as the left-hand operand. |
| **`int_expr_2`** | An integer expression, which is used as the right-hand operand. |

## Return types

Returns a 64-bit integer.

## Examples

This section contains examples of how to use this query language construct.

### Bitwise AND operation

In this example, the `INTBITAND` function is used to perform a bitwise AND operation.

```cosmos-db
SELECT VALUE {
  compareNumbers: INTBITAND(15, 25),
  compareZero: INTBITAND(15, 0),
  compareSameNumber: INTBITAND(15, 15),
  compareDecimal: INTBITAND(15, 1.5)
}
```

```json
[
  {
    "compareNumbers": 9,
    "compareZero": 0,
    "compareSameNumber": 15
  }
]
```
