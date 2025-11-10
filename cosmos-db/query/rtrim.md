---
title: RTRIM
description: The `RTRIM` function returns a string expression after it removes trailing whitespace or specified characters.
ms.date: 11/10/2025
---

# `RTRIM` - Query language in Cosmos DB (in Azure and Fabric)

The `RTRIM` function returns a string expression after it removes trailing whitespace or specified characters.

An Azure Cosmos DB for NoSQL system function that returns a string expression with trailing whitespace or specified characters removed.

## Syntax

```nosql
RTRIM(<string_expr_1> [, <string_expr_2>])
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr_1`** | A string expression. |
| **`string_expr_2`** | An optional string expression to be trimmed from `string_expr_1`. If not set, the default is to trim whitespace. |

## Return types

Returns a string expression.

## Examples

This section contains examples of how to use this query language construct.

### Remove trailing whitespace or characters

In this example, the `RTRIM` function is used with various parameters inside a query.

```nosql
SELECT VALUE {
  whitespaceStart: RTRIM("  AdventureWorks"),
  whitespaceStartEnd: RTRIM("  AdventureWorks  "),
  whitespaceEnd: RTRIM("AdventureWorks  "),
  noWhitespace: RTRIM("AdventureWorks"),
  trimSuffix: RTRIM("AdventureWorks", "Works"),
  trimPrefix: RTRIM("AdventureWorks", "Adventure"),
  trimEntireTerm: RTRIM("AdventureWorks", "AdventureWorks"),
  trimEmptyString: RTRIM("AdventureWorks", "")
}
```

```json
[
  {
    "whitespaceStart": "  AdventureWorks",
    "whitespaceStartEnd": "  AdventureWorks",
    "whitespaceEnd": "AdventureWorks",
    "noWhitespace": "AdventureWorks",
    "trimSuffix": "Adventure",
    "trimPrefix": "AdventureWorks",
    "trimEntireTerm": "",
    "trimEmptyString": "AdventureWorks"
  }
]
```

## Remarks

- This function doesn't utilize the index.
