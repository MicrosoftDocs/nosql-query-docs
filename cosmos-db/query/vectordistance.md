---
title: VECTORDISTANCE
description: The `VECTORDISTANCE` function returns the similarity score between two specified vectors.
ms.date: 11/10/2025
---

# `VECTORDISTANCE` - Query language in Cosmos DB (in Azure and Fabric)

The `VECTORDISTANCE` function returns the similarity score between two specified vectors.

An Azure Cosmos DB system function that returns the similarity score between two vectors for one or more items in a container.

## Syntax

```cosmos-db
VECTORDISTANCE(<vector_expr_1>, <vector_expr_2>, <bool_expr>, <obj_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`vector_expr_1`** | A one-dimensional array of `float32`, `float16`, `int8` or `unit8` types. |
| **`vector_expr_2`** | A one-dimensional array of `float32`, `float16`, `int8` or `unit8` types.|
| **`bool_expr`** | An optional boolean specifying how the computed value is used in an ORDER BY expression. If `true`, then brute force is used. A value of `false` uses any index defined on the vector property, if it exists. Default value is `false`. |
| **`obj_expr`** | An optional JSON formatted object literal used to specify options for the vector distance calculation. Valid items include `distanceFunction`, `dataType`, and `searchListSizeMultiplier`, `quantizedVectorListMultiplier`, and `filterPriority`. |

## Options (optional)
| Property | Type | Description |
|----------|------|-------------|
| `distanceFunction` | string | Distance function override (`Cosine`, `DotProduct`, `Euclidean`) |
| `dataType` | string | Data type override (`Float32`, `Float16`, `Int8`, `Uint8`) |
| `searchListSizeMultiplier` | number | Multiplier for DiskANN search list size. Increasing this may increase recall at expense of latency/RUs. Examples: 5, 10, 20|
| `quantizedVectorListMultiplier` | number | Multiplier for quantized vector candidate list. Increasing this may increase recall at expense of latency/RUs. Examples: 5, 10, 20 |
| `filterPriority` | number | Priority weight for query filter in WHERE clause vs. vector search in DiskANN. Examples: 0.0, 0.1, 0.5, 1.0 |


## Return types

Returns a numeric expression that enumerates the similarity score between two expressions.

## Examples

This section contains examples of how to use this query language construct.

### Vector similarity search

In this example, the `VECTORDISTANCE` function is used to return the similarity score between a document vector and a query vector, while sorting by the similarity score.

```cosmos-db
SELECT c.id, c.name, VECTORDISTANCE(c.vector, [1,2,3]) AS SimilarityScore 
FROM c
ORDER BY VECTORDISTANCE(c.vector, [1,2,3])
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
In this example, the VECTORDISTANCE function is used to order by similarity score. Optional parameters are provided to override the `dataType`, specify a larger  `searchListSizeMultiplier`, and specify a `filterPriority` on the `WHERE clause.

```cosmos-db
SELECT c.id, c.name
FROM c
WHERE c.Date >= "2025-09-30"
ORDER BY VectorDistance(c.embedding, [1, 2, 3], false, {dataType:'Float32', quantizedVectorListMultiplier:10, filterPriority: 0.75})
```


## Remarks

- If a multi-dimensional array is provided for `vector_expr_1` or `vector_expr_2`, the function doesn't return a `SimilarityScore` value and doesn't return an error.
