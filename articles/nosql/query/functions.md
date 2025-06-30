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

### Conditional functions

| | Description |
| --- | --- |
| **[`IIF`](iif.md)** | The `IIF` function returns one of two values, depending on whether the Boolean expression evaluates to true or false. |
