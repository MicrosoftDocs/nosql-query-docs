---
title: LOWER
description: The `LOWER` function returns a string expression after converting uppercase character data to lowercase.
ms.date: 11/10/2025
---

# `LOWER` - Query language in Cosmos DB (in Azure and Fabric)

The `LOWER` function returns a string expression after converting uppercase character data to lowercase.

An Azure Cosmos DB system function that returns a string expression with uppercase characters converted to lowercase.

## Syntax

```cosmos-db
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

```cosmos-db
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
