---
title: CONTAINS
description: The `CONTAINS` function returns a boolean indicating whether the first string expression contains the second string expression.
ms.date: 11/10/2025
---

# `CONTAINS` (NoSQL query)

The `CONTAINS` function returns a boolean indicating whether the first string expression contains the second string expression.

## Syntax

```nosql
CONTAINS(<string_expr_1>, <string_expr_2> [, <bool_expr>])
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr_1`** | The first string to search. |
| **`string_expr_2`** | The second string to find. |
| **`bool_expr`** | Optional boolean value for ignoring case. When set to `true`, `CONTAINS` performs a case-insensitive search. When `unspecified`, this value defaults to `false`. |

## Return types

Returns a boolean expression.

## Examples

This section contains examples of how to use this query language construct.

### Contains string examples

In this example, the `CONTAINS` function is used to check for substrings in a string.

```nosql
SELECT VALUE {
  containsPrefix: CONTAINS("AdventureWorks", "Adventure"), 
  containsSuffix: CONTAINS("AdventureWorks", "Works"),
  containsWrongCase: CONTAINS("AdventureWorks", "adventure"), 
  containsWrongCaseValidateCase: CONTAINS("AdventureWorks", "adventure", false), 
  containsWrongCaseIgnoreCase: CONTAINS("AdventureWorks", "works", true),
  containsMismatch: CONTAINS("AdventureWorks", "Contoso")
}
```

```json
[
  {
    "containsPrefix": true,
    "containsSuffix": true,
    "containsWrongCase": false,
    "containsWrongCaseValidateCase": false,
    "containsWrongCaseIgnoreCase": true,
    "containsMismatch": false
  }
]
```

## Remarks

- This function performs a full scan.
