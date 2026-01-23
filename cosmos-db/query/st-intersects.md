---
title: ST_INTERSECTS
description: The `ST_INTERSECTS` function returns a boolean indicating whether the GeoJSON object specified in the first argument intersects the GeoJSON object in the second argument.
ms.date: 11/10/2025
---

# `ST_INTERSECTS` - Query language in Cosmos DB (in Azure and Fabric)

The `ST_INTERSECTS` function returns a boolean indicating whether the GeoJSON object specified in the first argument intersects the GeoJSON object in the second argument.

The `ST_INTERSECTS` function returns a boolean indicating if two GeoJSON objects intersect in Azure Cosmos DB.

## Syntax

```cosmos-db
ST_INTERSECTS(<spatial_expr_1>, <spatial_expr_2>)
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

### Check if two polygons intersect

In this example, the `ST_INTERSECTS` function is used to determine if two GeoJSON polygons intersect.

```cosmos-db
SELECT VALUE {
  highWayAndCampusIntersect: ST_INTERSECTS({
      "type": "Polygon",
      "coordinates": [ [
          [
            -122.13693695285855,
            47.64996065621003
          ],
          [
            -122.1351662656516,
            47.64627863318731
          ],
          [
            -122.13488295569863,
            47.646326350048696
          ],
          [
            -122.1366182291613,
            47.650016321952904
          ],
          [
            -122.13693695285855,
            47.64996065621003
          ]
      ] ]
  }, {  
      "type": "Polygon",
      "coordinates": [ [
          [
            -122.14034847687708,
            47.6494835188378
          ],
          [
            -122.14014779899375,
            47.64625477474044
          ],
          [
            -122.13256925774829,
            47.646207057813655
          ],
          [
            -122.13254564858545,
            47.64941990019193
          ],
          [
            -122.14034847687708,
            47.6494835188378
          ]
      ] ]
  })
}
```

```json
[
  {
    "highWayAndCampusIntersect": true
  }
]
```

## Remarks

- This function benefits from a geospatial index except in queries with aggregates.
- The GeoJSON specification requires that points within a Polygon be specified in counter-clockwise order. A Polygon specified in clockwise order represents the inverse of the region within it.
