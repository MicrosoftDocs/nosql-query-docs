---
title: Overview
description: Discover the MongoDB Query Language (MQL) used in DocumentDB. Learn syntax, features, and best practices.
ms.date: 12/30/2025
ai-usage: ai-generated
---

# What is the query language in DocumentDB (in Azure)?

DocumentDB is an open-source, document-oriented database that uses the MongoDB Query Language (MQL) for querying and manipulating data. MQL provides a rich and expressive syntax for working with JSON-like documents stored in Binary JSON (BSON) format. This language is designed to work naturally with hierarchical document structures, supporting both simple queries and complex aggregations. As a widely adopted query language in the document database ecosystem, MQL enables developers to apply their existing MongoDB knowledge while working with DocumentDB's scalable, flexible storage engine.

## Model

In DocumentDB, MQL is built around the document model, where data is stored as collections of documents rather than rows in tables. Queries are expressed using a declarative syntax with operators that begin with the dollar sign (`$`), such as `$match`, `$project`, and `$group`. This approach allows developers to filter, transform, and aggregate data through a pipeline of operations that can be composed and reused.

The language natively supports nested documents and arrays, enabling developers to work directly with complex, hierarchical data structures without requiring joins or normalization. MQL provides a comprehensive set of operators for comparison, logical operations, array manipulation, and aggregation. DocumentDB's query engine uses indexes to efficiently execute queries across large datasets, making it suitable for both operational and analytical workloads.

## Compatibility

DocumentDB's compatibility philosophy centers on providing comprehensive MongoDB Query Language (MQL) support while maintaining flexibility to evolve with the document database ecosystem. The system evaluates compatibility by measuring support across key operator categories including aggregation stages, aggregation operators, query and projection operators, and update operators. This compatibility ensures you can apply your existing MongoDB expertise and migrate applications with minimal friction, as most standard MQL constructs work seamlessly without modification.

When building applications with DocumentDB, you benefit from transparent compatibility that eliminates the need for query translation or code adaptation. You can use existing MongoDB client drivers and software development kits (SDKs) directly, as DocumentDB implements the MongoDB wire protocol. Your typical CRUD operations, aggregation pipelines, and index strategies transfer directly from MongoDB-based systems, allowing you to focus on application logic rather than database-specific adaptations. While DocumentDB continuously expands its operator coverage, the stable foundation ensures your applications remain portable and maintainable.
