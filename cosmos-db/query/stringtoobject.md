---
title: STRINGTOOBJECT
description: The `STRINGTOOBJECT` function converts a string expression to an object.
ms.date: 11/10/2025
---

# `STRINGTOOBJECT` - Query language in Cosmos DB (in Azure and Fabric)

The `STRINGTOOBJECT` function converts a string expression to an object.

The `STRINGTOOBJECT` function converts a string expression to an object in Azure Cosmos DB for NoSQL.

## Syntax

```cosmos-db
STRINGTOOBJECT(<string_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr`** | A string expression. |

## Return types

Returns an object.

## Examples

This section contains examples of how to use this query language construct.

### Convert string to object

In this example, the `STRINGTOOBJECT` function is used to convert various string expressions to objects.

```cosmos-db
SELECT VALUE {
  parseEmptyObject: STRINGTOOBJECT("{}"),
  parseObjectWithProperty: STRINGTOOBJECT('{"isAvailable": true}'),
  parseObjectNested: STRINGTOOBJECT('{"division": {"name": "Sales"}}'),
  parseObjectInvalidJson: STRINGTOOBJECT("{'price': 27.55}"),
  parseUndefined: STRINGTONUMBER(undefined),
  parseNull: STRINGTONUMBER(null)
}
```

```json
[
  {
    "parseEmptyObject": {},
    "parseObjectWithProperty": {
      "isAvailable": true
    },
    "parseObjectNested": {
      "division": {
        "name": "Sales"
      }
    }
  }
]
```

## Remarks

- This function doesn't utilize the index.
- If the expression can't be converted, the function returns `undefined`.
- Nested string values must be written with double quotes to be valid.
