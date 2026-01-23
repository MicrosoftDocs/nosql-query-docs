---
title: SETINTERSECT
description: The `SETINTERSECT` function returns the set of expressions that is contained in both input arrays with no duplicates.
ms.date: 11/10/2025
---

# `SETINTERSECT` - Query language in Cosmos DB (in Azure and Fabric)

The `SETINTERSECT` function returns the set of expressions that is contained in both input arrays with no duplicates.

The `SETINTERSECT` function returns the set of expressions that exist in both input arrays, with no duplicates, in Azure Cosmos DB.

## Syntax

```cosmos-db
SETINTERSECT(<array_expr_1>, <array_expr_2>)
```

## Arguments

| | Description |
| --- | --- |
| **`array_expr_1`** | An array of expressions. |
| **`array_expr_2`** | An array of expressions. |

## Return types

Returns an array of expressions.

## Examples

This section contains examples of how to use this query language construct.

### Intersect static arrays

In this example, the `SETINTERSECT` function is used with static arrays to demonstrate the intersect functionality.

```cosmos-db
SELECT VALUE {
  simpleIntersect: SETINTERSECT([1, 2, 3, 4], [3, 4, 5, 6]),
  emptyIntersect: SETINTERSECT([1, 2, 3, 4], []),
  duplicatesIntersect: SETINTERSECT([1, 2, 3, 4], [1, 1, 1, 1]),
  noMatchesIntersect: SETINTERSECT([1, 2, 3, 4], ["A", "B"]),
  unorderedIntersect: SETINTERSECT([1, 2, "A", "B"], ["A", 1])
}
```

```json
[
  {
    "simpleIntersect": [3, 4],
    "emptyIntersect": [],
    "duplicatesIntersect": [1],
    "noMatchesIntersect": [],
    "unorderedIntersect": ["A", 1]
  }
]
```

### Intersect array fields in documents

In this example, the `SETINTERSECT` function is used to find the intersection of two array fields in a document.

```cosmos-db
SELECT
    p.name,
    SETINTERSECT(p.colors, p.inStockColors) AS availableColors
FROM
    products p
WHERE
    p.category = "modern-vests"
```

```json
[
  {
    "name": "Snowilla vest",
    "availableColors": ["Rhino", "Finch"]
  }
]
```

## Remarks

- This function doesn't return duplicates.
- This function doesn't utilize the index.
- SKIP-VALIDATION
