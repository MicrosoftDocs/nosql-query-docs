---
title: YEAR
description: This function returns the value of the year for the provided date and time.
ms.date: 11/10/2025
---

# YEAR (NoSQL query)

[!INCLUDE[NoSQL](../../includes/appliesto-nosql.md)]

Returns the value of the year for the provided date and time.

## Syntax

```nosql
YEAR(<date_time>)  
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
    "case1": YEAR("2000-10-10"),
    "case2": YEAR("2024-01-10T14:15:20"),
    "case3": YEAR("1989-03-03T12:12:12.1234567Z")
}
```

```json
[
    {
        "case1": 2000,
        "case2": 2024,
        "case3": 1989
    }
]
```

## Remarks

- This function behaves the same as the DateTimePart function when the year is specified.
- This function benefits from the use of a [range index](../../index-policy.md#includeexclude-strategy).

## Related content

- [System functions](system-functions.yml)
- [`MONTH`](month.md)
- [`DAY`](day.md)
- [`DATETIMEPART`](datetimepart.md)
