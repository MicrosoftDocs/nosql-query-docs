---
title: GETCURRENTDATETIME
description: The `GETCURRENTDATETIME` function returns the current UTC (Coordinated Universal Time) date and time as an **ISO 8601** string.
ms.date: 07/02/2025
---

# `GETCURRENTDATETIME` (NoSQL query)

The `GETCURRENTDATETIME` function returns the current UTC (Coordinated Universal Time) date and time as an **ISO 8601** string.

## Syntax

```nosql
GETCURRENTDATETIME()
```

## Return types

Returns the current UTC date and time string value in the **round-trip (ISO 8601)** format.

## Examples

This section contains examples of how to use this query language construct.

### Get current UTC date and time

In this example, the `GETCURRENTDATETIME` function is used to return the current UTC date and time.

```nosql
SELECT VALUE {
  currentUtcDateTime: GETCURRENTDATETIME()
}
```

```json
[
  {
    "currentUtcDateTime": "2019-05-03T20:36:17.1234567Z"
  }
]
```

## Remarks

- This function doesn't utilize the index.
- This function is nondeterministic.
- The result returned is UTC (Coordinated Universal Time) with precision of seven digits and an accuracy of 100 nanoseconds.
- If you need to compare values to the current time, obtain the current time before query execution and use that constant string value in the `WHERE` clause.
