---
title: CONCAT
description: The `CONCAT` function returns a string that is the result of concatenating multiple fields from a document.
ms.date: 11/10/2025
---

# `CONCAT` - Query language in Cosmos DB (in Azure and Fabric)

The `CONCAT` function returns a string that is the result of concatenating multiple fields from a document.

## Syntax

```nosql
CONCAT(<string_expr_1>, <string_expr_2> [, <string_expr_N>])
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr_1`** | The first string expression in the list. |
| **`string_expr_2`** | The second string expression in the list. |
| **`string_expr_N`** | Optional string expression(s), which can contain a variable number of expressions up to the Nth item in the list. |

## Return types

Returns a string expression.

## Examples

This section contains examples of how to use this query language construct.

Consider this sample set of documents within the `Products` collection for these examples.

```json
[
  {
    "name": "Stilld rope",
    "category": "gear",
    "sku": "66403",
    "detailCategory": "gear-climb-ropes"
  },
  {
    "name": "Orangas rope",
    "category": "gear",
    "sku": "66404",
    "detailCategory": "gear-climb-ropes"
  },
  {
    "name": "Vonel Rope",
    "category": "gear",
    "sku": "66400",
    "detailCategory": "gear-climb-ropes"
  },
  {
    "name": "Ferpal Ropes",
    "category": "gear",
    "sku": "66401",
    "detailCategory": "gear-climb-ropes"
  },
  {
    "name": "Cotings rope",
    "category": "gear",
    "sku": "66402",
    "detailCategory": "gear-climb-ropes"
  }
]
```

### Concatenate strings

In this example, the `CONCAT` function is used to concatenate two arbitrary strings.

```nosql
SELECT VALUE
  CONCAT("Ferpal", "Ropes")
```

```json
[
  "FerpalRopes"
]
```

### Concatenate product fields

In this example, the `CONCAT` function is used to concatenate fields from a product in the "heavy-coats" category.

```nosql
SELECT VALUE
  CONCAT(p.sku, "-", p.detailCategory)
FROM
  products p
WHERE
  p.detailCategory = "gear-climb-ropes"
```

```json
[
  "66403-gear-climb-ropes",
  "66404-gear-climb-ropes",
  "66400-gear-climb-ropes",
  "66401-gear-climb-ropes",
  "66402-gear-climb-ropes"
]
```

## Remarks

- This function doesn't utilize the index.
