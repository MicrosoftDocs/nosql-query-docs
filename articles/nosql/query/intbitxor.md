---
title: INTBITXOR
description: The `INTBITXOR` function returns the result of a bitwise exclusive OR operation on two integer values.
ms.date: 07/02/2025
---

# `INTBITXOR` (NoSQL query)

The `INTBITXOR` function returns the result of a bitwise exclusive OR operation on two integer values.

## Syntax

```nosql
INTBITXOR(<numeric_expr_1>, <numeric_expr_2>)
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

### Bitwise exclusive OR

In this example, the `INTBITXOR` function is used to perform a bitwise exclusive OR operation.

```nosql
SELECT VALUE {
  exclusiveOr: INTBITXOR(56, 100),
  exclusiveOrSame: INTBITXOR(56, 56),
  exclusiveOrZero: INTBITXOR(56, 0),
  exclusiveOrDecimal: INTBITXOR(56, 0.1)
}
```

```json
[
  {
    "exclusiveOr": 92,
    "exclusiveOrSame": 0,
    "exclusiveOrZero": 56
  }
]
```
