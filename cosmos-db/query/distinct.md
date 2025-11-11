---
title: DISTINCT
description: The `DISTINCT` keyword eliminates duplicates in the projected query results.
ms.date: 11/10/2025
---

# `DISTINCT` - Query language in Cosmos DB (in Azure and Fabric)

The `DISTINCT` keyword eliminates duplicates in the projected query results.

In this example, the query projects values for each product category. If two categories are equivalent, only a single occurrence returns in the results.

```nosql
SELECT DISTINCT VALUE
    p.category
FROM
    products p
```

```json
[
  "Accessories",
  "Tools"
]
```

You can also project values even if the target field doesn't exist. In this case, the field doesn't exist in one of the items, so the query returns an empty object for that specific unique value.

```nosql
SELECT DISTINCT
    p.category
FROM
    products p
```

The results are:

```json
[
  {},
  {
    "category": "Accessories"
  },
  {
    "category": "Tools"
  }
]
```
