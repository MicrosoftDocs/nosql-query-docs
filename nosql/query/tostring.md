---
title: TOSTRING
description: The `TOSTRING` function returns a string representation of a value.
ms.date: 07/02/2025
---

# `TOSTRING` (NoSQL query)

The `TOSTRING` function returns a string representation of a value.

An Azure Cosmos DB for NoSQL system function that returns a value converted to a string.

## Syntax

```nosql
TOSTRING(<expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`expr`** | Any expression. |

## Return types

Returns a string expression.

## Examples

This section contains examples of how to use this query language construct.

### Convert values to string

In this example, the `TOSTRING` function is used to convert multiple scalar and object values to a string.

```nosql
SELECT VALUE {
  integerToString: TOSTRING(125),
  floatToString: TOSTRING(0.1234),
  booleanToString: TOSTRING(false),
  arrayToString: TOSTRING([ 1, 2, 3 ]),
  objectToString: TOSTRING({ "department": "Bicycles" }),
  stringToString: TOSTRING("Hello World"),
  undefinedToString: TOSTRING(undefined),
  notANumberToString: TOSTRING(NaN),
  infinityToString: TOSTRING(Infinity)
}
```

```json
[
  {
    "integerToString": "125",
    "floatToString": "0.1234",
    "booleanToString": "false",
    "arrayToString": "[1,2,3]",
    "objectToString": "{\"department\":\"Bicycles\"}",
    "stringToString": "Hello World",
    "notANumberToString": "NaN",
    "infinityToString": "Infinity"
  }
]
```

## Remarks

- This function doesn't utilize the index.
