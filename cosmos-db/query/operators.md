---
title: Operators
description: 
ms.date: 11/10/2025
---

# Operators - Query language in Cosmos DB (in Azure and Fabric)

Cosmos DB (in Azure and Fabric) supports a comprehensive set of operators that enable you to perform complex queries and data manipulations. These operators include bitwise, equality and comparison, logical, and ternary/coalesce operators, each serving specific purposes in query construction and data processing.

## Bitwise operators

Bitwise operators are useful for performing low-level operations on integer values when constructing JSON result sets. These operators work similarly to those in higher-level programming languages like C# and JavaScript. For examples of C# bitwise operators, see [Bitwise and shift operators](/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators).

The following table describes the bitwise operations supported in the API for NoSQL:

| Operation | Operator | Description |
| --- | --- | --- |
| **Left shift** | `<<` | Shift left-hand value *left* by the specified number of bits. |
| **Right shift** | `>>` | Shift left-hand value *right* by the specified number of bits. |
| **Zero-fill (unsigned) right shift** | `>>>` | Shift left-hand value *right* by the specified number of bits without filling left-most bits. |
| **AND** | `&` |  Computes bitwise logical AND. |
| **OR** | `|` | Computes bitwise logical OR. |
| **XOR** | `^` | Computes bitwise logical exclusive OR. |

### Example

The following query demonstrates each bitwise operator:

```nosql
SELECT 
    (100 >> 2) AS rightShift,
    (100 << 2) AS leftShift,
    (100 >>> 0) AS zeroFillRightShift,
    (100 & 1000) AS logicalAnd,
    (100 | 1000) AS logicalOr,
    (100 ^ 1000) AS logicalExclusiveOr
```

This query returns the following results:

```json
[
  {
    "rightShift": 25,
    "leftShift": 400,
    "zeroFillRightShift": 100,
    "logicalAnd": 96,
    "logicalOr": 1004,
    "logicalExclusiveOr": 908
  }
]
```

