---
title: Azure Resource Graph Sample Queries
description: Sample Azure Resource Graph queries for Azure Cosmos DB showing use of resource types and tables to access Azure Cosmos DB related resources and properties.
ms.date: 07/07/2022
ms.topic: sample
author: manishmsfte
ms.author: mansha
ms.service: azure-cosmos-db
ms.custom: subject-resourcegraph-sample
ai-usage: ai-assisted
appliesto:
  - ✅ NoSQL
  - ✅ MongoDB
  - ✅ Apache Cassandra
  - ✅ Apache Gremlin
  - ✅ Table
---

# Azure Resource Graph sample queries for Azure Cosmos DB

This page is a collection of [Azure Resource Graph](/azure/governance/resource-graph/overview) sample queries for Azure Cosmos DB.

## Sample queries

### Count Azure Cosmos DB accounts

```kusto
Resources
| where type == 'microsoft.documentdb/databaseaccounts'
| summarize count()
```

### List Azure Cosmos DB accounts modified in the last 30 days

```kusto
Resources
| where type == 'microsoft.documentdb/databaseaccounts'
| extend lastModifiedAt = todatetime(properties.systemData.lastModifiedAt)
| where isnotnull(lastModifiedAt) and lastModifiedAt >= ago(30d)
| project subscriptionId, resourceGroup, name, lastModifiedAt
| order by lastModifiedAt desc
```

### Identify non-compliant Azure Cosmos DB accounts

```kusto
policyresources
| where type =~ 'microsoft.policyinsights/policystates'
| extend resourceType = tostring(properties.resourceType), complianceState = tostring(properties.complianceState)
| where resourceType =~ 'microsoft.documentdb/databaseaccounts' and complianceState =~ 'NonCompliant'
| project subscriptionId, resourceId = tostring(properties.resourceId), policyAssignment = tostring(properties.policyAssignmentName), policyDefinition = tostring(properties.policyDefinitionName), complianceState
| summarize nonCompliantPolicies = count() by subscriptionId, resourceId
| order by nonCompliantPolicies desc
```

### List Azure Cosmos DB accounts with specific write locations

```kusto
Resources
| where type =~ 'microsoft.documentdb/databaseaccounts'
| project id, name, writeLocations = (properties.writeLocations)
| mv-expand writeLocations
| project id, name, writeLocation = tostring(writeLocations.locationName)
| where writeLocation in ('East US', 'West US')
| summarize by id, name
```

## Next steps

- Learn more about the [query language](/azure/governance/resource-graph/concepts/query-language).
- Learn more about how to [explore resources](/azure/governance/resource-graph/concepts/explore-resources).
