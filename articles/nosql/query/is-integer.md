---
title: IS_INTEGER
description: The `IS_INTEGER` function returns a boolean indicating if a number is a 64-bit signed integer. 64-bit signed integers range from `-9,223,372,036,854,775,808` to `9,223,372,036,854,775,807`. For more information, see [__int64](/cpp/cpp/int8-int16-int32-int64).
ms.date: 06/30/2025
---

# `IS_INTEGER` (NoSQL query)

The `IS_INTEGER` function returns a boolean indicating if a number is a 64-bit signed integer. 64-bit signed integers range from `-9,223,372,036,854,775,808` to `9,223,372,036,854,775,807`. For more information, see [__int64](/cpp/cpp/int8-int16-int32-int64).

An Azure Cosmos DB for NoSQL system function that returns a boolean indicating if a number is a 64-bit signed integer.

## Syntax

```nosql
IS_INTEGER(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a boolean.

## Examples

This section contains examples of how to use this query language construct.

### Check if number is integer

In this example, the `IS_INTEGER` function is demonstrated with various static values.

```nosql
SELECT VALUE {
  smallDecimalValue: IS_INTEGER(3454.123),
  integerValue: IS_INTEGER(5523432),
  minIntegerValue: IS_INTEGER(-9223372036854775808),
  maxIntegerValue: IS_INTEGER(9223372036854775807),
  outOfRangeValue: IS_INTEGER(18446744073709551615)
}
```

```json
[
  {
    "smallDecimalValue": false,
    "integerValue": true,
    "minIntegerValue": true,
    "maxIntegerValue": true,
    "outOfRangeValue": false
  }
]
```

## Remarks

- This function benefits from the use of a range index. For more information, see [range indexes](/azure/cosmos-db/index-policy#includeexclude-strategy).
