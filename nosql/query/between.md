---
title: BETWEEN
description: The `BETWEEN` keyword evaluates to a boolean indicating whether the target value is between two specified values, inclusive.
ms.date: 07/02/2025
---

# `BETWEEN` (NoSQL query)

The `BETWEEN` keyword evaluates to a boolean indicating whether the target value is between two specified values, inclusive.

You can use the BETWEEN keyword with a WHERE clause to express queries that filters results against ranges of string or numerical values.

## Syntax

```nosql
<numeric_expr> BETWEEN <numeric_expr_lower_bound> AND <numeric_expr_upper_bound>
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression to evaluate. |
| **`numeric_expr_lower_bound`** | A numeric expression that defines the inclusive lower bound of the range. |
| **`numeric_expr_upper_bound`** | A numeric expression that defines the inclusive upper bound of the range. |

## Return types

Returns a boolean value.

## Examples

This section contains examples of how to use this query language construct.

Consider this sample set of documents within the `Products` collection for these examples.

```json
[
  {
    "name": "Minet Hat",
    "price": 50,
    "detailCategory": "apparel-accessories-beanies"
  },
  {
    "name": "Klinto Hat",
    "price": 65,
    "detailCategory": "apparel-accessories-beanies"
  },
  {
    "name": "Benki Hat",
    "price": 25,
    "detailCategory": "apparel-accessories-beanies"
  },
  {
    "name": "Jontra Hat",
    "price": 40,
    "detailCategory": "apparel-accessories-beanies"
  }
]
```

### Filter within a range of values

In this example, the `BETWEEN` keyword is used to filter products within a specific price range. The range is inclusive of the lower and upper bounds.

```nosql
SELECT VALUE
  p.name
FROM
  products p
WHERE
  (p.price BETWEEN 0 AND 40) AND
  p.detailCategory = "apparel-accessories-beanies"
```

```json
[
  "Benki Hat",
  "Jontra Hat"
]
```

### Evaluate price range for each product

In this example, the `BETWEEN` keyword is used to evaluate whether each product's price falls within a specific range by using the keyword in the `SELECT` clause. The result includes the product name and a boolean indicating if the price is within the range.

```nosql
SELECT
  p.name,
  (p.price BETWEEN 10 AND 20) AS lowPrice
FROM
  products p
WHERE
  p.detailCategory = "apparel-accessories-beanies"
```

```json
[
  {
    "name": "Minet Hat",
    "lowPrice": false
  },
  {
    "name": "Klinto Hat",
    "lowPrice": false
  },
  {
    "name": "Benki Hat",
    "lowPrice": false
  },
  {
    "name": "Jontra Hat",
    "lowPrice": false
  }
]
```
