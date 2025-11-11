---
title: TOP
description: The `TOP` keyword returns the first `N` number of query results in an undefined order.
ms.date: 11/10/2025
---

# `TOP` - Query language in Cosmos DB (in Azure and Fabric)

The `TOP` keyword returns the first `N` number of query results in an undefined order. As a best practice, use `TOP` with the `ORDER BY` clause to limit results to the first `N` number of ordered values. Combining these two clauses is the only way to predictably indicate which rows `TOP` affects.

You can use `TOP` with a constant value, as in the following example, or with a variable value using parameterized queries.

```nosql
SELECT TOP 10
    *
FROM
    products p
ORDER BY
    p.price ASC
```
