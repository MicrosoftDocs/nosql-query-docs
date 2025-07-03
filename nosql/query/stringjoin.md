---
title: STRINGJOIN
description: The `STRINGJOIN` function returns a string, which concatenates the elements of a specified array, using the specified separator between each element.
ms.date: 07/02/2025
---

# `STRINGJOIN` (NoSQL query)

The `STRINGJOIN` function returns a string, which concatenates the elements of a specified array, using the specified separator between each element.

The `STRINGJOIN` function returns a string by concatenating the elements of an array using a specified separator in Azure Cosmos DB for NoSQL.

## Syntax

```nosql
STRINGJOIN(<array_expr>, <string_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`array_expr`** | An array expression with all string items inside. |
| **`string_expr`** | A string expression to use as the separator. |

## Return types

Returns a string expression.

## Examples

This section contains examples of how to use this query language construct.

### Join array elements into a string

In this example, the `STRINGJOIN` function is used to combine multiple strings from an array using various separators.

```nosql
SELECT VALUE {
  joinUsingSpaces: STRINGJOIN(["Iropa", "Mountain", "Bike"], " "),
  joinUsingEmptyString: STRINGJOIN(["Iropa", "Mountain", "Bike"], ""),
  joinUsingUndefined: STRINGJOIN(["Iropa", "Mountain", "Bike"], undefined),
  joinUsingCharacter: STRINGJOIN(["6", "7", "4", "3"], "A"),
  joinUsingPhrase: STRINGJOIN(["Adventure", "LT"], "Works")
}
```

```json
[
  {
    "joinUsingSpaces": "Iropa Mountain Bike",
    "joinUsingEmptyString": "IropaMountainBike",
    "joinUsingCharacter": "6A7A4A3",
    "joinUsingPhrase": "AdventureWorksLT"
  }
]
```

## Remarks

- This function doesn't utilize the index.
