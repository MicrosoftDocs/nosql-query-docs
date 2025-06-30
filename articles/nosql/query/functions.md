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
