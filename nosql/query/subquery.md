---
title: Subqueries
description: Use different types of subqueries for complex query statements in the NoSQL query language.
ms.date: 07/02/2025
ai-usage: ai-generated
show_latex: true
---

# Subqueries in the NoSQL query language

A subquery is a query nested within another query within the NoSQL query language. A subquery is also called an *inner query* or *inner `SELECT`*. The statement that contains a subquery is typically called an *outer query*.

## Types of subqueries

There are two main types of subqueries:

- **Correlated**: A subquery that references values from the outer query. The subquery is evaluated once for each row that the outer query processes.
- **Non-correlated**: A subquery that's independent of the outer query. It can be run on its own without relying on the outer query.

Subqueries can be further classified based on the number of rows and columns that they return. There are three types:

- **Table**: Returns multiple rows and multiple columns.
- **Multi-value**: Returns multiple rows and a single column.
- **Scalar**: Returns a single row and a single column.

Queries in the NoSQL query language always return a single column (either a simple value or a complex item). Therefore, only multi-value and scalar subqueries are applicable. You can use a multi-value subquery only in the `FROM` clause as a relational expression. You can use a scalar subquery as a scalar expression in the `SELECT` or `WHERE` clause, or as a relational expression in the `FROM` clause.

## Multi-value subqueries

Multi-value subqueries return a set of items and are always used within the `FROM` clause. They're used for:

- Optimizing `JOIN` (self-join) expressions.
- Evaluating expensive expressions once and referencing multiple times.

## Optimize self-join expressions

Multi-value subqueries can optimize `JOIN` expressions by pushing predicates after each *select-many* expression rather than after all *cross-joins* in the `WHERE` clause.

Consider the following query:

```nosql
SELECT VALUE
  COUNT(1)
FROM
  products p
JOIN 
  t in p.tags
JOIN
  s in p.sizes
JOIN
  c in p.colors
WHERE
  t.key IN ("fabric", "material") AND
  s["order"] >= 3 AND
  c LIKE "%gray%"
```

For this query, the index matches any item that has a tag with a `key` of either `fabric` or `material`, at least one size with an `order` value greater than **three*, and at least one color with `gray` as a substring. The `JOIN` expression here performs the *cross-product* of all items of `tags`, `sizes`, and `colors` arrays for each matching item before any filter is applied.

The `WHERE` clause then applies the filter predicate on each $<c, t, n, s>$ tuple. For instance, if a matching item had **ten** items in each of the three arrays, it expands to **1,000** tuples using this formula:

$$1 x 10 x 10 x 10$$

Using subqueries here can help in filtering out joined array items before joining with the next expression.

This query is equivalent to the preceding one but uses subqueries:

```nosql
SELECT VALUE
  COUNT(1)
FROM
  products p
JOIN 
  (SELECT VALUE t FROM t IN p.tags WHERE t.key IN ("fabric", "material"))
JOIN 
  (SELECT VALUE s FROM s IN p.sizes WHERE s["order"] >= 3)
JOIN 
  (SELECT VALUE c FROM c in p.colors WHERE c LIKE "%gray%")
```

Assume that only one item in the tags array matches the filter, and there are five items for both quantity and stock arrays. The `JOIN` expression then expands to **25** tuples using this formula as opposed to **1,000** items in the first query:

$$1 x 1 x 5 x 5$$

## Evaluate once and reference many times

Subqueries can help optimize queries with expensive expressions such as user-defined functions (UDFs), complex strings, or arithmetic expressions. You can use a subquery along with a `JOIN` expression to evaluate the expression once but reference it many times.

This sample query calculates the price with a supplement of **25%** multiples times in the query.

```nosql
SELECT VALUE {
  subtotal: p.price,
  total: (p.price * 1.25)
}
FROM
  products p
WHERE
  (p.price * 1.25) < 22.25
```

Here's an equivalent query that runs the calculation only once:

```nosql
SELECT VALUE {
  subtotal: p.price,
  total: totalPrice
}
FROM
  products p
JOIN
  (SELECT VALUE p.price * 1.25) totalPrice
WHERE
  totalPrice < 22.25
```

```json
[
  {
    "subtotal": 15,
    "total": 18.75
  },
  {
    "subtotal": 10,
    "total": 12.5
  },
  ...
]
```


> [!TIP]
> Keep in mind the cross-product behavior of `JOIN` expressions. If the expression can evaluate to `undefined`, you should ensure that the `JOIN` expression always produces a single row by returning an object from the subquery rather than the value directly.

