---
title: Parameterized Queries
description: Execute parameterized queries in Cosmos DB to provide robust handling and escaping of user input, and prevent accidental exposure of data through SQL injection.
ms.date: 11/10/2025
---

# Parameterized queries - Query language in Cosmos DB (in Azure and Fabric)

Cosmos DB (in Azure and Fabric) supports queries with parameters expressed by the familiar @ notation. Parameterized SQL provides robust handling and escaping of user input, and prevents accidental exposure of data through SQL injection.

## Examples

For example, you can write a query that takes `upperPriceLimit` as a parameter, and execute it for various values of `price` based on user input.

```nosql
SELECT
    *
FROM
    p
WHERE
    (NOT p.onSale) AND
    (p.price BETWEEN 0 AND @upperPriceLimit)
```

You can then send this request to Cosmos DB as a parameterized JSON query object.

```json
{
  "query": "SELECT * FROM p WHERE (NOT p.onSale) AND (p.price BETWEEN 0 AND @upperPriceLimit)",
  "parameters": [
    {
      "name": "@upperPriceLimit",
      "value": 100
    }
  ]
}
```

This next example sets the `TOP` argument with a parameterized query:

```nosql
{
  "query": "SELECT TOP @pageSize * FROM products",
  "parameters": [
    {
      "name": "@pageSize",
      "value": 10
    }
  ]
}
```

Parameter values can be any valid JSON: strings, numbers, booleans, null, even arrays or nested JSON. Since Cosmos DB is schemaless, parameters aren't validated against any type.

Here are examples for parameterized queries in each Cosmos DB SDK:

- [.NET SDK](https://github.com/Azure/azure-cosmos-dotnet-v3/blob/master/Microsoft.Azure.Cosmos.Samples/Usage/Queries/Program.cs#L195)
- [Java](https://github.com/Azure-Samples/azure-cosmos-java-sql-api-samples/blob/main/src/main/java/com/azure/cosmos/examples/queries/sync/QueriesQuickstart.java#L392-L421)
- [Node.js](https://github.com/Azure/azure-cosmos-js/blob/master/samples/ItemManagement.ts#L58-L79)
- [Python](https://github.com/Azure/azure-sdk-for-python/blob/master/sdk/cosmos/azure-cosmos/samples/document_management.py#L66-L78)

## Related content

- [`SELECT` clause](select.md)
- [`WHERE` clause](where.md)
