---
title: Operators
description: MongoDB Query Language (MQL) operators enable powerful filtering, comparison, and data manipulation within queries. Mastering these operators helps you write expressive queries to efficiently retrieve and update documents in your collections.
type: operators
---

# Operators

MongoDB Query Language (MQL) operators enable powerful filtering, comparison, and data manipulation within queries. Mastering these operators helps you write expressive queries to efficiently retrieve and update documents in your collections.

## Accumulators

Accumulator operators are used in aggregation pipelines to perform calculations on grouped data.

| | Description |
| --- | --- |
| [**`$avg`**](accumulators/$avg.md) | The $avg operator computes the average of numeric values for documents in a group, bucket, or window. |
| [**`$bottom`**](accumulators/$bottom.md) | The $bottom operator returns the last document from the query's result set sorted by one or more fields |
| [**`$bottomN`**](accumulators/$bottomn.md) | The $bottomN operator returns the last N documents from the result sorted by one or more fields |
| [**`$count`**](accumulators/$count.md) | The `$count` operator is used to count the number of documents that match a query filtering criteria. |
| [**`$first`**](accumulators/$first.md) | The $first operator returns the first value in a group according to the group's sorting order. |
| [**`$firstN`**](accumulators/$firstn.md) | The $firstN operator sorts documents on one or more fields specified by the query and returns the first N document matching the filtering criteria |
| [**`$last`**](accumulators/$last.md) | The $last operator returns the last document from the result sorted by one or more fields |
| [**`$lastN`**](accumulators/$lastn.md) | The $lastN accumulator operator returns the last N values in a group of documents. |
| [**`$max`**](accumulators/$max.md) | The $max operator returns the maximum value from a set of input values. |
| [**`$maxN`**](accumulators/$maxn.md) | The $maxN opertor retrieves the top N values based on a specified filtering criteria |
| [**`$median`**](accumulators/$median.md) | The $median operator calculates the median value of a numeric field in a group of documents. |
| [**`$min`**](accumulators/$min.md) | The $min operator retrieves the minimum value for a specified field |
| [**`$minN`**](accumulators/$minn.md) | The $minN operator retrieves the bottom N values based on a specified filtering criteria |
| [**`$percentile`**](accumulators/$percentile.md) | The $percentile operator calculates the percentile of numerical values that match a filtering criteria |
| [**`$stddevpop`**](accumulators/$stddevpop.md) | The $stddevpop operator calculates the standard deviation of the specified values |
| [**`$stddevsamp`**](accumulators/$stddevsamp.md) | The $stddevsamp operator calculates the standard deviation of a specified sample of values and not the entire population |
| [**`$sum`**](accumulators/$sum.md) | The $sum operator calculates the sum of the values of a field based on a filtering criteria |
| [**`$top`**](accumulators/$top.md) | The $top operator returns the first document from the result set sorted by one or more fields |
| [**`$topN`**](accumulators/$topn.md) | The $topN operator returns the first N documents from the result sorted by one or more fields |

## Aggregation

Aggregation operators are used to perform operations on grouped data in aggregation pipelines.

