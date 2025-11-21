---
title: IS_NUMBER
description: The `IS_NUMBER` function returns a boolean value indicating if the type of the specified expression is a number.
ms.date: 11/10/2025
---

# `IS_NUMBER` - Query language in Cosmos DB (in Azure and Fabric)

The `IS_NUMBER` function returns a boolean value indicating if the type of the specified expression is a number.

An Azure Cosmos DB for NoSQL system function that returns true if the type of the specified expression is a number.

## Syntax

```cosmos-db
IS_NUMBER(<expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`expr`** | Any expression. |

## Return types

Returns a boolean expression.

## Examples

This section contains examples of how to use this query language construct.

### Check if value is number

In this example, the `IS_NUMBER` function is used to check various values to see if they're a number.

```cosmos-db
SELECT VALUE {
  isBooleanANumber: IS_NUMBER(true),
  isNumberANumber: IS_NUMBER(1),
  isStringANumber: IS_NUMBER("value"),
  isNullANumber: IS_NUMBER(null),
  isObjectANumber: IS_NUMBER({ "name": "Tecozow coat" }),
  isObjectStringPropertyANumber: IS_NUMBER({ "name": "Tecozow coat" }.name),
  isObjectNumberPropertyANumber: IS_NUMBER({ "quantity": 0 }.quantity),
  isUndefinedANumber: IS_NUMBER({}.category)
}
```

```json
[
  {
    "isBooleanANumber": false,
    "isNumberANumber": true,
    "isStringANumber": false,
    "isNullANumber": false,
    "isObjectANumber": false,
    "isObjectStringPropertyANumber": false,
    "isObjectNumberPropertyANumber": true,
    "isUndefinedANumber": false
  }
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
