---
title: LOG
description: The `LOG` function returns the natural logarithm of the specified numeric expression.
ms.date: 11/10/2025
---

# `LOG` - Query language in Cosmos DB (in Azure and Fabric)

The `LOG` function returns the natural logarithm of the specified numeric expression.

An Azure Cosmos DB for NoSQL system function that returns the natural logarithm of the specified numeric expression.

## Syntax

```cosmos-db
LOG(<numeric_expr> [, <numeric_base>])
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |
| **`numeric_base`** | An optional numeric value that sets the base for the logarithm. If not set, the default value is the natural logarithm approximately equal to `2.718281828`. |

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Get logarithm of values

In this example, the `LOG` function is used to return the logarithm value of various values.

```cosmos-db
SELECT VALUE {
  logFive: LOG(5),
  logTwoBaseTen: LOG(2, 10)
}
```

```json
[
  {
    "logFive": 1.6094379124341003,
    "logTwoBaseTen": 0.3010299956639812
  }
]
```

## Remarks

- This function doesn't utilize the index.
