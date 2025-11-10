---
title: GETCURRENTTICKS
description: The `GETCURRENTTICKS` function returns the current UTC time as the number of 100-nanosecond intervals (ticks) that have elapsed since 0001-01-01T00:00:00.0000000Z.
ms.date: 11/10/2025
---

# `GETCURRENTTICKS` - Query language in Cosmos DB (in Azure and Fabric)

The `GETCURRENTTICKS` function returns the current UTC time as the number of 100-nanosecond intervals (ticks) that have elapsed since 0001-01-01T00:00:00.0000000Z.

## Syntax

```nosql
GETCURRENTTICKS()
```

## Return types

Returns the current UTC time as a long integer (number of ticks).

## Examples

This section contains examples of how to use this query language construct.

### Get current ticks

In this example, the `GETCURRENTTICKS` function is used to return the current UTC time as ticks.

```nosql
SELECT VALUE {
  currentTicks: GETCURRENTTICKS()
}
```

```json
[
  {
    "currentTicks": 15973607943002652
  }
]
```

## Remarks

- The value returned is the number of 100-nanosecond intervals since 0001-01-01T00:00:00.0000000Z.
