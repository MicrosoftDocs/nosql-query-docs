---
title: YEAR
description: This function returns the value of the year for the provided date and time.
ms.date: 01/23/2026
---

# YEAR (NoSQL query)

Returns the value of the year for the provided date and time.

## Syntax

```cosmos-db
YEAR(<date_time>)  
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
- This function benefits from the use of a [range index](../indexing-policies.md#includeexclude-strategy).

## Related content

- [`MONTH`](month.md)
- [`DAY`](day.md)
- [`DATETIMEPART`](datetimepart.md)
