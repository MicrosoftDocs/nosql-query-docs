---
title: RAND
description: The `RAND` function returns a randomly generated numeric value from zero to one.
ms.date: 11/10/2025
---

# `RAND` (NoSQL query)

The `RAND` function returns a randomly generated numeric value from zero to one.

## Syntax

```nosql
RAND()
```

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Randomly generated values

In this example, the `RAND` function is used to return random values.

```nosql
SELECT VALUE {
  randomOneToOne: RAND(),
  randomeOneToHundred: RAND() * 100
}
```

```json
[
  {
    "randomOneToOne": 0.134644033620134,
    "randomeOneToHundred": 57.51777137629688
  }
]
```
