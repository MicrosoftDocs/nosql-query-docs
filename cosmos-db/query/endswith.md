---
title: ENDSWITH
description: The `ENDSWITH` function returns a boolean indicating whether a string ends with the specified suffix. Optionally, the comparison can be case-insensitive.
ms.date: 11/10/2025
---

# `ENDSWITH` - Query language in Cosmos DB (in Azure and Fabric)

The `ENDSWITH` function returns a boolean indicating whether a string ends with the specified suffix. Optionally, the comparison can be case-insensitive.

## Syntax

```nosql
ENDSWITH(<string_expr_1>, <string_expr_2> [, <bool_expr>])
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr`** | The string to evaluate. |
| **`suffix_expr`** | The suffix to check for. |
| **`bool_expr`** | Optional value for ignoring case. When set to `true`, this function does a case-insensitive search. When unspecified, this default value is `false`. |

## Return types

Returns a boolean value.

## Examples

This section contains examples of how to use this query language construct.

### Check if string ends with suffix

In this example, the `ENDSWITH` function is used to check if a string ends with various suffixes and case options.

```nosql
SELECT VALUE {
  endsWithWrongSuffix: ENDSWITH("AdventureWorks", "Adventure"),
  endsWithCorrectSuffix: ENDSWITH("AdventureWorks", "Works"),
  endsWithSuffixWrongCase: ENDSWITH("AdventureWorks", "works"),
  endsWithSuffixCaseInsensitive: ENDSWITH("AdventureWorks", "works", true)
}
```

```json
[
  {
    "endsWithWrongSuffix": false,
    "endsWithCorrectSuffix": true,
    "endsWithSuffixWrongCase": false,
    "endsWithSuffixCaseInsensitive": true
  }
]
```

## Remarks

- The `ENDSWITH` function is useful for string pattern matching and filtering.
