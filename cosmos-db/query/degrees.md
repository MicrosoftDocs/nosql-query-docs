---
title: DEGREES
description: The `DEGREES` function calculates the corresponding angle in degrees for an angle specified in radians.
ms.date: 11/10/2025
---

# `DEGREES` - Query language in Cosmos DB (in Azure and Fabric)

The `DEGREES` function calculates the corresponding angle in degrees for an angle specified in radians.

## Syntax

```nosql
DEGREES(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Convert radians to degrees

In this example, the `DEGREES` function is used to convert various radian values to degrees.

```nosql
SELECT VALUE {
  radiansHalfPiToDegrees: DEGREES(1.5707963267948966),
  radiansPiToDegrees: DEGREES(3.141592653589793),
  radiansOneAndHalfPiToDegrees: DEGREES(4.71238898038469),
  radiansDoublePiToDegrees: DEGREES(6.283185307179586)
}
```

```json
[
  {
    "radiansHalfPiToDegrees": 90,
    "radiansPiToDegrees": 180,
    "radiansOneAndHalfPiToDegrees": 270,
    "radiansDoublePiToDegrees": 360
  }
]
```

## Remarks

- STATIC-NOTIFY-NO-INDEX-USAGE
