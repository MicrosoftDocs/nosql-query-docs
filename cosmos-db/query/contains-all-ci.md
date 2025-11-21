---
title: CONTAINS_ALL_CI
description: This function returns a boolean value indicating if the source string contains all strings from a list through case-insensitive search.
ms.date: 11/10/2025
---

# CONTAINS_ALL_CI (NoSQL query)

Returns a boolean value indicating if the source string contains all strings from a list through case-insensitive search.

## Syntax

```cosmos-db
CONTAINS_ALL_CI(<string_expr>, <expr1>, ... [,<exprN>])  
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

The following example shows various uses of the CONTAINS_ALL_CI function with case-insensitive matching.

```cosmos-db
SELECT VALUE {
    "case1": CONTAINS_ALL_CI("Have a nice day!", "have", "nice", "day!"),
    "case2": CONTAINS_ALL_CI("Have a nice day!", "HAVE", "NICE", "DAY!"),
    "case3": CONTAINS_ALL_CI("Have a nice day!", "had", "nice", "day!"),
    "case4": CONTAINS_ALL_CI("Have a nice day!", undefined, "nice", "day!"),
    "case5": CONTAINS_ALL_CI("Have a nice day!", undefined, "had")
}
```

```json
[
    {
        "case1": true,
        "case2": true,
        "case3": false,
        "case4": undefined,
        "case5": false
    }
]
```

## Remarks

- This function is equivalent to `CONTAINS(<string_expr>, expr1, true) AND ... AND CONTAINS(<string_expr>, exprN, true)`.
- This function performs a full scan.

## Related content

- [`CONTAINS_ALL_CS`](contains-all-cs.md)
- [`CONTAINS`](contains.md)
