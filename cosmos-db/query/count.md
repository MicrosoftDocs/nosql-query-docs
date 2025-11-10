---
title: COUNT
description: The `COUNT` function returns the count of the values in the expression.
ms.date: 11/10/2025
---

# `COUNT` - Query language in Cosmos DB (in Azure and Fabric)

The `COUNT` function returns the count of the values in the expression.

## Syntax

```nosql
COUNT(<scalar_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`scalar_expr`** | A scalar expression to count. |

## Return types

Returns a numeric scalar value.

## Examples

This section contains examples of how to use this query language construct.

Consider this sample set of documents within the `Products` collection for these examples.

```json
[
  {
    "name": "Kameni Adult Bike Helmet",
    "detailCategory": "gear-cycle-helmets"
  },
  {
    "name": "Rockmak Full Face Helmet",
    "detailCategory": "gear-cycle-helmets"
  },
  {
    "name": "Barea Skateboard Helmet",
    "detailCategory": "gear-cycle-helmets"
  },
  {
    "name": "Cranix Full Face Helmet",
    "detailCategory": "gear-cycle-helmets"
  },
  {
    "name": "Furano Adult Bike Helmet",
    "detailCategory": "gear-cycle-helmets"
  },
  {
    "name": "Prigla Adult Bike Helmet",
    "detailCategory": "gear-cycle-helmets"
  },
  {
    "name": "Menitos Skateboard Helmet",
    "detailCategory": "gear-cycle-helmets"
  },
  {
    "name": "Knimer Adult Bike Helmet",
    "detailCategory": "gear-cycle-helmets"
  },
  {
    "name": "Cranix Bike Helmet",
    "detailCategory": "gear-cycle-helmets"
  },
  {
    "name": "Jeropa Adult Bike Helmet",
    "detailCategory": "gear-cycle-helmets"
  }
]
```

### Count using a scalar value and an expression

In this example, COUNT is used with a scalar and an expression. Both return `1`.

```nosql
SELECT VALUE {
  countScalar: COUNT(1),
  countExpression: COUNT(2 + 3)
}
```

```json
[
  {
    "countScalar": 1,
    "countExpression": 1
  }
]
```

### Count occurrences of a field

In this example, the function counts the number of times the `name` field occurs in filtered data.

```nosql
SELECT VALUE
  COUNT(p.name)
FROM
  products p
WHERE
  p.detailCategory = "gear-cycle-helmets"
```

```json
[
  10
]
```

### Count all items

In this example, the function is used to count every item within a container that matches the filter.

```nosql
SELECT VALUE
  COUNT(1)
FROM
  products p
WHERE
  p.detailCategory = "gear-cycle-helmets"
```

```json
[
  10
]
```

## Remarks

- This function benefits from the use of a range index for any properties in the query's filter. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
