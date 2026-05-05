---
title: Azure Cosmos DB Shell Command Reference
description: Complete reference for all Azure Cosmos DB Shell commands with syntax, options, and examples.
author: sajeetharan
ms.author: sasinnat
ms.reviewer: mjbrown
ms.service: azure-cosmos-db
ms.topic: reference
ms.date: 05/04/2024
---

# Azure Cosmos DB Shell Command Reference

Complete reference guide for all Azure Cosmos DB Shell commands.

## Navigation Commands

Commands for navigating databases and containers.

### `cd` - Change Directory

Navigate to a database or container.

**Syntax:**
```bash
cd <path>
```

**Examples:**
```bash
# Navigate to a database
cosmosdb-shell> cd mydb
cosmosdb-shell mydb>

# Navigate to a container
cosmosdb-shell mydb> cd users
cosmosdb-shell mydb/users>

# Go back one level
cosmosdb-shell mydb/users> cd ..
cosmosdb-shell mydb>

# Navigate to root
cosmosdb-shell mydb> cd /
cosmosdb-shell>
```

### `ls` - List

List databases or containers in current location.

**Syntax:**
```bash
ls [options]
```

**Options:**
- `-l`: Long format with details
- `-h`: Human-readable sizes

**Examples:**
```bash
# List databases
cosmosdb-shell> ls

# List containers with details
cosmosdb-shell mydb> ls -l

# List containers in human-readable format
cosmosdb-shell mydb> ls -h
```

### `pwd` - Print Working Directory

Show the current path.

**Syntax:**
```bash
pwd
```

**Examples:**
```bash
cosmosdb-shell mydb/users> pwd
/mydb/users
```

### `endpoint` - Show Endpoint

Display the current Cosmos DB account endpoint.

**Syntax:**
```bash
endpoint
```

**Examples:**
```bash
cosmosdb-shell> endpoint
https://myaccount.documents.azure.com:443/
```

## Database Management Commands

Commands for creating and managing databases.

### `mkdb` - Make Database

Create a new database.

**Syntax:**
```bash
mkdb <database_name> [options]
```

**Options:**
- `--throughput <RU/s>`: Provisioned throughput
- `--autoscale <max_RU/s>`: Autoscale max throughput

**Examples:**
```bash
# Create database with default settings
cosmosdb-shell> mkdb mydb

# Create database with provisioned throughput
cosmosdb-shell> mkdb mydb --throughput 400

# Create database with autoscale
cosmosdb-shell> mkdb mydb --autoscale 4000
```

### `rmdb` - Remove Database

Delete a database and all its contents.

**Syntax:**
```bash
rmdb <database_name> [--force]
```

**Options:**
- `--force`: Skip confirmation prompt

**Examples:**
```bash
# Delete database (with confirmation)
cosmosdb-shell> rmdb tempdb

# Delete database without confirmation
cosmosdb-shell> rmdb tempdb --force
```

## Container Management Commands

Commands for creating and managing containers.

### `mkcon` - Make Container

Create a new container.

**Syntax:**
```bash
mkcon <container_name> -pk <partition_key> [options]
```

**Options:**
- `-pk`, `--partition-key`: Partition key path (required)
- `--throughput <RU/s>`: Provisioned throughput
- `--autoscale <max_RU/s>`: Autoscale max throughput
- `--ttl <seconds>`: Time-to-live in seconds
- `--unique-key <path>`: Unique constraint path

**Examples:**
```bash
# Create container with partition key
cosmosdb-shell mydb> mkcon users -pk /id

# Create with provisioned throughput
cosmosdb-shell mydb> mkcon users -pk /id --throughput 400

# Create with autoscale
cosmosdb-shell mydb> mkcon users -pk /id --autoscale 4000

# Create with TTL
cosmosdb-shell mydb> mkcon users -pk /id --ttl 86400

# Create with unique key
cosmosdb-shell mydb> mkcon users -pk /id --unique-key /email
```

### `rmcon` - Remove Container

Delete a container.

**Syntax:**
```bash
rmcon <container_name> [--force]
```

**Options:**
- `--force`: Skip confirmation prompt

**Examples:**
```bash
# Delete container (with confirmation)
cosmosdb-shell mydb> rmcon tempcontainer

# Delete without confirmation
cosmosdb-shell mydb> rmcon tempcontainer --force
```

## Data Manipulation Commands

Commands for querying and managing data.

### `query` - Execute Query

Execute a SQL query against a container.

**Syntax:**
```bash
query "<SQL_query>" [options]
```

**Options:**
- `--partition-key <value>`: Specify partition key for targeted query
- `--max-items <count>`: Maximum items to return
- `--continuation-token <token>`: Continuation token for pagination

**Examples:**
```bash
# Query all documents
cosmosdb-shell mydb/users> query "SELECT * FROM c"

# Query with filter
cosmosdb-shell mydb/users> query "SELECT * FROM c WHERE c.status = 'active'"

# Query with partition key (faster)
cosmosdb-shell mydb/users> query "SELECT * FROM c WHERE c.id = 'user1'" --partition-key user1

# Query with limit
cosmosdb-shell mydb/users> query "SELECT TOP 10 * FROM c"

# Aggregate query
cosmosdb-shell mydb/users> query "SELECT c.status, COUNT(*) as count FROM c GROUP BY c.status"

# Join query
cosmosdb-shell mydb/users> query "SELECT c.id, c.name, o.orderId FROM c JOIN o IN c.orders"
```

