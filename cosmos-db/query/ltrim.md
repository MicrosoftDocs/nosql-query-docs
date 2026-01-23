---
title: LTRIM
description: The `LTRIM` function returns a string expression after it removes leading whitespace or specified characters.
ms.date: 11/10/2025
---

# `LTRIM` - Query language in Cosmos DB (in Azure and Fabric)

The `LTRIM` function returns a string expression after it removes leading whitespace or specified characters.

An Azure Cosmos DB system function that returns a string expression with leading whitespace or specified characters removed.

## Syntax

```cosmos-db
LTRIM(<string_expr_1> [, <string_expr_2>])
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

### Remove leading whitespace or characters

In this example, the `LTRIM` function is used with various parameters inside a query.

```cosmos-db
SELECT VALUE {
  whitespaceStart: LTRIM("  AdventureWorks"),
  whitespaceStartEnd: LTRIM("  AdventureWorks  "),
  whitespaceEnd: LTRIM("AdventureWorks  "),
  noWhitespace: LTRIM("AdventureWorks"),
  trimSuffix: LTRIM("AdventureWorks", "Works"),
  trimPrefix: LTRIM("AdventureWorks", "Adventure"),
  trimEntireTerm: LTRIM("AdventureWorks", "AdventureWorks"),
  trimEmptyString: LTRIM("AdventureWorks", "")
}
```

```json
[
  {
    "whitespaceStart": "AdventureWorks",
    "whitespaceStartEnd": "AdventureWorks  ",
    "whitespaceEnd": "AdventureWorks  ",
    "noWhitespace": "AdventureWorks",
    "trimSuffix": "AdventureWorks",
    "trimPrefix": "Works",
    "trimEntireTerm": "",
    "trimEmptyString": "AdventureWorks"
  }
]
```

## Remarks

- This function doesn't utilize the index.