| | Description |
| --- | --- |
| [**`$addFields`**](aggregation/$addfields.md) | The $addFields stage in the aggregation pipeline is used to add new fields to documents. |
| [**`$bucket`**](aggregation/$bucket.md) | The $bucket operator groups input documents into buckets based on specified boundaries. |
| [**`$changeStream`**](aggregation/$changestream.md) | The $changeStream stage opens a change stream cursor to track data changes in real-time. |
| [**`$collStats`**](aggregation/$collstats.md) | The $collStats stage in the aggregation pipeline is used to return statistics about a collection. |
| [**`$convert`**](aggregation/$convert.md) | The $convert operator converts an expression into the specified type |
| [**`$densify`**](aggregation/$densify.md) | The $densify operator adds missing data points in a sequence of values within an array or collection. |
| [**`$documents`**](aggregation/$documents.md) | The $documents stage creates a pipeline from a set of provided documents. |
| [**`$facet`**](aggregation/$facet.md) | The $facet allows for multiple parallel aggregations to be executed within a single pipeline stage. |
| [**`$fill`**](aggregation/$fill.md) | The $fill stage allows filling missing values in documents based on specified methods and criteria. |
| [**`$geoNear`**](aggregation/$geonear.md) | The $geoNear operator finds and sorts documents by their proximity to a geospatial point, returning distance information for each document. |
| [**`$group`**](aggregation/$group.md) | The $group stage groups documents by specified identifier expressions and applies accumulator expressions. |
| [**`$indexStats`**](aggregation/$indexstats.md) | The $indexStats stage returns usage statistics for each index in the collection. |
| [**`$isNumber`**](aggregation/$isnumber.md) | The $isNumber operator checks if a specified expression is a numerical type |
| [**`$lookup`**](aggregation/$lookup.md) | The $lookup stage in the Aggregation Framework is used to perform left outer joins with other collections. |
| [**`$match`**](aggregation/$match.md) | The $match stage in the aggregation pipeline is used to filter documents that match a specified condition. |
| [**`$merge`**](aggregation/$merge.md) | The $merge stage in an aggregation pipeline writes the results of the aggregation to a specified collection. |
| [**`$out`**](aggregation/$out.md) | The `$out` stage in an aggregation pipeline writes the resulting documents to a specified collection. |
| [**`$redact`**](aggregation/$redact.md) | The $redact operator filters the content of the documents based on access rights. |
| [**`$replaceWith`**](aggregation/$replacewith.md) | The $replaceWith operator in DocumentDB returns a document after replacing a document with the specified document |
| [**`$sample`**](aggregation/$sample.md) | The $sample operator in DocumentDB returns a randomly selected number of documents |
| [**`$set`**](aggregation/$set.md) | The $set operator in DocumentDB updates or creates a new field with a specified value |
| [**`$skip`**](aggregation/$skip.md) | The $skip stage in the aggregation pipeline is used to skip a specified number of documents from the input and pass the remaining documents to the next stage in the pipeline. |
| [**`$sort`**](aggregation/$sort.md) | The $sort stage in the aggregation pipeline is used to order the documents in the pipeline by a specified field or fields. |
| [**`$sortByCount`**](aggregation/$sortbycount.md) | The $sortByCount stage in the aggregation pipeline is used to group documents by a specified expression and then sort the count of documents in each group in descending order. |
| [**`$toBool`**](aggregation/$tobool.md) | The $toBool operator converts an expression into a Boolean type |
| [**`$toDate`**](aggregation/$todate.md) | The $toDate operator converts supported types to a proper Date object. |
| [**`$toDecimal`**](aggregation/$todecimal.md) | The $toDecimal operator converts an expression into a Decimal type |
| [**`$toDouble`**](aggregation/$todouble.md) | The $toDouble operator converts an expression into a Double value |
| [**`$toInt`**](aggregation/$toint.md) | The $toInt operator converts an expression into an Integer |
| [**`$toLong`**](aggregation/$tolong.md) | The $toLong operator converts an expression into a Long value |
| [**`$toObjectId`**](aggregation/$toobjectid.md) | The $toObjectId operator converts an expression into an ObjectId |
| [**`$toString`**](aggregation/$tostring.md) | The $toString operator converts an expression into a String |
| [**`$unset`**](aggregation/$unset.md) | The $unset stage in the aggregation pipeline is used to remove specified fields from documents. |
| [**`$unwind`**](aggregation/$unwind.md) | The $unwind stage in the aggregation framework is used to deconstruct an array field from the input documents to output a document for each element. |

## Arithmetic Expression

Arithmetic expression operators perform mathematical operations on numeric values.