> [!IMPORTANT]
> The bitwise operators in Cosmos DB follow the same behavior as bitwise operators in JavaScript. JavaScript stores numbers as 64 bits floating point numbers, but all bitwise operations are performed on 32 bits binary numbers. Before a bitwise operation is performed, JavaScript converts numbers to 32 bits signed integers. After the bitwise operation is performed, the result is converted back to 64 bits JavaScript numbers. For more information about the bitwise operators in JavaScript, see [JavaScript binary bitwise operators at MDN Web Docs](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Operators#binary_bitwise_operators).

## Equality and comparison operators

Equality and comparison operators check two expressions for equivalency or compare them relationally. The following table shows the result of equality comparisons between any two JSON types in the API for NoSQL:

| | **Undefined** | Null | Boolean | Number | String | Object | Array |
| --- | --- | --- | --- | --- | --- | --- | --- |
| **Undefined** | Undefined | Undefined | Undefined | Undefined | Undefined | Undefined | Undefined |
| **Null** | Undefined | **Ok** | Undefined | Undefined | Undefined | Undefined | Undefined |
| **Boolean** | Undefined | Undefined | **Ok** | Undefined | Undefined | Undefined | Undefined |
| **Number** | Undefined | Undefined | Undefined | **Ok** | Undefined | Undefined | Undefined |
| **String** | Undefined | Undefined | Undefined | Undefined | **Ok** | Undefined | Undefined |
| **Object** | Undefined | Undefined | Undefined | Undefined | Undefined | **Ok** | Undefined |
| **Array** | Undefined | Undefined | Undefined | Undefined | Undefined | Undefined | **Ok** |

For comparison operators such as `>``, `>=``, `!=``, `<``, and `<=``, comparison across types or between two objects or arrays produces `undefined``. If the result of the scalar expression is `undefined``, the item isn't included in the result, because `undefined` doesn't equate to `true``.

### Example

The following query compares a number and string value, which produces `undefined``. Therefore, the filter doesn't include any results:

```nosql
SELECT
    *
FROM
    products p
WHERE 
    0 = "true"
```

## Logical operators

Logical operators compare two expressions with boolean (``true``/``false``) operands. The following sections describe the truth tables and precedence for each logical operator.

### OR operator

The `OR` operator returns `true` when either of the conditions is `true``.

|  | `true` | `false` | `undefined` |
| --- | --- | --- | --- |
| **``true``** | `true` | `true` | `true` |
| **``false``** | `true` | `false` | `undefined` |
| **``undefined``** | `true` | `undefined` | `undefined` |

### AND operator

The `AND` operator returns `true` when both expressions are `true``.

|  | `true` | `false` | `undefined` |
| --- | --- | --- | --- |
| **``true``** | `true` | `false` | `undefined` |
| **``false``** | `false` | `false` | `false` |
| **``undefined``** | `undefined` | `false` | `undefined` |

### NOT operator

The `NOT` operator reverses the value of any boolean expression.

|  | `NOT` |
| --- | --- |
| **``true``** | `false` |
| **``false``** | `true` |
| **``undefined``** | `undefined` |

### Operator precedence

The logical operators `OR``, `AND``, and `NOT` have the following precedence levels:

| Operator | Priority |
| --- | --- |
| **``NOT``** | 1 |
| **``AND``** | 2 |
| **``OR``** | 3 |

## Projection operator

The special operator `*` projects the entire item as is. When used, it must be the only projected field. A query like `SELECT * FROM products p` is valid, but `SELECT VALUE * FROM products p` or `SELECT *, p.id FROM products p` aren't valid.

## Ternary and coalesce operators

Ternary and coalesce operators evaluate expressions and return results based on boolean operands or field existence. These operators function similarly to those in popular programming languages like C# and JavaScript. Use the ternary (``?``) and coalesce (``??``) operators to build conditional expressions that are resilient against semi-structured or mixed-type data.

### Ternary operator

The `?` operator returns a value based on the evaluation of a boolean expression.

#### Syntax

```
<bool_expr> ?  
    <expr_true> : 
    <expr_false>
```

#### Arguments

| | Description |
| --- | --- |
| **``bool_expr``** | A boolean expression. |
| **``expr_true``** | The expression to evaluate if `bool_expr` evaluates to `true``. |
| **``expr_false``** | The expression to evaluate if `bool_expr` evaluates to `false``. |

#### Examples

This example uses items in a container that contain multiple metadata properties related to pricing. Note that the `collapsible` property doesn't exist on all items:

```json
[
  {
    "name": "Stangincy trekking poles",
    "price": 24.50,
    "onCloseout": false,
    "onSale": true,
    "collapsible": true
  },
  {
    "name": "Vimero hiking poles",
    "price": 24.50,
    "onCloseout": false,
    "onSale": false
  },
  {
    "name": "Kramundsen trekking poles",
    "price": 24.50,
    "onCloseout": true,
    "onSale": true,
    "collapsible": false
  }
]
```

This query evaluates the `onSale` expression, which is equivalent to `onSale = true``. The query returns the price multiplied by `0.85` if `true``, or the price unchanged if `false``:

```nosql
SELECT
    p.name,
    p.price AS subtotal,
    p.onSale ? (p.price * 0.85) : p.price AS total
FROM
    products p
```

This query returns:

```json
[
  {
    "name": "Stangincy trekking poles",
    "subtotal": 24.5,
    "total": 20.825
  },
  {
    "name": "Vimero hiking poles",
    "subtotal": 24.5,
    "total": 24.5
  },
  {
    "name": "Kramundsen trekking poles",
    "subtotal": 24.5,
    "total": 20.825
  }
]
```

You can also nest calls to the `?` operator. This example adds an extra calculation based on a second property (``onCloseout``):

```nosql
SELECT
    p.name,
    p.price AS subtotal,
    p.onCloseout ? (p.price * 0.55) : p.onSale ? (p.price * 0.85) : p.price AS total
FROM
    products p
```

This query returns:

```json
[
  {
    "name": "Stangincy trekking poles",
    "subtotal": 24.5,
    "total": 20.825
  },
  {
    "name": "Vimero hiking poles",
    "subtotal": 24.5,
    "total": 24.5
  },
  {
    "name": "Kramundsen trekking poles",
    "subtotal": 24.5,
    "total": 13.475000000000001
  }
]
```

As with other query operators, the `?` operator excludes items if the referenced properties are missing or the types being compared are different.

### Coalesce operator

Use the `??` operator to efficiently check for a property in an item when querying against semi-structured or mixed-type data.

#### Example

This query assumes that any item where the `collapsible` property isn't present, isn't collapsible:

```nosql
SELECT
    p.name,
    p.collapsible ?? false AS isCollapsible
FROM
    products p
```

## Related content

- [`SELECT` clause](select.md)
- [Keywords](keywords.md)
