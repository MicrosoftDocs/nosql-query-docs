---
title: FULLTEXTCONTAINSALL
description: The `FULLTEXTCONTAINSALL` function returns a boolean indicating whether all of the provided string expressions are contained in a specified property path.
ms.date: 11/10/2025
---

# `FULLTEXTCONTAINSALL` (NoSQL query)

The `FULLTEXTCONTAINSALL` function returns a boolean indicating whether all of the provided string expressions are contained in a specified property path.

## Syntax

```nosql
FULLTEXTCONTAINSALL(<property_path>, <string_expr1>, <string_expr2>, ...)
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

### Full text contains all simple example

In this example, the `FULLTEXTCONTAINSALL` function is used to find all documents that contain both "search phrase" and "keyword" in the path `c.text`, projects the path, and returns only the TOP 10.

```nosql
SELECT TOP 10 c.text
FROM c
WHERE FULLTEXTCONTAINSALL(c.text, "search phrase", "keyword")
```

```json
-- Example result not available (result not provided in markdown)
```

### Full text contains all with multiple keywords

In this example, the `FULLTEXTCONTAINSALL` function is used to return all documents that contain "keyword1", "keyword2", and "keyword3" in the path `c.text`.

```nosql
SELECT *
FROM c
WHERE FULLTEXTCONTAINSALL(c.text, "keyword1", "keyword2", "keyword3")
```

```json
-- Example result not available (result not provided in markdown)
```

## Remarks

- This function requires enrollment in the Azure Cosmos DB NoSQL Full Text Search feature.
- This function benefits from a Full Text Index.
