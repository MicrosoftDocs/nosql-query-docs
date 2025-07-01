---
title: Functions
description: The NoSQL query language provides many built-in functions for common tasks across a wide variety of categories.
ms.date: 07/01/2025
---

# NoSQL query language functions

The NoSQL query language includes a series of system functions that are built in to the query language and designed to handle a wide variety of common tasks.

## Functions

Here's a list of functions that the NoSQL query language currently supports:

### Mathematical functions

| | Description |
| --- | --- |
| **[`ABS`](abs.md)** | The `ABS` function calculates the absolute (positive) value of the specified numeric expression. |
| **[`ACOS`](acos.md)** | The `ACOS` function calculates the trigonometric arccosine of the specified numeric value. The arccosine is the angle, in radians, whose cosine is the specified numeric expression. |
| **[`ASIN`](asin.md)** | The `ASIN` function calculates the trigonometric arcsine of the specified numeric value. The arcsine is the angle, in radians, whose sine is the specified numeric expression. |
| **[`ATAN`](atan.md)** | The `ATAN` function calculates the trigonometric arctangent of the specified numeric value. The arctangent is the angle, in radians, whose tangent is the specified numeric expression. |
| **[`ATN2`](atn2.md)** | The `ATN2` function calculates the principal value of the arctangent of `y/x`, expressed in radians. |
| **[`CEILING`](ceiling.md)** | The `CEILING` function calculates the smallest integer value greater than or equal to the specified numeric expression. |
| **[`COS`](cos.md)** | The `COS` function calculates the trigonometric cosine of the specified angle in radians. |
| **[`COT`](cot.md)** | The `COT` function calculates the trigonometric cotangent of the specified angle in radians. |
| **[`DEGREES`](degrees.md)** | The `DEGREES` function calculates the corresponding angle in degrees for an angle specified in radians. |
| **[`EXP`](exp.md)** | The `EXP` function calculates the exponential value of the specified numeric expression. |
| **[`FLOOR`](floor.md)** | The `FLOOR` function calculates the largest integer less than or equal to the specified numeric expression. |

### Array functions

| | Description |
| --- | --- |
| **[`ARRAY_CONCAT`](array-concat.md)** | The `ARRAY_CONCAT` function returns an array that is the result of concatenating two or more array values. |
| **[`ARRAY_CONTAINS_ALL`](array-contains-all.md)** | The `ARRAY_CONTAINS_ALL` function returns a boolean indicating whether the array contains all of the specified values. |
| **[`ARRAY_CONTAINS_ANY`](array-contains-any.md)** | The `ARRAY_CONTAINS_ANY` function returns a boolean indicating whether the array contains any of the specified values. |
| **[`ARRAY_CONTAINS`](array-contains.md)** | The `ARRAY_CONTAINS` function returns a boolean indicating whether the array contains the specified value. You can check for a partial or full match of an object by using a boolean expression within the function. |
| **[`ARRAY_LENGTH`](array-length.md)** | The `ARRAY_LENGTH` function returns the number of elements in the specified array expression. |
| **[`ARRAY_SLICE`](array-slice.md)** | The `ARRAY_SLICE` function returns a subset of an array expression using the index and length specified. |
| **[`CHOOSE`](choose.md)** | The `CHOOSE` function returns the expression at the specified index of a list, or Undefined if the index exceeds the bounds of the list. |
| **[`OBJECTTOARRAY`](objecttoarray.md)** | The `OBJECTTOARRAY` function converts field/value pairs in a JSON object to a JSON array. |
| **[`SETINTERSECT`](setintersect.md)** | The `SETINTERSECT` function returns the set of expressions that is contained in both input arrays with no duplicates. |
| **[`SETUNION`](setunion.md)** | The `SETUNION` function returns a set of expressions containing all expressions from two gathered sets with no duplicates. |

### Aggregation functions

