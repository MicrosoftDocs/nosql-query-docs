---
title: IS_PRIMITIVE
description: The `IS_PRIMITIVE` function returns a boolean value indicating if the type of the specified expression is a primitive (string, boolean, numeric, or null).
ms.date: 06/30/2025
---

# `IS_PRIMITIVE` (NoSQL query)

The `IS_PRIMITIVE` function returns a boolean value indicating if the type of the specified expression is a primitive (string, boolean, numeric, or null).

An Azure Cosmos DB for NoSQL system function that returns true if the type of the specified expression is a primitive (string, boolean, numeric, or null).

## Syntax

```nosql
IS_PRIMITIVE(<expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`expr`** | Any expression. |

## Return types

Returns a boolean expression.

## Examples

This section contains examples of how to use this query language construct.

### Check if value is primitive

In this example, the `IS_PRIMITIVE` function is used to check various values to see if they're a primitive.

```nosql
SELECT VALUE {
  isBooleanAPrimitive: IS_PRIMITIVE(true),
  isNumberAPrimitive: IS_PRIMITIVE(1),
  isStringAPrimitive: IS_PRIMITIVE("value"),
  isArrayAPrimitive: IS_PRIMITIVE([ "green", "red", "yellow" ]),
  isNullAPrimitive: IS_PRIMITIVE(null),
  isObjectAPrimitive: IS_PRIMITIVE({ "name": "Tecozow coat" }),
  isObjectStringPropertyAPrimitive: IS_PRIMITIVE({ "name": "Tecozow coat" }.name),
  isObjectBooleanPropertyAPrimitive: IS_PRIMITIVE({ "onSale": false }.onSale),
  isUndefinedAPrimitive: IS_PRIMITIVE({}.category)
}
```

```json
[
  {
    "isBooleanAPrimitive": true,
    "isNumberAPrimitive": true,
    "isStringAPrimitive": true,
    "isArrayAPrimitive": false,
    "isNullAPrimitive": true,
    "isObjectAPrimitive": false,
    "isObjectStringPropertyAPrimitive": true,
    "isObjectBooleanPropertyAPrimitive": true,
    "isUndefinedAPrimitive": false
  }
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
