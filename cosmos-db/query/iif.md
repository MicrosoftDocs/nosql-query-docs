---
title: IIF
description: The `IIF` function returns one of two values, depending on whether the Boolean expression evaluates to true or false.
ms.date: 11/10/2025
---

# `IIF` - Query language in Cosmos DB (in Azure and Fabric)

The `IIF` function returns one of two values, depending on whether the Boolean expression evaluates to true or false.

## Syntax

```nosql
IIF(<boolean_expr>, <true_expr>, <false_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`boolean_expr`** | The Boolean expression to evaluate. |
| **`true_expr`** | The value returned if the Boolean expression evaluates to true. |
| **`false_expr`** | The value returned if the Boolean expression evaluates to false. |

## Return types

Returns the value of `true_expr` if the Boolean expression is true; otherwise, returns the value of `false_expr`.

## Examples

This section contains examples of how to use this query language construct.

### Conditional evaluation

In this example, the `IIF` function is used to return different values based on the Boolean expression.

```nosql
SELECT VALUE {
  evalTrue: IIF(true, 123, 456),
  evalFalse: IIF(false, 123, 456),
  evalNumberNotTrue: IIF(123, 123, 456),
  evalStringNotTrue: IIF("ABC", 123, 456),
  evalArrayNotTrue: IIF([1,2,3], 123, 456),
  evalObjectNotTrue: IIF({"name": "Alice", "age": 20}, 123, 456)
}
```

```json
[
  {
    "evalTrue": 123,
    "evalFalse": 456,
    "evalNumberNotTrue": 456,
    "evalStringNotTrue": 456,
    "evalArrayNotTrue": 456,
    "evalObjectNotTrue": 456
  }
]
```
