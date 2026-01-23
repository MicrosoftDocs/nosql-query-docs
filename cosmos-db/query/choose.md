---
title: CHOOSE
description: The `CHOOSE` function returns the expression at the specified index of a list, or undefined if the index exceeds the bounds of the list.
ms.date: 01/23/2026
---

# `CHOOSE` - Query language in Cosmos DB (in Azure and Fabric)

The `CHOOSE` function returns the expression at the specified index of a list, or `undefined` if the index exceeds the bounds of the list.

## Syntax

```cosmos-db
CHOOSE(<numeric_expr>, <expr_1> [, <expr_N>])
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression, which specifies the index used to get a specific expression in the list. The starting index of the list is `1`. |
| **`expr_1`** | The first expression in the list. |
| **`expr_N`** | Optional expression(s), which can contain a variable number of expressions up to the Nth item in the list. |

## Return types

Returns an expression, which could be of any type.

## Examples

This section contains examples of how to use this query language construct.

Consider this sample set of documents within the `Products` collection for these examples.

```json
[
  {
    "name": "Vimero Hydration Pack",
    "category": "gear",
    "sku": "69500",
    "detailCategory": "gear-hike-hydration-packs"
  },
  {
    "name": "Mt. Hood Hydration Pack",
    "category": "gear",
    "sku": "69501",
    "detailCategory": "gear-hike-hydration-packs"
  }
]
```

### Choose from a list

In this example, the `CHOOSE` function is used to select the value at index 1.

```cosmos-db
SELECT VALUE 
  CHOOSE(1, "Vimero", "Hydration", "Pack")
```

```json
[
  "Vimero"
]
```

### Choose by index

In this example, the `CHOOSE` function is used to select values at different indexes.

```cosmos-db
SELECT VALUE {
  index_0: CHOOSE(0, "Mt.", "Hood", "Hydration", "Pack"),
  index_1: CHOOSE(1, "Mt.", "Hood", "Hydration", "Pack"),
  index_2: CHOOSE(2, "Mt.", "Hood", "Hydration", "Pack"),
  index_3: CHOOSE(3, "Mt.", "Hood", "Hydration", "Pack"),
  index_4: CHOOSE(4, "Mt.", "Hood", "Hydration", "Pack"),
  index_5: CHOOSE(5, "Mt.", "Hood", "Hydration", "Pack")
}
```

```json
[
  {
    "index_1": "Mt.",
    "index_2": "Hood",
    "index_3": "Hydration",
    "index_4": "Pack"
  }
]
```

> [!NOTE]
> In this example, `index_0` and `index_5` are omitted from the output because `CHOOSE` returns `undefined` for out-of-range indices, and properties with `undefined` values aren't included in JSON objects.

### Choose field from product

In this example, the `CHOOSE` function is used to select the third field from products in the `gear-hike-hydration-packs` category.

```cosmos-db
SELECT VALUE
  CHOOSE(3, p.category, p.name, p.sku)
FROM
  products p
WHERE
  p.detailCategory = "gear-hike-hydration-packs"
```

```json
[
  "69500",
  "69501"
]
```

## Remarks

- This function doesn't utilize the index.
- This function uses *one-based indexing*, meaning that the first item in the list is at index `1` instead of the typical zero-based indexing found in many programming languages.
- If the index is out of range, the function returns `undefined`. When constructing an object, properties with `undefined` values are omitted from the result.
