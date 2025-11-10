---
title: TIMESTAMPTODATETIME
description: The `TIMESTAMPTODATETIME` function converts the specified timestamp to a date and time value.
ms.date: 11/10/2025
---

# `TIMESTAMPTODATETIME` (NoSQL query)

The `TIMESTAMPTODATETIME` function converts the specified timestamp to a date and time value.

An Azure Cosmos DB for NoSQL system function that returns the timestamp as a date and time value.

## Syntax

```nosql
TIMESTAMPTODATETIME(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a UTC date and time string in the ISO 8601 format `YYYY-MM-DDThh:mm:ss.fffffffZ`.

## Examples

This section contains examples of how to use this query language construct.

### Convert timestamp to date and time

In this example, the `TIMESTAMPTODATETIME` function is used to convert timestamps to date and time values.

```nosql
SELECT VALUE {
  parseTicks: TIMESTAMPTODATETIME(1597360794300),
  parseUnixEpoch: TIMESTAMPTODATETIME(0),
  parseWindowsEpoch: TIMESTAMPTODATETIME(-11644473600000)
}
```

```json
[
  {
    "parseTicks": "2020-08-13T23:19:54.3000000Z",
    "parseUnixEpoch": "1970-01-01T00:00:00.0000000Z",
    "parseWindowsEpoch": "1601-01-01T00:00:00.0000000Z"
  }
]
```

## Remarks

- This function returns `undefined` if the date and time isn't a valid **ISO 8601** date and time string.
