---
title: GETCURRENTTIMESTAMPSTATIC
description: The `GETCURRENTTIMESTAMPSTATIC` function returns a static timestamp value (milliseconds since the Unix epoch) for all items in the same partition.
ms.date: 11/10/2025
---

# `GETCURRENTTIMESTAMPSTATIC` (NoSQL query)

The `GETCURRENTTIMESTAMPSTATIC` function returns a static timestamp value (milliseconds since the Unix epoch) for all items in the same partition.

## Syntax

```nosql
GETCURRENTTIMESTAMPSTATIC()
```

## Return types

Returns a signed numeric value that represents the current number of milliseconds that have elapsed since the Unix epoch (`00:00:00 Thursday, 1 January 1970`).

## Examples

This section contains examples of how to use this query language construct.

### Static timestamp per partition

In this example, the `GETCURRENTTIMESTAMPSTATIC` function returns the same static timestamp for items within the same partition.

```nosql
SELECT
  i.id,
  i.pk AS partitionKey,
  GETCURRENTTIMESTAMP() AS nonStaticTimestamp,
  GETCURRENTTIMESTAMPSTATIC() AS staticTimestamp
FROM
  items i
```

```json
[
  {
    "id": "1",
    "partitionKey": "A",
    "nonStaticTimestamp": 1687977636235,
    "staticTimestamp": 1687977636232
  },
  {
    "id": "2",
    "partitionKey": "A",
    "nonStaticTimestamp": 1687977636235,
    "staticTimestamp": 1687977636232
  },
  {
    "id": "3",
    "partitionKey": "B",
    "nonStaticTimestamp": 1687977636238,
    "staticTimestamp": 1687977636237
  }
]
```

## Remarks

- Static versions of system functions only get their respective values once during binding, rather than execute repeatedly in the runtime as is the case for the nonstatic versions of the same functions.
