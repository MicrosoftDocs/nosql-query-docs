---
title: CONTAINS_ALL_CS
description: This function returns a boolean value indicating if the source string contains all strings from a list through case-sensitive search.
ms.date: 11/10/2025
---

# CONTAINS_ALL_CS (NoSQL query)

Returns a boolean value indicating if the source string contains all strings from a list through case-sensitive search.

## Syntax

```nosql
CONTAINS_ALL_CS(<string_expr>, <expr1>, ... [,<exprN>])  
```  

## Arguments

| | Description |
| --- | --- |
| **`string_expr`** | The string expression to search in. |
| **`expr1`** | The first string expression to search for. |
| **`exprN` *(Optional)*** | Additional string expressions to search for. |

## Return types

Returns a Boolean expression.

## Examples

The following example shows various uses of the CONTAINS_ALL_CS function with case-sensitive matching.

```nosql
SELECT VALUE {
    "case1": CONTAINS_ALL_CS("Have a nice day!", "have", "nice", "day!"),
    "case2": CONTAINS_ALL_CS("Have a nice day!", "HAVE", "NICE", "DAY!"),
    "case3": CONTAINS_ALL_CS("Have a nice day!", "had", "nice", "day!"),
    "case4": CONTAINS_ALL_CS("Have a nice day!", undefined, "nice", "day!"),
    "case5": CONTAINS_ALL_CS("Have a nice day!", undefined, "had")
}
```

```json
[
    {
        "case1": true,
        "case2": false,
        "case3": false,
        "case4": undefined,
        "case5": false
    }
]
```

## Remarks

- This function is equivalent to `CONTAINS(<string_expr>, expr1, false) AND ... AND CONTAINS(<string_expr>, exprN, false)`.
- This function performs a full scan.

## Related content

- [`CONTAINS_ALL_CI`](contains-all-ci.md)
- [`CONTAINS`](contains.md)
