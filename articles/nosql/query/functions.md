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

### Conditional functions

| | Description |
| --- | --- |
| **[`IIF`](iif.md)** | The `IIF` function returns one of two values, depending on whether the Boolean expression evaluates to true or false. |
