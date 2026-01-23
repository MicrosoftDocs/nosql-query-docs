---
title: IS_OBJECT
description: The `IS_OBJECT` function returns a boolean value indicating if the type of the specified expression is a JSON object.
ms.date: 11/10/2025
---

# `IS_OBJECT` - Query language in Cosmos DB (in Azure and Fabric)

The `IS_OBJECT` function returns a boolean value indicating if the type of the specified expression is a JSON object.

An Azure Cosmos DB system function that returns true if the type of the specified expression is a JSON object.

## Syntax

```cosmos-db
IS_OBJECT(<expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`expr`** | Any expression. |

## Return types

Returns a boolean expression.

## Examples

This section contains examples of how to use this query language construct.

### Check if value is object

In this example, the `IS_OBJECT` function is used to check various values to see if they're an object.

```cosmos-db
SELECT VALUE {
  isBooleanAnObject: IS_OBJECT(true),
  isNumberAnObject: IS_OBJECT(1),
  isStringAnObject: IS_OBJECT("value"),
  isArrayAnObject: IS_OBJECT([ "green", "red", "yellow" ]),
  isNullAnObject: IS_OBJECT(null),
  isObjectAnObject: IS_OBJECT({ "name": "Tecozow coat" }),
  isObjectStringPropertyAnObject: IS_OBJECT({ "name": "Tecozow coat" }.name),
  isObjectObjectPropertyAnObject: IS_OBJECT({ "quantity": { "count": 0 } }.quantity),
  isUndefinedAnObject: IS_OBJECT({}.category)
}
```

```json
[
  {
    "isBooleanAnObject": false,
    "isNumberAnObject": false,
    "isStringAnObject": false,
    "isArrayAnObject": false,
    "isNullAnObject": false,
    "isObjectAnObject": true,
    "isObjectStringPropertyAnObject": false,
    "isObjectObjectPropertyAnObject": true,
    "isUndefinedAnObject": false
  }
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
