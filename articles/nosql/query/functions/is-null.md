---
title: IS_NULL
description: The `IS_NULL` function returns a boolean value indicating if the type of the specified expression is `null`.
ms.date: 06/23/2025
---

# `IS_NULL` (NoSQL query)

The `IS_NULL` function returns a boolean value indicating if the type of the specified expression is `null`.

## Syntax

```nosql
IS_NULL(<expr>)
```

## Return types

Returns a boolean expression.

## Examples

This section contains examples of how to use this query language construct.

### Check if values are null

In this example, the `IS_NULL` function is used to check various types for null values.

```nosql
SELECT VALUE {
    booleanIsNull: IS_NULL(true),
    numberIsNull: IS_NULL(15),
    stringIsNull: IS_NULL("AdventureWorks"),
    nullIsNull: IS_NULL(null),
    objectIsNull: IS_NULL({price: 85.23}),
    arrayIsNull: IS_NULL(["red", "blue", "yellow"]),
    populatedObjectPropertyIsNull: IS_NULL({quantity: 25, vendor: null}.quantity),
    invalidObjectPropertyIsNull: IS_NULL({quantity: 25, vendor: null}.size),
    nullObjectPropertyIsNull: IS_NULL({quantity: 25, vendor: null}.vendor)
}
```

```json
[
  {
    "booleanIsNull": false,
    "numberIsNull": false,
    "stringIsNull": false,
    "nullIsNull": true,
    "objectIsNull": false,
    "arrayIsNull": false,
    "populatedObjectPropertyIsNull": false,
    "invalidObjectPropertyIsNull": false,
    "nullObjectPropertyIsNull": true
  }
]
```

## Remarks

- This function benefits from a range index.

## Related content

- [NoSQL query reference](index.md)
- [`<error>`](is-object.md)
