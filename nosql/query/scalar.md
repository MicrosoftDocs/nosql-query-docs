---
title: Scalar expressions
description: Use symbols and operators in scalar expressions within the NoSQL query language to perform complex evaluations to a single result value.
ms.date: 07/02/2025
---

# Scalar expressions in NoSQL query language

The [`SELECT`](select.md) clause supports scalar expressions. A scalar expression is a combination of symbols and operators that can be evaluated to obtain a single value. Examples of scalar expressions include: constants, property references, array element references, alias references, or function calls. Scalar expressions can be combined into complex expressions using operators.

## Syntax
  
```nosql  
<scalar_expression> ::=  
       <constant>
     | input_alias
     | parameter_name  
     | <scalar_expression>.property_name  
     | <scalar_expression>'['"property_name"|array_index']'  
     | unary_operator <scalar_expression>  
     | <scalar_expression> binary_operator <scalar_expression>    
     | <scalar_expression> ? <scalar_expression> : <scalar_expression>  
     | <scalar_function_expression>  
     | <create_object_expression>
     | <create_array_expression>  
     | (<scalar_expression>)
  
<scalar_function_expression> ::=  
        'udf.' Udf_scalar_function([<scalar_expression>][,…n])  
        | builtin_scalar_function([<scalar_expression>][,…n])  
  
<create_object_expression> ::=  
   '{' [{property_name | "property_name"} : <scalar_expression>][,…n] '}'  
  
<create_array_expression> ::=  
   '[' [<scalar_expression>][,…n] ']'
```

## Arguments
  
| | Description |
| --- | --- |
| **`<constant>`** | Represents a constant value. See [Constants](constants.md) section for details. |
| **`input_alias`** | Represents a value defined by the `input_alias` introduced in the `FROM` clause. |
  This value is guaranteed to not be **undefined** –**undefined** values in the input are skipped. |
| **`<scalar_expression>.property_name`** | Represents a value of the property of an object. If the property doesn't exist or property is referenced on a value, which isn't an object, then the expression evaluates to **undefined** value. |
| **`<scalar_expression>'['"property_name"|array_index']'`** | Represents a value of the property with name `property_name` or array element with index `array_index` of an array. If the property/array index doesn't exist or the property/array index is referenced on a value that isn't an object/array, then the expression evaluates to undefined value. |
| **`unary_operator <scalar_expression>`** | Represents an operator that is applied to a single value.
| **`<scalar_expression> binary_operator <scalar_expression>`** | Represents an operator that is applied to two values.
| **`<scalar_function_expression>`** | Represents a value defined by a result of a function call. |
| **`udf_scalar_function`** | Name of the user-defined scalar function. |
| **`builtin_scalar_function`** | Name of the built-in scalar function. |
| **`<create_object_expression>`** | Represents a value obtained by creating a new object with specified properties and their values. |
| **`<create_array_expression>`** | Represents a value obtained by creating a new array with specified values as elements |
| **`parameter_name`** | Represents a value of the specified parameter name. Parameter names must have a single \@ as the first character. |

## Examples

The most common example of a scalar expression is a math equation.

```nosql
SELECT VALUE
  ((2 + 11 % 7) - 2) / 2
```

```json
[
  2
]
```

In this next example, the result of the scalar expression is a boolean:

```nosql
SELECT
  ("Redmond" = "WA") AS isCitySameAsState,
  ("WA" = "WA") AS isStateSameAsState
```

```json
[
  {
    "isCitySameAsState": false,
    "isStateSameAsState": true
  }
]
```

## Remarks

- All arguments must be defined when calling a built-in or user-defined scalar function. If any of the arguments is undefined, the function isn't called, and the result is `undefined`.  
- Any property that is assigned undefined value is skipped and not included in the created object when creating an object.  
- Any element value that is assigned **undefined** value is skipped and not included in the created object when creating an array. This skip causes the next defined element to take its place in such a way that the created array doesn't skip indexes.  

