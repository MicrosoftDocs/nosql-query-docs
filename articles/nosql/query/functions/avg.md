---
title: AVG
description: The `AVG` function calculates the average of the values in the expression.
ms.date: 06/23/2025
---

# `AVG` (NoSQL query)

The `AVG` function calculates the average of the values in the expression.

## Syntax

```nosql
AVG(<numeric_expr>)
```

## Return types

Returns a numeric scalar value.

## Examples

This section contains examples of how to use this query language construct.

Consider this sample set of documents within the `Products` collection for these examples.

```json
[
  {
    "name": "Diannis Watch",
    "price": 98.0,
    "category": "apparel"
  },
  {
    "name": "Confira Watch",
    "price": 105.0,
    "category": "apparel"
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
- If any argument has an `undefined` value, that specific value isn&#39;t included in the `AVG` calculation.

## Related content

- [NoSQL query reference](index.md)
