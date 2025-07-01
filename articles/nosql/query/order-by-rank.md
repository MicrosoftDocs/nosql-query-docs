---
title: ORDER BY RANK
description: The `ORDER BY RANK` clause returns the sorted result set of a query based on the rank of scoring functions.
ms.date: 07/01/2025
---

# `ORDER BY RANK` (NoSQL query)

The `ORDER BY RANK` clause returns the sorted result set of a query based on the rank of scoring functions.

## Syntax

```nosql
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

```nosql
-- Example query for ORDER BY RANK
SELECT * FROM c ORDER BY RANK FullTextScore
```

```json
[
  -- Example result set
]
```
