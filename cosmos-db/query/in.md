---
title: IN
description: The `IN` keyword checks whether a specified value matches any value in a list.
ms.date: 11/10/2025
---

# `IN` - Query language in Cosmos DB (in Azure and Fabric)

The `IN` keyword checks whether a specified value matches any value in a list. For example, the following query returns all items where the category matches at least one of the values in a list.

```nosql
SELECT
    *
FROM
    products p
WHERE
    p.category IN ("Accessories", "Clothing")
```

> [!TIP]
> If you include your partition key in the `IN` filter, your query automatically filters to only the relevant partitions.
