---
title: ARRAY_LENGTH
description: The `ARRAY_LENGTH` function returns the number of elements in the specified array expression.
ms.date: 11/10/2025
---

# `ARRAY_LENGTH` (NoSQL query)

The `ARRAY_LENGTH` function returns the number of elements in the specified array expression.

## Syntax

```nosql
ARRAY_LENGTH(<array_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`array_expr`** | An array expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Array length examples

In this example, the `ARRAY_LENGTH` function is used to get the length of various arrays.

```nosql
SELECT VALUE {
  length: ARRAY_LENGTH([70, 86, 92, 99, 85, 90, 82]),
  emptyLength: ARRAY_LENGTH([]),
  nullLength: ARRAY_LENGTH(null)
}
```

```json
[
  {
    "length": 7,
    "emptyLength": 0
  }
]
```

## Remarks

- This function doesn't utilize the index.
