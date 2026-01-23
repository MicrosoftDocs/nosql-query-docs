---
title: ST_ISVALIDDETAILED
description: The `ST_ISVALIDDETAILED` function returns a JSON value containing a Boolean value if the specified GeoJSON Point, Polygon, or LineString expression is valid, and if invalid, the reason.
ms.date: 11/10/2025
---

# `ST_ISVALIDDETAILED` - Query language in Cosmos DB (in Azure and Fabric)

The `ST_ISVALIDDETAILED` function returns a JSON value containing a Boolean value if the specified GeoJSON Point, Polygon, or LineString expression is valid, and if invalid, the reason.

The `ST_ISVALIDDETAILED` function returns a JSON object indicating if a GeoJSON object is valid and, if not, the reason in Azure Cosmos DB.

## Syntax

```cosmos-db
ST_ISVALIDDETAILED(<spatial_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`spatial_expr`** | Any valid GeoJSON Point, Polygon, or LineString expression. |

## Return types

Returns a JSON object containing a boolean value indicating if the specified GeoJSON point or polygon expression is valid. If invalid, the object additionally contains the reason as a string value.

## Examples

This section contains examples of how to use this query language construct.

### Check validity of GeoJSON objects

In this example, the `ST_ISVALIDDETAILED` function is used to check the validity of multiple GeoJSON objects.

```cosmos-db
SELECT VALUE {
  valid: ST_ISVALIDDETAILED({ 
      "type": "Point",
      "coordinates": [-84.38876194345323, 33.75682784306348] 
  }),
  invalid: ST_ISVALIDDETAILED({ 
      "type": "Point",
      "coordinates": [133.75682784306348, -184.38876194345323] 
  })
}
```

```json
[
  {
    "valid": {
      "valid": true
    },
    "invalid": {
      "valid": false,
      "reason": "Latitude values must be between -90 and 90 degrees."
    }
  }
]
```

## Remarks

- The GeoJSON specification requires that points within a Polygon be specified in counter-clockwise order. A Polygon specified in clockwise order represents the inverse of the region within it.
