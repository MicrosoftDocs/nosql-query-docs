---
title: FULLTEXTSCORE
description: The `FULLTEXTSCORE` function returns a BM25 score value that can only be used in an `ORDER BY RANK` clause to sort results from highest relevancy to lowest relevancy of the specified terms.
ms.date: 07/02/2025
---

# `FULLTEXTSCORE` (NoSQL query)

The `FULLTEXTSCORE` function returns a BM25 score value that can only be used in an `ORDER BY RANK` clause to sort results from highest relevancy to lowest relevancy of the specified terms.

## Syntax

```nosql
FULLTEXTSCORE(<property_path>, <string_expr1>, <string_expr2>, ...)
```

## Arguments

| | Description |
| --- | --- |
| **`property_path`** | The property path to search. |
| **`string_expr1`** | The first term to find. |
| **`string_expr2`** | The second term to find. |

## Return types

Returns a BM25 scoring that can be used with `ORDER BY RANK` or `RRF`.

## Examples

This section contains examples of how to use this query language construct.

### Full text score with ORDER BY RANK

In this example, the `FULLTEXTSCORE` function is used with `ORDER BY RANK` to sort from highest relevancy to lowest relevancy.

```nosql
SELECT TOP 10 c.text
FROM c
ORDER BY RANK FULLTEXTSCORE(c.text, "keyword")
```

```json
-- Example result not available (result not provided in markdown)
```

### Full text score with WHERE and ORDER BY RANK

In this example, the `FULLTEXTSCORE` function is used in the `ORDER BY RANK` clause, and `FULLTEXTCONTAINS` is used in the `WHERE` clause.

```nosql
SELECT TOP 10 c.text
FROM c
WHERE FULLTEXTCONTAINS(c.text, "keyword1")
ORDER BY RANK FULLTEXTSCORE(c.text, "keyword1", "keyword2")
```

```json
-- Example result not available (result not provided in markdown)
```

## Remarks

- This function requires enrollment in the Azure Cosmos DB NoSQL Full Text Search feature.
- This function requires a Full Text Index.
- This function can only be used in an `ORDER BY RANK` clause, or as an argument in an `RRF` system function.
- This function can’t be part of a projection (for example, `SELECT FullTextScore(c.text, "keyword") AS Score FROM c` is invalid).
