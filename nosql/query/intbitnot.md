---
title: INTBITNOT
description: The `INTBITNOT` function returns the result of a bitwise NOT operation on an integer value.
ms.date: 07/02/2025
---

# `INTBITNOT` (NoSQL query)

The `INTBITNOT` function returns the result of a bitwise NOT operation on an integer value.

## Syntax

```nosql
INTBITNOT(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | The numeric expression to complement. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Bitwise NOT

In this example, the `INTBITNOT` function is used to perform a bitwise NOT operation.

```nosql
SELECT VALUE {
  complementNumber: INTBITNOT(65),
  complementZero: INTBITNOT(0),
  complementDecimal: INTBITNOT(0.1)
}
```

```json
[
  {
    "complementNumber": -66,
    "complementZero": -1
  }
]
```
