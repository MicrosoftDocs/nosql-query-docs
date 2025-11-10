---
title: ST_WITHIN
description: The `ST_WITHIN` function returns a boolean expression indicating whether the GeoJSON object specified in the first argument is within the GeoJSON object in the second argument.
ms.date: 11/10/2025
---

# `ST_WITHIN` (NoSQL query)

The `ST_WITHIN` function returns a boolean expression indicating whether the GeoJSON object specified in the first argument is within the GeoJSON object in the second argument.

The `ST_WITHIN` function returns a boolean indicating if one GeoJSON object is within another in Azure Cosmos DB for NoSQL.

## Syntax

```nosql
ST_WITHIN(<spatial_expr_1>, <spatial_expr_2>)
```

## Arguments

| | Description |
| --- | --- |
| **`spatial_expr_1`** | Any valid GeoJSON Point, Polygon, MultiPolygon or LineString expression. |
| **`spatial_expr_2`** | Any valid GeoJSON Point, Polygon, MultiPolygon or LineString expression. |

## Return types

Returns a boolean value.

## Examples

This section contains examples of how to use this query language construct.

### Check if a point is within a polygon

In this example, the `ST_WITHIN` function is used to determine if a GeoJSON Point is within a Polygon.

```nosql
SELECT VALUE {
  isHeadquartersWithinCampus: ST_WITHIN({
      "type": "Point",
      "coordinates": [
          -122.12824857332558,
          47.6395516675712
      ]
  }, {            
      "type": "Polygon",
      "coordinates": [ [
          [
            -122.13236581015025,
            47.64606476313813
          ],
          [
            -122.13221982500913,
            47.633757091363975
          ],
          [
            -122.11840598103835,
            47.641749416109235
          ],
          [
            -122.12061400629656,
            47.64589264786028
          ],
          [
            -122.13236581015025,
            47.64606476313813
          ]
      ] ]
  })
}
```

```json
[
  {
    "isHeadquartersWithinCampus": true
  }
]
```

## Remarks

- This function benefits from a geospatial index except in queries with aggregates.
- The GeoJSON specification requires that points within a Polygon be specified in counter-clockwise order. A Polygon specified in clockwise order represents the inverse of the region within it.
