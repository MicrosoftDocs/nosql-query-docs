---
title: INTBITOR
description: The `INTBITOR` function returns the result of a bitwise inclusive OR operation on two integer values.
ms.date: 11/10/2025
---

# `INTBITOR` - Query language in Cosmos DB (in Azure and Fabric)

The `INTBITOR` function returns the result of a bitwise inclusive OR operation on two integer values.

## Syntax

```cosmos-db
INTBITOR(<numeric_expr_1>, <numeric_expr_2>)
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

### Bitwise inclusive OR

In this example, the `INTBITOR` function is used to perform a bitwise inclusive OR operation.

```cosmos-db
SELECT VALUE {
  inclusiveOr: INTBITOR(56, 100),
  inclusiveOrSame: INTBITOR(56, 56),
  inclusiveOrZero: INTBITOR(56, 0),
  inclusiveOrDecimal: INTBITOR(56, 0.1)
}
```

```json
[
  {
    "inclusiveOr": 124,
    "inclusiveOrSame": 56,
    "inclusiveOrZero": 56
  }
]
```
