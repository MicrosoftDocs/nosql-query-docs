---
title: GROUP BY
description: The `GROUP BY` clause collects rows that have the same values into summary rows.
ms.date: 11/10/2025
---

# `GROUP BY` (NoSQL query)

The `GROUP BY` clause collects rows that have the same values into summary rows.

## Syntax

```nosql
GROUP BY <expression>
```

## Arguments

| | Description |
| --- | --- |
| **`expression`** | The expression to group by. |

## Return types

Returns grouped rows based on the specified expression.

## Examples

This section contains examples of how to use this query language construct.

### Group by a property

In this example, the `GROUP BY` clause is used to group employees by their software development language.

```nosql
SELECT 
  e.capabilities.softwareDevelopment AS developmentLang
FROM
  employees e
WHERE
  e.team = "Cloud software engineering"
GROUP BY
  e.capabilities.softwareDevelopment
```

```json
[
  {},
  {
    "developmentLang": "c-sharp"
  },
  {
    "developmentLang": "javascript"
  },
  {
    "developmentLang": "python"
  }
]
```