| | Description |
| --- | --- |
| [**`$abs`**](arithmetic-expression/$abs.md) | The $abs operator returns the absolute value of a number. |
| [**`$add`**](arithmetic-expression/$add.md) | The $add operator returns the sum of two numbers or the sum of a date and numbers. |
| [**`$ceil`**](arithmetic-expression/$ceil.md) | The $ceil operator returns the smallest integer greater than or equal to the specified number. |
| [**`$divide`**](arithmetic-expression/$divide.md) | The $divide operator divides two numbers and returns the quotient. |
| [**`$exp`**](arithmetic-expression/$exp.md) | The $exp operator raises e to the specified exponent and returns the result |
| [**`$floor`**](arithmetic-expression/$floor.md) | The $floor operator returns the largest integer less than or equal to the specified number |
| [**`$ln`**](arithmetic-expression/$ln.md) | The $ln operator calculates the natural logarithm of the input |
| [**`$log`**](arithmetic-expression/$log.md) | The $log operator calculates the logarithm of a number in the specified base |
| [**`$log10`**](arithmetic-expression/$log10.md) | The $log10 operator calculates the log of a specified number in base 10 |
| [**`$multiply`**](arithmetic-expression/$multiply.md) | The $multiply operator multiplies the input numerical values |
| [**`$pow`**](arithmetic-expression/$pow.md) | The `$pow` operator calculates the value of a numerical value raised to the power of a specified exponent. |
| [**`$round`**](arithmetic-expression/$round.md) | The $round operator rounds a number to a specified decimal place. |
| [**`$sqrt`**](arithmetic-expression/$sqrt.md) | The $sqrt operator calculates and returns the square root of an input number |
| [**`$subtract`**](arithmetic-expression/$subtract.md) | The $subtract operator subtracts two numbers and returns the result. |
| [**`$trunc`**](arithmetic-expression/$trunc.md) | The $trunc operator truncates a number to a specified decimal place. |
| [**`Index`**](arithmetic-expression/index.md) |  |

## Array Expression

Array expression operators perform operations on arrays and array elements.

| | Description |
| --- | --- |
| [**`$arrayElemAt`**](array-expression/$arrayelemat.md) | The $arrayElemAt returns the element at the specified array index. |
| [**`$arrayToObject`**](array-expression/$arraytoobject.md) | The $arrayToObject allows converting an array into a single document. |
| [**`$concatArrays`**](array-expression/$concatarrays.md) | The $concatArrays is used to combine multiple arrays into a single array. |
| [**`$filter`**](array-expression/$filter.md) | The $filter operator filters for elements from an array based on a specified condition. |
| [**`$indexOfArray`**](array-expression/$indexofarray.md) | The $indexOfArray operator is used to search for an element in an array and return the index of the first occurrence of the element. |
| [**`$isArray`**](array-expression/$isarray.md) | The $isArray operator is used to determine if a specified value is an array. |
| [**`$map`**](array-expression/$map.md) | The $map operator allows applying an expression to each element in an array. |
| [**`$range`**](array-expression/$range.md) | The $range operator allows generating an array of sequential integers. |
| [**`$reduce`**](array-expression/$reduce.md) | The $reduce operator applies an expression to each element in an array &amp; accumulate result as single value. |
| [**`$reverseArray`**](array-expression/$reversearray.md) | The $reverseArray operator is used to reverse the order of elements in an array. |
| [**`$slice`**](array-expression/$slice.md) | The $slice operator returns a subset of an array from any element onwards in the array. |
| [**`$sortArray`**](array-expression/$sortarray.md) | The $sortArray operator helps in sorting the elements in an array. |
| [**`$zip`**](array-expression/$zip.md) | The $zip operator allows merging two or more arrays element-wise into a single array or arrays. |

## Array Query

Array query operators are used to query and filter array elements.

| | Description |
| --- | --- |
| [**`$all`**](array-query/$all.md) | The $all operator helps finding array documents matching all the elements. |
| [**`$elemMatch`**](array-query/$elemmatch.md) | The $elemMatch operator returns complete array, qualifying criteria with at least one matching array element. |
| [**`$size`**](array-query/$size.md) | The $size operator is used to query documents where an array field has a specified number of elements. |

## Array Update

Array update operators are used to modify array elements and structure.

| | Description |
| --- | --- |
| [**`$`**](array-update/$.md) | The $ positional operator identifies an element in an array to update without explicitly specifying the position of the element in the array. |
| [**`$addToSet`**](array-update/$addtoset.md) | The addToSet operator adds elements to an array if they don't already exist, while ensuring uniqueness of elements within the set. |
| [**`$each`**](array-update/$each.md) | The $each operator is used within an `$addToSet` or `$push` operation to add multiple elements to an array field in a single update operation. |
| [**`$pop`**](array-update/$pop.md) | The $pop operator removes the first or last element of an array. |
| [**`$position`**](array-update/$positional.md) | The $position is used to specify the position in the array where a new element should be inserted. |
| [**`$[]`**](array-update/$positional-all.md) | The $[] operator is used to update all elements in an array that match the query condition. |
| [**`$[identifier]`**](array-update/$positional-filtered.md) | The $[identifier] operator is used to update all elements using a specific identifier in an array that match the query condition. |
| [**`$pull`**](array-update/$pull.md) | Removes all instances of a value from an array. |
| [**`$pullAll`**](array-update/$pullall.md) | The $pullAll operator is used to remove all instances of the specified values from an array. |
| [**`$push`**](array-update/$push.md) | The $push operator adds a specified value to an array within a document. |

