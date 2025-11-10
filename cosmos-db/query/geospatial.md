---
title: Geospatial data
description: The query language provides support for geometrics shapes, locations, and polygons.
ms.date: 11/10/2025
---

# Geospatial data - Query language in Cosmos DB (in Azure and Fabric)

The query language has built-in geospatial functionality to represent geometric shapes or actual locations/polygons on a map. Geospatial data often involves proximity queries. For example, the question "find all retail locations near my current location" is answered using a proximity query over multiple geospatial data object.

## Use cases

Common geospatial use cases include, but aren't limited to:

- **Geolocation analytics**, driving specific location-based marketing initiatives.

- **Location-based personalization**, for industries like retail and healthcare to improve user experience.

- **Logistics enhancement**, for industries like transportation where optimization is critical.

- **Risk Analysis**, for industries like insurance and finance to supplement other metadata.

- **Situational awareness***, for proximity-based alerts and notifications.

## Introduction to spatial data

Spatial data describes the position and shape of objects in space. In most applications, these points and shapes correspond to objects on the earth and geospatial data. 

Spatial data can be used to represent:

- The location of a person

- A place of interest

- The boundary of a city, or a lake

The query language supports two spatial data types: the **geometry** data type and the **geography** data type.

- The **geometry** type represents data in a Euclidean (flat) coordinate system. This type is useful for common geometric tasks, like measuring lines, intersecting polygons, and measuring distance between points.

- The **geography** type represents data in a round-earth coordinate system. This type is useful for common geographical tasks, like determining if a location is within specific bounds and measuring distance between locations.

## Supported data types

The query language supports indexing and querying geospatial point data represented using the [GeoJSON specification](https://tools.ietf.org/html/rfc7946). GeoJSON data structures are valid JSON objects, so you can store and query them using the query language without any specialized tools or libraries.

The query language supports the following spatial data types:

- **Point**

- **LineString**

- **Polygon**

- **MultiPolygon**

### Points

A **Point** denotes a single position in space. In geospatial data, a Point represents the exact location, which could be a street address of a grocery store, a kiosk, an automobile, or a city. A point is represented in GeoJSON (and The query language) using its coordinate pair (**longitude** and **latitude**).

Consider this example GeoJSON point. The longitude is `-122.12826822304672` and the latitude is `47.63980239335718`.

```json
{
  "type": "Point",
  "coordinates": [
    -122.12826822304672,
    47.63980239335718
  ]
}
```

> [!TIP]
> For the **geography** data type, GeoJSON specification specifies longitude first and latitude second. Like in other mapping applications, longitude and latitude are angles and represented in terms of degrees. Longitude values are measured from the Prime Meridian and are between `-180` degrees and `180.0` degrees, and latitude values are measured from the equator and are between `-90.0` degrees and `90.0` degrees.
>
> For the **geometry** data type, GeoJSON specification specifies the horizontal axis first and the vertical axis second.

Spatial data types can be embedded in an item as shown in this example of a facility item that includes the GeoJSON data.

```json
{
  "name": "Headquarters",
  "location": {
    "type": "Point",
    "coordinates": [
      -122.12826822304672,
      47.63980239335718
    ]
  },
  "category": "business-offices"
}
```

The query language interprets coordinates as represented per the WGS-84 reference system. For more information, see [coordinate reference systems](#coordinate-reference-systems).

### LineStrings

**LineStrings** represent a series of two or more points in space and the line segments that connect them. In geospatial data, LineStrings are commonly used to represent highways or rivers.

In this example, a line string is used to represent a line that drawn between two points.

```json
{
  "type": "LineString",
  "coordinates": [
    [ 31.8, -5 ],
    [ 31.8, -4.7 ]
  ]
}
```

### Polygons

A **Polygon** is a boundary of connected points that forms a closed LineString. Polygons are commonly used to represent natural formations like lakes or political jurisdictions like cities and states.

Points within a Polygon must be specified in counter-clockwise order. A Polygon specified in clockwise order represents the inverse of the region within it.

In this example, a polygon is created by connecting multiple points. 

```json
{
  "type":"Polygon",
  "coordinates":[[
    [ 31.8, -5 ],
    [ 32, -5 ],
    [ 32, -4.7 ],
    [ 31.8, -4.7 ],
    [ 31.8, -5 ]
  ]]
}
```

> [!TIP]
> The GeoJSON specification requires that for valid Polygons, the last coordinate pair provided should be the same as the first, to create a closed shape. 

### MultiPolygons

A **MultiPolygon** is an array of zero or more Polygons. **MultiPolygons** can't overlap sides or have any common area. They could touch at one or more points.

Here's an example of a MultiPolygon.

```json
{
    "type":"MultiPolygon",
    "coordinates":[
      [[
          [52.0, 12.0],
          [53.0, 12.0],
          [53.0, 13.0],
          [52.0, 13.0],
          [52.0, 12.0]
      ]],
      [[
          [50.0, 0.0],
          [51.0, 0.0],
          [51.0, 5.0],
          [50.0, 5.0],
          [50.0, 0.0]
      ]]
    ]
}
```

## Coordinate reference systems

Since the shape of the earth is irregular, coordinates of geography geospatial data are represented in many coordinate reference systems (CRS). Each CRS has their own frames of reference and units of measurement. For example, the "National Grid of Britain" is a reference system is accurate for the United Kingdom, but not outside it.

The most popular CRS in use today is the World Geodetic System [WGS-84](https://earth-info.nga.mil/GandG/update/index.php). GPS devices, and many mapping services including Google Maps and Bing Maps APIs use WGS-84. The query language supports indexing and querying of geography geospatial data using the WGS-84 CRS only.
