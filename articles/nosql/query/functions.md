---
title: Functions
description: The NoSQL query language provides many built-in functions for common tasks across a wide variety of categories.
ms.date: 06/30/2025
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

### Aggregation functions

| | Description |
| --- | --- |
| **[`AVG`](avg.md)** | The `AVG` function calculates the average of the values in the expression. |

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
