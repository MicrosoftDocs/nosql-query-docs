---
title: Array Update - Operators
description: Array update operators are used to modify array elements and structure.
type: operators
category: array-update
---

# Array update - operators

Array update operators are used to modify array elements and structure.

| | Description |
| --- | --- |
| [**`$`**]($.md) | The $ positional operator identifies an element in an array to update without explicitly specifying the position of the element in the array. |
| [**`$addToSet`**]($addtoset.md) | The addToSet operator adds elements to an array if they don't already exist, while ensuring uniqueness of elements within the set. |
| [**`$each`**]($each.md) | The $each operator is used within an `$addToSet` or `$push` operation to add multiple elements to an array field in a single update operation. |
| [**`$pop`**]($pop.md) | The $pop operator removes the first or last element of an array. |
| [**`$position`**]($positional.md) | The $position is used to specify the position in the array where a new element should be inserted. |
| [**`$[]`**]($positional-all.md) | The $[] operator is used to update all elements in an array that match the query condition. |
| [**`$[identifier]`**]($positional-filtered.md) | The $[identifier] operator is used to update all elements using a specific identifier in an array that match the query condition. |
| [**`$pull`**]($pull.md) | Removes all instances of a value from an array. |
| [**`$pullAll`**]($pullall.md) | The $pullAll operator is used to remove all instances of the specified values from an array. |
| [**`$push`**]($push.md) | The $push operator adds a specified value to an array within a document. |
