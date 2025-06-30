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

### Full Text Search functions

| | Description |
| --- | --- |
| **[`FULLTEXTCONTAINS`](fulltextcontains.md)** | The `FULLTEXTCONTAINS` function returns a boolean indicating whether the keyword string expression is contained in a specified property path. |
| **[`FULLTEXTCONTAINSALL`](fulltextcontainsall.md)** | The `FULLTEXTCONTAINSALL` function returns a boolean indicating whether all of the provided string expressions are contained in a specified property path. |
| **[`FULLTEXTCONTAINSANY`](fulltextcontainsany.md)** | The `FULLTEXTCONTAINSANY` function returns a boolean indicating whether any of the provided string expressions are contained in a specified property path. |
| **[`FULLTEXTSCORE`](fulltextscore.md)** | The `FULLTEXTSCORE` function returns a BM25 score value that can only be used in an `ORDER BY RANK` clause to sort results from highest relevancy to lowest relevancy of the specified terms. |
| **[`RRF`](rrf.md)** | The `RRF` function returns a fused score by combining two or more scores provided by other functions. |
