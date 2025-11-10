---
title: ST_AREA
description: The `ST_AREA` function returns the total area of a GeoJSON Polygon or MultiPolygon expression.
ms.date: 11/10/2025
---

# `ST_AREA` (NoSQL query)

The `ST_AREA` function returns the total area of a GeoJSON Polygon or MultiPolygon expression.

The `ST_AREA` function returns a numeric value representing the total area of a GeoJSON Polygon or MultiPolygon in Azure Cosmos DB for NoSQL.

## Syntax

```nosql
ST_AREA(<spatial_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`spatial_expr`** | Any valid GeoJSON Polygon or MultiPolygon expression. |

## Return types

Returns a numeric expression that enumerates the total area of a set of points.

## Examples

This section contains examples of how to use this query language construct.

### Calculate area of a polygon

In this example, the `ST_AREA` function is used to return the area of a GeoJSON polygon.

```nosql
SELECT VALUE {
  areaPolygon: ST_AREA({
      "type": "Polygon",
      "coordinates": [ [
          [ 31.8, -5 ],
          [ 32, -5 ],
          [ 32, -4.7 ],
          [ 31.8, -4.7 ],
          [ 31.8, -5 ]
      ] ]
  })
}
```

```json
[
  {
    "areaPolygon": 735970283.0522614
  }
]
```

## Remarks

- The result is expressed in square meters for the default reference system.
- Using this function to calculate the area of zero or one-dimensional figures like GeoJSON Points and LineStrings results in an area of `0`.
- The GeoJSON specification requires that points within a Polygon be specified in counter-clockwise order. A Polygon specified in clockwise order represents the inverse of the region within it.
