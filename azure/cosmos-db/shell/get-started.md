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

# Azure Cosmos DB Shell quick start

Get started with Azure Cosmos DB Shell in just a few minutes with these practical examples.

## Prerequisites

- Azure Cosmos DB Shell installed ([Installation Guide](install.md))
- Azure Cosmos DB account
- Authentication configured (Entra ID, Managed Identity, or Account Keys)

## Launch the shell

```bash
cosmosdb-shell
```

You'll see a prompt:
```
cosmosdb-shell>
```

## Connect to your account

When you launch Cosmos DB Shell, it prompts you for authentication. You can:

- **Use Entra ID** (Recommended)
  - Follow the browser authentication flow
  - Most secure method

- **Use Managed Identity** (Production)
  - Automatically uses Azure managed identity
  - Best for production environments

- **Use Account Key** (Development)
  - Provide connection string or account key
  - Quick for development/testing

## Basic navigation

### View your account endpoint
```bash
cosmosdb-shell> endpoint
```

### List databases
```bash
cosmosdb-shell> ls
```

Output:
```
database1
database2
mydb
```

### Navigate to a database
```bash
cosmosdb-shell> cd mydb
cosmosdb-shell mydb>
```

### List containers in database
```bash
cosmosdb-shell mydb> ls
```

Output:
```
users
products
orders
```

### Navigate to a container
```bash
cosmosdb-shell mydb> cd users
cosmosdb-shell mydb/users>
```

### Show current path
```bash
cosmosdb-shell mydb/users> pwd
```

Output:
```
/mydb/users
```

## Basic operations

### Create database
```bash
cosmosdb-shell> mkdb mynewdb
```

### Create container
```bash
cosmosdb-shell mydb> mkcon mycontainer -pk /id
```

(Creates container with partition key `/id`)

### Query documents
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

### Count documents
```bash
cosmosdb-shell mydb/users> query "SELECT COUNT(*) FROM c"
```

### Insert document
```bash
cosmosdb-shell mydb/users> create item {"id": "user3", "name": "Charlie", "status": "active"}
```

### Update document
```bash
cosmosdb-shell mydb/users> update {"id": "user1", "name": "Alice", "status": "inactive"}
```

### Delete document
```bash
cosmosdb-shell mydb/users> rm user1
```

### Delete container
```bash
cosmosdb-shell mydb> rmcon users
```

### Delete database
```bash
cosmosdb-shell> rmdb mydb
```

## Piping commands

Combine commands to create powerful workflows.

### Query and count
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq 'length'
```

### Filter results with jq
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq '.[] | select(.status == "active")'
```

### Extract specific fields
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq '.[] | {id, name}'
```

### Transform and output
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq '.[] | .name' | tr '\n' ','
```

## Shell scripts

Create a script file for automated operations.

### Example script: `batch_operations.sh`
```bash
#!/bin/bash

# Connect to Cosmos DB Shell
cosmosdb-shell << 'EOF'
cd mydb
cd users

# Insert multiple documents
create item {"id": "user10", "name": "David", "status": "active"}
create item {"id": "user11", "name": "Eve", "status": "inactive"}
create item {"id": "user12", "name": "Frank", "status": "active"}

# Query and count
query "SELECT COUNT(*) as count FROM c"

# Exit
exit
EOF
```

### Run script
```bash
bash batch_operations.sh
```

## Filtering and searching

### Find documents with specific criteria
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c WHERE c.age > 30 AND c.status = 'active'"
```

### Search in arrays
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c WHERE ARRAY_CONTAINS(c.tags, 'vip')"
```

### Aggregate results
```bash
cosmosdb-shell mydb/users> query "SELECT c.status, COUNT(*) as count FROM c GROUP BY c.status"
```

## Export and import

