---
title: Azure Cosmos DB Shell Quick Start
description: Quick start guide with examples to get you started with Azure Cosmos DB Shell in minutes.
author: sajeetharan
ms.author: sasinnat
ms.reviewer: mjbrown
ms.service: azure-cosmos-db
ms.topic: how-to
ms.date: 05/04/2024
---

# Azure Cosmos DB Shell Quick Start

Get started with Azure Cosmos DB Shell in just a few minutes with these practical examples.

## Prerequisites

- Azure Cosmos DB Shell installed ([Installation Guide](install.md))
- Azure Cosmos DB account
- Authentication configured (Entra ID, Managed Identity, or Account Keys)

## Launch the Shell

```bash
cosmosdb-shell
```

You'll see a prompt:
```
cosmosdb-shell>
```

## Connect to Your Account

When you launch Cosmos DB Shell, it prompts you for authentication. You can:

1. **Use Entra ID** (Recommended)
   - Follow the browser authentication flow
   - Most secure method

2. **Use Managed Identity** (Production)
   - Automatically uses Azure managed identity
   - Best for production environments

3. **Use Account Key** (Development)
   - Provide connection string or account key
   - Quick for development/testing

## Basic Navigation

### View Your Account Endpoint
```bash
cosmosdb-shell> endpoint
```

### List Databases
```bash
cosmosdb-shell> ls
```

Output:
```
database1
database2
mydb
```

### Navigate to a Database
```bash
cosmosdb-shell> cd mydb
cosmosdb-shell mydb>
```

### List Containers in Database
```bash
cosmosdb-shell mydb> ls
```

Output:
```
users
products
orders
```

### Navigate to a Container
```bash
cosmosdb-shell mydb> cd users
cosmosdb-shell mydb/users>
```

### Show Current Path
```bash
cosmosdb-shell mydb/users> pwd
```

Output:
```
/mydb/users
```

## Basic Operations

### Create Database
```bash
cosmosdb-shell> mkdb mynewdb
```

### Create Container
```bash
cosmosdb-shell mydb> mkcon mycontainer -pk /id
```

(Creates container with partition key `/id`)

### Query Documents
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c WHERE c.status = 'active'"
```

Output:
```json
{
  "id": "user1",
  "name": "Alice",
  "status": "active"
}
{
  "id": "user2", 
  "name": "Bob",
  "status": "active"
}
```

### Count Documents
```bash
cosmosdb-shell mydb/users> query "SELECT COUNT(*) FROM c"
```

### Insert Document
```bash
cosmosdb-shell mydb/users> create {"id": "user3", "name": "Charlie", "status": "active"}
```

### Update Document
```bash
cosmosdb-shell mydb/users> update {"id": "user1", "name": "Alice", "status": "inactive"}
```

### Delete Document
```bash
cosmosdb-shell mydb/users> rm user1
```

### Delete Container
```bash
cosmosdb-shell mydb> rmcon users
```

### Delete Database
```bash
cosmosdb-shell> rmdb mydb
```

## Piping Commands

Combine commands to create powerful workflows.

### Query and Count
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq 'length'
```

### Filter Results with jq
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq '.[] | select(.status == "active")'
```

### Extract Specific Fields
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq '.[] | {id, name}'
```

### Transform and Output
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq '.[] | .name' | tr '\n' ','
```

## Shell Scripts

Create a script file for automated operations.

### Example Script: `batch_operations.sh`
```bash
#!/bin/bash

# Connect to Cosmos DB Shell
cosmosdb-shell << 'EOF'
cd mydb
cd users

# Insert multiple documents
create {"id": "user10", "name": "David", "status": "active"}
create {"id": "user11", "name": "Eve", "status": "inactive"}
create {"id": "user12", "name": "Frank", "status": "active"}

# Query and count
query "SELECT COUNT(*) as count FROM c"

# Exit
exit
EOF
```

### Run Script
```bash
bash batch_operations.sh
```

## Filtering and Searching

### Find Documents with Specific Criteria
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c WHERE c.age > 30 AND c.status = 'active'"
```

### Search in Arrays
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c WHERE ARRAY_CONTAINS(c.tags, 'vip')"
```

### Aggregate Results
```bash
cosmosdb-shell mydb/users> query "SELECT c.status, COUNT(*) as count FROM c GROUP BY c.status"
```

## Export and Import

### Export Data to JSON
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c" > users_export.json
```

### Export to CSV-like Format
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq -r '.id, .name, .status' | paste -sd, > users.csv
```

## Tips and Best Practices

### Use Aliases for Common Commands
```bash
# Add to your shell profile
alias cosmosdb='cosmosdb-shell'
```

### Tab Completion
- Use Tab to auto-complete database and container names
- Press Tab twice to see all available options

### Command History
- Arrow up/down to navigate command history
- Ctrl+R to search command history

### Formatting Output
```bash
# Pretty-print JSON
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq .

# Compact output
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq -c .
```

### Performance Tips

- **Use partition key in queries** for faster results:
  ```bash
  cosmosdb-shell mydb/users> query "SELECT * FROM c WHERE c.id = 'user1'"
  ```

- **Limit result set** for large queries:
  ```bash
  cosmosdb-shell mydb/users> query "SELECT TOP 100 * FROM c"
  ```

- **Use projections** to reduce data transfer:
  ```bash
  cosmosdb-shell mydb/users> query "SELECT c.id, c.name FROM c"
  ```

## Common Workflows

### Bulk Insert From File
```bash
cosmosdb-shell mydb/users> jq -r '.[]' data.json | while read line; do
  create $line
done
```

### Backup Container
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c" > backup_users.json
```

### Verify Data Migration
```bash
cosmosdb-shell mydb/users> query "SELECT COUNT(*) FROM c" 
cosmosdb-shell mydb/products> query "SELECT COUNT(*) FROM c"
```

## Next Steps

- [Complete Command Reference](command-reference.md) - Learn all available commands
- [MCP Server Setup](mcp-setup.md) - Enable AI integration
- [Troubleshooting Guide](troubleshooting.md) - Resolve issues
- [Security Best Practices](security.md) - Secure your setup

## See Also

- [Azure Cosmos DB Shell Overview](overview.md)
- [Installation Guide](install.md)
- [Azure Cosmos DB Query Reference](query/index.md)
