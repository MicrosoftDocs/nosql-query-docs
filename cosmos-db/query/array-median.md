---
title: ARRAY_MEDIAN
description: This function returns the median value of elements in the specified array expression.
ms.date: 11/10/2025
---

# ARRAY_MEDIAN (NoSQL query)

Returns the median value of elements in the specified array expression.

## Syntax

```nosql
ARRAY_MEDIAN(<array_expr>)  
```  

## Arguments

| | Description |
| --- | --- |
| **`array_expr`** | An array expression. |

## Return types

Returns a numeric expression.

## Examples

The following example shows the results of using this function on arrays with numeric values.

```nosql
SELECT VALUE {
    "case1": ARRAY_MEDIAN([1, 2, 3, 4]),
    "case2": ARRAY_MEDIAN([1.0, 2.0, 3.3, 4.7, 7.8]),
    "case3": ARRAY_MEDIAN([1, -2.7, 3, -4, undefined]),
    "case4": ARRAY_MEDIAN(['abc', 'ABC', 'aBc', 'AbC']),
    "case5": ARRAY_MEDIAN([12, 'abc', true, false, null, undefined])
}
```

```json
[
    {
        "case1": 2.5,
        "case2": 3.3,
        "case3": -0.8500000000000001
    }
]
```

## Remarks

- The elements in array can only be number.
- Any undefined values are ignored.
- This function performs a full scan.

## Related content

- [`ARRAY_AVG`](array-avg.md)
- [`ARRAY_MAX`](array-max.md)
