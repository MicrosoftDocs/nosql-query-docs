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
| **[`INTADD`](intadd.md)** | The `INTADD` function returns the sum of two integer values. |
| **[`INTBITAND`](intbitand.md)** | The `INTBITAND` function returns a comparison of the bits of each operand using an inclusive AND operator. |
| **[`INTBITLEFTSHIFT`](intbitleftshift.md)** | The `INTBITLEFTSHIFT` function returns the result of a bitwise left shift operation on an integer value. |
| **[`INTBITNOT`](intbitnot.md)** | The `INTBITNOT` function returns the result of a bitwise NOT operation on an integer value. |
| **[`INTBITOR`](intbitor.md)** | The `INTBITOR` function returns the result of a bitwise inclusive OR operation on two integer values. |
| **[`INTBITRIGHTSHIFT`](intbitrightshift.md)** | The `INTBITRIGHTSHIFT` function returns the result of a bitwise right shift operation on an integer value. |
| **[`INTBITXOR`](intbitxor.md)** | The `INTBITXOR` function returns the result of a bitwise exclusive OR operation on two integer values. |
| **[`INTDIV`](intdiv.md)** | The `INTDIV` function returns the result of dividing the first integer value by the second. |
| **[`INTMOD`](intmod.md)** | The `INTMOD` function returns the remainder of dividing the first integer value by the second. |
| **[`INTMUL`](intmul.md)** | The `INTMUL` function returns the product of two integer values. |
| **[`INTSUB`](intsub.md)** | The `INTSUB` function returns the result of subtracting the second integer value from the first. |
| **[`LOG`](log.md)** | The `LOG` function returns the natural logarithm of the specified numeric expression. |
| **[`LOG10`](log10.md)** | The `LOG10` function returns the base-10 logarithm of the specified numeric expression. |
| **[`NUMBERBIN`](numberbin.md)** | The `NUMBERBIN` function calculates the input value rounded to a multiple of the specified size. |
| **[`PI`](pi.md)** | The `PI` function returns the constant value of Pi. |
| **[`POWER`](power.md)** | The `POWER` function returns the value of the specified expression multipled by itself the given number of times. |
| **[`RADIANS`](radians.md)** | The `RADIANS` function returns the corresponding angle in radians for an angle specified in degrees. |
| **[`RAND`](rand.md)** | The `RAND` function returns a randomly generated numeric value from zero to one. |
| **[`ROUND`](round.md)** | The `ROUND` function returns a numeric value rounded to the closest integer value. |
| **[`SIGN`](sign.md)** | The `SIGN` function returns the positive (+1), zero (0), or negative (-1) sign of the specified numeric expression. |

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

### Date and time functions

| | Description |
| --- | --- |
| **[`DATETIMEADD`](datetimeadd.md)** | The `DATETIMEADD` function returns a date and time string value that is the result of adding a specified number value to the provided date and time string. |
| **[`DATETIMEBIN`](datetimebin.md)** | The `DATETIMEBIN` function returns a date and time string value that is the result of binning (or rounding) a part of the provided date and time string. |
| **[`DATETIMEDIFF`](datetimediff.md)** | The `DATETIMEDIFF` function returns the difference, as a signed integer, of the specified date and time part between two date and time values. |
| **[`DATETIMEFROMPARTS`](datetimefromparts.md)** | The `DATETIMEFROMPARTS` function returns a date and time string value constructed from input numeric values for various date and time parts. |
| **[`DATETIMEPART`](datetimepart.md)** | The `DATETIMEPART` function returns the value of the specified date and time part for the provided date and time. |
| **[`DATETIMETOTICKS`](datetimetoticks.md)** | The `DATETIMETOTICKS` function converts the specified DateTime to ticks. A single tick represents 100 nanoseconds or 0.0000001 of a second. |
| **[`DATETIMETOTIMESTAMP`](datetimetotimestamp.md)** | The `DATETIMETOTIMESTAMP` function converts the specified date and time to a numeric timestamp. The timestamp is a signed numeric integer that measures the milliseconds since the Unix epoch. |
| **[`GETCURRENTDATETIME`](getcurrentdatetime.md)** | The `GETCURRENTDATETIME` function returns the current UTC (Coordinated Universal Time) date and time as an **ISO 8601** string. |
| **[`GETCURRENTDATETIMESTATIC`](getcurrentdatetimestatic.md)** | The `GETCURRENTDATETIMESTATIC` function returns the same UTC date and time value for all items in the query, as an ISO 8601 string. This is useful for consistent timestamps across query results. |
| **[`GETCURRENTTICKS`](getcurrentticks.md)** | The `GETCURRENTTICKS` function returns the current UTC time as the number of 100-nanosecond intervals (ticks) that have elapsed since 0001-01-01T00:00:00.0000000Z. |

### Item functions

| | Description |
| --- | --- |
| **[`DOCUMENTID`](documentid.md)** | The `DOCUMENTID` function returns the unique document ID for a given item in the container. |

### Full text search functions

| | Description |
| --- | --- |
| **[`FULLTEXTCONTAINS`](fulltextcontains.md)** | The `FULLTEXTCONTAINS` function returns a boolean indicating whether the keyword string expression is contained in a specified property path. |
| **[`FULLTEXTCONTAINSALL`](fulltextcontainsall.md)** | The `FULLTEXTCONTAINSALL` function returns a boolean indicating whether all of the provided string expressions are contained in a specified property path. |
| **[`FULLTEXTCONTAINSANY`](fulltextcontainsany.md)** | The `FULLTEXTCONTAINSANY` function returns a boolean indicating whether any of the provided string expressions are contained in a specified property path. |
| **[`FULLTEXTSCORE`](fulltextscore.md)** | The `FULLTEXTSCORE` function returns a BM25 score value that can only be used in an `ORDER BY RANK` clause to sort results from highest relevancy to lowest relevancy of the specified terms. |
| **[`RRF`](rrf.md)** | The `RRF` function returns a fused score by combining two or more scores provided by other functions. |

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
| **[`STRINGTONULL`](stringtonull.md)** | The `STRINGTONULL` function converts a string expression to `null`. |
| **[`STRINGTONUMBER`](stringtonumber.md)** | The `STRINGTONUMBER` function converts a string expression to a number. |
| **[`STRINGTOOBJECT`](stringtoobject.md)** | The `STRINGTOOBJECT` function converts a string expression to an object. |

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
