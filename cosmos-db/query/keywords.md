---
title: Keywords
description: Learn about reserved keywords in the query language in Cosmos DB (in Azure and Fabric) including BETWEEN, DISTINCT, LIKE, IN, and TOP. Use these keywords to build powerful queries.
ms.date: 11/10/2025
---

# Keywords - Query language in Cosmos DB (in Azure and Fabric)

The query language in Cosmos DB (in Azure and Fabric) includes reserved keywords that provide extended functionality for building queries. These keywords enable operations like filtering with BETWEEN and LIKE, eliminating duplicates with DISTINCT, and limiting results with TOP.

## Keywords

Here's a list of keywords that the query language currently supports:

| | Description |
| --- | --- |
| **[`BETWEEN`](between.md)** | The `BETWEEN` keyword evaluates to a boolean indicating whether the target value is between two specified values, inclusive. |
| **[`DISTINCT`](distinct.md)** | The `DISTINCT` keyword eliminates duplicates in the projected query results. |
| **[`LIKE`](like.md)** | The `LIKE` keyword a boolean value depending on whether a specific character string matches a specified pattern. |
| **[`IN`](like.md)** | The ``IN`` keyword checks whether a specified value matches any value in a list. |
| **[`TOP`](like.md)** | The `TOP` keyword returns the first `N` number of query results in an undefined order. |
