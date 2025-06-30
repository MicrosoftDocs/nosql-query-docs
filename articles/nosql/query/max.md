---
title: MAX
description: The `MAX` function returns the maximum value of the specified expression.
ms.date: 06/30/2025
---

# `MAX` (NoSQL query)

The `MAX` function returns the maximum value of the specified expression.

## Syntax

```nosql
MAX(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric scalar value.

## Examples

This section contains examples of how to use this query language construct.

### Maximum value for a property

In this example, the `MAX` function is used to return the maximum value of the `price` property.

```nosql
SELECT
  MAX(p.price) AS maxPrice
FROM 
  products p
WHERE
  p.category = "activity-bracelet"
```

```json
[
  {
    "maxPrice": 71.76
  }
]
```
