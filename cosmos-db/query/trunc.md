---
title: TRUNC
description: The `TRUNC` function returns a numeric value truncated to the closest integer value.
ms.date: 11/10/2025
---

# `TRUNC` - Query language in Cosmos DB (in Azure and Fabric)

The `TRUNC` function returns a numeric value truncated to the closest integer value.

An Azure Cosmos DB for NoSQL system function that returns a truncated numeric value.

## Syntax

```cosmos-db
TRUNC(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Truncate numbers to integer

In this example, the `TRUNC` function is used to truncate various numbers to their integer part.

```cosmos-db
SELECT VALUE {
  truncateFloatingPoint: TRUNC(2.37),
  truncateNegative: TRUNC(-2.78),
  truncateInteger: TRUNC(2),
  truncateSmallNumber: TRUNC(0.0000714),
  truncatePi: TRUNC(PI())
}
```

```json
[
  {
    "truncateFloatingPoint": 2,
    "truncateNegative": -2,
    "truncateInteger": 2,
    "truncateSmallNumber": 0,
    "truncatePi": 3
  }
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
