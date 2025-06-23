---
title: ARRAY_CONCAT
description: The `ARRAY_CONCAT` function returns an array that is the result of concatenating two or more array values.
ms.date: 06/23/2025
---

# `ARRAY_CONCAT` (NoSQL query)

The `ARRAY_CONCAT` function returns an array that is the result of concatenating two or more array values.

## Syntax

```nosql
ARRAY_CONCAT(<array_expr_1>, <array_expr_2> [, <array_expr_N>])
```

## Return types

Returns an array expression.

## Examples

This section contains examples of how to use this query language construct.

### Concatenate two arrays

In this example, the `ARRAY_CONCAT` function concatenates two arrays.

```nosql
SELECT ARRAY_CONCAT(["apples", "strawberries"], ["bananas"]) AS arrayConcat
```

```json
[
  {
    "arrayConcat": [
      "apples",
      "strawberries",
      "bananas"
    ]
  }
]
```

## Remarks

- This function doesn&#39;t utilize the index.

## Related content

- [NoSQL query reference](index.md)
