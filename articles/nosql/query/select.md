---
title: SELECT
description: The `SELECT` clause identifies fields to return in query results. The clause then projects those fields into the JSON result set.
ms.date: 06/27/2025
---

# `SELECT` (NoSQL query)

The `SELECT` clause identifies fields to return in query results. The clause then projects those fields into the JSON result set.

Every query consists of a `SELECT` clause and optionally `FROM` and `WHERE` clauses, per ANSI SQL standards. Typically, the source in the `FROM` clause is enumerated, and the `WHERE` clause applies a filter on the source to retrieve a subset of JSON items.

## Syntax

```nosql
SELECT <select_specification>  

<select_specification> ::=
      '*'
      | [DISTINCT] <object_property_list>
      | [DISTINCT] VALUE <scalar_expression> [[ AS ] value_alias]  
  
<object_property_list> ::=
{ <scalar_expression> [ [ AS ] property_alias ] } [ ,...n ]
```

## Arguments

| | Description |
| --- | --- |
| **`select_specification`** | Properties or value to be selected for the result set. |
| **`*`** | Specifies that the value should be retrieved without making any changes. Specifically if the processed value is an object, all properties are retrieved. |
| **`object_property_list`** | Specifies the list of properties to be retrieved. Each returned value is an object with the properties specified. |
| **`VALUE`** | Specifies that the JSON value should be retrieved instead of the complete JSON object. This argument, unlike <property_list> doesn't wrap the projected value in an object. |
| **`DISTINCT`** | Specifies that duplicates of projected properties should be removed. |
| **`scalar_expression`** | Expression representing the value to be computed. |

## Return types

Returns the projected fields or values as specified.

## Examples

This section contains examples of how to use this query language construct.

### Select static string values

In this example,  two static string values and returns an array with a single object containing both values. Since the values are unnamed, a sequential generated number is used to name the equivalent json field.

```nosql
SELECT
  "Cosmic", "Works"
```

```json
[
  {
    "$1": "Cosmic",
    "$2": "Works"
  }
]
```

### Project fields

In this example, JSON projection is used to fine tune the exact structure and field names for the resulting JSON object. Here, a JSON object is created with fields named `identifier` and `model`. The outside JSON object is still unnamed, so a generated number (`$1`) is used to name this field.

```nosql
SELECT {
  identifier: p.name,
  model: p.sku
}
FROM
  products p
```

```json
[
  {
    "$1": {
      "identifier": "Remdriel Shoes",
      "model": "61506"
    }
  },
  {
    "$1": {
      "identifier": "Tirevy trunks",
      "model": "73402"
    }
  },
  ...
]
```

### Project static string

In this example, the VALUE keyword is used with a static string to create an array of strings as the result.

```nosql
SELECT VALUE
  "Cosmic Works"
```

```json
[
  "Cosmic Works"
]
```

### Complex projection

In this example, the query uses a combination of a `SELECT` clause, the `VALUE` keyword, a `FROM` clause, and JSON projection to perform a common query with the results transformed to a JSON object for the client to parse.

```nosql
SELECT VALUE {
  name: p.name,
  link: p.metadata.link,
  firstTag: p.tags[0]["value"]
}
FROM
  products p
```

```json
[
  {
    "name": "Remdriel Shoes",
    "link": "https://www.adventure-works.com/remdriel-shoes/68719521615.p",
    "firstTag": "suede-leather-and-mesh"
  },
  {
    "name": "Tirevy trunks",
    "link": "https://www.adventure-works.com/tirevy-trunks/68719520573.p",
    "firstTag": "polyester"
  },
  ...
]
```

## Remarks

- The `SELECT *` syntax is only valid if `FROM` clause has declared exactly one alias. `SELECT *` provides an identity projection, which can be useful if no projection is needed. `SELECT *` is only valid if `FROM` clause is specified and introduced only a single input source.
- Both `SELECT <select_list>` and `SELECT *` are syntactic sugar and can be expressed using simple `SELECT` statements.
- The expression `SELECT * FROM ... AS from_alias ...` is equivalent to `SELECT from_alias FROM ... AS from_alias ...`.
- The expression `SELECT <expr1> AS p1, <expr2> AS p2,..., <exprN> AS pN [other clauses...]` is equivalent to `SELECT VALUE { p1: <expr1>, p2: <expr2>, ..., pN: <exprN> }[other clauses...]`.
