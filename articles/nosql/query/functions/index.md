---
title: Query language reference
description: Azure Cosmos DB for NoSQL provides many built-in functions for common tasks across a wide variety of categories.
ms.date: 06/23/2025
---

# NoSQL query language reference

Azure Cosmos DB for NoSQL has the ability to query data by writing queries using a custom NoSQL dialect derived from Structured Query Language (SQL) with JavaScript Object Notation (JSON) as the primary data type language.

## Functions

Here's a list of functions that are currently supported by the NoSQL query language.

### Mathematical functions

| | Description |
| --- | --- |
| **[`ABS`](abs.md)** | The `ABS` function returns the absolute (positive) value of the specified numeric expression. |
| **[`FLOOR`](floor.md)** | The `FLOOR` function returns the largest integer less than or equal to the specified numeric expression. |

### Array functions

| | Description |
| --- | --- |
| **[`ARRAY_CONCAT`](array-concat.md)** | The `ARRAY_CONCAT` function returns an array that is the result of concatenating two or more array values. |
| **[`SETUNION`](setunion.md)** | The `SetUnion` function gathers expressions in two sets and returns a set of expressions containing all expressions in both sets with no duplicates. |

### Aggregation functions

| | Description |
| --- | --- |
| **[`AVG`](avg.md)** | The `AVG` function calculates the average of the values in the expression. |
| **[`COUNT`](count.md)** | The `COUNT` function returns the count of the values in the expression. |
| **[`SUM`](sum.md)** | The `SUM` function calculates the sum of the values in the expression. |

### Type Checking functions

| | Description |
| --- | --- |
| **[`IS_NULL`](is-null.md)** | The `IS_NULL` function returns a boolean value indicating if the type of the specified expression is `null`. |