### `create` - Create Document

Insert a new document.

**Syntax:**
```bash
create <JSON_document>
```

**Examples:**
```bash
# Create simple document
cosmosdb-shell mydb/users> create {"id": "user1", "name": "Alice"}

# Create nested document
cosmosdb-shell mydb/users> create {"id": "user2", "name": "Bob", "address": {"city": "Seattle", "country": "USA"}}

# Create with array
cosmosdb-shell mydb/users> create {"id": "user3", "name": "Charlie", "tags": ["vip", "premium"]}
```

### `update` - Update Document

Update an existing document.

**Syntax:**
```bash
update <JSON_document>
```

**Examples:**
```bash
# Update document
cosmosdb-shell mydb/users> update {"id": "user1", "name": "Alice", "status": "active"}

# Partial update (with JSON merge semantics)
cosmosdb-shell mydb/users> update {"id": "user1", "status": "inactive"}
```

### `rm` - Remove Document

Delete a document.

**Syntax:**
```bash
rm <document_id> [--partition-key <value>]
```

**Options:**
- `--partition-key <value>`: Specify partition key for faster deletion

**Examples:**
```bash
# Delete document
cosmosdb-shell mydb/users> rm user1

# Delete with partition key
cosmosdb-shell mydb/users> rm user1 --partition-key user1
```

### `get` - Get Document

Retrieve a specific document by ID.

**Syntax:**
```bash
get <document_id> [--partition-key <value>]
```

**Options:**
- `--partition-key <value>`: Specify partition key for faster retrieval

**Examples:**
```bash
# Get document
cosmosdb-shell mydb/users> get user1

# Get with partition key
cosmosdb-shell mydb/users> get user1 --partition-key user1
```

## Utility Commands

General utility commands.

### `jq` - JSON Processing

Process JSON output using jq syntax.

**Syntax:**
```bash
<command> | jq '<jq_filter>'
```

**Examples:**
```bash
# Pretty print JSON
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq .

# Extract specific fields
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq '.[] | {id, name}'

# Filter results
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq '.[] | select(.status == "active")'

# Transform data
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq '[.[] | {id, name}]'
```

### `echo` - Display Text

Output text to console.

**Syntax:**
```bash
echo "<text>"
```

**Examples:**
```bash
cosmosdb-shell> echo "Starting operations..."
Starting operations...
```

### `help` - Show Help

Display help information.

**Syntax:**
```bash
help [command]
```

**Examples:**
```bash
# General help
cosmosdb-shell> help

# Help for specific command
cosmosdb-shell> help query

# Help for container commands
cosmosdb-shell> help mkcon
```

### `version` - Show Version

Display the shell version.

**Syntax:**
```bash
version
```

**Examples:**
```bash
cosmosdb-shell> version
Azure Cosmos DB Shell 1.0.213-preview
```

### `exit` - Exit Shell

Exit the Cosmos DB Shell.

**Syntax:**
```bash
exit
```

**Examples:**
```bash
cosmosdb-shell> exit
```

## Command Chaining and Piping

Commands can be chained using pipes (`|`) and redirects.

### Pipe to `jq`
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq '.[]'
```

### Pipe to File
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c" > output.json
```

### Pipe to External Command
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c" | grep "active"
```

### Combine Multiple Operations
```bash
cosmosdb-shell mydb/users> query "SELECT * FROM c" | jq '.[] | select(.status == "active")' | wc -l
```

## JSON Path Expressions

Use JSON path expressions in queries for advanced filtering.

**Examples:**
```bash
# Query nested properties
cosmosdb-shell mydb/users> query "SELECT c.address.city FROM c"

# Array operations
cosmosdb-shell mydb/users> query "SELECT * FROM c WHERE ARRAY_CONTAINS(c.tags, 'vip')"

# String functions
cosmosdb-shell mydb/users> query "SELECT * FROM c WHERE STARTSWITH(c.name, 'A')"

# Numeric functions
cosmosdb-shell mydb/users> query "SELECT * FROM c WHERE c.age > 30"
```

## Connection Commands

### `connect` - Connect to Account

Switch to a different Cosmos DB account.

**Syntax:**
```bash
connect <connection_string|endpoint> [--auth-method <method>]
```

**Auth Methods:**
- `entra-id`: Microsoft Entra ID (default, recommended)
- `managed-identity`: Managed Identity
- `key`: Account key

**Examples:**
```bash
# Connect with Entra ID
cosmosdb-shell> connect https://myaccount.documents.azure.com:443/ --auth-method entra-id

# Connect with account key
cosmosdb-shell> connect DefaultEndpointProtocol=https;AccountName=myaccount;... --auth-method key
```

## Best Practices

- **Use partition keys** for faster queries
- **Limit result sets** with TOP or --max-items
- **Use projections** to reduce data transfer
- **Chain commands** with pipes for complex operations
- **Use jq** for JSON processing and formatting
- **Save complex queries** in script files

## See Also

- [Quick Start Guide](get-started.md)
- [Troubleshooting Guide](troubleshooting.md)
- [SQL Query Syntax](../how-to-query-container.md)
- [Azure Cosmos DB Query Reference](../query-cheat-sheet.md)
