---
title: LIKE
description: The `LIKE` keyword a boolean value depending on whether a specific character string matches a specified pattern.
ms.date: 11/10/2025
---

# `LIKE` - Query language in Cosmos DB (in Azure and Fabric)

The `LIKE` keyword a boolean value depending on whether a specific character string matches a specified pattern. A pattern can include regular characters and wildcard characters.

> [!TIP]
> You can write logically equivalent queries using either the `LIKE` keyword or the [`RegexMatch`](regexmatch.md) system function. You observe the same index utilization regardless of which option you choose. The choice of which option to use is largely based on syntax preference.

> [!NOTE]
> Because `LIKE` can utilize an index, you should [create a range index](../../index-policy.md) for properties you're comparing using `LIKE`.

You can use the following wildcard characters with LIKE:

| | Description | Example |
| --- | --- | --- |
| *`%`* | Any string of zero or more characters. | `WHERE c.description LIKE "%SO%PS%"` |
| *`_`* *(underscore)* | Any single character. | `WHERE c.description LIKE"%SO_PS%"` |
| *`[ ]`* | Any single character within the specified range (`[a-f]`) or set (`[abcdef]`). | `WHERE c.description LIKE "%SO[t-z]PS%"` |
| *`[^]`* | Any single character not within the specified range   (`[^a-f]`) or set (`[^abcdef]`). | `WHERE c.description LIKE "%SO[^abc]PS%"` |

The `%` character matches any string of zero or more characters. For example, by placing a `%` at the beginning and end of the pattern, the following query returns all items where the specified field contains the phrase as a substring:

```nosql
SELECT VALUE
    p.name
FROM
    products p
WHERE
    p.name LIKE "%driver%"
```

If you only used a `%` character at the end of the pattern, you'd only return items with a description that started with `fruit`:

```nosql
SELECT VALUE
    p.name
FROM
    products p
WHERE
    p.name LIKE "fruit%"
```

Similarly, the wildcard at the start of the pattern indicates that you want to match values with the specified value as a prefix:

```nosql
SELECT VALUE
    p.name
FROM
    products p
WHERE
    p.name LIKE "%Road"
```

The `NOT` keyword inverses the result of the `LIKE` keyword's expression evaluation. This example returns all items that do **not** match the `LIKE` expression.

```nosql
SELECT VALUE
    p.name
FROM
    products p
WHERE
    p.name NOT LIKE "%winter%"
```

You can search for patterns that include one or more wildcard characters using the `ESCAPE` clause. For example, if you wanted to search for descriptions that contained the string `20%`, you wouldn't want to interpret the `%` as a wildcard character. This example interprets the `^` as the escape character so you can escape a specific instance of `%`.

```nosql
SELECT VALUE
    p.name
FROM
    products p
WHERE
    p.description LIKE "%20^%%" ESCAPE "^"
```

You can enclose wildcard characters in brackets to treat them as literal characters. When you enclose a wildcard character in brackets, you remove any special attributes. This table includes examples of literal characters.

| | Parsed value |
| --- | --- |
| *`LIKE "20-30[%]"`* | `20-30%` |
| *`LIKE "[_]n"`* | `_n` |
| *`LIKE "[ [ ]"`* | `[` |
| *`LIKE "]"`* | `]` |
