---
title: DAY
description: This function returns the value of the day for the provided date and time.
ms.date: 01/23/2026
---

# DAY (NoSQL query)

Returns the value of the day for the provided date and time.

## Syntax

```cosmos-db
DAY(<date_time>)  
```  

## Arguments

| | Description |
| --- | --- |
| **`date_time`** | A Coordinated Universal Time (UTC) date and time string in the ISO 8601 format `YYYY-MM-DDThh:mm:ss.fffffffZ`. |

## Return types

Returns a numeric value that is a positive integer.

## Examples

The following example shows the results of using this function on different date values.

```cosmos-db
SELECT VALUE {
    "case1": DAY("2024-01-10"),
    "case2": DAY("2000-12-12T10:00:00"),
    "case3": DAY("1989-03-03T12:12:12.1234567Z")
}
```

```json
[
    {
        "case1": 10,
        "case2": 12,
        "case3": 3
    }
]
```

## Remarks

- Returns a value in the range 1-31, representing the day of the month.
- This function behaves the same as the DateTimePart function when the day is specified.
- This function benefits from the use of a [range index](../indexing-policies.md#includeexclude-strategy).

## Related content

- [`YEAR`](year.md)
- [`MONTH`](month.md)
- [`DATETIMEPART`](datetimepart.md)
