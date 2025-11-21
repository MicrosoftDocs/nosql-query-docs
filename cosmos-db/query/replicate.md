---
title: REPLICATE
description: The `REPLICATE` function returns a string value repeated a specific number of times.
ms.date: 11/10/2025
---

# `REPLICATE` - Query language in Cosmos DB (in Azure and Fabric)

The `REPLICATE` function returns a string value repeated a specific number of times.

An Azure Cosmos DB for NoSQL system function that returns a string value repeated a specific number of times.

## Syntax

```cosmos-db
REPLICATE(<string_expr>, <numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr`** | A string expression. |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a string expression.

## Examples

This section contains examples of how to use this query language construct.

### Repeat string value

In this example, the function builds a repeating string.

```cosmos-db
SELECT VALUE {
  catchPhrase: REPLICATE("Cosmic", 3)
}
```

```json
[
  {
    "catchPhrase": "CosmicCosmicCosmic"
  }
]
```

## Remarks

- This function doesn't utilize the index.
- The maximum length of the result is **10,000** characters. - `(length(string_expr) * numeric_expr) <= 10,000`
- If `numeric_expr` is *negative* or *nonfinite*, the result is `undefined`.
