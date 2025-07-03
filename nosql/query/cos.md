---
title: COS
description: The `COS` function calculates the trigonometric cosine of the specified angle in radians.
ms.date: 07/02/2025
---

# `COS` (NoSQL query)

The `COS` function calculates the trigonometric cosine of the specified angle in radians.

## Syntax

```nosql
COS(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Cosine of a value

In this example, the `COS` function is used to calculate the cosine of 14.78 radians.

```nosql
SELECT VALUE {
  cosine: COS(14.78)
}
```

```json
[
  {
    "cosine": -0.5994654261946543
  }
]
```

## Remarks

- This function doesn't utilize the index.
