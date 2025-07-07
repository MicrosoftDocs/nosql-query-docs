---
title: ARRAY_CONTAINS
description: The `ARRAY_CONTAINS` function returns a boolean indicating whether the array contains the specified value. You can check for a partial or full match of an object by using a boolean expression within the function.
ms.date: 07/02/2025
---

# `ARRAY_CONTAINS` (NoSQL query)

The `ARRAY_CONTAINS` function returns a boolean indicating whether the array contains the specified value. You can check for a partial or full match of an object by using a boolean expression within the function.

## Syntax

```nosql
ARRAY_CONTAINS(<array_expr>, <expr> [, <bool_expr>])
```

## Arguments

| | Description |
| --- | --- |
| **`array_expr`** | An array expression. |
| **`expr`** | Expression to search for within the array. |
| **`bool_expr`** | A boolean expression indicating whether the search should check for a partial match (`true`) or a full match (`false`). If not specified, the default value is `false`. |

## Return types

Returns a boolean value.

## Examples

This section contains examples of how to use this query language construct.

### Array contains examples

In this example, the `ARRAY_CONTAINS` function is used to check for the presence of values and objects in arrays.

```nosql
SELECT VALUE {
  containsItem: ARRAY_CONTAINS(["coats", "jackets", "sweatshirts"], "coats"),
  missingItem: ARRAY_CONTAINS(["coats", "jackets", "sweatshirts"], "hoodies"),
  containsFullMatchObject: ARRAY_CONTAINS([{ category: "shirts", color: "blue" }], { category: "shirts", color: "blue" }),
  missingFullMatchObject: ARRAY_CONTAINS([{ category: "shirts", color: "blue" }], { category: "shirts" }),
  containsPartialMatchObject: ARRAY_CONTAINS([{ category: "shirts", color: "blue" }], { category: "shirts" }, true),
  missingPartialMatchObject: ARRAY_CONTAINS([{ category: "shirts", color: "blue" }], { category: "shorts", color: "blue" }, true)
}
```

```json
[
  {
    "containsItem": true,
    "missingItem": false,
    "containsFullMatchObject": true,
    "missingFullMatchObject": false,
    "containsPartialMatchObject": true,
    "missingPartialMatchObject": false
  }
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
