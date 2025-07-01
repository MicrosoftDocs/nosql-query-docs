---
title: DOCUMENTID
description: The `DOCUMENTID` function returns the unique document ID for a given item in the container. This can be used for filtering or retrieving the document&#39;s internal identifier.
ms.date: 06/30/2025
---

# `DOCUMENTID` (NoSQL query)

The `DOCUMENTID` function returns the unique document ID for a given item in the container. This can be used for filtering or retrieving the document's internal identifier.

## Syntax

```nosql
DOCUMENTID(<item_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`item_expr`** | The item or alias representing the document. |

## Return types

Returns the unique document ID as a numeric value.

## Examples

This section contains examples of how to use this query language construct.

### Retrieve document ID

In this example, the `DOCUMENTID` function is used to get the internal document ID for each product.

```nosql
SELECT
  p.id,
  p._rid,
  DOCUMENTID(p) AS documentId
FROM  
  product p
```

```json
[
  {
    "id": "5741047452",
    "_rid": "36ZyAPW+uN8NAAAAAAAAAA==",
    "documentId": 13
  }
]
```

### Filter by document ID range

In this example, the `DOCUMENTID` function is used in a WHERE clause to filter documents by their internal ID.

```nosql
SELECT
  p.id,
  DOCUMENTID(p) AS documentId
FROM  
  product p
WHERE
  DOCUMENTID(p) >= 5 AND
  DOCUMENTID(p) <= 15
```

```json
[
  {
    "id": "5720559175",
    "documentId": 13
  }
]
```

## Remarks

- This function returns an integer value that is only unique within a single physical partition.
