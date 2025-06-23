---
title: FLOOR
description: The `FLOOR` function returns the largest integer less than or equal to the specified numeric expression.
ms.date: 06/23/2025
---

# `FLOOR` (NoSQL query)

The `FLOOR` function returns the largest integer less than or equal to the specified numeric expression.

## Syntax

```nosql
FLOOR(<numeric_expr>)
```

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Floor of various numbers

In this example, the `FLOOR` function is used on positive, negative, and zero values.

```nosql
SELECT VALUE {
    floorPostiveNumber: FLOOR(62.6),
    floorNegativeNumber: FLOOR(-145.12),
    floorSmallNumber: FLOOR(0.2989),
    floorZero: FLOOR(0.0),
    floorNull: FLOOR(null)
}
```

```json
[
  {
    "floorPostiveNumber": 62,
    "floorNegativeNumber": -146,
    "floorSmallNumber": 0,
    "floorZero": 0
  }
]
```

## Remarks

- This system function benefits from a range index.

## Related content

- [NoSQL query reference](index.md)
- [`AVG`](avg.md)
