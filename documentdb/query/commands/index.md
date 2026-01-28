---
title: Commands
description: MongoDB Query Language (MQL) commands are direct instructions for managing and interacting with your database server. They are essential for performing administrative tasks, optimizing performance, and maintaining security.
type: commands
---

# Commands

MongoDB Query Language (MQL) commands are direct instructions for managing and interacting with your database server. They are essential for performing administrative tasks, optimizing performance, and maintaining security.

## Aggregation

Aggregation commands process data records and return computed results. They group values from multiple documents, perform operations on the grouped data, and return a single result. Common aggregation tasks include calculating averages, sums, and counts.

| | Description |
| --- | --- |
| [**`Aggregate`**](aggregation/aggregate.md) | The aggregate command is used to process data records and return computed results. |
| [**`Count`**](aggregation/count.md) | Count command is used to count the number of documents in a collection that match a specified query. |
| [**`Distinct`**](aggregation/distinct.md) | The distinct command is used to find the unique values for a specified field across a single collection. |

## Query and Write

Query and write commands allow you to retrieve, insert, update, and delete documents in your DocumentDB collections. These operations are fundamental for interacting with your data, enabling you to perform CRUD (Create, Read, Update, Delete) tasks efficiently.

| | Description |
| --- | --- |
| [**`delete`**](query-and-write/delete.md) | The delete command in DocumentDB deletes documents that match a specified criteria |
| [**`find`**](query-and-write/find.md) | The find command in DocumentDB returns documents that match a specified filter criteria |
| [**`findAndModify`**](query-and-write/findandmodify.md) | The findAndModify command is used to atomically modify and return a single document. |
| [**`getMore`**](query-and-write/getMore.md) | The getMore command is used to retrieve extra batches of documents from an existing cursor. |
| [**`insert`**](query-and-write/insert.md) | The insert command in DocumentDB creates new documents in a collection |
| [**`update`**](query-and-write/update.md) | The update commands in DocumentDB modify documents within a collection that match specific filters |
