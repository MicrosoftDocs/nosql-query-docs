---
title: ORDER BY RANK
description: The `ORDER BY RANK` clause returns the sorted result set of a query based on the rank of scoring functions.
ms.date: 11/10/2025
---

# `ORDER BY RANK` - Query language in Cosmos DB (in Azure and Fabric)

The `ORDER BY RANK` clause returns the sorted result set of a query based on the rank of scoring functions.

## Syntax

```cosmos-db
ORDER BY RANK <scoring function>
```

## Arguments

| | Description |
| --- | --- |
| **`scoring function`** | Specifies a scoring function like `VectorDistance`, `FullTextScore`, or `RRF`. |

## Return types

Returns the sorted result set based on the specified scoring function's rank.

## Examples

This section contains examples of how to use this query language construct.

### Sort by scoring function rank

In this example, the `ORDER BY RANK` clause is used to sort results by the rank of a scoring function.

```cosmos-db
SELECT TOP 10 *
FROM c
ORDER BY RANK FullTextScore(c.text, "keyword")
```

```json
[
  {
    "id": "1",
    "text": "The keyword appears in this document multiple times with keyword variations."
  },
  {
    "id": "7",
    "text": "This document also references the keyword in context."
  }
]
```
