---
title: Get started with JSON
description: 
ms.devlang: nosql
ms.date: 06/26/2025
ai-usage: ai-generated
---

# Get started with JSON in the NoSQL query language

Working with JSON is at the heart of the NoSQL query language. Items are stored as JSON, and all queries, expressions, and types are designed to work with JSON data. If you want to learn more about JSON itself, check out the [JSON specification](https://www.json.org/).

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
{
  "name": "Teapo rainbow surfboard",
  "manufacturer": {
    "name": "AdventureWorks"
  },
  "releaseDate": null,
  "metadata": {
    "sku": "72109",
    "colors": [
      "cruise",
      "picton-blue"
    ],
    "sizes": {
      "small": {
        "inches": 76,
        "feet": 6.33333
      },
      "large": {
        "inches": 92,
        "feet": 7.66667
      }
    }
  }
}
```

You can project nested properties in your queries:

```nosql
SELECT
    p.manufacturer.name,
    p.metadata.sku,
    p.metadata.sizes.small.inches AS size
FROM
    products p
```

## Working with arrays

JSON supports arrays, and you can work with them in your queries. To access a specific element, use its position in the array.

```nosql
SELECT
    p.name,
    p.metadata.colors
FROM
    products p
WHERE
    p.metadata.colors[0] NOT LIKE "%orange%"
```

Often, you'll want to use a subquery or a self-join to work with all elements in an array. For example, to get each color as a separate row:

```nosql
SELECT
    p.name,
    c AS color
FROM
    products p
JOIN
    c IN p.metadata.colors
```

Or, to check if a certain value exists in an array:

```nosql
SELECT VALUE
    p.name
FROM
    products p
WHERE
    EXISTS (SELECT VALUE 
        c
    FROM
        c IN p.metadata.colors
    WHERE
        c LIKE "%picton%")
```

## Null vs. undefined

If a property isn't present in a document, its value is `undefined`. If a property is present but set to `null`, that's an explicit value.

There are built-in functions to check for these cases:

- `IS_NULL` checks if a property is `null`.
- `IS_DEFINED` checks if a property exists (is not `undefined`).

Here's how you can check for both:

```nosql
SELECT
    IS_NULL(p.releaseDate) AS isReleaseDateNull,
    IS_DEFINED(p.releaseDate) AS isReleaseDateDefined,
    IS_NULL(p.retirementDate) AS isRetirementDateNull,
    IS_DEFINED(p.retirementDate) AS isRetirementDateDefined
FROM
    products p
```

## Reserved keywords and special characters

If a property name has spaces, special characters, or matches a reserved word, use bracket notation:

```nosql
SELECT
    p.manufacturer.name AS dotNotationReference,
    p["manufacturer"]["name"] AS bracketReference,
    p.manufacturer["name"] AS mixedReference
FROM
    products p
```

## JSON expressions in queries

You can create JSON objects directly in your query results:

```nosql
SELECT {
    "productName": p.name,
    "largeSizeInFeet": p.metadata.sizes.large.feet
}
FROM
    products p
```

Or, give the result an explicit name:

```nosql
SELECT {
    "productName": p.name,
    "largeSizeInFeet": p.metadata.sizes.large.feet
} AS product
FROM
    products p
```

Or, flatten the object with `SELECT VALUE`:

```nosql
SELECT VALUE {
    "productName": p.name,
    "largeSizeInFeet": p.metadata.sizes.large.feet
}
FROM
    products p
```

## Aliasing values

You can rename fields in your results using aliases. The `AS` keyword is optional:

```nosql
SELECT
    p.name,
    p.metadata.sku AS modelNumber
FROM
    products p
```

## JSON expressions

Query projection supports JSON expressions and syntax.

```nosql
SELECT {
    "productName": p.name,
    "largeSizeInFeet": p.metadata.sizes.large.feet
}
FROM
    products p
```

```json
[
  {
    "$1": {
      "productName": "Teapo rainbow surfboard",
      "largeSizeInFeet": 7.66667
    }
  }
]
```

In this example, the ``SELECT`` clause creates a JSON object. Since the sample provides no key, the clause uses the implicit argument variable name ``$<index-number>``.

This example explicitly names the same field.

```nosql
SELECT {
    "productName": p.name,
    "largeSizeInFeet": p.metadata.sizes.large.feet
} AS product
FROM
    products p
```

```json
[
  {
    "product": {
      "productName": "Teapo rainbow surfboard",
      "largeSizeInFeet": 7.66667
    }
  }
]
```

Alternatively, the query can flatten the object to avoid naming a redundant field.

```nosql
SELECT VALUE {
    "productName": p.name,
    "largeSizeInFeet": p.metadata.sizes.large.feet
}
FROM
    products p
```

```json
[
  {
    "productName": "Teapo rainbow surfboard",
    "largeSizeInFeet": 7.66667
  }
]
```

## Alias values

You can explicitly alias values in queries. If a query has two properties with the same name, use aliasing to rename one or both of the properties so they're disambiguated in the projected result.

### Examples

The ``AS`` keyword used for aliasing is optional, as shown in the following example.

```nosql
SELECT
    p.name,
    p.metadata.sku AS modelNumber
FROM
    products p
```

```json
[
  {
    "name": "Teapo rainbow surfboard",
    "modelNumber": "72109"
  }
]
```

### Alias values with reserved keywords or special characters

You can't use aliasing to project a value as a property name with a space, special character, or reserved word. If you wanted to change a value's projection to, for example, have a property name with a space, you could use a [JSON expression](#json-expressions).

Here's an example:

```nosql
SELECT VALUE {
    "Product's name | ": p.name,
    "Model number => ": p.metadata.sku
}
FROM
    products p
```

```json
[
  {
    "Product's name | ": "Teapo rainbow surfboard",
    "Model number => ": "72109"
  }
]
```

## Related content

- [What is the NoSQL query language?](overview.md)
- [System functions](functions/index.md)
