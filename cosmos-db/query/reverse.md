---
title: REVERSE
description: The `REVERSE` function returns the reverse order of a string value.
ms.date: 11/10/2025
---

# `REVERSE` - Query language in Cosmos DB (in Azure and Fabric)

The `REVERSE` function returns the reverse order of a string value.

An Azure Cosmos DB for NoSQL system function that returns a reversed string.

## Syntax

```cosmos-db
REVERSE(<string_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr`** | A string expression. |

## Return types

Returns a string expression.

## Examples

This section contains examples of how to use this query language construct.

### Reverse string value

In this example, the function reverses multiple strings.

```cosmos-db
SELECT VALUE {
  reverseAdventureWorks: REVERSE("AdventureWorks"),
  reverseAdventureWorksBack: REVERSE("skroWerutnevdA"),
  doubleReverseAdventureWorks: REVERSE(REVERSE("AdventureWorks"))
}
```

```json
[
  {
    "reverseAdventureWorks": "skroWerutnevdA",
    "reverseAdventureWorksBack": "AdventureWorks",
    "doubleReverseAdventureWorks": "AdventureWorks"
  }
]
```

## Remarks

- This function doesn't utilize the index.
