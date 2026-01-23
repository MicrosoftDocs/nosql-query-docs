---
title: ARRAY_CONTAINS_ANY
description: The `ARRAY_CONTAINS_ANY` function returns a boolean indicating whether the array contains any of the specified values.
ms.date: 01/23/2026
---

# `ARRAY_CONTAINS_ANY` - Query language in Cosmos DB (in Azure and Fabric)

The `ARRAY_CONTAINS_ANY` function returns a boolean indicating whether the array contains any of the specified values.

## Syntax

```cosmos-db
ARRAY_CONTAINS_ANY(<array_expr>, <expr> [, exprN])
```

## Arguments

| | Description |
| --- | --- |
| **`array_expr`** | An array expression. |
| **`expr`** | Expression to search for within the array. |
| **`exprN`** | One or more extra expressions to search for within the array. |

## Return types

Returns a boolean value.

## Examples

This section contains examples of how to use this query language construct.

### Array contains any examples

In this example, the `ARRAY_CONTAINS_ANY` function is used to check for specific values or objects in an array.

```cosmos-db
SELECT VALUE {
  matchesEntireArray: ARRAY_CONTAINS_ANY([1, true, "3", [1,2,3]], 1, true, "3", [1,2,3]),
  matchesSomeValues: ARRAY_CONTAINS_ANY([1, 2, 3, 4], 2, 3, 4, 5),
  matchSingleValue: ARRAY_CONTAINS_ANY([1, 2, 3, 4], 1, undefined),
  noMatches: ARRAY_CONTAINS_ANY([1, 2, 3, 4], 5, 6, 7, 8),
  emptyArray: ARRAY_CONTAINS_ANY([], 1, 2, 3),
  noMatchesUndefined: ARRAY_CONTAINS_ANY([1, 2, 3, 4], 5, undefined)
}
```

```json
[
  {
    "emptyArray": false,
    "matchSingleValue": true,
    "matchesEntireArray": true,
    "matchesSomeValues": true,
    "noMatches": false
  }
]
```

> [!NOTE]
> In the examples above, `undefined` is used as a search value. When `undefined` is passed as an argument, it doesn't match any value in the array. Only explicitly defined values are compared.

## Remarks

- This function doesn't utilize the index.
