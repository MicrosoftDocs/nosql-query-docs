---
title: RRF
description: The `RRF` function returns a fused score by combining two or more scores provided by other functions.
ms.date: 11/10/2025
---

# `RRF` - Query language in Cosmos DB (in Azure and Fabric)

The `RRF` function returns a fused score by combining two or more scores provided by other functions.

## Syntax

```nosql
RRF(<function1>, <function2>, ..., <weights>)
```

## Arguments

| | Description |
| --- | --- |
| **`function1`** | A scoring function such as VectorDistance or FullTextScore. |
| **`function2`** | A scoring function such as VectorDistance or FullTextScore. |
| **`weights`** | An array of numbers defining an importance weight for each scoring function. |

## Return types

Returns a numeric value representing the fused score.

## Examples

This section contains examples of how to use this query language construct.

### Hybrid Search (vector similarity + BM25)

In this example, Hybrid Search combines FullTextScore and VectorDistance.

```nosql
SELECT TOP 10 *
FROM c
ORDER BY RANK RRF(FullTextScore(c.text, "keyword"), VectorDistance(c.vector, [1,2,3]))
```

```json
-- Example result not available (see documentation)
```

### Weighted Hybrid Search

In this example, Hybrid Search uses weights for the scoring functions.

```nosql
SELECT TOP 10 *
FROM c
ORDER BY RANK RRF(FullTextScore(c.text, "keyword"), VectorDistance(c.vector, [1,2,3]), [2,1])
```

```json
-- Example result not available (see documentation)
```

### Fusion with two FullTextScore functions

In this example, two FullTextScore functions are fused.

```nosql
SELECT TOP 10 *
FROM c
ORDER BY RANK RRF(FullTextScore(c.text, "keyword1"), FullTextScore(c.text, "keyword2"))
```

```json
-- Example result not available (see documentation)
```

### Fusion with two VectorDistance functions

In this example, two VectorDistance functions are fused.

```nosql
SELECT TOP 5 *
FROM c
ORDER BY RANK RRF(VectorDistance(c.vector1, [1,2,3]), VectorDistance(c.vector2, [2,2,4]))
```

```json
-- Example result not available (see documentation)
```

## Remarks

- This function requires enrollment in the Azure Cosmos DB NoSQL Full Text Search feature.
- Hybrid Search also requires enrollment in Azure Cosmos DB NoSQL Vector Search.
- This function requires a Full Text Index.
- This function can only be used in an `ORDER BY RANK` clause, and can't be combined with `ORDER BY` on other property paths.
- This function can’t be part of a projection (for example, `SELECT FullTextScore(c.text, "keyword") AS Score FROM c` is invalid).
