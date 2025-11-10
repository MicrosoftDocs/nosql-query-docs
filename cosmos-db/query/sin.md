---
title: SIN
description: The `SIN` function returns the trigonometric sine of the specified angle in radians.
ms.date: 11/10/2025
---

# `SIN` (NoSQL query)

The `SIN` function returns the trigonometric sine of the specified angle in radians.

An Azure Cosmos DB for NoSQL system function that returns the trigonometric sine of the specified angle.

## Syntax

```nosql
SIN(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Calculate sine of an angle

In this example, the `SIN` function is used to calculate the sine of a specified angle.

```nosql
SELECT VALUE {
  sine: SIN(45.175643)
}
```

```json
[
  {
    "sine": 0.929607286611012
  }
]
```

## Remarks

- This function doesn't utilize the index.