### Export data to JSON
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c" > users_export.json
```

The exported file wraps the documents in an `items` envelope:

```json
{
  "items": [
    { "id": "user1", "pk": "tenantA", "name": "Alice", "status": "active",
      "_rid": "...", "_self": "...", "_etag": "...", "_attachments": "...", "_ts": 1730000000 },
    { "id": "user2", "pk": "tenantA", "name": "Bob", "status": "active",
      "_rid": "...", "_self": "...", "_etag": "...", "_attachments": "...", "_ts": 1730000001 }
  ]
}
```

### Export to CSV-like format
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq -r '.id, .name, .status' | paste -sd, > users.csv
```

### Import a bare JSON array

The `create item` command (alias `mkitem`) accepts either a single JSON object
or a top-level JSON array. Use this form when you control the input file and
can produce a clean array of documents.

Sample `users_import.json`:

```json
[
  { "id": "user10", "pk": "tenantA", "name": "David", "status": "active" },
  { "id": "user11", "pk": "tenantA", "name": "Eve",   "status": "inactive" },
  { "id": "user12", "pk": "tenantB", "name": "Frank", "status": "active" }
]
```

Import it by piping the file into `mkitem`:

```bash
cosmosdb-shell mydb/users> cat users_import.json | mkitem
```

Add `--force` (alias `--upsert`) to replace existing items instead of failing
on `id` conflicts:

```bash
cosmosdb-shell mydb/users> cat users_import.json | mkitem --force
```

### Import a previously exported query result

A file produced by `query "SELECT * FROM c" > users_export.json` is **not** a
bare array — it has the `{ "items": [ ... ] }` wrapper shown above and the
documents still contain Cosmos system fields (`_rid`, `_self`, `_etag`,
`_attachments`, `_ts`) that must not be sent back on insert.

Use `jq` to unwrap the array and strip system fields before piping to
`mkitem`:

```bash
cosmosdb-shell mydb/users> cat users_export.json \
  | jq '[.items[] | del(._rid, ._self, ._etag, ._attachments, ._ts)]' \
  | mkitem --force --db=mydb --con=users
```

What each step does:

- `.items[]` unwraps the envelope and streams each document.
- `del(...)` removes the read-only Cosmos system fields.
- `[ ... ]` re-collects the results into the top-level array `mkitem` expects.
- `--force` makes the import idempotent (re-running replaces existing items).
- `--db` / `--con` target the destination explicitly so the import works
  regardless of your current shell location.

`mkitem` iterates the array sequentially and prints a summary with the number
of items created or replaced and the total RU charge. Per-item failures (for
example, an `id` conflict without `--force`) are reported inline but do not
stop the import.

## Tips and best practices

### Use aliases for common commands
```bash
# Add to your shell profile
alias cosmosdb='cosmosdb-shell'
```

### Tab completion
- Use Tab to auto-complete database and container names
- Press Tab twice to see all available options

### Command history
- Arrow up/down to navigate command history
- Ctrl+R to search command history

### Formatting output
```bash
# Pretty-print JSON
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq .

# Compact output
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq -c .
```

### Performance tips

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

## Common workflows

### Bulk insert from file
```bash
cosmosdb-shell mydb/users> jq -r '.[]' data.json | while read line; do
  create $line
done
```

### Backup container
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c" > backup_users.json
```

### Verify data migration
```bash
cosmosdb-shell mydb/users> query "SELECT COUNT(*) FROM c" 
cosmosdb-shell mydb/products> query "SELECT COUNT(*) FROM c"
```

## Next steps

- [Complete Command Reference](command-reference.md) - Learn all available commands
- [MCP Server Setup](model-context-protocol-setup.md) - Enable AI integration
- [Troubleshooting Guide](troubleshooting.md) - Resolve issues
- [Security Best Practices](security.md) - Secure your setup

## See also

- [Azure Cosmos DB Shell Overview](overview.md)
- [Installation Guide](install.md)
- [Azure Cosmos DB Query Reference](../query-cheat-sheet.md)
