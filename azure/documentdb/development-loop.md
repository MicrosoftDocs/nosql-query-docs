---
title: |
  Tutorial: Build a TypeScript app with DocumentDB and deploy to Azure
titleSuffix:
description: In this tutorial, use DocumentDB for local development, build a TypeScript app with the MongoDB driver, and deploy to Azure DocumentDB.
ms.topic: tutorial
ms.date: 04/15/2026
# Customer intent: As a developer, I want to build and test an app locally using DocumentDB so that I can migrate to Azure DocumentDB with minimal friction.
---

# Tutorial: Build a TypeScript app with DocumentDB and deploy to Azure DocumentDB

In this tutorial, you use DocumentDB as a local development database in a Docker container, build a TypeScript application with the MongoDB driver, and then migrate to Azure DocumentDB by swapping your connection string.

In this tutorial, you:

> [!div class="checklist"]
> - Start DocumentDB in a Docker container
> - Create a TypeScript application
> - Connect the application to the local database
> - Create an Azure DocumentDB cluster
> - Deploy the application to Azure DocumentDB

## Prerequisites

- [Node.js 18 or newer](https://nodejs.org/en/download/)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [Azure CLI](/cli/azure/install-azure-cli)
- An Azure subscription. If you don't have an Azure subscription, create a [free account](https://azure.microsoft.com/pricing/purchase-options/azure-account) before you begin.

