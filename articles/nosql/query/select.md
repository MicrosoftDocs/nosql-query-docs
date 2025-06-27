---
title: SELECT
description: The `SELECT` clause identifies fields to return in query results. It can project specific fields, use the VALUE keyword for scalar results, and supports DISTINCT and JSON projection.
ms.date: 06/27/2025
---

# `SELECT` (NoSQL query)

The `SELECT` clause identifies fields to return in query results. It can project specific fields, use the VALUE keyword for scalar results, and supports DISTINCT and JSON projection.

The `SELECT` clause identifies fields to return in query results in Azure Cosmos DB for NoSQL.

## Syntax

```nosql
SELECT <select_specification>
<select_specification> ::= '*' | [DISTINCT] <object_property_list> | [DISTINCT] VALUE <scalar_expression> [[ AS ] value_alias]
<object_property_list> ::= { <scalar_expression> [ [ AS ] property_alias ] } [ ,...n ]
```

## Arguments

| | Description |
| --- | --- |
| **`select_specification`** | Properties or value to be selected for the result set. |

## Return types

Returns the projected fields or values as specified.

## Examples

This section contains examples of how to use this query language construct.

### Select static string values

In this example, the `SELECT` clause is used to select two static string values and return an array with a single object containing both values.

```nosql
SELECT "Adventure", "Works"
```

```json
[
  {
    "$1": "Adventure",
    "$2": "Works"
  }
]
```

## Remarks

- The `SELECT *` syntax is only valid if the FROM clause has declared exactly one alias.
- Both `SELECT <select_list>` and `SELECT *` are syntactic sugar and can be expressed using simple SELECT statements.