## Mimic relational join with external reference data

You might often need to reference static data that rarely changes, such as *units of measurement*. It's ideal to not duplicate static data for each item in a query. Avoiding this duplication saves on storage and improve write performance by keeping the individual item size smaller. You can use a subquery to mimic inner-join semantics with a collection of static reference data.

For instance, consider this set of measurements that represents the length of a garment:

| Size | Length | Units |
| --- | --- | --- |
| `xs` | `63.5` | `cm` |
| `s` | `64.5` | `cm` |
| `m` | `66.0` | `cm` |
| `l` | `67.5` | `cm` |
| `xl` | `69.0` | `cm` |
| `xxl` | `70.5` | `cm` |

The following query mimics joining with this data so that you add the name of the unit to the output:

```nosql
SELECT
  p.name,
  p.subCategory,
  s.description AS size,
  m.length,
  m.unit
FROM
  products p
JOIN
  s IN p.sizes
JOIN m IN (
  SELECT VALUE [
    {size: 'xs', length: 63.5, unit: 'cm'},
    {size: 's', length: 64.5, unit: 'cm'},
    {size: 'm', length: 66, unit: 'cm'},
    {size: 'l', length: 67.5, unit: 'cm'},
    {size: 'xl', length: 69, unit: 'cm'},
    {size: 'xxl', length: 70.5, unit: 'cm'}
  ]
)
WHERE
  s.key = m.size
```

## Scalar subqueries

A scalar subquery expression is a subquery that evaluates to a single value. The value of the scalar subquery expression is the value of the projection (`SELECT` clause) of the subquery. You can use a scalar subquery expression in many places where a scalar expression is valid. For instance, you can use a scalar subquery in any expression in both the `SELECT` and `WHERE` clauses.

Using a scalar subquery doesn't always help optimize your query. For example, passing a scalar subquery as an argument to either a system or user-defined functions provides no benefit in reducing resource unit (RU) consumption or latency.

Scalar subqueries can be further classified as:

- Simple-expression scalar subqueries
- Aggregate scalar subqueries

### Simple-expression scalar subqueries

A simple-expression scalar subquery is a correlated subquery that has a `SELECT` clause that doesn't contain any aggregate expressions. These subqueries provide no optimization benefits because the compiler converts them into one larger simple expression. There's no correlated context between the inner and outer queries.

As a first example, consider this trivial query.

```nosql
SELECT
  1 AS a,
  2 AS b
```

You can rewrite this query, by using a simple-expression scalar subquery.

```nosql
SELECT
  (SELECT VALUE 1) AS a, 
  (SELECT VALUE 2) AS b
```

Both queries produce the same output.

```json
[
  {
    "a": 1,
    "b": 2
  }
]
```

This next example query concatenates the unique identifier with a prefix as a simple-expression scalar subquery.

```nosql
SELECT 
  (SELECT VALUE CONCAT('ID-', p.id)) AS internalId
FROM
  products p
```

This example uses a simple-expression scalar subquery to only return the relevant fields for each item. The query outputs something for each item, but it only includes the projected field if it meets the filter within the subquery.

```nosql
SELECT
  p.id,
  (SELECT p.name WHERE CONTAINS(p.name, "Shoes")).name
FROM
  products p
```

```json
[
  {
    "id": "00000000-0000-0000-0000-000000004041",
    "name": "Remdriel Shoes"
  },
  {
    "id": "00000000-0000-0000-0000-000000004322"
  },
  {
    "id": "00000000-0000-0000-0000-000000004055"
  }
]
```

### Aggregate scalar subqueries

An aggregate scalar subquery is a subquery that has an aggregate function in its projection or filter that evaluates to a single value.

As a first example, consider an item with the following fields.

```json
[
  {
    "name": "Blators Snowboard Boots",
    "colors": [
      "turquoise",
      "cobalt",
      "jam",
      "galliano",
      "violet"
    ],
    "sizes": [ ... ],
    "tags": [ ... ]
  }
]
```

Here's a subquery with a single aggregate function expression in its projection. This query counts all tags for each item.

```nosql
SELECT
  p.name,
  (SELECT VALUE COUNT(1) FROM c IN p.colors) AS colorsCount
FROM
  products p
WHERE
  p.id = "00000000-0000-0000-0000-000000004389"
```

```json
[
  {
    "name": "Blators Snowboard Boots",
    "colorsCount": 5
  }
]
```

Here's the same subquery with a filter.