| | Description |
| --- | --- |
| **[`AVG`](avg.md)** | The `AVG` function calculates the average of the values in the expression. |
| **[`COUNT`](count.md)** | The `COUNT` function returns the count of the values in the expression. |
| **[`MAX`](max.md)** | The `MAX` function returns the maximum value of the specified expression. |
| **[`MIN`](min.md)** | The `MIN` function returns the minimum value of the specified expression. |
| **[`SUM`](sum.md)** | The `SUM` function calculates the sum of the values in the expression. |

### String functions

| | Description |
| --- | --- |
| **[`CONCAT`](concat.md)** | The `CONCAT` function returns a string that is the result of concatenating multiple fields from a document. |
| **[`CONTAINS`](contains.md)** | The `CONTAINS` function returns a boolean indicating whether the first string expression contains the second string expression. |
| **[`ENDSWITH`](endswith.md)** | The `ENDSWITH` function returns a boolean indicating whether a string ends with the specified suffix. Optionally, the comparison can be case-insensitive. |
| **[`INDEX-OF`](index-of.md)** | The `INDEX_OF` function returns the index of the first occurrence of a string. |
| **[`LEFT`](left.md)** | The `LEFT` function returns the left part of a string up to the specified number of characters. |
| **[`LENGTH`](length.md)** | The `LENGTH` function returns the number of characters in the specified string expression. |
| **[`LOWER`](lower.md)** | The `LOWER` function returns a string expression after converting uppercase character data to lowercase. |
| **[`LTRIM`](ltrim.md)** | The `LTRIM` function returns a string expression after it removes leading whitespace or specified characters. |
| **[`REGEXMATCH`](regexmatch.md)** | The `REGEXMATCH` function returns a boolean indicating whether the provided string matches the specified regular expression. Regular expressions are a concise and flexible notation for finding patterns of text. |
| **[`REPLACE`](replace.md)** | The `REPLACE` function returns a string with all occurrences of a specified string replaced. |

### Item functions

| | Description |
| --- | --- |
| **[`DOCUMENTID`](documentid.md)** | The `DOCUMENTID` function returns the unique document ID for a given item in the container. |

### Conditional functions

| | Description |
| --- | --- |
| **[`IIF`](iif.md)** | The `IIF` function returns one of two values, depending on whether the Boolean expression evaluates to true or false. |

### Type checking functions

| | Description |
| --- | --- |
| **[`IS_ARRAY`](is-array.md)** | The `IS_ARRAY` function returns a boolean value indicating if the type of the specified expression is an array. |
| **[`IS_BOOL`](is-bool.md)** | The `IS_BOOL` function returns a boolean value indicating if the type of the specified expression is a boolean. |
| **[`IS_DEFINED`](is-defined.md)** | The `IS_DEFINED` function returns a boolean indicating if the property has been assigned a value. |
| **[`IS_FINITE_NUMBER`](is-finite-number.md)** | The `IS_FINITE_NUMBER` function returns a boolean indicating if a number is a finite number (not infinite). |
| **[`IS_INTEGER`](is-integer.md)** | The `IS_INTEGER` function returns a boolean indicating if a number is a 64-bit signed integer. 64-bit signed integers range from `-9,223,372,036,854,775,808` to `9,223,372,036,854,775,807`. For more information, see [__int64](/cpp/cpp/int8-int16-int32-int64). |
| **[`IS_NULL`](is-null.md)** | The `IS_NULL` function returns a boolean value indicating if the type of the specified expression is `null`. |
| **[`IS_NUMBER`](is-number.md)** | The `IS_NUMBER` function returns a boolean value indicating if the type of the specified expression is a number. |
| **[`IS_OBJECT`](is-object.md)** | The `IS_OBJECT` function returns a boolean value indicating if the type of the specified expression is a JSON object. |
| **[`IS_PRIMITIVE`](is-primitive.md)** | The `IS_PRIMITIVE` function returns a boolean value indicating if the type of the specified expression is a primitive (string, boolean, numeric, or null). |
| **[`IS_STRING`](is-string.md)** | The `IS_STRING` function returns a boolean value indicating if the type of the specified expression is a string. |

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
