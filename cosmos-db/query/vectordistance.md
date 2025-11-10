---
title: VECTORDISTANCE
description: The `VECTORDISTANCE` function returns the similarity score between two specified vectors.
ms.date: 11/10/2025
---

# `VECTORDISTANCE` - Query language in Cosmos DB (in Azure and Fabric)

The `VECTORDISTANCE` function returns the similarity score between two specified vectors.

An Azure Cosmos DB for NoSQL system function that returns the similarity score between two vectors for one or more items in a container.

## Syntax

```nosql
VECTORDISTANCE(<vector_expr_1>, <vector_expr_2>, <bool_expr>, <obj_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`vector_expr_1`** | A one-dimensional array of `float32` or smaller. |
| **`vector_expr_2`** | A one-dimensional array of `float32` or smaller. |
| **`bool_expr`** | An optional boolean specifying how the computed value is used in an ORDER BY expression. If `true`, then brute force is used. A value of `false` uses any index defined on the vector property, if it exists. Default value is `false`. |
| **`obj_expr`** | An optional JSON formatted object literal used to specify options for the vector distance calculation. Valid items include `distanceFunction`, `dataType`, and `searchListSizeMultiplier`. |

## Return types

Returns a numeric expression that enumerates the similarity score between two expressions.

## Examples

This section contains examples of how to use this query language construct.

### Vector similarity search

In this example, the `VECTORDISTANCE` function is used to return the similarity score between a document vector and a query vector.

```nosql
SELECT
  c.name,
  VECTORDISTANCE(c.vector, [1,2,3]) AS SimilarityScore 
FROM
  c
ORDER BY VECTORDISTANCE(c.vector, [1,2,3]) AS SimilarityScore
```

```json
[
  {
    "name": "document1",
    "SimilarityScore": 0.8923471786
  },
  {
    "name": "document2",
    "SimilarityScore": 0.7492739573
  }
]
```

## Remarks

- If a multi-dimensional array is provided for `vector_expr_1` or `vector_expr_2`, the function doesn't return a `SimilarityScore` value and doesn't return an error.