```nosql
SELECT
  p.name,
  (SELECT VALUE COUNT(1) FROM c IN p.colors) AS colorsCount,
  (SELECT VALUE COUNT(1) FROM c IN p.colors WHERE c LIKE "%t") AS colorsEndsWithTCount
FROM
  products p
```

```json
[
  {
    "name": "Blators Snowboard Boots",
    "colorsCount": 5,
    "colorsEndsWithTCount": 2
  }
]
```

Here's another subquery with multiple aggregate function expressions:

```nosql
SELECT
  p.name,
  (SELECT VALUE COUNT(1) FROM c IN p.colors) AS colorsCount,
  (SELECT VALUE COUNT(1) FROM s in p.sizes) AS sizesCount,
  (SELECT VALUE COUNT(1) FROM t IN p.tags) AS tagsCount
FROM
  products p
```

```json
[
  {
    "name": "Blators Snowboard Boots",
    "colorsCount": 5,
    "sizesCount": 7,
    "tagsCount": 2
  }
]
```

Finally, here's a query with an aggregate subquery in both the projection and the filter:

```nosql
SELECT
  p.name,
  (SELECT VALUE COUNT(1) FROM s in p.sizes WHERE s.description LIKE "%Small") AS smallSizesCount,
  (SELECT VALUE COUNT(1) FROM s in p.sizes WHERE s.description LIKE "%Large") AS largeSizesCount
FROM
  products p
WHERE
  (SELECT VALUE COUNT(1) FROM c IN p.colors) >= 5
```

A more optimal way to write this query is to join on the subquery and reference the subquery alias in both the SELECT and WHERE clauses. This query is more efficient because you need to execute the subquery only within the join statement, and not in both the projection and filter.

```nosql
SELECT
  p.name,
  colorCount,
  smallSizesCount,
  largeSizesCount
FROM
  products p
JOIN
  (SELECT VALUE COUNT(1) FROM c IN p.colors) AS colorCount
JOIN
  (SELECT VALUE COUNT(1) FROM s in p.sizes WHERE s.description LIKE "%Small") AS smallSizesCount
JOIN
  (SELECT VALUE COUNT(1) FROM s in p.sizes WHERE s.description LIKE "%Large") AS largeSizesCount
WHERE
  colorCount >= 5 AND
  largeSizesCount > 0 AND
  smallSizesCount > 0
```

## EXISTS expression

The NoSQL query language supports `EXISTS` expressions. This expression is an aggregate scalar subquery built into the NoSQL query language. `EXISTS` takes a subquery expression and returns `true` if the subquery returns any rows. Otherwise, it returns `false`.

Because the query engine doesn't differentiate between boolean expressions and any other scalar expressions, you can use `EXISTS` in both `SELECT` and `WHERE` clauses. This behavior is unlike T-SQL, where a boolean expression is restricted to only filters.

If the `EXISTS` subquery returns a single value that's `undefined`, `EXISTS` evaluates to false. For example, consider the following query that returns nothing.

```nosql
SELECT VALUE
  undefined
```

If you use the `EXISTS` expression and the preceding query as a subquery, the expression returns `false`.

```nosql
SELECT VALUE
  EXISTS (SELECT VALUE undefined)
```

```json
[
  false
]
```

If the VALUE keyword in the preceding subquery is omitted, the subquery evaluates to an array with a single empty object.

```nosql
SELECT
  undefined
```

```json
[
  {}
]
```

At that point, the `EXISTS` expression evaluates to `true` since the object (`{}`) technically exits.

```nosql
SELECT VALUE
  EXISTS (SELECT undefined)
```

```json
[
  true
]
```

A common use case of `ARRAY_CONTAINS` is to filter an item by the existence of an item in an array. In this case, we're checking to see if the `tags` array contains an item named **"outerwear."**

```nosql
SELECT
  p.name,
  p.colors
FROM
  products p
WHERE
  ARRAY_CONTAINS(p.colors, "cobalt")
```

The same query can use `EXISTS` as an alternative option.

```nosql
SELECT
  p.name,
  p.colors
FROM
  products p
WHERE
  EXISTS (SELECT VALUE c FROM c IN p.colors WHERE c = "cobalt")
```

Additionally, `ARRAY_CONTAINS` can only check if a value is equal to any element within an array. If you need more complex filters on array properties, use `JOIN` instead.

Consider this example item in a set with multiple items each containing an `accessories` array.

