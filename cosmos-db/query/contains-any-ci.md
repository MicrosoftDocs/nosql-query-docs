---
title: CONTAINS_ANY_CI
description: This function returns a boolean value indicating if the source string contains any strings from a list through case-insensitive search.
ms.date: 01/23/2026
---

# CONTAINS_ANY_CI (NoSQL query)

Returns a boolean value indicating if the source string contains any strings from a list through case-insensitive search.

## Syntax

```cosmos-db
CONTAINS_ANY_CI(<string_expr>, <expr1>, ... [,<exprN>])  
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

The following example shows various uses of the CONTAINS_ANY_CI function with case-insensitive matching.

```cosmos-db
SELECT VALUE {
    "case1": CONTAINS_ANY_CI("Have a nice day!", "have", "nice", "day!"),
    "case2": CONTAINS_ANY_CI("Have a nice day!", "HAVE", "NICE", "DAY!"),
    "case3": CONTAINS_ANY_CI("Have a nice day!", "had", "nice", "day!"),
    "case4": CONTAINS_ANY_CI("Have a nice day!", undefined, "nice", "day!"),
    "case5": CONTAINS_ANY_CI("Have a nice day!", undefined, "had")
}
```

```json
[
    {
        "case1": true,
        "case2": true,
        "case3": true,
        "case4": true
    }
]
```

> [!NOTE]
> In this example, `case5` is omitted from the output because the function returns `undefined` when no valid search expressions match, and properties with `undefined` values aren't included in JSON objects.

## Remarks

- This function is equivalent to `CONTAINS(<string_expr>, expr1, true) OR ... OR CONTAINS(<string_expr>, exprN, true)`.
- This function performs a full scan.
- Search expressions with `undefined` values are skipped. If all search expressions are `undefined` or no valid search expressions match, the function returns `undefined`.

## Related content

- [`CONTAINS_ANY_CS`](contains-any-cs.md)
- [`CONTAINS`](contains.md)
