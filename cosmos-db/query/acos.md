---
title: ACOS
description: The `ACOS` function calculates the trigonometric arccosine of the specified numeric value. The arccosine is the angle, in radians, whose cosine is the specified numeric expression.
ms.date: 11/10/2025
---

# `ACOS` - Query language in Cosmos DB (in Azure and Fabric)

The `ACOS` function calculates the trigonometric arccosine of the specified numeric value. The arccosine is the angle, in radians, whose cosine is the specified numeric expression.

## Syntax

```cosmos-db
ACOS(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Arccosine of a value

In this example, the `ACOS` function is used to calculate the arccosine of -1.

```cosmos-db
SELECT VALUE { 
  arccosine: ACOS(-1) 
}
```

```json
[
  {
    "arccosine": 3.141592653589793
  }
]
```

## Remarks

- This function doesn't utilize the index.
