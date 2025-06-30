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
