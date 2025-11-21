---
title: STRINGTOBOOLEAN
description: The `STRINGTOBOOLEAN` function converts a string expression to a boolean.
ms.date: 11/10/2025
---

# `STRINGTOBOOLEAN` - Query language in Cosmos DB (in Azure and Fabric)

The `STRINGTOBOOLEAN` function converts a string expression to a boolean.

An Azure Cosmos DB for NoSQL system function that returns a string expression converted to a boolean.

## Syntax

```cosmos-db
STRINGTOBOOLEAN(<string_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr`** | A string expression. |

## Return types

Returns a boolean value.

## Examples

This section contains examples of how to use this query language construct.

### Convert string to boolean

In this example, the `STRINGTOBOOLEAN` function is used to parse various string values into booleans.

```cosmos-db
SELECT VALUE {
  parseBooleanString: STRINGTOBOOLEAN("true"),
  parseWithPrefix: STRINGTOBOOLEAN("true  "),
  parseWithSuffix: STRINGTOBOOLEAN("  false"),
  parseWithWhitespace: STRINGTOBOOLEAN("  false  "),
  parseBoolean: STRINGTOBOOLEAN(true),
  parseUndefined: STRINGTOBOOLEAN(undefined),
  parseNull: STRINGTOBOOLEAN(null)
}
```

```json
[
  {
    "parseBooleanString": true,
    "parseWithPrefix": true,
    "parseWithSuffix": false,
    "parseWithWhitespace": false
  }
]
```

## Remarks

- This function doesn't utilize the index.
