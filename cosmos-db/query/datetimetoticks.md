---
title: DATETIMETOTICKS
description: The `DATETIMETOTICKS` function converts the specified DateTime to ticks. A single tick represents 100 nanoseconds or 0.0000001 of a second.
ms.date: 11/10/2025
---

# `DATETIMETOTICKS` - Query language in Cosmos DB (in Azure and Fabric)

The `DATETIMETOTICKS` function converts the specified DateTime to ticks. A single tick represents 100 nanoseconds or 0.0000001 of a second.

## Syntax

```nosql
DATETIMETOTICKS(<date_time>)
```

## Arguments

| | Description |
| --- | --- |
| **`date_time`** | A Coordinated Universal Time (UTC) date and time string in the ISO 8601 format `YYYY-MM-DDThh:mm:ss.fffffffZ`. |

## Return types

Returns a signed numeric value, the current number of 100-nanosecond ticks that have elapsed since the Unix epoch (January 1, 1970).

## Examples

This section contains examples of how to use this query language construct.

### Convert date and time to ticks

In this example, the `DATETIMETOTICKS` function is used to convert a date and time to ticks.

```nosql
SELECT VALUE {
  ticks: DATETIMETOTICKS("2015-05-19T12:00:00.0000000")
}
```

```json
[
  {
    "ticks": 14320368000000000
  }
]
```

## Remarks

- This function doesn't utilize the index.
- This function returns `undefined` if the date and time isn't a valid **ISO 8601** date and time string.
