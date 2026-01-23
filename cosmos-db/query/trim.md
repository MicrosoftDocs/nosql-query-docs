---
title: TRIM
description: The `TRIM` function returns a string expression after it removes leading and trailing whitespace or custom characters.
ms.date: 11/10/2025
---

# `TRIM` - Query language in Cosmos DB (in Azure and Fabric)

The `TRIM` function returns a string expression after it removes leading and trailing whitespace or custom characters.

An Azure Cosmos DB system function that returns a string with leading or trailing whitespace trimmed.

## Syntax

```cosmos-db
TRIM(<string_expr_1> [, <string_expr_2>])
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr_1`** | A string expression. |
| **`string_expr_2`** | An optional string expression with a string to trim from `string_expr_1`. If not specified, the default is to trim whitespace. |

## Return types

Returns a string expression.

## Examples

This section contains examples of how to use this query language construct.

### Trim whitespace and characters

In this example, the `TRIM` function is used to trim whitespace and custom characters from strings.

```cosmos-db
SELECT VALUE {
  trimPrefix: TRIM("   AdventureWorks"),
  trimSuffix: TRIM("AdventureWorks   "),
  trimWhitespace: TRIM("   AdventureWorks   "),
  trimWrongCharacter: TRIM("---AdventureWorks---"),
  trimUnderscores: TRIM("___AdventureWorks___", "_"),
  trimHyphens: TRIM("---AdventureWorks---", "-"),
  trimSubsetCharacters: TRIM("-- AdventureWorks --", "-"),
  trimMultipleCharacters: TRIM("-_-AdventureWorks-_-", "-_")
}
```

```json
[
  {
    "trimPrefix": "AdventureWorks",
    "trimSuffix": "AdventureWorks",
    "trimWhitespace": "AdventureWorks",
    "trimWrongCharacter": "---AdventureWorks---",
    "trimUnderscores": "AdventureWorks",
    "trimHyphens": "AdventureWorks",
    "trimSubsetCharacters": " AdventureWorks ",
    "trimMultipleCharacters": "AdventureWorks"
  }
]
```

## Remarks

- This function doesn't utilize the index.
