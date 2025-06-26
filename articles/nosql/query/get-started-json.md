---
title: Get started with JSON
description: 
ms.date: 06/26/2025
ai-usage: ai-generated
---

# Get started with JSON in the NoSQL query language

Working with JavaScript Object Notation (JSON) is at the heart of the NoSQL query language. Items are stored as JSON, and all queries, expressions, and types are designed to work with JSON data. For more information about JSON itself, see the [formal JSON specification](https://www.json.org/).

Here are some key things to know about JSON in this context:

- JSON objects always start with `{` and end with `}`.
- Properties can be [nested](#nested-properties) inside each other.
- Property values can be arrays.
- Property names are case sensitive.
- Property names can be any string, even with spaces or special characters.

## Nested properties

You can access nested JSON properties using dot notation. This works just like accessing properties in most programming languages.

Here's an example document with nested JSON:

```json
[
  {
    "name": "Heatker Women's Jacket",
    "category": "apparel",
    "slug": "heatker-women-s-jacket",
    "sizes": [
      {
        "key": "s",
        "description": "Small"
      }
    ],
    "metadata": {
      "link": "https://www.adventure-works.com/heatker-women-s-jacket/68719520138.p"
    }
  }
]
```

You can then project the same nested properties in your queries:

```nosql
SELECT
  p.name,
  p.category,
  p.metadata.link
FROM
  products p
WHERE
  p.name = "Heatker Women's Jacket"
```

And you would get this expected output:

```json
[
  {
    "name": "Heatker Women's Jacket",
    "category": "apparel",
    "link": "https://www.adventure-works.com/heatker-women-s-jacket/68719520138.p"
  }
]
```

## Arrays and sets

JSON supports arrays, and you can work with them in your queries. To access a specific element, use its position in the array.

Using the same example from the previous section, we can access an item in the array using its index. For example, if we want to access the first item in the array, we would use an index of `0` since its a **zero-based index** system for arrays in the NoSQL query language:

```nosql
SELECT
  p.name,
  p.sizes[0].description AS defaultSize
FROM
  products p
WHERE
  p.name = "Heatker Women's Jacket"
```

This results in the following JSON object:

```json
[
  {
    "name": "Heatker Women's Jacket",
    "defaultSize": "Small"
  }
]
```

Now, let's consider an example with a larger array:

```json
[
  {
    "name": "Vencon Kid's Coat",
    "category": "apparel",
    "slug": "vencon-kid-s-coat",
    "colors": [
      "cardinal",
      "disco"
    ],
    "sizes": [
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


Often, you'll want to use a subquery or a self-join to work with all elements in an array. For example, to get each color as a separate row:

```nosql
SELECT
  p.name,
  c AS color
FROM
  products p
JOIN
  c IN p.colors
WHERE
  p.name = "Vencon Kid's Coat"
```

Which would result in a JSON array like this:

```json
[
  {
    "name": "Vencon Kid's Coat",
    "color": "cardinal"
  },
  {
    "name": "Vencon Kid's Coat",
    "color": "disco"
  }
]
```

To check if a certain value exists in an array, you can use the array in the filter after the `WHERE` keyword. This example uses a [subquery](subquery.md) to filter the array's items:

```nosql
SELECT VALUE
  p.name
FROM
  products p
WHERE
  EXISTS(SELECT VALUE
    c
  FROM
    c IN p.sizes
  WHERE
    c.description LIKE "%Large")
```

This results in a flat JSON array of strings which would include the item in the example:

```json
[
  ...,
  "Vencon Kid's Coat"
  ...
]
```

Finally, you can construct arrays by combining multiple properties. In this example, multiple properties are combined to form a `metadata` array:

```nosql
SELECT
  p.name,
  [
    p.category,
    p.slug,
    p.metadata.link
  ] AS metadata
FROM
  products p
WHERE
  p.name = "Heatker Women's Jacket"
```

```json
[
  {
    "name": "Heatker Women's Jacket",
    "metadata": [
      "apparel",
      "heatker-women-s-jacket",
      "https://www.adventure-works.com/heatker-women-s-jacket/68719520138.p"
    ]
  }
]
```

## Iteration

The NoSQL query language supports iteration over JSON arrays using the `IN` keyword in the `FROM` source.

Consider this example data set:

```json
[
  {
    "name": "Pila Swimsuit",
    "colors": [
      "regal-blue",
      "rose-bud-cherry"
    ],
    "sizes": [
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
  },
  {
    "name": "Makay Bikini",
    "colors": [
      "starship"
    ],
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
      }
    ]
  }
]
```

Using the `IN` keyword, this first example query performs iteration over the `colors` property for each product

```nosql
SELECT
  *
FROM
  p IN p.colors
```

```json
[
  "regal-blue",
  "rose-bud-cherry",
  "starship"
]
```

You can also filter individual entries in the array using the `WHERE` clause. In this example, the `sizes` property is filtered:

```nosql
SELECT
  p.key
FROM
  p IN p.sizes
WHERE
  p.description LIKE "%Large"
```

```json
[
  {
    "key": "l"
  },
  {
    "key": "xl"
  },
  {
    "key": "l"
  }
]
```

Using the same `IN` keyword, you can aggregate over the result of an array iteration. In this example, the query returns the count of the number of tags summed across all items in the container:

```nosql
SELECT VALUE
  COUNT(1)
FROM
  p IN p.sizes
```

> [!NOTE]
> When using the `IN` keyword for iteration, you cannot filter or project any properties outside of the array. Instead, you should considering using [self-joins](join.md).

## Null and undefined values

If a property isn't present in a document, its value is `undefined`. If a property is present but set to `null`, that's an explicitly set value. The distinction between `null` and `undefined` is a very important distinction that can cause confusion in queries.

For example, this JSON object would have a value of `undefined` for the `sku` property because the property was never defined:

```json
[
  {
    "name": "Witalica helmet",
    "category": "gear",
  }
]
```

But this JSON object would have a value of `null` for the same property because it is defined, but not set with a value:

```json
[
  {
    "name": "Witalica helmet",
    "category": "gear",
    "sku": null
  }
]
```

There are built-in functions to check for these cases:

- `IS_NULL` checks if a property is `null`.
- `IS_DEFINED` checks if a property exists (is not `undefined`).

Here's how you can check for both:

```nosql
SELECT
  IS_DEFINED(p.sku) AS isSkuDefined,
  IS_NULL(p.sku) AS isSkuDefinedButNull
FROM
  products p
```

## Bracket notation

While most examples will use **dot** notation to specify properties, you can always specify the same properties using **bracket** notation.

Let's start with a simple object with a nested object as the value of the `metadata` property:

```json
[
  {
    "name": "Hikomo Sandals",
    "metadata": {
      "link": "https://www.adventure-works.com/hikomo-sandals/68719519305.p"
    }
  }
]
```

For that object, we can reference the `metadata.link` property in three distinct ways using combinations of **dot** and **bracket** notation:

```nosql
SELECT
  p.metadata.link AS metadataLinkDotNotation,
  p["metadata"]["link"] AS metadataLinkBracketNotation,
  p.metadata["link"] AS metadataLinkMixedNotation
FROM
  products p
WHERE
  p.name = "Hikomo Sandals"
```

```json
[
  {
    "metadataLinkDotNotation": "https://www.adventure-works.com/hikomo-sandals/68719519305.p",
    "metadataLinkBracketNotation": "https://www.adventure-works.com/hikomo-sandals/68719519305.p",
    "metadataLinkMixedNotation": "https://www.adventure-works.com/hikomo-sandals/68719519305.p"
  }
]
```

> [!TIP]
> If a property name has spaces, special characters, or matches a reserved word, you must use bracket notation to specify the property.

## JSON expressions

You can create JSON objects directly in your query results. Let's start with this JSON array as an example:

```json
[
  {
    "name": "Diannis Watch",
    "category": "apparel",
    "detailCategory": "apparel-accessories-watches",
    "slug": "diannis-watch",
    "sku": "64801",
    "price": 98,
    "quantity": 159
  },
  {
    "name": "Confira Watch",
    "category": "apparel",
    "detailCategory": "apparel-accessories-watches",
    "slug": "confira-watch",
    "sku": "64800",
    "price": 105,
    "quantity": 193
  }
]
```

Using the most straightforward syntax, you can influence the property names of a relatively flat JSON object using angle brackets (`{`/`}`) and the embedded JSON syntax in a NoSQL query:

```nosql
SELECT {
  "brandName": p.name,
  "department": p.category
}
FROM
  products p
WHERE
  p.detailCategory = "apparel-accessories-watches"
```

```json
[
  {
    "$1": {
      "brandName": "Diannis Watch",
      "department": "apparel"
    }
  },
  {
    "$1": {
      "brandName": "Confira Watch",
      "department": "apparel"
    }
  }
]
```

In the previous example, the result had an inferred name of `$1` because an explicit name wasn't defined. In this next example, the result has an explicit name of `product` defined using an alias:

```nosql
SELECT {
  "brandName": p.name,
  "department": p.category
} AS product
FROM
  products p
WHERE
  p.detailCategory = "apparel-accessories-watches"
```

```json
[
  {
    "product": {
      "brandName": "Diannis Watch",
      "department": "apparel"
    }
  },
  {
    "product": {
      "brandName": "Confira Watch",
      "department": "apparel"
    }
  }
]
```

Alternatively, the result can be flattened using the `VALUE` keyword in a `SELECT VALUE` statement:

```nosql
SELECT VALUE {
  "brandName": p.name,
  "department": p.category
}
FROM
  products p
WHERE
  p.detailCategory = "apparel-accessories-watches"
```

```json
[
  {
    "brandName": "Diannis Watch",
    "department": "apparel"
  },
  {
    "brandName": "Confira Watch",
    "department": "apparel"
  }
]
```

Going even further, you can use the JSON syntax to "reshape" the result JSON object to include arrays, sub-objects, and other JSON constructs that may not be explicitly defined in the original item. This is a very useful technique if the client application is expecting data in a specific schema that doesn't match the structure of the data that's stored.

Consider this JSON schema, for example:

```json
{
  "$schema": "http://json-schema.org/draft-04/schema#",
  "type": "object",
  "required": [
    "id",
    "category",
    "financial"
  ],
  "properties": {
    "id": {
      "type": "string"
    },
    "name": {
      "type": "string"
    },
    "category": {
      "type": "object",
      "properties": {
        "department": {
          "type": "string"
        },
        "section": {
          "type": "string"
        }
      },
      "required": [
        "department"
      ]
    },
    "inventory": {
      "type": "object",
      "properties": {
        "stock": {
          "type": "number"
        }
      }
    },
    "financial": {
      "type": "object",
      "properties": {
        "listPrice": {
          "type": "number"
        }
      },
      "required": [
        "listPrice"
      ]
    }
  }
}
```

That would allow a JSON object structured in this format:

```json
[
  {
    "id": "[string]",
    "name": "[string]",
    "category": {
      "department": "[string]",
      "section": "[string]"
    },
    "inventory": {
      "stock": [number]
    },
    "financial": {
      "listPrice": [number]
    }
  }
]
```

This NoSQL query will remap the original object\[s\] to be compliant with this new schema:

```nosql
SELECT VALUE {
  "id": p.sku,
  "name": p.name,
  "category": {
    "department": p.category,
    "section": p.detailCategory
  },
  "inventory": {
    "stock": p.quantity
  },
  "financial": {
    "listPrice": p.price
  }
}
FROM
  products p
WHERE
  p.detailCategory = "apparel-accessories-watches"
```

```json
[
  {
    "id": "64801",
    "name": "Diannis Watch",
    "category": {
      "department": "apparel",
      "section": "apparel-accessories-watches"
    },
    "inventory": {
      "stock": 159
    },
    "financial": {
      "listPrice": 98
    }
  },
  {
    "id": "64800",
    "name": "Confira Watch",
    "category": {
      "department": "apparel",
      "section": "apparel-accessories-watches"
    },
    "inventory": {
      "stock": 193
    },
    "financial": {
      "listPrice": 105
    }
  }
]
```

## Container aliases

By default, the term used after the `FROM` keyword references the **container** that's the target of the query. The term itself is **NOT** required to match the name of the container.

For example, if the container is named `products`, any of these queries will work fine and all reference the `products` container as long as that container is the *target* of the query:

```nosql
SELECT
  products.id
FROM
  products
```

```nosql
SELECT
  p.id
FROM
  p
```

```nosql
SELECT
  items.id
FROM
  items
```

```nosql
SELECT
  targetContainer.id
FROM
  targetContainer
```

To make your NoSQL query more concise, it's very common to alias the container name with a shorter name. This can be done using the `AS` keyword:

```nosql
SELECT
  p.id
FROM
  products AS p
```

The NoSQL query language also has a shorthand syntax where the alias can be defined immediately after the target container's reference without the `AS` keyword. This will be functionally equivalent to using the `AS` keyword:

```nosql
SELECT
  p.id
FROM
  products p
```

## Property aliases

You can also rename fields in your results using aliases defines with the same `AS` keyword. For the next few examples, consider this sample data:

```json
[
  {
    "name": "Oceabelle Scarf",
    "detailCategory": "apparel-accessories-scarfs-and-socks",
    "metadata": {
      "link": "https://www.adventure-works.com/oceabelle-scarf/68719522190.p"
    }
  },
  {
    "name": "Shinity Socks",
    "detailCategory": "apparel-accessories-scarfs-and-socks",
    "metadata": {
      "link": "https://www.adventure-works.com/shinity-socks/68719522161.p"
    }
  },
  {
    "name": "Horric Socks",
    "detailCategory": "apparel-accessories-scarfs-and-socks",
    "metadata": {
      "link": "https://www.adventure-works.com/horric-socks/68719522177.p"
    }
  }
]
```

In this first example, the `metadataLink` alias is used for the `metadata.link` property's value:

```nosql
SELECT
  p.name,
  p.metadata.link AS metadataLink
FROM
  products p
```

```json
[
  {
    "name": "Oceabelle Scarf",
    "metadataLink": "https://www.adventure-works.com/oceabelle-scarf/68719522190.p"
  },
  {
    "name": "Shinity Socks",
    "metadataLink": "https://www.adventure-works.com/shinity-socks/68719522161.p"
  },
  {
    "name": "Horric Socks",
    "metadataLink": "https://www.adventure-works.com/horric-socks/68719522177.p"
  }
]
```

> [!IMPORTANT]
> You can't use aliasing to project a value as a property name with a space, special character, or reserved word. If you wanted to change a value's projection to, for example, have a property name with a space, you must use a [JSON expression](#json-expressions).
>
> For example,
>
> ```nosql
> SELECT VALUE {
>   "product name": p.name,
>   "from": p.metadata.link,
>   "detail/category": p.detailCategory
> }
> FROM
>   products p
> WHERE
>   p.detailCategory = "apparel-accessories-scarfs-and-socks"
> ```
> 
> ```json
> [
>   {
>     "product name": "Oceabelle Scarf",
>     "from": "https://www.adventure-works.com/oceabelle-scarf/68719522190.p",
>     "detail/category": "apparel-accessories-scarfs-and-socks"
>   },
>   {
>     "product name": "Shinity Socks",
>     "from": "https://www.adventure-works.com/shinity-socks/68719522161.p",
>     "detail/category": "apparel-accessories-scarfs-and-socks"
>   },
>   {
>     "product name": "Horric Socks",
>     "from": "https://www.adventure-works.com/horric-socks/68719522177.p",
>     "detail/category": "apparel-accessories-scarfs-and-socks"
>   }
> ]
> ```
>

If a NoSQL query has two properties with the same name, use aliases to rename one or both of the properties so they're disambiguated in the projected result.

Consider this sample data:

```json
[
  {
    "name": "Oceabelle Scarf",
    "detailCategory": "apparel-accessories-scarfs-and-socks",
    "sizes": [
      {
        "key": "s"
      },
      ...
    ],
    "tags": [
      ...
    ]
  },
  {
    "name": "Shinity Socks",
    "detailCategory": "apparel-accessories-scarfs-and-socks",
    "sizes": [
      ...
      {
        "key": "10"
      },
      ...
    ],
    "tags": [
      ...
      {
        "key": "length"
      }
    ]
  },
  {
    "name": "Horric Socks",
    "detailCategory": "apparel-accessories-scarfs-and-socks",
    "sizes": [
      ...
      {
        "key": "7"
      },
      ...
    ],
    "tags": [
      {
        "key": "fabric"
      },
      ...
    ]
  }
]
```

> [!NOTE]
> In this sample data and the query result, multiple properties and values were removed for brevity.

This NoSQL query will return the `p.sizes[].key` and `p.tags[].key` properties in the cross-product result but will alias each `key` property to avoid collisions:

```nosql
SELECT
  p.name,
  s.key AS sizeKey,
  t.key AS tagKey
FROM
  products p
JOIN
  s IN p.sizes
JOIN
  t in p.tags
WHERE
  p.detailCategory = "apparel-accessories-scarfs-and-socks"
```

```json
[
  {
    "name": "Oceabelle Scarf",
    "sizeKey": "s",
    "tagKey": "fabric"
  },
  ...
  {
    "name": "Shinity Socks",
    "sizeKey": "10",
    "tagKey": "length"
  },
  ...
  {
    "name": "Horric Socks",
    "sizeKey": "7",
    "tagKey": "fabric"
  }
]
```

## Related content

- [What is the NoSQL query language?](overview.md)
- [Work with subqueries](subquery.md)
- [Perform self-joins](join.md)
- [System functions](functions/index.md)
