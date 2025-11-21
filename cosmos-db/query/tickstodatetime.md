---
title: TICKSTODATETIME
description: The `TICKSTODATETIME` function converts the specified number of ticks to a date and time value.
ms.date: 11/10/2025
---

# `TICKSTODATETIME` - Query language in Cosmos DB (in Azure and Fabric)

The `TICKSTODATETIME` function converts the specified number of ticks to a date and time value.

An Azure Cosmos DB for NoSQL system function that returns the number of ticks as a date and time value.

## Syntax

```cosmos-db
TICKSTODATETIME(<numeric_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`numeric_expr`** | A numeric expression. |

## Return types

Returns a UTC date and time string in the ISO 8601 format `YYYY-MM-DDThh:mm:ss.fffffffZ`.

## Examples

This section contains examples of how to use this query language construct.

### Convert ticks to date and time

In this example, the `TICKSTODATETIME` function is used to convert ticks to date and time values.

```cosmos-db
SELECT VALUE {
  parseTicks: TICKSTODATETIME(15973607943002652),
  parseUnixEpoch: TICKSTODATETIME(0),
  parseWindowsEpoch: TICKSTODATETIME(-116444736000000000)
}
```

```json
[
  {
    "parseTicks": "2020-08-13T23:19:54.3002652Z",
    "parseUnixEpoch": "1970-01-01T00:00:00.0000000Z",
    "parseWindowsEpoch": "1601-01-01T00:00:00.0000000Z"
  }
]
```

## Remarks

- This function returns `undefined` if the date and time isn't a valid **ISO 8601** date and time string.