## Bitwise

Bitwise operators perform operations on the binary representation of numbers.

| | Description |
| --- | --- |
| [**`$bitAnd`**](bitwise/$bitand.md) | The $bitAnd operator performs a bitwise AND operation on integer values and returns the result as an integer. |
| [**`$bitNot`**](bitwise/$bitnot.md) | The $bitNot operator performs a bitwise NOT operation on integer values and returns the result as an integer. |
| [**`$bitOr`**](bitwise/$bitor.md) | The $bitOr operator performs a bitwise OR operation on integer values and returns the result as an integer. |
| [**`$bitXor`**](bitwise/$bitxor.md) | The $bitXor operator performs a bitwise XOR operation on integer values. |

## Bitwise Query

Bitwise query operators are used to query and filter based on bitwise operations.

| | Description |
| --- | --- |
| [**`$bitsAllClear`**](bitwise-query/$bitsAllClear.md) | The $bitsAllClear operator is used to match documents where all the bit positions specified in a bitmask are clear. |
| [**`$bitsAllSet`**](bitwise-query/$bitsAllSet.md) | The bitsAllSet command is used to match documents where all the specified bit positions are set. |
| [**`$bitsAnyClear`**](bitwise-query/$bitsAnyClear.md) | The $bitsAnyClear operator matches documents where any of the specified bit positions in a bitmask are clear. |
| [**`$bitsAnySet`**](bitwise-query/$bitsAnySet.md) | The $bitsAnySet operator returns documents where any of the specified bit positions are set to 1. |

## Bitwise Update

Bitwise update operators are used to modify values using bitwise operations.

| | Description |
| --- | --- |
| [**`$bit`**](bitwise-update/$bit.md) | The `$bit` operator is used to perform bitwise operations on integer values. |

## Comparison Query

Comparison query operators are used to compare values and create boolean expressions.

| | Description |
| --- | --- |
| [**`$cmp`**](comparison-query/$cmp.md) | The $cmp operator compares two values |
| [**`$eq`**](comparison-query/$eq.md) | The $eq query operator compares the value of a field to a specified value |
| [**`$gt`**](comparison-query/$gt.md) | The $gt query operator retrieves documents where the value of a field is greater than a specified value |
| [**`$gte`**](comparison-query/$gte.md) | The $gte operator retrieves documents where the value of a field is greater than or equal to a specified value |
| [**`$in`**](comparison-query/$in.md) | The $in operator matches value of a field against an array of specified values |
| [**`$lt`**](comparison-query/$lt.md) | The $lt operator retrieves documents where the value of field is less than a specified value |
| [**`$lte`**](comparison-query/$lte.md) | The $lte operator retrieves documents where the value of a field is less than or equal to a specified value |
| [**`$ne`**](comparison-query/$ne.md) | The $ne operator retrieves documents where the value of a field doesn't equal a specified value |
| [**`$nin`**](comparison-query/$nin.md) | The $nin operator retrieves documents where the value of a field doesn't match a list of values |

## Conditional Expression

Conditional expression operators provide control flow and conditional logic in expressions.

| | Description |
| --- | --- |
| [**`$cond`**](conditional-expression/$cond.md) | The $cond operator is used to evaluate a condition and return one of two expressions based on the result. |
| [**`$ifNull`**](conditional-expression/$ifnull.md) | The $ifNull operator is used to evaluate an expression and return a specified value if the expression resolves to null. |
| [**`$switch`**](conditional-expression/$switch.md) | The $switch operator is used to evaluate a series of conditions and return a value based on the first condition that evaluates to true. |

## Data Size

Data size operators are used to determine the size of data structures and values.

| | Description |
| --- | --- |
| [**`$binarySize`**](data-size/$binarysize.md) | The $binarySize operator is used to return the size of a binary data field. |
| [**`$bsonSize`**](data-size/$bsonsize.md) | The $bsonSize operator returns the size of a document in bytes when encoded as BSON. |

## Date Expression

