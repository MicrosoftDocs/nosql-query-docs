---
title: Geospatial - Operators
description: Geospatial operators perform operations on geographic data and spatial relationships.
type: operators
category: geospatial
---

# Geospatial - operators

Geospatial operators perform operations on geographic data and spatial relationships.

| | Description |
| --- | --- |
| [**`$box`**]($box.md) | The $box operator defines a rectangular area for geospatial queries using coordinate pairs. |
| [**`$center`**]($center.md) | The $center operator specifies a circle using legacy coordinate pairs for $geoWithin queries. |
| [**`$centerSphere`**]($centersphere.md) | The $centerSphere operator specifies a circle using spherical geometry for $geoWithin queries. |
| [**`$geoIntersects`**]($geointersects.md) | The $geoIntersects operator selects documents whose location field intersects with a specified GeoJSON object. |
| [**`$geometry`**]($geometry.md) | The $geometry operator specifies a GeoJSON geometry for geospatial queries. |
| [**`$geoWithin`**]($geowithin.md) | The $geoWithin operator selects documents whose location field is completely within a specified geometry. |
| [**`$maxDistance`**]($maxdistance.md) | The $maxDistance operator specifies the maximum distance that can exist between two points in a geospatial query. |
| [**`$minDistance`**]($mindistance.md) | The $minDistance operator specifies the minimum distance that must exist between two points in a geospatial query. |
| [**`$near`**]($near.md) | The $near operator returns documents with location fields that are near a specified point, sorted by distance. |
| [**`$nearSphere`**]($nearsphere.md) | The $nearSphere operator returns documents whose location fields are near a specified point on a sphere, sorted by distance on a spherical surface. |
| [**`$polygon`**]($polygon.md) | The $polygon operator defines a polygon for geospatial queries, allowing you to find locations within an irregular shape. |
