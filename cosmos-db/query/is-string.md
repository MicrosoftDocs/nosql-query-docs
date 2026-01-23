---
title: IS_STRING
description: The `IS_STRING` function returns a boolean value indicating if the type of the specified expression is a string.
ms.date: 11/10/2025
---

# `IS_STRING` - Query language in Cosmos DB (in Azure and Fabric)

The `IS_STRING` function returns a boolean value indicating if the type of the specified expression is a string.

An Azure Cosmos DB system function that returns true if the type of the specified expression is a string.

## Syntax

```cosmos-db
IS_STRING(<expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`expr`** | Any expression. |

## Return types

Returns a boolean expression.

## Examples

This section contains examples of how to use this query language construct.

### Check if value is string

In this example, the `IS_STRING` function is used to check various values to see if they're a string.

```cosmos-db
SELECT VALUE {
  isBooleanAString: IS_STRING(true),
  isNumberAString: IS_STRING(1),
  isStringAString: IS_STRING("value"),
  isArrayAString: IS_STRING([ "green", "red", "yellow" ]),
  isNullAString: IS_STRING(null),
  isObjectAString: IS_STRING({ "name": "Tecozow coat" }),
  isObjectStringPropertyAString: IS_STRING({ "name": "Tecozow coat" }.name),
  isObjectBooleanPropertyAString: IS_STRING({ "onSale": false }.onSale),
  isUndefinedAString: IS_STRING({}.category)
}
```

```json
[
  {
    "isBooleanAString": false,
    "isNumberAString": false,
    "isStringAString": true,
    "isArrayAString": false,
    "isNullAString": false,
    "isObjectAString": false,
    "isObjectStringPropertyAString": true,
    "isObjectBooleanPropertyAString": false,
    "isUndefinedAString": false
  }
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
