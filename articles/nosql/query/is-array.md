---
title: IS_ARRAY
description: The `IS_ARRAY` function returns a boolean value indicating if the type of the specified expression is an array.
ms.date: 06/30/2025
---

# `IS_ARRAY` (NoSQL query)

The `IS_ARRAY` function returns a boolean value indicating if the type of the specified expression is an array.

An Azure Cosmos DB for NoSQL system function that returns a boolean indicating whether an expression is an array.

## Syntax

```nosql
IS_ARRAY(<expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`expr`** | Any expression. |

## Return types

Returns a boolean expression.

## Examples

This section contains examples of how to use this query language construct.

### Check if value is array

In this example, the `IS_ARRAY` function is used to check objects of various types.

```nosql
SELECT VALUE {
  booleanIsArray: IS_ARRAY(true),
  numberIsArray: IS_ARRAY(65),
  stringIsArray: IS_ARRAY("AdventureWorks"),
  nullIsArray: IS_ARRAY(null),
  objectIsArray: IS_ARRAY({size: "small"}),
  arrayIsArray: IS_ARRAY([25344, 82947]),
  arrayObjectPropertyIsArray: IS_ARRAY({skus: [25344, 82947], vendors: null}.skus),
  invalidObjectPropertyIsArray: IS_ARRAY({skus: [25344, 82947], vendors: null}.size),
  nullObjectPropertyIsArray: IS_ARRAY({skus: [25344, 82947], vendors: null}.vendor)
}
```

```json
[
  {
    "booleanIsArray": false,
    "numberIsArray": false,
    "stringIsArray": false,
    "nullIsArray": false,
    "objectIsArray": false,
    "arrayIsArray": true,
    "arrayObjectPropertyIsArray": true,
    "invalidObjectPropertyIsArray": false,
    "nullObjectPropertyIsArray": false
  }
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
