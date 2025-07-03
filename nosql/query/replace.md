---
title: REPLACE
description: The `REPLACE` function returns a string with all occurrences of a specified string replaced.
ms.date: 07/02/2025
---

# `REPLACE` (NoSQL query)

The `REPLACE` function returns a string with all occurrences of a specified string replaced.

An Azure Cosmos DB for NoSQL system function that returns a string with all occurrences of a specified string replaced.

## Syntax

```nosql
REPLACE(<string_expr_1>, <string_expr_2>, <string_expr_3>)
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr_1`** | A string expression to be searched. |
| **`string_expr_2`** | A string expression to be found within `string_expr_1`. |
| **`string_expr_3`** | A string expression with the text to replace all occurrences of `string_expr_2` within `string_expr_1`. |

## Return types

Returns a string expression.

## Examples

This section contains examples of how to use this query language construct.

### Replace substring in string

In this example, a static value is replaced in the string.

```nosql
SELECT VALUE {
  replaceSubstring: REPLACE("AdventureWorksLT", "LT", "LT2")
}
```

```json
[
  {
    "replaceSubstring": "AdventureWorksLT2"
  }
]
```

## Remarks

- This function doesn't utilize the index.
