---
title: FULLTEXTCONTAINS
description: The `FULLTEXTCONTAINS` function returns a boolean indicating whether the keyword string expression is contained in a specified property path.
ms.date: 11/10/2025
---

# `FULLTEXTCONTAINS` - Query language in Cosmos DB (in Azure and Fabric)

The `FULLTEXTCONTAINS` function returns a boolean indicating whether the keyword string expression is contained in a specified property path.

## Syntax

```nosql
FULLTEXTCONTAINS(<property_path>, <string_expr>)
```

## Arguments

| | Description |
| --- | --- |
| **`property_path`** | The property path to search. |
| **`string_expr`** | The string to find. |

## Return types

Returns a boolean expression.

## Examples

This section contains examples of how to use this query language construct.

### Full text contains simple example

In this example, the `FULLTEXTCONTAINS` function is used to return 10 results that contain "search phrase" in the `c.text` property.

```nosql
SELECT TOP 10 *
FROM c
WHERE FULLTEXTCONTAINS(c.text, "search phrase")
```

```json
-- Example result not available (result not provided in markdown)
```

### Full text contains with logical operators

In this example, the `FULLTEXTCONTAINS` function is used with logical operators to ensure multiple keywords or phrases are included.

```nosql
SELECT *
FROM c
WHERE FULLTEXTCONTAINS(c.text, "keyword1") AND FULLTEXTCONTAINS(c.text, "keyword2")
```

```json
-- Example result not available (result not provided in markdown)
```

## Remarks

- This function requires enrollment in the Azure Cosmos DB NoSQL Full Text Search feature.
- This function benefits from a Full Text Index.
