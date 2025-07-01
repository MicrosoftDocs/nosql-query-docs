---
title: OFFSET LIMIT
description: The `OFFSET LIMIT` clause returns a subset of the result set by skipping a specified number of results and then taking a specified number of results.
ms.date: 06/30/2025
---

# `OFFSET LIMIT` (NoSQL query)

The `OFFSET LIMIT` clause returns a subset of the result set by skipping a specified number of results and then taking a specified number of results.

## Syntax

```nosql
OFFSET <offset_amount> LIMIT <limit_amount>
```

## Arguments

| | Description |
| --- | --- |
| **`offset_amount`** | Specifies the integer number of items that the query results should skip. |
| **`limit_amount`** | Specifies the integer number of items that the query results should include. |

## Return types

Returns a subset of the result set after skipping and taking the specified number of results.

## Examples

This section contains examples of how to use this query language construct.

### Skip and take results

In this example, the `OFFSET LIMIT` clause is used to skip one result and take the next three.

```nosql
SELECT VALUE {
  name: e.name
}
FROM
  employees e
WHERE
  e.team = "Leadership team"
ORDER BY
  e.name
OFFSET 1 LIMIT 3
```

```json
[
  {
    "name": "Isaac Talbot"
  },
  {
    "name": "Jennifer Wilkins"
  },
  {
    "name": "Riley Johnson"
  }
]
```
