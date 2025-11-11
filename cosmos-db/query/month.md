---
title: MONTH
description: This function returns the value of the month for the provided date and time.
ms.devlang: nosql
ms.date: 11/10/2025
---

# MONTH (NoSQL query)

Returns the value of the month for the provided date and time.

## Syntax

```nosql
MONTH(<date_time>)  
```  

## Arguments

| | Description |
| --- | --- |
| **`date_time`** | A date/time value. |

## Return types

Returns a numeric value that is a positive integer.

## Examples

The following example shows the results of using this function on different date values.

```nosql
SELECT VALUE {
    "case1": MONTH("2024-01-10"),
    "case2": MONTH("2000-12-12T10:00:00"),
    "case3": MONTH("1989-03-03T12:12:12.1234567Z")
}
```

```json
[
    {
        "case1": 1,
        "case2": 12,
        "case3": 3
    }
]
```

## Remarks

- This function behaves the same as the DateTimePart function when the month is specified.
- This function benefits from the use of a [range index](../../index-policy.md#includeexclude-strategy).

## Related content

- [System functions](system-functions.yml)
- [`YEAR`](year.md)
- [`DAY`](day.md)
- [`DATETIMEPART`](datetimepart.md)
