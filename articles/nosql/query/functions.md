---
title: Functions
description: The NoSQL query language provides many built-in functions for common tasks across a wide variety of categories.
ms.date: 06/30/2025
---

# NoSQL query language functions

The NoSQL query language includes a series of system functions that are built-in to the query language and designd to handle a wide variety of common tasks.

## Functions

Here's a list of functions that are currently supported by the NoSQL query language.

### Mathematical functions

| | Description |
| --- | --- |
| **[`ABS`](abs.md)** | The `ABS` function calculates the absolute (positive) value of the specified numeric expression. |

### Array functions

| | Description |
| --- | --- |
| **[`ARRAY_CONCAT`](array-concat.md)** | The `ARRAY_CONCAT` function returns an array that is the result of concatenating two or more array values. |

### Aggregation functions

| | Description |
| --- | --- |
| **[`AVG`](avg.md)** | The `AVG` function calculates the average of the values in the expression. |

### Spatial functions

| | Description |
| --- | --- |
| **[`ST_AREA`](st-area.md)** | The `ST_AREA` function returns the total area of a GeoJSON Polygon or MultiPolygon expression. |
| **[`ST_DISTANCE`](st-distance.md)** | The `ST_DISTANCE` function returns the distance between two GeoJSON Point, Polygon, MultiPolygon or LineString expressions. |
| **[`ST_INTERSECTS`](st-intersects.md)** | The `ST_INTERSECTS` function returns a boolean indicating whether the GeoJSON object specified in the first argument intersects the GeoJSON object in the second argument. |
| **[`ST_ISVALID`](st-isvalid.md)** | The `ST_ISVALID` function returns a boolean value indicating whether the specified GeoJSON Point, Polygon, MultiPolygon, or LineString expression is valid. |
| **[`ST_ISVALIDDETAILED`](st-isvaliddetailed.md)** | The `ST_ISVALIDDETAILED` function returns a JSON value containing a Boolean value if the specified GeoJSON Point, Polygon, or LineString expression is valid, and if invalid, the reason. |
| **[`ST_WITHIN`](st-within.md)** | The `ST_WITHIN` function returns a boolean expression indicating whether the GeoJSON object specified in the first argument is within the GeoJSON object in the second argument. |
| **[`VECTORDISTANCE`](vectordistance.md)** | The `VECTORDISTANCE` function returns the similarity score between two specified vectors. |
