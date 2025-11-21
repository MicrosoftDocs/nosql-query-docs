---
title: ROUND
description: The `ROUND` function returns a numeric value rounded to the closest integer value.
ms.date: 11/10/2025
---

# `ROUND` - Query language in Cosmos DB (in Azure and Fabric)

The `ROUND` function returns a numeric value rounded to the closest integer value.

An Azure Cosmos DB for NoSQL system function that returns the number rounded to the closest integer.

## Syntax

```cosmos-db
ROUND(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Round numbers to nearest integer

In this example, positive and negative numbers are rounded to the nearest integer.

```cosmos-db
SELECT VALUE {
  roundTwoPointFour: ROUND(2.4),
  roundTwoPointSix: ROUND(2.6),
  roundTwoPointFive: ROUND(2.5),
  roundNegativeTwoPointFour: ROUND(-2.4),
  roundNegativeTwoPointSix: ROUND(-2.6)
}
```

```json
[
  {
    "roundTwoPointFour": 2,
    "roundTwoPointSix": 3,
    "roundTwoPointFive": 3,
    "roundNegativeTwoPointFour": -2,
    "roundNegativeTwoPointSix": -3
  }
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
- The rounding operation performed follows midpoint rounding away from zero. If the input is a numeric expression which falls exactly between two integers, the result is the closest integer value away from 0. For example `-6.5 to -7, -0.5 to -1, 0.5 to 1, 6.5 to 7`.
