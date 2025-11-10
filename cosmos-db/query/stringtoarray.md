---
title: STRINGTOARRAY
description: The `STRINGTOARRAY` function converts a string expression to an array.
ms.date: 07/02/2025
---

# `STRINGTOARRAY` (NoSQL query)

The `STRINGTOARRAY` function converts a string expression to an array.

An Azure Cosmos DB for NoSQL system function that returns a string expression converted to an array.

## Syntax

```nosql
STRINGTOARRAY(<string_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr`** | A string expression. |

## Return types

Returns an array.

## Examples

This section contains examples of how to use this query language construct.

### Convert string to array

In this example, the `STRINGTOARRAY` function is used to parse various string values into arrays.

```nosql
SELECT VALUE {
  parseEmptyArray: STRINGTOARRAY("[]"),
  parseArray: STRINGTOARRAY('[ "coats", "gloves", "hats" ]'),
  complexArray: STRINGTOARRAY('[ { "types": [ "coats", "gloves" ] }, [ "hats" ], 76, false, null ]'),
  nestedArray: STRINGTOARRAY('[ [ "coats", "gloves" ], [ "hats" ] ]'),
  invalidArray: STRINGTOARRAY("[ 'coats', 'gloves', 'hats' ]"),
  parseUndefined: STRINGTOARRAY(undefined),
  parseNull: STRINGTOARRAY(null)
}
```

```json
[
  {
    "parseEmptyArray": [],
    "parseArray": [ "coats", "gloves", "hats" ],
    "complexArray": [
      {
        "types": [ "coats", "gloves" ]
      },
      [ "hats" ],
      76,
      false,
      null
    ],
    "nestedArray": [
      [ "coats", "gloves" ],
      [ "hats" ]
    ]
  }
]
```

## Remarks

- This function doesn't utilize the index.
