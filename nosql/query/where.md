---
title: WHERE
description: The `WHERE` clause returns a subset of items that satisfy the specified filter condition.
ms.date: 07/02/2025
---

# `WHERE` (NoSQL query)

The `WHERE` clause returns a subset of items that satisfy the specified filter condition.

An Azure Cosmos DB for NoSQL clause that applies a filter to return a subset of items in the query results.

## Syntax

```nosql
WHERE <filter_condition>
<filter_condition> ::= <scalar_expression>
```

## Arguments

| | Description |
| --- | --- |
| **`filter_condition`** | Specifies the condition to be met for the items to be returned. |

## Return types

Returns a filtered set of items from the source.

## Examples

This section contains examples of how to use this query language construct.

### Filter items by equality

In this example, the `WHERE` clause is used to filter items where the team is "Hospitality".

```nosql
SELECT VALUE {
  employeeName: e.name,
  currentTeam: e.team
}
FROM
  employees e
WHERE
  e.team = "Hospitality"
```

```json
[
  {
    "employeeName": "Jordan Mitchell",
    "currentTeam": "Hospitality"
  },
  {
    "employeeName": "Ashley Schroeder",
    "currentTeam": "Hospitality"
  },
  {
    "employeeName": "Tomas Richardson",
    "currentTeam": "Hospitality"
  }
]
```