```json
[
  {
    "name": "Cosmoxy Pack",
    "tags": [
      {
        "key": "fabric",
        "value": "leather",
        "description": "Leather"
      },
      {
        "key": "volume",
        "value": "68-gal",
        "description": "6.8 Gal"
      }
    ]
  }
]
```

Now, consider the following query that filters based on the `type` and `quantityOnHand` properties in the array within each item.

```nosql
SELECT
  p.name,
  t.description AS tag
FROM
  products p
JOIN
  t in p.tags
WHERE
  t.key = "fabric" AND
  t["value"] = "leather"
```

```json
[
  {
    "name": "Cosmoxy Pack",
    "tag": "Leather"
  }
]
```

For each of the items in the collection, a cross-product is performed with its array elements. This `JOIN` operation makes it possible to filter on properties within the array. However, this query's RU consumption is significant. For instance, if **1,000** items had **100** items in each array, it expands to **100,000** tuples using this formula:

$$1,000 x 100$$

Using `EXISTS` helps to avoid this expensive cross-product. In this next example, the query filters on array elements within the `EXISTS` subquery. If an array element matches the filter, then you project it and `EXISTS` evaluates to true.

```nosql
SELECT VALUE
  p.name
FROM
  products p
WHERE
  EXISTS (
    SELECT VALUE
      t
    FROM
      t IN p.tags
    WHERE
      t.key = "fabric" AND
      t["value"] = "leather"
  )
```

```json
[
  "Cosmoxy Pack"
]
```

Queries are allowed to also alias `EXISTS` and reference the alias in the projection:

```nosql
SELECT
  p.name,
  EXISTS (
    SELECT VALUE
      t
    FROM
      t IN p.tags
    WHERE
      t.key = "fabric" AND
      t["value"] = "leather"
  ) AS containsFabricLeatherTag
FROM
  products p
```

```json
[
  {
    "name": "Cosmoxy Pack",
    "containsFabricLeatherTag": true
  }
]
```

## ARRAY expression

You can use the `ARRAY` expression to project the results of a query as an array. You can use this expression only within the `SELECT` clause of the query.

For these examples, let's assume there's a container with at least this item.

```json
[
  {
    "name": "Menti Sandals",
    "sizes": [
      {
        "key": "5"
      },
      {
        "key": "6"
      },
      {
        "key": "7"
      },
      {
        "key": "8"
      },
      {
        "key": "9"
      }
    ]
  }
]
```

In this first example, the expression is used within the `SELECT` clause.

```nosql
SELECT
  p.name,
  ARRAY (
    SELECT VALUE
      s.key
    FROM
      s IN p.sizes
  ) AS sizes
FROM
  products p
WHERE
  p.name = "Menti Sandals"
```

```json
[
  {
    "name": "Menti Sandals",
    "sizes": [
      "5",
      "6",
      "7",
      "8",
      "9"
    ]
  }
]
```

As with other subqueries, filters with the `ARRAY` expression are possible.

```nosql
SELECT
  p.name,
  ARRAY (
    SELECT VALUE
      s.key
    FROM
      s IN p.sizes
    WHERE
      STRINGTONUMBER(s.key) <= 6
  ) AS smallSizes,
  ARRAY (
    SELECT VALUE
      s.key
    FROM
      s IN p.sizes
    WHERE
      STRINGTONUMBER(s.key) >= 9
  ) AS largeSizes
FROM
  products p
WHERE
  p.name = "Menti Sandals"
```

```json
[
  {
    "name": "Menti Sandals",
    "smallSizes": [
      "5",
      "6"
    ],
    "largeSizes": [
      "9"
    ]
  }
]
```

Array expressions can also come after the `FROM` clause in subqueries.

```nosql
SELECT
  p.name,
  z.s.key AS sizes
FROM
  products p
JOIN
  z IN (
    SELECT VALUE
      ARRAY (
        SELECT
          s
        FROM
          s IN p.sizes
        WHERE
          STRINGTONUMBER(s.key) <= 8
      )
  )
```

```json
[
  {
    "name": "Menti Sandals",
    "sizes": "5"
  },
  {
    "name": "Menti Sandals",
    "sizes": "6"
  },
  {
    "name": "Menti Sandals",
    "sizes": "7"
  },
  {
    "name": "Menti Sandals",
    "sizes": "8"
  }
]
```

## Related content

- [Review the NoSQL query language](overview.md)
- [Get started with JSON in the NoSQL query language](get-started-json.md)
- [Perform self-joins](join.md)
- [Explore system functions](functions.md)
