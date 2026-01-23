---
title: STRINGTONUMBER
description: The `STRINGTONUMBER` function converts a string expression to a number.
ms.date: 11/10/2025
---

# `STRINGTONUMBER` - Query language in Cosmos DB (in Azure and Fabric)

The `STRINGTONUMBER` function converts a string expression to a number.

The `STRINGTONUMBER` function converts a string expression to a number in Azure Cosmos DB.

## Syntax

```cosmos-db
STRINGTONUMBER(<string_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr`** | A string expression. |

## Return types

Returns a number value.

## Examples

This section contains examples of how to use this query language construct.

### Convert string to number

In this example, the `STRINGTONUMBER` function is used to convert various string expressions to numbers.

```cosmos-db
SELECT VALUE {
  parseIntegerString: STRINGTONUMBER("100"),
  parseDecimalString: STRINGTONUMBER("3.14"),
  parseWithWhitespace: STRINGTONUMBER("   60   "),
  parseScientific: STRINGTONUMBER("-1.79769e+308"),
  parseInvalid: STRINGTONUMBER("Hello"),
  parseUndefined: STRINGTONUMBER(undefined),
  parseNull: STRINGTONUMBER(null),
  parseNaN: STRINGTONUMBER(NaN),
  parseInfinity: STRINGTONUMBER(Infinity)
}
```

```json
[
  {
    "parseIntegerString": 100,
    "parseDecimalString": 3.14,
    "parseWithWhitespace": 60,
    "parseScientific": -1.79769e+308
  }
]
```

## Remarks

- This function doesn't utilize the index.
- String expressions are parsed as a JSON number expression.
- Numbers in JSON must be an integer or a floating point.
- If the expression can't be converted, the function returns `undefined`.
