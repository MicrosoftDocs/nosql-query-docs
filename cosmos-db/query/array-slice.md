---
title: ARRAY_SLICE
description: The `ARRAY_SLICE` function returns a subset of an array expression using the index and length specified.
ms.date: 11/10/2025
---

# `ARRAY_SLICE` (NoSQL query)

The `ARRAY_SLICE` function returns a subset of an array expression using the index and length specified.

## Syntax

```nosql
ARRAY_SLICE(<array_expr>, <numeric_expr_1> [, <numeric_expr_2>])
```

## Arguments

| | Description |
| --- | --- |
| **`array_expr`** | An array expression. |
| **`numeric_expr_1`** | A numeric expression indicating the index where to begin the array for the subset. Optionally, negative values can be used to specify the starting index relative to the last element of the array. |
| **`numeric_expr_2`** | An optional numeric expression indicating the maximum length of elements in the resulting array. |

## Return types

Returns an array expression.

## Examples

This section contains examples of how to use this query language construct.

### Array slice examples

In this example, the `ARRAY_SLICE` function is used to get subsets of an array.

```nosql
SELECT VALUE {
  sliceFromStart: ARRAY_SLICE(["Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Golf"], 0),
  sliceFromSecond: ARRAY_SLICE(["Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Golf"], 1),
  sliceFromLast: ARRAY_SLICE(["Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Golf"], -1),
  sliceFromSecondToLast: ARRAY_SLICE(["Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Golf"], -2),
  sliceThreeFromStart: ARRAY_SLICE(["Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Golf"], 0, 3),
  sliceTwelveFromStart: ARRAY_SLICE(["Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Golf"], 0, 12),
  sliceFiveFromThird: ARRAY_SLICE(["Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Golf"], 3, 5),
  sliceOneFromSecondToLast: ARRAY_SLICE(["Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Golf"], -2, 1)
}
```

```json
[
  {
    "sliceFromStart": [
      "Alpha",
      "Bravo",
      "Charlie",
      "Delta",
      "Echo",
      "Foxtrot",
      "Golf"
    ],
    "sliceFromSecond": [
      "Bravo",
      "Charlie",
      "Delta",
      "Echo",
      "Foxtrot",
      "Golf"
    ],
    "sliceFromLast": [
      "Golf"
    ],
    "sliceFromSecondToLast": [
      "Foxtrot",
      "Golf"
    ],
    "sliceThreeFromStart": [
      "Alpha",
      "Bravo",
      "Charlie"
    ],
    "sliceTwelveFromStart": [
      "Alpha",
      "Bravo",
      "Charlie",
      "Delta",
      "Echo",
      "Foxtrot",
      "Golf"
    ],
    "sliceFiveFromThird": [
      "Delta",
      "Echo",
      "Foxtrot",
      "Golf"
    ],
    "sliceOneFromSecondToLast": [
      "Foxtrot"
    ]
  }
]
```

## Remarks

- This function doesn't utilize the index.
