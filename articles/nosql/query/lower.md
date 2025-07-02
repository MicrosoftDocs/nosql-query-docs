---
title: LOWER
description: The `LOWER` function returns a string expression after converting uppercase character data to lowercase.
ms.date: 07/02/2025
---

# `LOWER` (NoSQL query)

The `LOWER` function returns a string expression after converting uppercase character data to lowercase.

An Azure Cosmos DB for NoSQL system function that returns a string expression with uppercase characters converted to lowercase.

## Syntax

```nosql
LOWER(<string_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr`** | A string expression. |

## Return types

Returns a string expression.

## Examples

This section contains examples of how to use this query language construct.

### Convert string to lowercase

In this example, the `LOWER` function is used to modify various strings.

```nosql
SELECT VALUE {
  lowercase: LOWER("adventureworks"),
  uppercase: LOWER("ADVENTUREWORKS"),
  camelCase: LOWER("adventureWorks"),
  pascalCase: LOWER("AdventureWorks"),
  upperSnakeCase: LOWER("ADVENTURE_WORKS")
}
```

```json
[
  {
    "lowercase": "adventureworks",
    "uppercase": "adventureworks",
    "camelCase": "adventureworks",
    "pascalCase": "adventureworks",
    "upperSnakeCase": "adventure_works"
  }
]
```

## Remarks

- This function doesn't utilize the index.
