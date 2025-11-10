---
title: Query Advisor
description: Learn how to use Query Advisor to optimize queries for performance, cost, and scalability in Azure Cosmos DB. Get actionable recommendations to improve your data queries. Try Query Advisor now!
ms.date: 11/10/2025
ms.custom:
  - sfi-ropc-nochange
appliesto:
  - ✅ Azure Cosmos DB for NoSQL
---

# Query Advisor for Cosmos DB

Cosmos DB now features Query Advisor, designed to help you write faster and more efficient queries using the Cosmos DB query language. Whether you're optimizing for performance, cost, or scalability, Query Advisor provides actionable recommendations to help you get the most out of your data across Azure and Microsoft Fabric.

## Why query optimization matters

The query language for Cosmos DB (in Azure and Fabric) is flexible, allowing developers to query JSON data with familiar SQL-like syntax. As applications grow in complexity, small differences in query structure can have a significant effect on performance and request units (RUs), especially at large scale.

For example, two queries that return the same result could differ dramatically in efficiency based on how predicates are written and how indexes are applied.

Query Advisor analyzes your queries and offers targeted recommendations to help you:

- **Reduce RU costs** by identifying inefficient expressions or unnecessary filters.
- **Improve query performance** through more optimal query structures.
- **Understand the "why"** behind each suggestion, with explanations written in clear, developer-friendly language.

## How it works

When you execute a query, Query Advisor runs over your query plan, evaluating patterns that might cause high RU consumption, excessive scans, or potentially unnecessary processing. It then returns a set of recommendations that indicate which part of the query could be limiting performance, and suggests potential changes that could help.

## Using Query Advisor

You can enable Query Advisor capabilities by setting the `PopulateQueryAdvice` property in `QueryRequestOptions` to `true`. When not specified, `PopulateQueryAdvice` defaults to `false`. To access the advice, use the string property `FeedResponse.QueryAdvice`.

> [!IMPORTANT]
> Query Advisor only works with the .NET SDK for Cosmos DB. The query advice is also only returned on the first round trip. The advice is unavailable on subsequent continuation calls.

Consider this example query:

```nosql
SELECT VALUE
    r.id
FROM
    root r
WHERE
    CONTAINS(r.name, 'Abc')
```

Here's an example of an SDK request that performs this query and uses Query Advisor:

```csharp
using Microsoft.Azure.Cosmos;

CosmosClient client = new("<connection-string>");
Container container = client.GetContainer("<database-name>", "<container-name>");

string query = """
SELECT VALUE
    r.id
FROM
    root r
WHERE
    CONTAINS(r.name, 'Abc')
""";

QueryRequestOptions requestOptions = new()
{
    PopulateQueryAdvice = true
};

using FeedIterator<dynamic> itemQuery = container.GetItemQueryIterator<dynamic>(
    query,
    requestOptions: requestOptions);

string? queryAdvice = null;
while (itemQuery.HasMoreResults)
{
    if (queryAdvice is not null)
    {
        break;
    }

    FeedResponse<dynamic> page = await itemQuery.ReadNextAsync();
    queryAdvice = page.QueryAdvice;
}

Console.WriteLine(queryAdvice);
```

This request returns a single advice statement for `QA1002`:

```output
QA1002: If you are matching on a string prefix, consider using STARTSWITH. [...]
```

The query advice contains three important pieces of information:

- **The Query Advice ID**: `QA1002`
- **The advice description**: IN this example, `If you are matching on a string prefix, consider using STARTSWITH.`
- **The link to the documentation**: A URL to detailed guidance

> [!NOTE]
> The link to the documentation was omitted from this example.

## Examples

Consider the following examples of scenarios where you can use Query Advisor.

### Optimizing system function usage

Consider this example where the `GetCurrentTimestamp` function is used:

```nosql
SELECT
    GetCurrentTicks() 
FROM
    container c
WHERE
    GetCurrentTimestamp() > 10
```

In this example, there are two pieces of advice returned by Query Advisor: `QA1008` and `QA1009`. Each piece of advice is separated into a new line in the string output.

```output
QA1009: Consider using GetCurrentTimestampStatic instead of GetCurrentTimestamp in the WHERE clause. [...]
```

```output
QA1008: Consider using GetCurrentTicksStatic instead of GetCurrentTicks in the WHERE clause. [...]
```

Using this advice, you could rewrite the query to the following alternative:

```nosql
SELECT
    GetCurrentTicksStatic() 
FROM
    container c
WHERE
    GetCurrentTimestampStatic() > 10
```
