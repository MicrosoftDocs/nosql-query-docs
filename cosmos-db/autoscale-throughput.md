---
title: Autoscale Throughput
description: Discover how autoscale throughput in Cosmos DB (in Azure and Fabric) optimizes performance and costs for variable workloads. Learn benefits, use cases, and implementation strategies.
ms.topic: concept-article
ms.date: 11/10/2025
---

# Autoscale throughput in Cosmos DB (in Azure and Fabric)

Cosmos DB (in Azure and Fabric) supports autoscale provisioned throughput. Autoscale provisioned throughput is well suited for mission-critical workloads that have variable or unpredictable traffic patterns. Autoscale in Cosmos DB scales workloads based on the most active partition. For nonuniform workloads that have different workload patterns, this scaling can cause unnecessary scale-ups. Dynamic autoscale is an enhancement to autoscale provisioned throughout that helps scaling of such nonuniform workloads independently based on usage, at a per partition level. Dynamic scaling allows you to save cost if you often experience hot partitions.

## Benefits

Cosmos DB containers (or databases) configured with autoscale provisioned throughput have the following benefits:

- **Simple:** Autoscale removes the complexity of managing throughput or manually scaling capacity.

- **Scalable:** Containers automatically scale the provisioned throughput as needed. There's no disruption to client applications.

- **Instantaneous:** Containers scale up *instantly* when needed. There's no warm-up period when extra throughput is required for sudden increases.

- **Cost-effective:** Autoscale helps optimize your RU/s usage and cost usage by scaling down when not in use. You only pay for the resources that your workloads need on a per-hour basis.

- **Highly available:** Containers using autoscale use the same fault-tolerant, highly available Cosmos DB backend to ensure data durability and high availability.

> [!IMPORTANT]
> Database and container-level throughput provisioning is available in Azure Cosmos DB. Container-level throughout provisioning is available in Cosmos DB in Microsoft Fabric.

## Use cases

Autoscale in Cosmos DB can be beneficial across various workloads, especially variable or unpredictable workloads. When your workloads have variable or unpredictable spikes in usage, autoscale helps by automatically scaling up and down based on usage. Examples include:

- Power BI reports or notebooks executed by users with unpredictable usage patterns.
- Development and test workloads used primarily during working hours.
- Scheduled Spark jobs with operations, or queries that you want to run during idle periods.
- Line of business applications that see peak usage a few times a month or year, and more.

Building a custom solution to these problems not only requires an enormous amount of time, but also introduces complexity in your application's configuration or code. Autoscale enables the above scenarios out of the box and removes the need for custom or manual scaling of capacity.

## Related content

- [Request units in Cosmos DB (in Azure and Fabric)](request-units.md)