Date expression operators perform operations on date and time values.

| | Description |
| --- | --- |
| [**`$dateAdd`**](date-expression/$dateadd.md) | The $dateAdd operator adds a specified number of time units (day, hour, month etc) to a date. |
| [**`$dateDiff`**](date-expression/$datediff.md) | The $dateDiff operator calculates the difference between two dates in various units such as years, months, days, etc. |
| [**`$dateFromParts`**](date-expression/$datefromparts.md) | The $dateFromParts operator constructs a date from individual components. |
| [**`$dateFromString`**](date-expression/$datefromstring.md) | The $dateDiff operator converts a date/time string to a date object. |
| [**`$dateSubtract`**](date-expression/$datesubtract.md) | The $dateSubtract operator subtracts a specified amount of time from a date. |
| [**`$dateToParts`**](date-expression/$datetoparts.md) | The $dateToParts operator decomposes a date into its individual parts such as year, month, day, and more. |
| [**`$dateToString`**](date-expression/$datetostring.md) | The $dateToString operator converts a date object into a formatted string. |
| [**`$dateTrunc`**](date-expression/$datetrunc.md) | The $dateTrunc operator truncates a date to a specified unit. |
| [**`$dayOfMonth`**](date-expression/$dayofmonth.md) | The $dayOfMonth operator extracts the day of the month from a date. |
| [**`$dayOfWeek`**](date-expression/$dayofweek.md) | The $dayOfWeek operator extracts the day of the week from a date. |
| [**`$dayOfYear`**](date-expression/$dayofyear.md) | The $dayOfYear operator extracts the day of the year from a date. |
| [**`$hour`**](date-expression/$hour.md) | The $hour operator returns the hour portion of a date as a number between 0 and 23. |
| [**`$isoDayOfWeek`**](date-expression/$isodayofweek.md) | The $isoDayOfWeek operator returns the weekday number in ISO 8601 format, ranging from 1 (Monday) to 7 (Sunday). |
| [**`$isoWeek`**](date-expression/$isoweek.md) | The $isoWeek operator returns the week number of the year in ISO 8601 format, ranging from 1 to 53. |
| [**`$isoWeekYear`**](date-expression/$isoweekyear.md) | The $isoWeekYear operator returns the year number in ISO 8601 format, which can differ from the calendar year for dates at the beginning or end of the year. |
| [**`$millisecond`**](date-expression/$millisecond.md) | The $millisecond operator extracts the milliseconds portion from a date value. |
| [**`$minute`**](date-expression/$minute.md) | The $minute operator extracts the minute portion from a date value. |
| [**`$month`**](date-expression/$month.md) | The $month operator extracts the month portion from a date value. |
| [**`$second`**](date-expression/$second.md) | The $second operator extracts the seconds portion from a date value. |
| [**`$week`**](date-expression/$week.md) | The $week operator returns the week number for a date as a value between 0 and 53. |
| [**`$year`**](date-expression/$year.md) | The $year operator returns the year for a date as a four-digit number. |

## Element Query

Element query operators are used to query document elements based on their existence and type.

| | Description |
| --- | --- |
| [**`$exists`**](element-query/$exists.md) | The $exists operator retrieves documents that contain the specified field in their document structure. |
| [**`$type`**](element-query/$type.md) | The $type operator retrieves documents if the chosen field is of the specified type. |

## Evaluation Query

Evaluation query operators are used to evaluate expressions and perform dynamic operations.

| | Description |
| --- | --- |
| [**`$expr`**](evaluation-query/$expr.md) | The $expr operator allows the use of aggregation expressions within the query language, enabling complex field comparisons and calculations. |
| [**`$jsonSchema`**](evaluation-query/$jsonschema.md) | The $jsonSchema operator validates documents against a JSON Schema definition for data validation and structure enforcement. Discover supported features and limitations. |
| [**`$mod`**](evaluation-query/$mod.md) | The $mod operator performs a modulo operation on the value of a field and selects documents with a specified result. |
| [**`$regex`**](evaluation-query/$regex.md) | The $regex operator provides regular expression capabilities for pattern matching in queries, allowing flexible string matching and searching. |
| [**`$text`**](evaluation-query/$text.md) | The $text operator performs text search on the content of indexed string fields, enabling full-text search capabilities. |

## Field Update

Field update operators are used to modify specific fields in documents during update operations.

