---
title: Overview
description: Discover the NoSQL query language used in Azure Cosmos DB for NoSQL and Cosmos DB in Microsoft Fabric. Learn syntax, features, and best practices.
ms.devlang: nosql
ms.date: 06/24/2025
ai-usage: ai-generated
---

# What is the NoSQL query language?

The NoSQL query language provides a powerful, SQL-like syntax for working with JSON data. This language is designed to be familiar to users with SQL experience, while also supporting the flexibility and hierarchical nature of JSON documents. This article introduces the core concepts, syntax, and features of the NoSQL query language.

## Core concepts of the NoSQL query language

The NoSQL query language is built to provide expressive and efficient access to data stored as JSON documents. At its foundation, the language is designed to work natively with hierarchical and flexible data, supporting both simple and complex queries over documents that may have varying structures.

Queries are composed using a familiar SQL-like syntax, but are adapted for the document model. This means that, unlike traditional relational databases, there is no fixed schema—properties can be missing or have different types across documents. The language is case-sensitive and supports referencing nested properties, arrays, and objects directly within queries. Logical, comparison, and arithmetic operators are available, and the language is designed to be intuitive for those with SQL experience while embracing the flexibility of NoSQL data.

The query engine is optimized for high performance and scalability, automatically leveraging indexes to efficiently filter, sort, and aggregate data. It supports a wide range of query patterns, from simple lookups to complex aggregations and subqueries, making it suitable for both transactional and analytical workloads. The language also provides constructs for working with arrays, handling null and undefined values, and projecting results in flexible JSON shapes, enabling developers to retrieve exactly the data they need in the format required by their applications.

## Basic Query Structure

A typical query consists of the following clauses:

- `SELECT`: Specifies which fields or values to return.
- `FROM`: Identifies the source container and can assign an alias.
- `WHERE`: Filters documents based on conditions.
- `ORDER BY`: Sorts the results.
- `GROUP BY`: Groups results by one or more properties.

### Example: Simple Query

```nosql
SELECT p.id, p.name
FROM products p
WHERE p.price > 20
ORDER BY p.price ASC
```

This query returns the `id` and `name` of products with a price greater than 20, sorted by price in ascending order.

## Working with JSON Properties

You can access nested properties using dot notation or bracket notation:

```nosql
SELECT p.manufacturer.name, p["metadata"].sku
FROM products p
```

Arrays can be traversed using `JOIN` or subqueries:

```nosql
SELECT p.name, c AS color
FROM products p
JOIN c IN p.metadata.colors
```

## Filtering Data

The `WHERE` clause supports a wide range of operators, including arithmetic, logical, comparison, and string operations:

```nosql
SELECT *
FROM products p
WHERE p.category IN ("Accessories", "Clothing") AND p.price BETWEEN 10 AND 50
```

## Aggregation and Grouping

You can use aggregate functions and group results:

```nosql
SELECT p.category, COUNT(1) AS productCount
FROM products p
GROUP BY p.category
```

## Distinct, Top, and Like

- `DISTINCT` removes duplicate values.
- `TOP N` limits the number of results.
- `LIKE` supports pattern matching with wildcards.

```nosql
SELECT DISTINCT VALUE p.category
FROM products p

SELECT TOP 5 *
FROM products p
ORDER BY p.price DESC

SELECT *
FROM products p
WHERE p.name LIKE "%bike%"
```

## Subqueries

Subqueries allow for more advanced filtering and projection, including checking for the existence of values in arrays:

```nosql
SELECT VALUE p.name
FROM products p
WHERE EXISTS (
    SELECT VALUE c FROM c IN p.metadata.colors WHERE c LIKE "%blue%"
)
```

## Summary

The NoSQL query language is a flexible, expressive way to retrieve and manipulate JSON data. It combines the familiarity of SQL with the power of querying hierarchical, schema-less data. For more details on each clause and advanced features, see the related articles in this folder.

## Related content

- [Get started with the NoSQL query language](get-started-json.md)
- [System functions](functions/index.md)
