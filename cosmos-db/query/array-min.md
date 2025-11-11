---
title: ARRAY_MIN
description: This function returns the minimal value of elements in the specified array expression.
ms.date: 11/10/2025
---

# ARRAY_MIN (NoSQL query)

Returns the minimal value of elements in the specified array expression.

## Syntax

```nosql
ARRAY_MIN(<array_expr>)  
```  

## Arguments

| | Description |
| --- | --- |
| **`array_expr`** | An array expression. |

## Return types

Returns a numeric/boolean/string expression.

## Examples

The following example shows the results of using this function on arrays with different data types.

```nosql
SELECT VALUE {
    "case1": ARRAY_MIN([1, 2, 3, 4]),
    "case2": ARRAY_MIN(['abc', 'ABC', 'aBc', 'AbC']),
    "case3": ARRAY_MIN([true, false]),
    "case4": ARRAY_MIN([null, null]),
    "case5": ARRAY_MIN([12, 'abc', true, false, null, undefined])
}
```

```json
[
    {
        "case1": 1,
        "case2": "ABC",
        "case3": false,
        "case4": null,
        "case5": null
    }
]
```

## Remarks

- The elements in array can be number, string, boolean, or null.
- Any undefined values are ignored.
- The following priority order is used (in descending order), when comparing different types of data:
  - string
  - number
  - boolean
  - null
- This function performs a full scan.

## Related content

- [`ARRAY_MAX`](array-max.md)
- [`ARRAY_AVG`](array-avg.md)
