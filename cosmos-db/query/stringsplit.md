---
title: STRINGSPLIT
description: The `STRINGSPLIT` function returns an array of substrings obtained from separating the source string by the specified delimiter.
ms.date: 11/10/2025
---

# `STRINGSPLIT` (NoSQL query)

The `STRINGSPLIT` function returns an array of substrings obtained from separating the source string by the specified delimiter.

The `STRINGSPLIT` function returns an array of substrings obtained from separating the source string by the specified delimiter in Azure Cosmos DB for NoSQL.

## Syntax

```nosql
STRINGSPLIT(<string_expr1>, <string_expr2>)
```

## Arguments

| | Description |
| --- | --- |
| **`string_expr1`** | The source string expression to parse. |
| **`string_expr2`** | The string used as the delimiter. |

## Return types

Returns an array expression.

## Examples

This section contains examples of how to use this query language construct.

### Split string into substrings

In this example, the `STRINGSPLIT` function is used to split a string into substrings using various delimiters.

```nosql
SELECT VALUE {
  seperateOnLetter: STRINGSPLIT("Handlebar", "e"),
  seperateOnSymbol: STRINGSPLIT("CARBON_STEEL_BIKE_WHEEL", "_"),
  seperateOnWhitespace: STRINGSPLIT("Road Bike", " "),
  seperateOnPhrase: STRINGSPLIT("xenmoun mountain bike", "moun"),
  undefinedSeperator: STRINGSPLIT("AluminumBikeFrame", undefined),
  emptySeparatorString: STRINGSPLIT("Helmet", ""),
  emptySourceString: STRINGSPLIT("", "")
}
```

```json
[
  {
    "seperateOnLetter": [
      "Handl",
      "bar"
    ],
    "seperateOnSymbol": [
      "CARBON",
      "STEEL",
      "BIKE",
      "WHEEL"
    ],
    "seperateOnWhitespace": [
      "Road",
      "Bike"
    ],
    "seperateOnPhrase": [
      "xen",
      " ",
      "tain bike"
    ],
    "emptySeparatorString": [
      "Helmet"
    ],
    "emptySourceString": [
      ""
    ]
  }
]
```

## Remarks

- This function doesn't utilize the index.
