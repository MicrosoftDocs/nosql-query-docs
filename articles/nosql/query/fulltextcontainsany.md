---
title: FULLTEXTCONTAINSANY
description: The `FULLTEXTCONTAINSANY` function returns a boolean indicating whether any of the provided string expressions are contained in a specified property path.
ms.date: 06/30/2025
---

# `FULLTEXTCONTAINSANY` (NoSQL query)

The `FULLTEXTCONTAINSANY` function returns a boolean indicating whether any of the provided string expressions are contained in a specified property path.

## Syntax

```nosql
FULLTEXTCONTAINSANY(<property_path>, <string_expr1>, <string_expr2>, ...)
```

## Arguments

| | Description |
| --- | --- |
| **`property_path`** | The property path to search. |
| **`string_expr1`** | A string to find. |
| **`string_expr2`** | A string to find. |

## Return types

Returns a boolean expression.

## Examples

This section contains examples of how to use this query language construct.

### Full text contains any simple example

In this example, the `FULLTEXTCONTAINSANY` function is used to return all documents that contain either "search phrase" or "keyword" in the path `c.text`, projects the path, and returns only the TOP 10.

```nosql
SELECT TOP 10 c.text
FROM c
WHERE FULLTEXTCONTAINSANY(c.text, "search phrase", "keyword")
```

```json
-- Example result not available (result not provided in markdown)
```

### Full text contains any with multiple keywords

In this example, the `FULLTEXTCONTAINSANY` function is used to return all documents that contain "keyword1", "keyword2", or "keyword3" in the path `c.text`.

```nosql
SELECT *
FROM c
WHERE FULLTEXTCONTAINSANY(c.text, "keyword1", "keyword2", "keyword3")
```

```json
-- Example result not available (result not provided in markdown)
```

## Remarks

- This function requires enrollment in the Azure Cosmos DB NoSQL Full Text Search feature.
- This function benefits from a Full Text Index.
