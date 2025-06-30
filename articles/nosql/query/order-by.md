---
title: ORDER-BY
description: The `ORDER BY` clause returns the sorted result set of a query based on one or more expressions.
ms.date: 06/30/2025
---

# `ORDER-BY` (NoSQL query)

The `ORDER BY` clause returns the sorted result set of a query based on one or more expressions.

## Syntax

```nosql
ORDER BY <sort_specification>
```

## Arguments

| | Description |
| --- | --- |
| **`sort_specification`** | Specifies a property or expression on which to sort the query result set. Multiple properties can be specified. The sequence of the sort properties defines the organization of the sorted result set. |

## Return types

Returns the sorted result set based on the specified sort specification.

## Examples

This section contains examples of how to use this query language construct.

### Sort employees by last name

In this example, the `ORDER BY` clause is used to sort employees by their last name.

```nosql
SELECT VALUE {
  firstName: e.name.first,
  lastName: e.name.last
}
FROM
  employees e
WHERE
  e.team = "Human resources"
ORDER BY
  e.name.last
```

```json
[
  {
    "firstName": "Casey",
    "lastName": "Jensen"
  },
  {
    "firstName": "Kayla",
    "lastName": "Lewis"
  },
  {
    "firstName": "Amari",
    "lastName": "Rivera"
  }
]
```
