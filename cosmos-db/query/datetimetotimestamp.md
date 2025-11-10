---
title: DATETIMETOTIMESTAMP
description: The `DATETIMETOTIMESTAMP` function converts the specified date and time to a numeric timestamp. The timestamp is a signed numeric integer that measures the milliseconds since the Unix epoch.
ms.date: 11/10/2025
---

# `DATETIMETOTIMESTAMP` (NoSQL query)

The `DATETIMETOTIMESTAMP` function converts the specified date and time to a numeric timestamp. The timestamp is a signed numeric integer that measures the milliseconds since the Unix epoch.

## Syntax

```nosql
DATETIMETOTIMESTAMP(<date_time>)
```

## Arguments

| | Description |
| --- | --- |
| **`date_time`** | A Coordinated Universal Time (UTC) date and time string in the ISO 8601 format `YYYY-MM-DDThh:mm:ss.fffffffZ`. |

## Return types

Returns a signed numeric value, the current number of milliseconds that have elapsed since the Unix epoch (January 1, 1970).

## Examples

This section contains examples of how to use this query language construct.

### Convert date and time to timestamp

In this example, the `DATETIMETOTIMESTAMP` function is used to convert a date and time to a timestamp.

```nosql
SELECT VALUE {
  timestamp: DATETIMETOTIMESTAMP("2015-05-19T12:00:00.0000000")
}
```

```json
[
  {
    "timestamp": 1432036800000
  }
]
```

## Remarks

- This function returns `undefined` if the date and time isn't a valid **ISO 8601** date and time string.
