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
