---
title: DATETIMEFROMPARTS
description: The `DATETIMEFROMPARTS` function returns a date and time string value constructed from input numeric values for various date and time parts.
ms.date: 06/30/2025
---

# `DATETIMEFROMPARTS` (NoSQL query)

The `DATETIMEFROMPARTS` function returns a date and time string value constructed from input numeric values for various date and time parts.

## Syntax

```nosql
DATETIMEFROMPARTS(<numeric_year>, <numeric_month>, <numeric_day> [, <numeric_hour>] [, <numeric_minute>] [, <numeric_second>] [, <numeric_second_fraction>])
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_year`** | A positive numeric integer value for the year (ISO 8601 format yyyy). |
| **`numeric_month`** | A positive numeric integer value for the month (ISO 8601 format mm). |
| **`numeric_day`** | A positive numeric integer value for the day (ISO 8601 format dd). |
| **`numeric_hour`** | An optional positive numeric integer value for the hour (ISO 8601 format hh). If not specified, the default value is 0. |
| **`numeric_minute`** | An optional positive numeric integer value for the minute (ISO 8601 format mm). If not specified, the default value is 0. |
| **`numeric_second`** | An optional positive numeric integer value for the second (ISO 8601 format ss). If not specified, the default value is 0. |
| **`numeric_second_fraction`** | An optional positive numeric integer value for the fractional of a second (ISO 8601 format fffffffZ). If not specified, the default value is 0. |

## Return types

Returns a date and time string value.

## Examples

This section contains examples of how to use this query language construct.

### Construct date and time from parts

In this example, the `DATETIMEFROMPARTS` function is used to construct date and time values from various arguments.

```nosql
SELECT VALUE {
  constructMinArguments: DATETIMEFROMPARTS(2017, 4, 20),
  constructMinEquivalent: DATETIMEFROMPARTS(2017, 4, 20, 0, 0, 0, 0),
  constructAllArguments: DATETIMEFROMPARTS(2017, 4, 20, 13, 15, 20, 3456789),
  constructPartialArguments: DATETIMEFROMPARTS(2017, 4, 20, 13, 15),
  constructInvalidArguments: DATETIMEFROMPARTS(-2000, -1, -1)
}
```

```json
[
  {
    "constructMinArguments": "2017-04-20T00:00:00.0000000Z",
    "constructMinEquivalent": "2017-04-20T00:00:00.0000000Z",
    "constructAllArguments": "2017-04-20T13:15:20.3456789Z",
    "constructPartialArguments": "2017-04-20T13:15:00.0000000Z"
  }
]
```

## Remarks

- If the specified integers would create an invalid date and time, the function returns `undefined`.
