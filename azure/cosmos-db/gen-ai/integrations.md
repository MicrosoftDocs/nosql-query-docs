---
title: Integrations for AI
description: Learn how to integrate Azure Cosmos DB with AI and large language model (LLM) orchestration frameworks like Semantic Kernel, LangChain, and LlamaIndex for building intelligent applications.
author: jcodella
ms.author: jacodel
ms.service: azure-cosmos-db
ms.topic: how-to
ms.date: 10/20/2025
ms.collection:
  - ce-skilling-ai-copilot
appliesto:
  - ✅ NoSQL
---

# Azure Cosmos DB integrations for AI applications

Azure Cosmos DB integrates seamlessly with popular AI and large language model (LLM) orchestration frameworks to help you build intelligent applications. This article provides an overview of the available integrations with Semantic Kernel, LangChain, and LlamaIndex, along with links to their respective connectors and documentation.


## Semantic Kernel

[Semantic Kernel](https://github.com/microsoft/semantic-kernel) is an open-source framework by Microsoft that combines AI agents with languages like C#, Python, and Java, enabling seamless orchestration of code and AI models.

### .NET/C# 

[Vector Store Connector](https://github.com/MicrosoftDocs/semantic-kernel-docs/blob/main/semantic-kernel/concepts/vector-store-connectors/out-of-the-box-connectors/azure-cosmosdb-nosql-connector.md) The Azure CosmosDB NoSQL Vector Store connector can be used to access and manage data in Azure CosmosDB NoSQL. The connector provides seamless integration for vector search operations.

### Python

- [Vector Store Connector](/semantic-kernel/concepts/vector-store-connectors/out-of-the-box-connectors/azure-cosmosdb-nosql-connector?pivots=programming-language-python)

### C# / .NET

- [Vector Store Connector](/semantic-kernel/concepts/vector-store-connectors/out-of-the-box-connectors/azure-cosmosdb-nosql-connector?pivots=programming-language-csharp)


## LangChain

[LangChain](https://www.langchain.com/) is a framework that simplifies the creation of applications powered by large language models (LLMs), offering tools for context-aware reasoning applications across multiple languages.

### Python

The [langchain-azure-cosmosdb](https://pypi.org/project/langchain-azure-cosmosdb/) package provides comprehensive Azure Cosmos DB integration for LangChain in Python:

| Functionality | Sync | Async |
| --- | --- | --- |
| **Vector Store** | `AzureCosmosDBNoSqlVectorSearch` | `AsyncAzureCosmosDBNoSqlVectorSearch` |
| **Semantic Cache** | `AzureCosmosDBNoSqlSemanticCache` | `AsyncAzureCosmosDBNoSqlSemanticCache` |
| **Chat History** | `CosmosDBChatMessageHistory` | `AsyncCosmosDBChatMessageHistory` |

**Capabilities:**
- Vector, full-text, hybrid, and weighted hybrid search
- LLM response caching backed by CosmosDB
- Persistent chat message history

### JavaScript

- [Vector Store](https://js.langchain.com/docs/integrations/vectorstores/azure_cosmosdb_nosql/)

### Java

- [Embedding Store](https://docs.langchain4j.dev/integrations/embedding-stores/azure-cosmos-nosql/)


## LangGraph

[LangGraph](https://www.langchain.com/langgraph) is a library from LangChain for building stateful, multi-actor applications with LLMs, used to create agent and multi-agent workflows.

### Python

The [langchain-azure-cosmosdb](https://pypi.org/project/langchain-azure-cosmosdb/) package provides comprehensive Azure Cosmos DB integration for LangGraph in Python:

| Functionality | Sync | Async |
| --- | --- | --- |
| **Graph State Persistence** | `CosmosDBSaverSync` | `CosmosDBSaver` |
| **Node-level Result Caching** | `CosmosDBCacheSync` | `CosmosDBCache` |
| **Long-term Memory** | `CosmosDBStore` | `AsyncCosmosDBStore` |

**Capabilities:**
- LangGraph graph state persistence
- LangGraph node-level result caching
- LangGraph long-term memory with optional vector search


## Agent Framework

[Agent Framework](https://github.com/microsoft/agent-framework) is a Microsoft framework for building AI agents and workflows with support for multi-agent orchestration and state management.

### Python

The Azure Cosmos DB integration for Agent Framework Python provides workflow and agent state management:

**Components:**
- `CosmosDBWorkflowCheckpointStorage` - Cosmos DB Workflow Checkpoint Storage
- `CosmosDBHistoryProvider` - Azure Cosmos DB History Provider
- Database and Container Setup utilities

**[Python Package](https://github.com/microsoft/agent-framework/tree/main/python/packages/azure-cosmos)**

### C# / .NET

The Azure Cosmos DB NoSQL integration for Agent Framework .NET provides checkpoint and chat history management:

**Components:**
- `CheckpointStore` - Workflow checkpoint storage
- `ChatHistoryProvider` - Chat history management
- `WorkflowExtensions` - Workflow integration extensions
- `ChatExtensions` - Chat integration extensions

**[.NET Package](https://github.com/microsoft/agent-framework/tree/main/dotnet/src/Microsoft.Agents.AI.CosmosNoSql)**


## LlamaIndex

[LlamaIndex](https://www.llamaindex.ai/) is a framework for building context-augmented AI applications that can integrate private or domain-specific data with LLMs for complex workflows.

### Python

- [Vector Store](https://developers.llamaindex.ai/python/examples/vector_stores/azurecosmosdbnosqldemo/)


## Spring AI

[Spring AI](https://spring.io/projects/spring-ai) is a Spring-based framework that provides a consistent API for AI engineering, bringing familiar Spring design patterns to AI application development in Java.

### Java

- [Vector Store](https://docs.spring.io/spring-ai/reference/api/vectordbs/azure-cosmos-db.html)

## Related content

- [Azure Cosmos DB Samples Gallery](https://aka.ms/AzureCosmosDB/Gallery)
- [Vector Search with Azure Cosmos DB for NoSQL](vector-search-overview.md)
- [Tokens](tokens.md)
- [Vector Embeddings](vector-embeddings.md)
- [Retrieval Augmented Generated (RAG)](rag.md)
 