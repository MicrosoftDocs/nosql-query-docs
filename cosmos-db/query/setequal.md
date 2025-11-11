---
title: SETEQUAL
description: This function returns a boolean value indicating whether two sets are equal after removing duplicated elements.
ms.date: 11/10/2025
---

# SETEQUAL (NoSQL query)

Returns a boolean value indicating whether two sets are equal after removing duplicated elements.

## Syntax

```nosql
SETEQUAL(<arr_expr1>, <arr_expr2>)  
```  

## Arguments

| | Description |
| --- | --- |
| **`arr_expr1`** | The first array expression. |
| **`arr_expr2`** | The second array expression. |

## Return types

Returns a boolean expression.

## Examples

The following example shows the results of using this function to compare sets for equality.

```nosql
SELECT VALUE {
    "case1": SETEQUAL([1, 2, 3], [1, 2, 3]),
    "case2": SETEQUAL([1, 2, 3], [3, 2, 1]),
    "case3": SETEQUAL([1, 2, 3, 3], [1, 2, 2, 3, 1, 2]),
    "case4": SETEQUAL([], [1, 2, 3]),
    "case5": SETEQUAL([1, true, 'abc'], [true, 1, 'abc']),
    "case6": SETEQUAL([1, 1, 1, 1], [2, 3, 4])
}
```

```json
[
    {
        "case1": true,
        "case2": true,
        "case3": true,
        "case4": false,
        "case5": true,
        "case6": false
    }
]
```

## Remarks

- This system function will not utilize the index.

## Related content

- [`SETDIFFERENCE`](setdifference.md)
- [`SETINTERSECT`](setintersect.md)