| | Description |
| --- | --- |
| [**`$currentDate`**](field-update/$currentdate.md) | The $currentDate operator sets the value of a field to the current date, either as a Date or a timestamp. |
| [**`$inc`**](field-update/$inc.md) | The $inc operator increments the value of a field by a specified amount. |
| [**`$mul`**](field-update/$mul.md) | The $mul operator multiplies the value of a field by a specified number. |
| [**`$rename`**](field-update/$rename.md) | The $rename operator allows renaming fields in documents during update operations. |
| [**`$setOnInsert`**](field-update/$setoninsert.md) | The $setOnInsert operator sets field values only when an upsert operation results in an insert of a new document. |

## Geospatial

Geospatial operators perform operations on geographic data and spatial relationships.

| | Description |
| --- | --- |
| [**`$box`**](geospatial/$box.md) | The $box operator defines a rectangular area for geospatial queries using coordinate pairs. |
| [**`$center`**](geospatial/$center.md) | The $center operator specifies a circle using legacy coordinate pairs for $geoWithin queries. |
| [**`$centerSphere`**](geospatial/$centersphere.md) | The $centerSphere operator specifies a circle using spherical geometry for $geoWithin queries. |
| [**`$geoIntersects`**](geospatial/$geointersects.md) | The $geoIntersects operator selects documents whose location field intersects with a specified GeoJSON object. |
| [**`$geometry`**](geospatial/$geometry.md) | The $geometry operator specifies a GeoJSON geometry for geospatial queries. |
| [**`$geoWithin`**](geospatial/$geowithin.md) | The $geoWithin operator selects documents whose location field is completely within a specified geometry. |
| [**`$maxDistance`**](geospatial/$maxdistance.md) | The $maxDistance operator specifies the maximum distance that can exist between two points in a geospatial query. |
| [**`$minDistance`**](geospatial/$mindistance.md) | The $minDistance operator specifies the minimum distance that must exist between two points in a geospatial query. |
| [**`$near`**](geospatial/$near.md) | The $near operator returns documents with location fields that are near a specified point, sorted by distance. |
| [**`$nearSphere`**](geospatial/$nearsphere.md) | The $nearSphere operator returns documents whose location fields are near a specified point on a sphere, sorted by distance on a spherical surface. |
| [**`$polygon`**](geospatial/$polygon.md) | The $polygon operator defines a polygon for geospatial queries, allowing you to find locations within an irregular shape. |

## Literal Expression

Literal expression operators are used to represent literal values in aggregation expressions.

| | Description |
| --- | --- |
| [**`$literal`**](literal-expression/$literal.md) | The $literal operator returns the specified value without parsing it as an expression, allowing literal values to be used in aggregation pipelines. |

## Logical Query

Logical query operators combine boolean expressions using logical operations.

| | Description |
| --- | --- |
| [**`$and`**](logical-query/$and.md) | The $and operator joins multiple query clauses and returns documents that match all specified conditions. |
| [**`$nor`**](logical-query/$nor.md) | The $nor operator performs a logical NOR on an array of expressions and retrieves documents that fail all the conditions. |
| [**`$not`**](logical-query/$not.md) | The $not operator performs a logical NOT operation on a specified expression, selecting documents that don't match the expression. |
| [**`$or`**](logical-query/$or.md) | The $or operator joins query clauses with a logical OR and returns documents that match at least one of the specified conditions. |

## Miscellaneous

Miscellaneous operators include various utility and helper operators that don't fit into other categories.

| | Description |
| --- | --- |
| [**`$getField`**](miscellaneous/$getfield.md) | The $getField operator allows retrieving the value of a specified field from a document. |
| [**`$sampleRate`**](miscellaneous/$samplerate.md) | The $sampleRate operator randomly samples documents from a collection based on a specified probability rate, useful for statistical analysis and testing. |

## Miscellaneous Query

Miscellaneous query operators include various utility and helper operators for querying that don't fit into other categories.

| | Description |
| --- | --- |
| [**`$comment`**](miscellaneous-query/$comment.md) | The $comment operator adds a comment to a query to help identify the query in logs and profiler output. |
| [**`$natural`**](miscellaneous-query/$natural.md) | The $natural operator forces the query to use the natural order of documents in a collection, providing control over document ordering and retrieval. |
| [**`$rand`**](miscellaneous-query/$rand.md) | The $rand operator generates a random float value between 0 and 1. |

