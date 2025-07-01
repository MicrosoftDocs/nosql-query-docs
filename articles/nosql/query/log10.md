---
title: LOG10
description: The `LOG10` function returns the base-10 logarithm of the specified numeric expression.
ms.date: 07/01/2025
---

# `LOG10` (NoSQL query)

The `LOG10` function returns the base-10 logarithm of the specified numeric expression.

An Azure Cosmos DB for NoSQL system function that returns the base-10 logarithm of the specified numeric expression.

## Syntax

```nosql
LOG10(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Get base-10 logarithm of values

In this example, the `LOG10` function is used to return the logarithm value of various values.

```nosql
SELECT VALUE {
  logFiveBaseTen: LOG10(5),
  logTwoBaseTen: LOG10(2),
  logHundredBaseTen: LOG10(100)
}
```

```json
[
  {
    "logFiveBaseTen": 0.6989700043360189,
    "logTwoBaseTen": 0.3010299956639812,
    "logHundredBaseTen": 2
  }
]
```

## Remarks

- This function doesn't utilize the index.
