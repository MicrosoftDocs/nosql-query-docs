---
title: |
  Tutorial: Build a TypeScript app with the Azure Cosmos DB emulator and deploy to Azure
description: In this tutorial, use the Azure Cosmos DB Linux emulator for local development, build a TypeScript app, and deploy to Azure Cosmos DB.
ms.topic: tutorial
ms.date: 04/15/2026
# Customer intent: As a developer, I want to build and test an app locally using the Azure Cosmos DB emulator so that I can migrate to Azure Cosmos DB with minimal friction.
---

# Tutorial: Build a TypeScript app with the Azure Cosmos DB emulator and deploy to Azure Cosmos DB

In this tutorial, you use the Azure Cosmos DB Linux emulator as a local development database, build a TypeScript application, and then migrate to Azure Cosmos DB by swapping your credentials.

In this tutorial, you:

> [!div class="checklist"]
> - Start the Azure Cosmos DB emulator in a Docker container
> - Create a TypeScript application
> - Connect the application to the local emulator
> - Create an Azure Cosmos DB account
> - Deploy the application to Azure Cosmos DB

## Prerequisites

- [Node.js 22 or newer](https://nodejs.org/en/download/)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [Azure CLI](/cli/azure/install-azure-cli)
- An Azure subscription. If you don't have an Azure subscription, create a [free account](https://azure.microsoft.com/pricing/purchase-options/azure-account) before you begin.
