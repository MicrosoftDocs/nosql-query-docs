---
title: ARRAY_CONCAT
description: The `ARRAY_CONCAT` function returns an array that is the result of concatenating two or more array values.
ms.date: 07/02/2025
---

# `ARRAY_CONCAT` (NoSQL query)

The `ARRAY_CONCAT` function returns an array that is the result of concatenating two or more array values.

## Syntax

```nosql
ARRAY_CONCAT(<array_expr_1>, <array_expr_2> [, <array_expr_N>])
```

## Arguments

| | Description |
| --- | --- |
| **`array_expr_1`** | The first array expression in the list. |
| **`array_expr_2`** | The second array expression in the list. |
| **`array_expr_N`** | Optional additional array expressions to concatenate. |

## Return types

Returns an array expression.

## Examples

This section contains examples of how to use this query language construct.

### Concatenate two arrays

In this example, the `ARRAY_CONCAT` function concatenates two arrays.

```nosql
SELECT
  ARRAY_CONCAT([
      "backpacks",
      "daypacks"
    ], [
      "hippacks"
    ]) AS gearList
```

```json
[
  {
    "gearList": [
      "backpacks",
      "daypacks",
      "hippacks"
    ]
  }
]
```

## Remarks

- This function doesn't utilize the index.
