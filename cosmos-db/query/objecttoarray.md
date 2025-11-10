---
title: OBJECTTOARRAY
description: The `OBJECTTOARRAY` function converts field/value pairs in a JSON object to a JSON array.
ms.date: 11/10/2025
---

# `OBJECTTOARRAY` - Query language in Cosmos DB (in Azure and Fabric)

The `OBJECTTOARRAY` function converts field/value pairs in a JSON object to a JSON array.

## Syntax

```nosql
OBJECTTOARRAY(<object_expr> [, <string_expr_1>, <string_expr_2>])
```

## Arguments

| | Description |
| --- | --- |
| **`object_expr`** | An object expression with properties in field/value pairs. |
| **`string_expr_1`** | A string expression with a name for the field representing the *field* portion of the original field/value pair. |
| **`string_expr_2`** | A string expression with a name for the field representing the *value* portion of the original field/value pair. |

## Return types

Returns an array of elements with two fields, either `k` and `v` or custom-named fields.

## Examples

This section contains examples of how to use this query language construct.

### Convert object to array

In this example, the `OBJECTTOARRAY` function is used to convert a JSON object to an array.

```nosql
SELECT VALUE
  OBJECTTOARRAY({
    "a": "12345",
    "b": "67890"
  })
```

```json
[
  [
    {
      "k": "a",
      "v": "12345"
    },
    {
      "k": "b",
      "v": "67890"
    }
  ]
]
```
