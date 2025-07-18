---
title: ABS
description: The `ABS` function calculates the absolute (positive) value of the specified numeric expression.
ms.date: 07/02/2025
---

# `ABS` (NoSQL query)

The `ABS` function calculates the absolute (positive) value of the specified numeric expression.

## Syntax

```nosql
ABS(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Absolute value of numbers

In this example, the `ABS` function is used on negative, zero, and positive numbers.

```nosql
SELECT VALUE { 
  absoluteNegativeOne: ABS(-1),
  absoluteZero: ABS(0),
  absoluteOne: ABS(1) 
}
```

```json
[
  {
    "absoluteNegativeOne": 1,
    "absoluteZero": 0,
    "absoluteOne": 1
  }
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