## Object Expression

Object expression operators perform operations on objects and object properties.

| | Description |
| --- | --- |
| [**`$mergeObjects`**](object-expression/$mergeobjects.md) | The $mergeObjects operator merges multiple documents into a single document |
| [**`$objectToArray`**](object-expression/$objectToArray.md) | The objectToArray command is used to transform a document (object) into an array of key-value pairs. |
| [**`$setField`**](object-expression/$setField.md) | The setField command is used to add, update, or remove fields in embedded documents. |

## Projection

Projection operators are used to select and transform fields in documents.

| | Description |
| --- | --- |
| [**`$meta`**](projection/$meta.md) | The $meta operator returns a calculated metadata column with returned dataset. |

## Set Expression

Set expression operators perform operations on sets and arrays treated as sets.

| | Description |
| --- | --- |
| [**`$allElementsTrue`**](set-expression/$allelementstrue.md) | The $allElementsTrue operator returns true if all elements in an array evaluate to true. |
| [**`$anyElementTrue`**](set-expression/$anyelementtrue.md) | The $anyElementTrue operator returns true if any element in an array evaluates to a value of true. |
| [**`$setDifference`**](set-expression/$setdifference.md) | The $setDifference operator returns a set with elements that exist in one set but not in a second set. |
| [**`$setEquals`**](set-expression/$setequals.md) | The $setEquals operator returns true if two sets have the same distinct elements. |
| [**`$setIntersection`**](set-expression/$setintersection.md) | The $setIntersection operator returns the common elements that appear in all input arrays. |
| [**`$setIsSubset`**](set-expression/$setissubset.md) | The $setIsSubset operator determines if one array is a subset of a second array. |
| [**`$setUnion`**](set-expression/$setunion.md) | The $setUnion operator returns an array that contains all the unique elements from the input arrays. |

## Timestamp Expression

Timestamp expression operators perform operations on timestamp values.

| | Description |
| --- | --- |
| [**`$tsIncrement`**](timestamp-expression/$tsincrement.md) | The $tsIncrement operator extracts the increment portion from a timestamp value. |
| [**`$tsSecond`**](timestamp-expression/$tssecond.md) | The $tsSecond operator extracts the seconds portion from a timestamp value. |

## Variable Expression

Variable expression operators are used to define and reference variables in expressions.

| | Description |
| --- | --- |
| [**`$let`**](variable-expression/$let.md) | The $let operator allows defining variables for use in a specified expression, enabling complex calculations and reducing code repetition. |

## Window Operators

Window operators perform calculations across a set of documents in a specified window.

| | Description |
| --- | --- |
| [**`$covariancePop`**](window-operators/$covariancepop.md) | The $covariancePop operator returns the covariance of two numerical expressions |
| [**`$covarianceSamp`**](window-operators/$covariancesamp.md) | The $covarianceSamp operator returns the covariance of a sample of two numerical expressions |
| [**`$denseRank`**](window-operators/$denserank.md) | The $denseRank operator assigns and returns a positional ranking for each document within a partition based on a specified sort order |
| [**`$derivative`**](window-operators/$derivative.md) | The $derivative operator calculates the average rate of change of the value of a field within a specified window. |
| [**`$documentNumber`**](window-operators/$documentnumber.md) | The $documentNumber operator assigns and returns a position for each document within a partition based on a specified sort order |
| [**`$expMovingAvg`**](window-operators/$expmovingavg.md) | The $expMovingAvg operator calculates the moving average of a field based on the specified number of documents to hold the highest weight |
| [**`$integral`**](window-operators/$integral.md) | The $integral operator calculates the area under a curve with the specified range of documents forming the adjacent documents for the calculation. |
| [**`$linearFill`**](window-operators/$linearfill.md) | The $linearFill operator interpolates missing values in a sequence of documents using linear interpolation. |
| [**`$locf`**](window-operators/$locf.md) | The $locf operator propagates the last observed non-null value forward within a partition in a windowed query. |
| [**`$rank`**](window-operators/$rank.md) | The $rank operator ranks documents within a partition based on a specified sort order. |
| [**`$shift usage on DocumentDB`**](window-operators/$shift.md) | A window operator that shifts values within a partition and returns the shifted value. |
