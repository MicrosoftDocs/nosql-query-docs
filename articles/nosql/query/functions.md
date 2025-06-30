---
title: Functions
description: The NoSQL query language provides many built-in functions for common tasks across a wide variety of categories.
ms.date: 06/27/2025
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
