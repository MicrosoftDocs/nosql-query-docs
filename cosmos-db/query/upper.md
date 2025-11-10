---
title: UPPER
description: The `UPPER` function returns a string expression after converting lowercase character data to uppercase.
ms.date: 11/10/2025
---

# `UPPER` - Query language in Cosmos DB (in Azure and Fabric)

The `UPPER` function returns a string expression after converting lowercase character data to uppercase.

An Azure Cosmos DB for NoSQL system function that returns a string expression with lowercase characters converted to uppercase.

## Syntax

```nosql
UPPER(<string_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr`** | A string expression. |

## Return types

Returns a string expression.

## Examples

This section contains examples of how to use this query language construct.

### Convert strings to uppercase

In this example, the `UPPER` function is used to convert various string cases to uppercase.

```nosql
SELECT VALUE {
  lowercase: UPPER("adventureworks"),
  uppercase: UPPER("ADVENTUREWORKS"),
  camelCase: UPPER("adventureWorks"),
  pascalCase: UPPER("AdventureWorks"),
  upperSnakeCase: UPPER("ADVENTURE_WORKS")
}
```

```json
[
  {
    "lowercase": "ADVENTUREWORKS",
    "uppercase": "ADVENTUREWORKS",
    "camelCase": "ADVENTUREWORKS",
    "pascalCase": "ADVENTUREWORKS",
    "upperSnakeCase": "ADVENTURE_WORKS"
  }
]
```

## Remarks

- This function doesn't utilize the index.
