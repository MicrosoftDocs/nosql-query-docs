---
title: POWER
description: The `POWER` function returns the value of the specified expression multipled by itself the given number of times.
ms.date: 11/10/2025
---

# `POWER` - Query language in Cosmos DB (in Azure and Fabric)

The `POWER` function returns the value of the specified expression multipled by itself the given number of times.

## Syntax

```cosmos-db
POWER(<numeric_expr_1>, <numeric_expr_2>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr_1`** | A numeric expression. |
| **`numeric_expr_2`** | A numeric expression indicating the power to raise `numeric_expr_1`. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Raise a number to a power

In this example, the `POWER` function is used to raise numbers to various powers.

```cosmos-db
SELECT VALUE {
  oneFirstPower: POWER(1, 1),
  twoSquared: POWER(2, 2),
  threeCubed: POWER(3, 3),
  fourFourthPower: POWER(4, 4),
  fiveFithPower: POWER(5, 5),
  zeroSquared: POWER(0, 2),
  nullCubed: POWER(null, 3),
  twoNullPower: POWER(2, null)
}
```

```json
[
  {
    "oneFirstPower": 1,
    "twoSquared": 4,
    "threeCubed": 27,
    "fourFourthPower": 256,
    "fiveFithPower": 3125,
    "zeroSquared": 0
  }
]
```
