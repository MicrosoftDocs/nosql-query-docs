---
title: DATETIMEBIN
description: The `DATETIMEBIN` function returns a date and time string value that is the result of binning (or rounding) a part of the provided date and time string.
ms.date: 06/30/2025
---

# `DATETIMEBIN` (NoSQL query)

The `DATETIMEBIN` function returns a date and time string value that is the result of binning (or rounding) a part of the provided date and time string.

## Syntax

```nosql
DATETIMEBIN(<date_time>, <date_time_part> [, <bin_size>] [, <bin_start_date_time>])
```

## Arguments

| | Description |
| --- | --- |
| **`date_time`** | A Coordinated Universal Time (UTC) date and time string in the ISO 8601 format `YYYY-MM-DDThh:mm:ss.fffffffZ`. |
| **`date_time_part`** | A string representing a part of an ISO 8601 date format specification. This part is used to indicate which aspect of the date to bin. |
| **`bin_size`** | An optional numeric value specifying the size of the bin. If not specified, the default value is `1`. |
| **`bin_start_date_time`** | An optional UTC date and time string in the ISO 8601 format. If not specified, the default value is the Unix epoch `1970-01-01T00:00:00.000000Z`. |

## Return types

Returns a date and time string value.

## Examples

This section contains examples of how to use this query language construct.

### Bin date and time values

In this example, the `DATETIMEBIN` function is used to bin a date and time by day, hour, second, and with custom bin sizes and start dates.

```nosql
SELECT VALUE {
  binDay: DATETIMEBIN("2021-01-08T18:35:00.0000000", "dd"),
  binHour: DATETIMEBIN("2021-01-08T18:35:00.0000000", "hh"),
  binSecond: DATETIMEBIN("2021-01-08T18:35:00.0000000", "ss"),
  binFiveHours: DATETIMEBIN("2021-01-08T18:35:00.0000000", "hh", 5),
  binSevenDaysUnixEpoch: DATETIMEBIN("2021-01-08T18:35:00.0000000", "dd", 7),
  binSevenDaysWindowsEpoch: DATETIMEBIN("2021-01-08T18:35:00.0000000", "dd", 7, "1601-01-01T00:00:00.0000000")
}
```

```json
[
  {
    "binDay": "2021-01-08T00:00:00.0000000Z",
    "binHour": "2021-01-08T18:00:00.0000000Z",
    "binSecond": "2021-01-08T18:35:00.0000000Z",
    "binFiveHours": "2021-01-08T15:00:00.0000000Z",
    "binSevenDaysUnixEpoch": "2021-01-07T00:00:00.0000000Z",
    "binSevenDaysWindowsEpoch": "2021-01-04T00:00:00.0000000Z"
  }
]
```

## Remarks

- This function returns `undefined` for these reasons:
- The specified date and time part is invalid.
- The bin size value isn't a valid integer, is zero, or is negative.
- The date and time in either argument isn't a valid **ISO 8601** date and time string.
- The date and time for the bin start precedes the year `1601``, the Windows epoch.
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
