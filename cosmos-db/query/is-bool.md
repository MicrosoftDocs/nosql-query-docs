---
title: IS_BOOL
description: The `IS_BOOL` function returns a boolean value indicating if the type of the specified expression is a boolean.
ms.date: 11/10/2025
---

# `IS_BOOL` - Query language in Cosmos DB (in Azure and Fabric)

The `IS_BOOL` function returns a boolean value indicating if the type of the specified expression is a boolean.

An Azure Cosmos DB for NoSQL system function that returns a boolean indicating whether an expression is a boolean.

## Syntax

```cosmos-db
IS_BOOL(<expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`expr`** | Any expression. |

## Return types

Returns a boolean expression.

## Examples

This section contains examples of how to use this query language construct.

### Check if value is boolean

In this example, the `IS_BOOL` function is used to check objects of various types.

```cosmos-db
SELECT VALUE {
  booleanIsBool: IS_BOOL(true),
  numberIsBool: IS_BOOL(65),
  stringIsBool: IS_BOOL("AdventureWorks"),
  nullIsBool: IS_BOOL(null),
  objectIsBool: IS_BOOL({size: "small"}),
  arrayIsBool: IS_BOOL([25344, 82947]),
  arrayObjectPropertyIsBool: IS_BOOL({skus: [25344, 82947], vendors: null}.skus),
  invalidObjectPropertyIsBool: IS_BOOL({skus: [25344, 82947], vendors: null}.size),
  nullObjectPropertyIsBool: IS_BOOL({skus: [25344, 82947], vendors: null}.vendor)
}
```

```json
[
  {
    "booleanIsBool": true,
    "numberIsBool": false,
    "stringIsBool": false,
    "nullIsBool": false,
    "objectIsBool": false,
    "arrayIsBool": false,
    "arrayObjectPropertyIsBool": false,
    "invalidObjectPropertyIsBool": false,
    "nullObjectPropertyIsBool": false
  }
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
