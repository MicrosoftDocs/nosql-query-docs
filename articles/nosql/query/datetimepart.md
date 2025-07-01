---
title: DATETIMEPART
description: The `DATETIMEPART` function returns the value of the specified date and time part for the provided date and time.
ms.date: 06/30/2025
---

# `DATETIMEPART` (NoSQL query)

The `DATETIMEPART` function returns the value of the specified date and time part for the provided date and time.

## Syntax

```nosql
DATETIMEPART(<date_time_part>, <date_time>)
```

## Arguments

| | Description |
| --- | --- |
| **`date_time_part`** | A string representing a part of an ISO 8601 date format specification. This part is used to indicate which aspect of the date to extract and return. |
| **`date_time`** | A Coordinated Universal Time (UTC) date and time string in the ISO 8601 format `YYYY-MM-DDThh:mm:ss.fffffffZ`. |

## Return types

Returns a numeric value that is a positive integer.

## Examples

This section contains examples of how to use this query language construct.

### Extract date and time parts

In this example, the `DATETIMEPART` function is used to extract year, month, day, hour, minute, second, millisecond, microsecond, and nanosecond from a date.

```nosql
SELECT VALUE {
  getYear: DATETIMEPART("yyyy", "2016-05-29T08:30:00.1301617"),
  getMonth: DATETIMEPART("mm", "2016-05-29T08:30:00.1301617"),
  getDay: DATETIMEPART("dd", "2016-05-29T08:30:00.1301617"),
  getHour: DATETIMEPART("hh", "2016-05-29T08:30:00.1301617"),
  getMinute: DATETIMEPART("mi", "2016-05-29T08:30:00.1301617"),
  getSecond: DATETIMEPART("ss", "2016-05-29T08:30:00.1301617"),
  getMillisecond: DATETIMEPART("ms", "2016-05-29T08:30:00.1301617"),
  getMicrosecond: DATETIMEPART("mcs", "2016-05-29T08:30:00.1301617"),
  getNanosecond: DATETIMEPART("ns", "2016-05-29T08:30:00.1301617")
}
```

```json
[
  {
    "getYear": 2016,
    "getMonth": 5,
    "getDay": 29,
    "getHour": 8,
    "getMinute": 30,
    "getSecond": 0,
    "getMillisecond": 130,
    "getMicrosecond": 130161,
    "getNanosecond": 130161700
  }
]
```

## Remarks

- This function doesn't utilize the index.
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
  - The date and time isn't a valid **ISO 8601** date and time string.
