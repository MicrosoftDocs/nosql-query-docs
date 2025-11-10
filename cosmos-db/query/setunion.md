---
title: SETUNION
description: The `SETUNION` function returns a set of expressions containing all expressions from two gathered sets with no duplicates.
ms.date: 11/10/2025
---

# `SETUNION` (NoSQL query)

The `SETUNION` function returns a set of expressions containing all expressions from two gathered sets with no duplicates.

## Syntax

```nosql
SetUnion(<array_expr_1>, <array_expr_2>)
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

### Union of static arrays

In this example, the `SetUnion` function is used with static arrays to demonstrate the union functionality.

```nosql
SELECT VALUE {
  simpleUnion: SetUnion([1, 2, 3, 4], [3, 4, 5, 6]),
  emptyUnion: SetUnion([1, 2, 3, 4], []),
  duplicatesUnion: SetUnion([1, 2, 3, 4], [1, 1, 1, 1]),
  unorderedUnion: SetUnion([1, 2, "A", "B"], ["A", 1])
}
```

```json
[
  {
    "simpleUnion": [1, 2, 3, 4, 5, 6],
    "emptyUnion": [1,2,3,4],
    "duplicatesUnion": [1,2,3,4],
    "unorderedUnion": [1,2,"A","B"]
  }
]
```

### Union of array properties in documents

In this example, the function returns the union of two array properties as a new property.

```nosql
SELECT
  p.name,
  SetUnion(p.colors[0].values, p.colors[1].values) AS allColors
FROM
  products p
WHERE
  p.category = "seasonal-coats"
```

```json
[
  {
    "name": "Malsca coat",
    "allColors": [
      "Cutty Sark",
      "Horizon",
      "Russet",
      "Fuscous",
      "Tacha"
    ]
  }
]
```

## Remarks

- This function doesn't utilize the index.
- This function doesn't return duplicates.
