---
title: CEILING
description: The `CEILING` function calculates the smallest integer value greater than or equal to the specified numeric expression.
ms.date: 11/10/2025
---

# `CEILING` (NoSQL query)

The `CEILING` function calculates the smallest integer value greater than or equal to the specified numeric expression.

## Syntax

```nosql
CEILING(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Ceiling of numbers

In this example, the `CEILING` function is used on positive, negative, and zero values.

```nosql
SELECT VALUE {
  ceilingPositiveInteger: CEILING(123.45), 
  ceilingNegativeInteger: CEILING(-45.72),
  ceilingZero: CEILING(0)
}
```

```json
[
  {
    "ceilingPositiveInteger": 124,
    "ceilingNegativeInteger": -45,
    "ceilingZero": 0
  }
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
