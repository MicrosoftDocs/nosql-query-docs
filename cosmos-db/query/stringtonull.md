---
title: STRINGTONULL
description: The `STRINGTONULL` function converts a string expression to `null`.
ms.date: 11/10/2025
---

# `STRINGTONULL` - Query language in Cosmos DB (in Azure and Fabric)

The `STRINGTONULL` function converts a string expression to `null`.

The `STRINGTONULL` function converts a string expression to `null` in Azure Cosmos DB for NoSQL.

## Syntax

```cosmos-db
STRINGTONULL(<string_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr`** | A string expression. |

## Return types

Returns a `null`.

## Examples

This section contains examples of how to use this query language construct.

### Convert string to null

In this example, the `STRINGTONULL` function is used to convert various string expressions to `null`.

```cosmos-db
SELECT VALUE {
  parseNullString: STRINGTONULL("null"),
  parseWithPrefix: STRINGTONULL("null  "),
  parseWithSuffix: STRINGTONULL("  null"),
  parseWithWhitespace: STRINGTONULL("  null  "),
  parseUppercase: STRINGTONULL("NULL"),
  parseTitlecase: STRINGTONULL("Null"),
  parseNull: STRINGTONULL(null),
  parseUndefined: STRINGTONULL(undefined)
}
```

```json
[
  {
    "parseNullString": null,
    "parseWithPrefix": null,
    "parseWithSuffix": null,
    "parseWithWhitespace": null
  }
]
```

## Remarks

- This function doesn't utilize the index.
- If the expression can't be converted, the function returns `undefined`.
