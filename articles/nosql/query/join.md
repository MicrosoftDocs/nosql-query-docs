---
title: Self-joins
description: Use the JOIN keyword to perform a self-join on arrays within an item in the NoSQL query language.
ms.date: 06/26/2025
ai-usage: ai-assisted
---

# Self-joins in the NoSQL query language

In the NoSQL query language, data is schema-free and typically denormalized. Instead of joining data across entities and sets, like you would in a relational database, joins occur within a single item. Specifically, joins are scoped to that item and can't occur across multiple items and containers.

> [!TIP]
> If you find yourself needing to join across items and containers, consider reworking your data model to avoid this anti-pattern.

## Self-join with a single item

Let's look at an example of a self-join within an item. Consider a container with a single item. This item represents a product with various sizes:

```json
[
  {
    "name": "Raiot Jacket",
    "sizes": [
      {
        "key": "s",
        "description": "Small"
      },
      {
        "key": "m",
        "description": "Medium"
      },
      {
        "key": "l",
        "description": "Large"
      },
      {
        "key": "xl",
        "description": "Extra Large"
      }
    ]
  }
]
```

What if you need to find products with a specific size? Typically, you would need to write a query that has a filter checking every potential index in the `sizes` array for a value with a prefix. In this example, the query finds all products with a size that ends with `Large`:

```nosql
SELECT
  *
FROM
  products p
WHERE
  p.sizes[0].description LIKE "%Large" OR
  p.sizes[1].description LIKE "%Large" OR
  p.sizes[2].description LIKE "%Large" OR
  p.sizes[3].description LIKE "%Large"
```

This technique can become untenable quickly. The complexity or length of the query syntax increases the number of potential items in the array. Also, this query isn't flexible enough to handle future products, which may have more than three sizes.

In a traditional relational database, the sizes would be separated into a separate table and a cross-table join is performed with a filter applied to the results. In the NoSQl query language, we can perform a self-join operation within the item using the `JOIN` keyword:

```nosql
SELECT
  p.name,
  s.key,
  s.description
FROM
  products p
JOIN
  s in p.sizes
```

This query returns a simple array with an item for each value in the tags array.

```json
[
  {
    "name": "Raiot Jacket",
    "key": "s",
    "description": "Small"
  },
  {
    "name": "Raiot Jacket",
    "key": "m",
    "description": "Medium"
  },
  {
    "name": "Raiot Jacket",
    "key": "l",
    "description": "Large"
  },
  {
    "name": "Raiot Jacket",
    "key": "xl",
    "description": "Extra Large"
  }
]
```

Let's break down the query. The query now has two aliases: `p` for each product item in the result set, and `s` for the self-joined `sizes` array. The `*` keyword is only valid to project all fields if it can infer the input set, but now there are two input sets (`p` and `t`). Because of this constraint, we must explicitly define our returned fields as `name` from the product along with `key`, and `description` from the sizes.

Finally, we can use a filter to find the sizes that end with `Large`. Because we used the `JOIN` keyword, our filter is flexible enough to handle any variable number of tags:

```nosql
SELECT
  p.name,
  s.key AS size
FROM
  products p
JOIN
  s in p.sizes
WHERE
  s.description LIKE "%Large"
```

```json
[
  {
    "name": "Raiot Jacket",
    "size": "l"
  },
  {
    "name": "Raiot Jacket",
    "size": "xl"
  }
]
```

---

## Self-joining multiple items

Let's move on to a sample where we need to find a value within an array that exists in multiple items. For this example, consider a container with two product items. Each item contains relevant `colors` for that item.

```json
[
  {
    "name": "Gremon Fins",
    "colors": [
      "science-blue",
      "turbo"
    ]
  },
  {
    "name": "Elecy Jacket",
    "colors": [
      "indigo-shark",
      "jordy-blue-shark"
    ]
  },
  {
    "name": "Tresko Pack",
    "colors": [
      "golden-dream"
    ]
  }
]
```

What if you needed to find every item with a color that includes `blue` in the name? You could manually search for the string `blue`, but you would need to write a complex query that accounts for two characteristics of these items:

- The colors with a `blue` substring occurs at different indexes in each array. For the `Elecy Jacket` product, the color is the second item (index: `1`). For the `Gremon Fins` product, the tag is the first item (index: `0`). The `Tresko Pack` product doesn't have any that contains this substring.

- The `colors` array for each item is a different length. The `Gremon Fins` and `Elecy Jacket` products both have **two** colors while the `Tresko Pack` product only has **one**.

Here, the `JOIN` keyword is a great tool to create a cross product of the items and colors. Joins create a **complete** cross product of the sets participating in the join. The result is a set of tuples with every permutation of the item and the values within the targeted array.

A join operation on our sample products and colors creates the following items:

| Product | Color |
| --- | --- |
| `Gremon Fins` | `science-blue` |
| `Gremon Fins` | `turbo` |
| `Elecy Jacket` | `indigo-shark` |
| `Elecy Jacket` | `jordy-blue-shark` |
| `Tresko Pack` | `golden-dream` |

This example NoSQl query uses the `JOIN` keyword to create a cross-product and returns all permutations:

```nosql
SELECT
  p.name,
  c AS color
FROM
  products p
JOIN
  c in p.colors
```

```json
[
  {
    "name": "Elecy Jacket",
    "color": "indigo-shark"
  },
  {
    "name": "Elecy Jacket",
    "color": "jordy-blue-shark"
  },
  {
    "name": "Gremon Fins",
    "color": "science-blue"
  },
  {
    "name": "Gremon Fins",
    "color": "turbo"
  },
  {
    "name": "Tresko Pack",
    "color": "golden-dream"
  }
]
```

Just like with the single item, you can apply a filter here to find only items that match a specific tag. For example, this query finds all items with a substring that contains `blue` to meet the initial requirement mentioned earlier in this section.

```nosql
SELECT
  p.name,
  c AS color
FROM
  products p
JOIN
  c in p.colors
WHERE
  c LIKE "%blue%"
```

```json
[
  {
    "name": "Elecy Jacket",
    "color": "jordy-blue-shark"
  },
  {
    "name": "Gremon Fins",
    "color": "science-blue"
  }
]
```

This query can be refined even further to just return the names of the products that meet the filter. This example does not project the color values, but the filter still works as expected:

```nosql
SELECT VALUE
  p.name
FROM
  products p
JOIN
  c in p.colors
WHERE
  c LIKE "%blue%"
```

```json
[
  "Elecy Jacket",
  "Gremon Fins"
]
```

## Related content

- [What is the NoSQL query language?](overview.md)
- [Get started with JSON in the NoSQL query language](get-started-json.md)
- [Work with subqueries](subquery.md)
- [System functions](functions/index.md)
