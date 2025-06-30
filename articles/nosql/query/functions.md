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
