---
title: DATETIMEADD
description: The `DATETIMEADD` function returns a date and time string value that is the result of adding a specified number value to the provided date and time string.
ms.date: 11/10/2025
---

# `DATETIMEADD` - Query language in Cosmos DB (in Azure and Fabric)

The `DATETIMEADD` function returns a date and time string value that is the result of adding a specified number value to the provided date and time string.

## Syntax

```nosql
DATETIMEADD(<date_time_part>, <numeric_expr>, <date_time>)
```

## Arguments

| | Description |
| --- | --- |
| **`date_time_part`** | A string representing a part of an ISO 8601 date format specification. This part is used to indicate which aspect of the date to modify by the related numeric expression. |
| **`numeric_expr`** | A numeric expression resulting in a signed integer. |
| **`date_time`** | A Coordinated Universal Time (UTC) date and time string in the ISO 8601 format `YYYY-MM-DDThh:mm:ss.fffffffZ`. |

## Return types

Returns a UTC date and time string in the ISO 8601 format `YYYY-MM-DDThh:mm:ss.fffffffZ`.

## Examples

This section contains examples of how to use this query language construct.

### Add and subtract date parts

In this example, the `DATETIMEADD` function is used to add and subtract years, months, days, and hours from a date.

```nosql
SELECT VALUE {
  addOneYear: DATETIMEADD("yyyy", 1, "2020-07-03T00:00:00.0000000"),
  addOneMonth: DATETIMEADD("mm", 1, "2020-07-03T00:00:00.0000000"),
  addOneDay: DATETIMEADD("dd", 1, "2020-07-03T00:00:00.0000000"),
  addOneHour: DATETIMEADD("hh", 1, "2020-07-03T00:00:00.0000000"),
  subtractOneYear: DATETIMEADD("yyyy", -1, "2020-07-03T00:00:00.0000000"),
  subtractOneMonth: DATETIMEADD("mm", -1, "2020-07-03T00:00:00.0000000"),
  subtractOneDay: DATETIMEADD("dd", -1, "2020-07-03T00:00:00.0000000"),
  subtractOneHour: DATETIMEADD("hh", -1, "2020-07-03T00:00:00.0000000"),
  modifySecondsExpression: DATETIMEADD("ss", 5 * -5, "2020-07-03T00:00:00.0000000")
}
```

```json
[
  {
    "addOneYear": "2021-07-03T00:00:00.0000000Z",
    "addOneMonth": "2020-08-03T00:00:00.0000000Z",
    "addOneDay": "2020-07-04T00:00:00.0000000Z",
    "addOneHour": "2020-07-03T01:00:00.0000000Z",
    "subtractOneYear": "2019-07-03T00:00:00.0000000Z",
    "subtractOneMonth": "2020-06-03T00:00:00.0000000Z",
    "subtractOneDay": "2020-07-02T00:00:00.0000000Z",
    "subtractOneHour": "2020-07-02T23:00:00.0000000Z",
    "modifySecondsExpression": "2020-07-02T23:59:35.0000000Z"
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
  - The numeric expression isn't a valid integer.
  - The date and time in the argument isn't a valid ISO 8601 date and time string.
