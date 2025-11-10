---
title: IS_DEFINED
description: The `IS_DEFINED` function returns a boolean indicating if the property has been assigned a value.
ms.date: 11/10/2025
---

# `IS_DEFINED` - Query language in Cosmos DB (in Azure and Fabric)

The `IS_DEFINED` function returns a boolean indicating if the property has been assigned a value.

An Azure Cosmos DB for NoSQL system function that returns true if the property has been assigned a value.

## Syntax

```nosql
IS_DEFINED(<expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`expr`** | Any expression. |

## Return types

Returns a boolean expression.

## Examples

This section contains examples of how to use this query language construct.

### Check if property is defined

In this example, the `IS_DEFINED` function is used to check for the presence of a property within a JSON document.

```nosql
SELECT VALUE {
  isDefined: IS_DEFINED({ "quantity" : 5 }.quantity),
  isNotDefined: IS_DEFINED({ "quantity" : 5 }.name)
}
```

```json
[
  {
    "isDefined": true,
    "isNotDefined": false
  }
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
