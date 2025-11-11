---
title: AGO
description: This function returns a datetime string representing the current UTC time minus a specified numeric offset.
ms.date: 11/10/2025
---

# AGO (NoSQL query)

Returns a datetime string representing the current UTC time minus a specified numeric offset.

## Syntax

```nosql
AGO(<date_time_part>, <numeric_expr>)  
```  

## Arguments

| | Description |
| --- | --- |
| **`date_time_part`** | A string representing a part of an ISO 8601 date format specification. This part is used to indicate which aspect of the date to modify by the related numeric expression. |
| **`numeric_expr`** | The value to subtract from the current datetime. |

## Return types

Returns a string expression.

## Examples

The following example shows various uses of the AGO function with different time parts.
Assume the current datetime is `2024-10-14T14:20:30.6668888Z`.

```nosql
SELECT VALUE {
    "case1": AGO("yyyy", 1),
    "case2": AGO("yyyy", -1), 
    "case3": AGO("ss", 30),
    "case4": AGO("ms", 4)
}
```

```json
[
    {
        "case1": "2023-10-14T14:20:30.6668888Z",
        "case2": "2025-10-14T14:20:30.6668888Z",
        "case3": "2024-10-14T14:20:00.6668888Z",
        "case4": "2024-10-14T14:20:30.6628888Z"
    }
]
```

## Remarks

- The ISO 8601 date format specifies valid date and time parts to use with this function:
  - **Year**: `year`, `yyyy`, `yy`
  - **Month**: `month`, `mm`, `m`
  - **Day**: `day`, `dd`, `d`
  - **Hour**: `hour`, `hh`
  - **Minute**: `minute`, `mi`, `n`
  - **Second**: `second`, `ss`, `s`
  - **Millisecond**: `millisecond`, `ms`
  - **Microsecond**: `microsecond`, `mcs`
  - **Nanosecond**: `nanosecond`, `ns`

## Related content

- [`NOW`](now.md)
