---
title: ST_DISTANCE
description: The `ST_DISTANCE` function returns the distance between two GeoJSON Point, Polygon, MultiPolygon or LineString expressions.
ms.date: 11/10/2025
---

# `ST_DISTANCE` - Query language in Cosmos DB (in Azure and Fabric)

The `ST_DISTANCE` function returns the distance between two GeoJSON Point, Polygon, MultiPolygon or LineString expressions.

The `ST_DISTANCE` function returns a numeric value representing the distance between two GeoJSON objects in Azure Cosmos DB for NoSQL.

## Syntax

```cosmos-db
ST_DISTANCE(<spatial_expr_1>, <spatial_expr_2>)
```

## Arguments

| | Description |
| --- | --- |
| **`spatial_expr_1`** | Any valid GeoJSON Point, Polygon, MultiPolygon or LineString expression. |
| **`spatial_expr_2`** | Any valid GeoJSON Point, Polygon, MultiPolygon or LineString expression. |

## Return types

Returns a numeric expression that enumerates the distance between two expressions.

## Examples

This section contains examples of how to use this query language construct.

### Calculate distance between points

In this example, the `ST_DISTANCE` function is used to calculate the distance between an office location and a reference point, returning the result in kilometers.

```cosmos-db
SELECT
    o.name,
    ST_DISTANCE(o.location, {
        "type": "Point", 
        "coordinates": [-122.11758113953535, 47.66901087006131]
    }) / 1000 AS distanceKilometers
FROM
    offices o
WHERE
    o.category = "business-offices"
```

```json
[
  {
    "name": "Headquarters",
    "distanceKilometers": 3.345269817267368
  },
  {
    "name": "Research and development",
    "distanceKilometers": 1907.438421299902
  }
]
```

## Remarks

- The result is expressed in meters for the default reference system.
- This function benefits from a geospatial index except in queries with aggregates.
- The GeoJSON specification requires that points within a Polygon be specified in counter-clockwise order. A Polygon specified in clockwise order represents the inverse of the region within it.
