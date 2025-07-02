---
title: ST_ISVALID
description: The `ST_ISVALID` function returns a boolean value indicating whether the specified GeoJSON Point, Polygon, MultiPolygon, or LineString expression is valid.
ms.date: 07/02/2025
---

# `ST_ISVALID` (NoSQL query)

The `ST_ISVALID` function returns a boolean value indicating whether the specified GeoJSON Point, Polygon, MultiPolygon, or LineString expression is valid.

The `ST_ISVALID` function returns a boolean indicating if a GeoJSON object is valid in Azure Cosmos DB for NoSQL.

## Syntax

```nosql
ST_ISVALID(<spatial_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`spatial_expr`** | Any valid GeoJSON Point, Polygon, MultiPolygon, or LineString expression. |

## Return types

Returns a boolean value.

## Examples

This section contains examples of how to use this query language construct.

### Check validity of GeoJSON objects

In this example, the `ST_ISVALID` function is used to check the validity of multiple GeoJSON objects.

```nosql
SELECT VALUE {
  valid: ST_ISVALID({ 
      "type": "Point",
      "coordinates": [-84.38876194345323, 33.75682784306348] 
  }),
  invalid: ST_ISVALID({ 
      "type": "Point",
      "coordinates": [133.75682784306348, -184.38876194345323] 
  })
}
```

```json
[
  {
    "valid": true,
    "invalid": false
  }
]
```

## Remarks

- The GeoJSON specification requires that points within a Polygon be specified in counter-clockwise order. A Polygon specified in clockwise order represents the inverse of the region within it.
