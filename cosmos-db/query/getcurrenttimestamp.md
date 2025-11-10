---
title: GETCURRENTTIMESTAMP
description: The `GETCURRENTTIMESTAMP` function returns the current timestamp in milliseconds since the Unix epoch.
ms.date: 11/10/2025
---

# `GETCURRENTTIMESTAMP` - Query language in Cosmos DB (in Azure and Fabric)

The `GETCURRENTTIMESTAMP` function returns the current timestamp in milliseconds since the Unix epoch.

## Syntax

```nosql
GETCURRENTTIMESTAMP()
```

## Return types

Returns a numeric expression representing the current timestamp in milliseconds.

## Examples

This section contains examples of how to use this query language construct.

### Get the current timestamp

In this example, the `GETCURRENTTIMESTAMP` function is used to return the current timestamp.

```nosql
SELECT VALUE {
  currentTimestamp: GETCURRENTTIMESTAMP()
}
```

```json
[
  {
    "currentTimestamp": 1556916469065
  }
]
```
