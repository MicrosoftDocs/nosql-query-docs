---
title: MIN
description: The `MIN` function returns the minimum value of the specified expression.
ms.date: 11/10/2025
---

# `MIN` - Query language in Cosmos DB (in Azure and Fabric)

The `MIN` function returns the minimum value of the specified expression.

## Syntax

```cosmos-db
MIN(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric scalar value.

## Examples

This section contains examples of how to use this query language construct.

### Minimum value for a property

In this example, the `MIN` function is used to return the minimum value of the `price` property.

```cosmos-db
SELECT
  MIN(p.price) AS minPrice
FROM 
  products p
WHERE
  p.category = "fashion-bracelet"
```

```json
[
  {
    "minPrice": 27.6
  }
]
```
