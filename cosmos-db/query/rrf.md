---
title: RRF
description: The `RRF` function returns a fused score by combining two or more scores provided by other functions.
ms.date: 11/10/2025
---

# `RRF` - Query language in Cosmos DB (in Azure and Fabric)

The `RRF` function returns a fused score by combining two or more scores provided by other functions.

## Syntax

```cosmos-db
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

```cosmos-db
SELECT TOP 10 *
FROM c
ORDER BY RANK RRF(FullTextScore(c.text, "keyword"), VectorDistance(c.vector, [1,2,3]))
```

```json
[
  {
    "id": "doc-042",
    "text": "The keyword appears frequently in this document about distributed systems.",
    "vector": [0.12, 0.87, 0.34]
  },
  {
    "id": "doc-119",
    "text": "Another relevant document mentioning the keyword in context.",
    "vector": [0.45, 0.22, 0.91]
  }
]
```

### Weighted Hybrid Search

In this example, Hybrid Search uses weights for the scoring functions.

```cosmos-db
SELECT TOP 10 *
FROM c
ORDER BY RANK RRF(FullTextScore(c.text, "keyword"), VectorDistance(c.vector, [1,2,3]), [2,1])
```

```json
[
  {
    "id": "doc-007",
    "text": "This document contains the keyword and is semantically close to the query vector.",
    "vector": [0.98, 0.11, 0.23]
  },
  {
    "id": "doc-355",
    "text": "A document with strong keyword relevance boosted by the higher weight.",
    "vector": [0.67, 0.44, 0.18]
  }
]
```

### Fusion with two FullTextScore functions

In this example, two FullTextScore functions are fused.

```cosmos-db
SELECT TOP 10 *
FROM c
ORDER BY RANK RRF(FullTextScore(c.text, "keyword1"), FullTextScore(c.text, "keyword2"))
```

```json
[
  {
    "id": "doc-201",
    "text": "This article discusses both keyword1 and keyword2 in the context of data engineering."
  },
  {
    "id": "doc-088",
    "text": "A comprehensive overview that mentions keyword1 and covers keyword2 in detail."
  }
]
```

### Fusion with two VectorDistance functions

In this example, two VectorDistance functions are fused.

```cosmos-db
SELECT TOP 5 *
FROM c
ORDER BY RANK RRF(VectorDistance(c.vector1, [1,2,3]), VectorDistance(c.vector2, [2,2,4]))
```

```json
[
  {
    "id": "doc-014",
    "vector1": [0.12, 0.87, 0.34],
    "vector2": [0.56, 0.78, 0.90]
  },
  {
    "id": "doc-092",
    "vector1": [0.45, 0.22, 0.91],
    "vector2": [0.33, 0.67, 0.45]
  }
]
```

## Remarks

- This function requires enrollment in the Azure Cosmos DB NoSQL Full Text Search feature.
- Hybrid Search also requires enrollment in Azure Cosmos DB NoSQL Vector Search.
- This function requires a Full Text Index.
- This function can only be used in an `ORDER BY RANK` clause, and can't be combined with `ORDER BY` on other property paths.
- This function can’t be part of a projection (for example, `SELECT FullTextScore(c.text, "keyword") AS Score FROM c` is invalid).
