---
title: NUMBERBIN
description: The `NUMBERBIN` function calculates the input value rounded to a multiple of the specified size.
ms.date: 11/10/2025
---

# `NUMBERBIN` (NoSQL query)

The `NUMBERBIN` function calculates the input value rounded to a multiple of the specified size.

## Syntax

```nosql
NUMBERBIN(<numeric_expr> [, <bin_size>])
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression, which is evaluated and then the resulting value is rounded to a multiple of the specified bin size. |
| **`bin_size`** | A numeric value that specifies the bin size to use when rounding the value. This numeric value defaults to `1` if not specified. |

## Return types

Returns a numeric value.

## Examples

This section contains examples of how to use this query language construct.

### Bin a number with various bin sizes

In this example, the `NUMBERBIN` function is used to round a number to various bin sizes.

```nosql
SELECT VALUE {
  roundToNegativeHundreds: NUMBERBIN(37.752, -100),
  roundToTens: NUMBERBIN(37.752, 10),
  roundToOnes: NUMBERBIN(37.752, 1),
  roundToZeroes: NUMBERBIN(37.752, 0),
  roundToOneTenths: NUMBERBIN(37.752, 0.1),
  roundToOneHundreds: NUMBERBIN(37.752, 0.01)
}
```

```json
[
  {
    "roundToNegativeHundreds": 100,
    "roundToTens": 30,
    "roundToOnes": 37,
    "roundToOneTenths": 37.7,
    "roundToOneHundreds": 37.75
  }
]
```
