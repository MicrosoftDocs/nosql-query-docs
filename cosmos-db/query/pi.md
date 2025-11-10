---
title: PI
description: The `PI` function returns the constant value of Pi.
ms.date: 11/10/2025
---

# `PI` (NoSQL query)

The `PI` function returns the constant value of Pi.

## Syntax

```nosql
PI()
```

## Return types

Returns a numeric expression.

## Examples

This section contains examples of how to use this query language construct.

### Return the constant value of Pi

In this example, the `PI` function is used to return the constant value of Pi.

```nosql
SELECT VALUE
  PI()
```

```json
[
  3.141592653589793
]
```
