---
title: DATETIMEDIFF
description: The `DATETIMEDIFF` function returns the difference, as a signed integer, of the specified date and time part between two date and time values.
ms.date: 06/30/2025
---

# `DATETIMEDIFF` (NoSQL query)

The `DATETIMEDIFF` function returns the difference, as a signed integer, of the specified date and time part between two date and time values.

## Syntax

```nosql
DATETIMEDIFF(<date_time_part>, <start_date_time>, <end_date_time>)
```

## Arguments

| | Description |
| --- | --- |
| **`date_time_part`** | A string representing a part of an ISO 8601 date format specification. This part is used to indicate which aspect of the date to compare. |
| **`start_date_time`** | A Coordinated Universal Time (UTC) date and time string in the ISO 8601 format `YYYY-MM-DDThh:mm:ss.fffffffZ`. |
| **`end_date_time`** | A Coordinated Universal Time (UTC) date and time string in the ISO 8601 format `YYYY-MM-DDThh:mm:ss.fffffffZ`. |

## Return types

Returns a numeric value that is a signed integer.

## Examples

This section contains examples of how to use this query language construct.

### Date and time difference

In this example, the `DATETIMEDIFF` function is used to calculate the difference between two dates in years, months, days, hours, and seconds.

```nosql
SELECT VALUE {
  diffPastYears: DATETIMEDIFF("yyyy", "2019-02-04T16:00:00.0000000", "2018-03-05T05:00:00.0000000"),
  diffPastMonths: DATETIMEDIFF("mm", "2019-02-04T16:00:00.0000000", "2018-03-05T05:00:00.0000000"),
  diffPastDays: DATETIMEDIFF("dd", "2019-02-04T16:00:00.0000000", "2018-03-05T05:00:00.0000000"),
  diffPastHours: DATETIMEDIFF("hh", "2019-02-04T16:00:00.0000000", "2018-03-05T05:00:00.0000000"),
  diffPastSeconds: DATETIMEDIFF("ss", "2019-02-04T16:00:00.0000000", "2018-03-05T05:00:00.0000000"),
  diffFutureYears: DATETIMEDIFF("yyyy", "2018-03-05T05:00:00.0000000", "2019-02-04T16:00:00.0000000"),
  diffFutureMonths: DATETIMEDIFF("mm", "2018-03-05T05:00:00.0000000", "2019-02-04T16:00:00.0000000"),
  diffFutureDays: DATETIMEDIFF("dd", "2018-03-05T05:00:00.0000000", "2019-02-04T16:00:00.0000000"),
  diffFutureHours: DATETIMEDIFF("hh", "2018-03-05T05:00:00.0000000", "2019-02-04T16:00:00.0000000"),
  diffFutureSeconds: DATETIMEDIFF("ss", "2018-03-05T05:00:00.0000000", "2019-02-04T16:00:00.0000000")
}
```

```json
[
  {
    "diffPastYears": -1,
    "diffPastMonths": -11,
    "diffPastDays": -336,
    "diffPastHours": -8075,
    "diffPastSeconds": -29070000,
    "diffFutureYears": 1,
    "diffFutureMonths": 11,
    "diffFutureDays": 336,
    "diffFutureHours": 8075,
    "diffFutureSeconds": 29070000
  }
]
```

## Remarks

- The **ISO 8601** date format specifies valid date and time parts to use with this function:
| | Format |
| --- | --- |
| **Year** | `year`, `yyyy`, `yy` |
| **Month** | `month`, `mm`, `m` |
| **Day** | `day`, `dd`, `d` |
| **Hour** | `hour`, `hh` |
| **Minute** | `minute`, `mi`, `n` |
| **Second** | `second`, `ss`, `s` |
| **Millisecond** | `millisecond`, `ms` |
| **Microsecond** | `microsecond`, `mcs` |
| **Nanosecond** | `nanosecond`, `ns` |
- This function returns `undefined` for these reasons:
- The specified date and time part is invalid.
- The date and time in either start or end argument isn't a valid **ISO 8601** date and time string.
- The function always returns a signed integer value. The function returns a measurement of the number of boundaries crossed for the specified date and time part, not a measurement of the time interval.
