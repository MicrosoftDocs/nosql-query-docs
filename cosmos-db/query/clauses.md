---
title: Clauses
description: The NoSQL query language provides many language clauses that can be used to build complex query language expressions.
ms.date: 11/10/2025
---

# Clauses - Query language in Cosmos DB (in Azure and Fabric)

Queries built in the NoSQL query language are constructed of various supported clauses that are built in to the query language.

## Clauses

Here's a list of clauses that the NoSQL query language currently supports:

| | Description |
| --- | --- |
| **[`FROM`](from.md)** | The `FROM` clause identifies the source of data for a query. |
| **[`GROUP BY`](group-by.md)** | The `GROUP BY` clause collects rows that have the same values into summary rows. |
| **[`OFFSET LIMIT`](offset-limit.md)** | The `OFFSET LIMIT` clause returns a subset of the result set by skipping a specified number of results and then taking a specified number of results. |
| **[`ORDER BY RANK`](order-by-rank.md)** | The `ORDER BY RANK` clause returns the sorted result set of a query based on the rank of scoring functions. |
| **[`ORDER BY`](order-by.md)** | The `ORDER BY` clause returns the sorted result set of a query based on one or more expressions. |
| **[`SELECT`](select.md)** | The `SELECT` clause identifies fields to return in query results. The clause then projects those fields into the JSON result set. |
| **[`WHERE`](where.md)** | The `WHERE` clause returns a subset of items that satisfy the specified filter condition. |

| | Description |
| --- | --- |
| **[Subquery](subquery.md)** | A subquery clause identifies a query nested within another query. |
