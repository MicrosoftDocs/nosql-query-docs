---
title: AVG
description: The `AVG` function calculates the average of the values in the expression.
ms.date: 11/10/2025
---

# `AVG` - Query language in Cosmos DB (in Azure and Fabric)

The `AVG` function calculates the average of the values in the expression.

## Syntax

```nosql
AVG(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression to calculate the average from. |

## Return types

Returns a numeric scalar value.

## Examples

This section contains examples of how to use this query language construct.

Consider this sample set of documents within the `Products` collection for these examples.

```json
[
  {
    "name": "Diannis Watch",
    "price": 98,
    "detailCategory": "apparel-accessories-watches"
  },
  {
    "name": "Confira Watch",
    "price": 105,
    "detailCategory": "apparel-accessories-watches"
  }
]
```

### Average value for a single property

In this example, the `AVG` function is used to average the values of the `price` property into a single aggregated value.

```nosql
SELECT
  AVG(p.price) AS averagePrice
FROM
  products p
WHERE
  p.detailCategory = "apparel-accessories-watches"
```

```json
[
  {
    "averagePrice": 101.5
  }
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
- If any arguments in `AVG` are string, boolean, or null; the entire aggregation system function returns `undefined`.
- If any argument has an `undefined` value, that specific value isn't included in the `AVG` calculation.
