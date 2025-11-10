---
title: SUM
description: The `SUM` function calculates the sum of the values in the expression.
ms.date: 11/10/2025
---

# `SUM` - Query language in Cosmos DB (in Azure and Fabric)

The `SUM` function calculates the sum of the values in the expression.

## Syntax

```nosql
SUM(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression to sum. |

## Return types

Returns a numeric scalar value.

## Examples

This section contains examples of how to use this query language construct.

Consider this sample set of documents within the `Products` collection for these examples.

```json
[
  {
    "name": "Sathem Backpack",
    "quantity": 0,
    "detailCategory": "gear-hike-backpacks"
  },
  {
    "name": "Ventrin Backpack",
    "quantity": 230,
    "detailCategory": "gear-hike-backpacks"
  },
  {
    "name": "Martox Backpack",
    "quantity": 14,
    "detailCategory": "gear-hike-backpacks"
  },
  {
    "name": "Rangeo Backpack",
    "quantity": 232,
    "detailCategory": "gear-hike-backpacks"
  },
  {
    "name": "Moonroq Backpack",
    "quantity": 141,
    "detailCategory": "gear-hike-backpacks"
  }
]
```

### Sum values for a single property

In this example, the `SUM` function is used to sum the values of the `quantity` property into a single aggregated value.

```nosql
SELECT VALUE
  SUM(p.quantity)
FROM
  products p
WHERE
  p.detailCategory = "gear-hike-backpacks"
```

```json
[
  617
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
- If any arguments in `SUM` are string, boolean, or null; the entire aggregate system function returns `undefined`.
- If any individual argument has an `undefined` value, that value isn't included in the `SUM` calculation.
