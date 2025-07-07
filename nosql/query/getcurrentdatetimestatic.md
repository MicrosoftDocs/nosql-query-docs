---
title: GETCURRENTDATETIMESTATIC
description: The `GETCURRENTDATETIMESTATIC` function returns the same UTC date and time value for all items in the query, as an ISO 8601 string. This is useful for consistent timestamps across query results.
ms.date: 07/02/2025
---

# `GETCURRENTDATETIMESTATIC` (NoSQL query)

The `GETCURRENTDATETIMESTATIC` function returns the same UTC date and time value for all items in the query, as an ISO 8601 string. This is useful for consistent timestamps across query results.

## Syntax

```nosql
GETCURRENTDATETIMESTATIC()
```

## Return types

Returns the current UTC date and time as a string in ISO 8601 format, consistent for all items in the query.

## Examples

This section contains examples of how to use this query language construct.

### Get static and non-static current date and time

In this example, the `GETCURRENTDATETIMESTATIC` function is used to return the same timestamp for all items, while `GetCurrentDateTime` returns a different value for each item.

```nosql
SELECT
  i.id,
  i.pk AS partitionKey,
  GetCurrentDateTime() AS nonStaticDateTime,
  GETCURRENTDATETIMESTATIC() AS staticDateTime
FROM
    items i
```

```json
[
  {
    "id": "1",
    "partitionKey": "A",
    "nonStaticDateTime": "2023-06-28T18:32:12.4500994Z",
    "staticDateTime": "2023-06-28T18:32:12.4499507Z"
  },
  {
    "id": "2",
    "partitionKey": "A",
    "nonStaticDateTime": "2023-06-28T18:32:12.4501101Z",
    "staticDateTime": "2023-06-28T18:32:12.4499507Z"
  },
  {
    "id": "3",
    "partitionKey": "B",
    "nonStaticDateTime": "2023-06-28T18:32:12.4501181Z",
    "staticDateTime": "2023-06-28T18:32:12.4401181Z"
  }
]
```

## Remarks

- This static function is called once per partition.
- Static versions of system functions only get their respective values once during binding, rather than execute repeatedly in the runtime as is the case for the nonstatic versions of the same functions.
