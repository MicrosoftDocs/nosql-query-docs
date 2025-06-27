---
title: FROM
description: The `FROM` clause identifies the source of data for a query.
ms.date: 06/27/2025
---

# `FROM` (NoSQL query)

The `FROM` clause identifies the source of data for a query.

## Syntax

```nosql
FROM <from_specification>

<from_specification> ::= <from_source> {[ JOIN <from_source>][,...n]}
<from_source> ::= <container_expression> [[AS] input_alias] | input_alias IN <container_expression>
<container_expression> ::= ROOT | container_name | input_alias | <container_expression> '.' property_name | <container_expression> '[' "property_name" | array_index ']'
```

## Arguments

| | Description |
| --- | --- |
| **`from_source`** | Specifies a data source, with or without an alias. |
| **`AS input_alias`** | Specifies that the input_alias is a set of values returned by the underlying container expression. |
| **`input_alias IN`** | Specifies that the input_alias should represent the set of values obtained by iterating over all array elements of each array returned by the underlying container expression. |
| **`container_expression`** | Specifies the container expression to be used to retrieve the items. |
| **`ROOT`** | Specifies that the item should be retrieved from the default, currently connected container. |
| **`container_name`** | Specifies that the item should be retrieved from the provided container. |
| **`input_alias`** | Specifies that the item should be retrieved from the other source defined by the provided alias. |
| **`<container_expression> '.' property_name`** | Specifies that the item should be retrieved by accessing the property_name property. |
| **`<container_expression> '[' "property_name" | array_index ']'`** | Specifies that the item should be retrieved by accessing the property_name property or array_index array element for all items retrieved by specified container expression. |

## Return types

Returns the set of items from the specified source.

## Examples

This section contains examples of how to use this query language construct.

### FROM clause with container alias

In this example, the `FROM` clause is used to specify the current container as a source, give it a unique name, and then alias it. The alias is then used to project specific fields in the query results.

```nosql
-- Example query not available (script file missing)
```

```json
-- Example result not available (script file missing)
```

### FROM clause with subroot as source

In this example, the `FROM` clause is used to enumerate only a subtree in each item, using an array or object subroot as a source.

```nosql
-- Example query not available (script file missing)
```

```json
-- Example result not available (script file missing)
```

## Remarks

- All aliases provided or inferred in the `<from_source>`(s) must be unique.
- If a container expression accesses properties or array elements and that value doesn't exist, that value is ignored and not processed further.
- A container expression may be container-scoped or item-scoped.
- An expression is container-scoped, if the underlying source of the container expression is either `ROOT` or `container_name`. Such an expression represents a set of items retrieved from the container directly, and isn't dependent on the processing of other container expressions.
- An expression is item-scoped, if the underlying source of the container expression is `input_alias` introduced earlier in the query. Such an expression represents a set of items obtained by evaluating the container expression. This evaluation is performed in the scope of each item belonging to the set associated with the aliased container. The resulting set is a union of sets obtained by evaluating the container expression for each of the items in the underlying set.

## Related content

- [NoSQL query reference](index.md)
- [`SELECT`](select.md)
- [`WHERE`](where.md)
