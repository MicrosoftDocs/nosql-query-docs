---
title: GETCURRENTTICKSSTATIC
description: The `GETCURRENTTICKSSTATIC` function returns a static nanosecond ticks value (100-nanosecond intervals since the Unix epoch) for all items in the same partition.
ms.date: 07/02/2025
---

# `GETCURRENTTICKSSTATIC` (NoSQL query)

The `GETCURRENTTICKSSTATIC` function returns a static nanosecond ticks value (100-nanosecond intervals since the Unix epoch) for all items in the same partition.

## Syntax

```nosql
GETCURRENTTICKSSTATIC()
```

## Return types

Returns a signed numeric value that represents the current number of 100-nanosecond ticks that have elapsed since the Unix epoch (`00:00:00 Thursday, 1 January 1970`).

## Examples

This section contains examples of how to use this query language construct.

### Static ticks per partition

In this example, the `GETCURRENTTICKSSTATIC` function returns the same static ticks for items within the same partition.

```nosql
SELECT
  i.id,
  i.pk AS partitionKey,
  GETCURRENTTICKS() AS nonStaticTicks,
  GETCURRENTTICKSSTATIC() AS staticTicks
FROM
  items i
```

```json
[
  {
    "id": "1",
    "partitionKey": "A",
    "nonStaticTicks": 16879779663422236,
    "staticTicks": 16879779663415572
  },
  {
    "id": "2",
    "partitionKey": "A",
    "nonStaticTicks": 16879779663422320,
    "staticTicks": 16879779663415572
  },
  {
    "id": "3",
    "partitionKey": "B",
    "nonStaticTicks": 16879779663422380,
    "staticTicks": 16879779663421680
  }
]
```

## Remarks

- Static versions of system functions only get their respective values once during binding, rather than execute repeatedly in the runtime as is the case for the nonstatic versions of the same functions.
