---
title: Aggregation - Operators
description: Aggregation operators are used to perform operations on grouped data in aggregation pipelines.
type: operators
category: aggregation
---

# Aggregation - operators

Aggregation operators are used to perform operations on grouped data in aggregation pipelines.

| | Description |
| --- | --- |
| [**`$addFields`**]($addfields.md) | The $addFields stage in the aggregation pipeline is used to add new fields to documents. |
| [**`$bucket`**]($bucket.md) | The $bucket operator groups input documents into buckets based on specified boundaries. |
| [**`$changeStream`**]($changestream.md) | The $changeStream stage opens a change stream cursor to track data changes in real-time. |
| [**`$collStats`**]($collstats.md) | The $collStats stage in the aggregation pipeline is used to return statistics about a collection. |
| [**`$convert`**]($convert.md) | The $convert operator converts an expression into the specified type |
| [**`$densify`**]($densify.md) | The $densify operator adds missing data points in a sequence of values within an array or collection. |
| [**`$documents`**]($documents.md) | The $documents stage creates a pipeline from a set of provided documents. |
| [**`$facet`**]($facet.md) | The $facet allows for multiple parallel aggregations to be executed within a single pipeline stage. |
| [**`$fill`**]($fill.md) | The $fill stage allows filling missing values in documents based on specified methods and criteria. |
| [**`$geoNear`**]($geonear.md) | The $geoNear operator finds and sorts documents by their proximity to a geospatial point, returning distance information for each document. |
| [**`$group`**]($group.md) | The $group stage groups documents by specified identifier expressions and applies accumulator expressions. |
| [**`$indexStats`**]($indexstats.md) | The $indexStats stage returns usage statistics for each index in the collection. |
| [**`$isNumber`**]($isnumber.md) | The $isNumber operator checks if a specified expression is a numerical type |
| [**`$lookup`**]($lookup.md) | The $lookup stage in the Aggregation Framework is used to perform left outer joins with other collections. |
| [**`$match`**]($match.md) | The $match stage in the aggregation pipeline is used to filter documents that match a specified condition. |
| [**`$merge`**]($merge.md) | The $merge stage in an aggregation pipeline writes the results of the aggregation to a specified collection. |
| [**`$out`**]($out.md) | The `$out` stage in an aggregation pipeline writes the resulting documents to a specified collection. |
| [**`$redact`**]($redact.md) | The $redact operator filters the content of the documents based on access rights. |
| [**`$replaceWith`**]($replacewith.md) | The $replaceWith operator in DocumentDB returns a document after replacing a document with the specified document |
| [**`$sample`**]($sample.md) | The $sample operator in DocumentDB returns a randomly selected number of documents |
| [**`$set`**]($set.md) | The $set operator in DocumentDB updates or creates a new field with a specified value |
| [**`$skip`**]($skip.md) | The $skip stage in the aggregation pipeline is used to skip a specified number of documents from the input and pass the remaining documents to the next stage in the pipeline. |
| [**`$sort`**]($sort.md) | The $sort stage in the aggregation pipeline is used to order the documents in the pipeline by a specified field or fields. |
| [**`$sortByCount`**]($sortbycount.md) | The $sortByCount stage in the aggregation pipeline is used to group documents by a specified expression and then sort the count of documents in each group in descending order. |
| [**`$toBool`**]($tobool.md) | The $toBool operator converts an expression into a Boolean type |
| [**`$toDate`**]($todate.md) | The $toDate operator converts supported types to a proper Date object. |
| [**`$toDecimal`**]($todecimal.md) | The $toDecimal operator converts an expression into a Decimal type |
| [**`$toDouble`**]($todouble.md) | The $toDouble operator converts an expression into a Double value |
| [**`$toInt`**]($toint.md) | The $toInt operator converts an expression into an Integer |
| [**`$toLong`**]($tolong.md) | The $toLong operator converts an expression into a Long value |
| [**`$toObjectId`**]($toobjectid.md) | The $toObjectId operator converts an expression into an ObjectId |
| [**`$toString`**]($tostring.md) | The $toString operator converts an expression into a String |
| [**`$unset`**]($unset.md) | The $unset stage in the aggregation pipeline is used to remove specified fields from documents. |
| [**`$unwind`**]($unwind.md) | The $unwind stage in the aggregation framework is used to deconstruct an array field from the input documents to output a document for each element. |
