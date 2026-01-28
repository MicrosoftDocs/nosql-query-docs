---
title: Accumulators - Operators
description: Accumulator operators are used in aggregation pipelines to perform calculations on grouped data.
type: operators
category: accumulators
---

# Accumulators - operators

Accumulator operators are used in aggregation pipelines to perform calculations on grouped data.

| | Description |
| --- | --- |
| [**`$avg`**]($avg.md) | The $avg operator computes the average of numeric values for documents in a group, bucket, or window. |
| [**`$bottom`**]($bottom.md) | The $bottom operator returns the last document from the query's result set sorted by one or more fields |
| [**`$bottomN`**]($bottomn.md) | The $bottomN operator returns the last N documents from the result sorted by one or more fields |
| [**`$count`**]($count.md) | The `$count` operator is used to count the number of documents that match a query filtering criteria. |
| [**`$first`**]($first.md) | The $first operator returns the first value in a group according to the group's sorting order. |
| [**`$firstN`**]($firstn.md) | The $firstN operator sorts documents on one or more fields specified by the query and returns the first N document matching the filtering criteria |
| [**`$last`**]($last.md) | The $last operator returns the last document from the result sorted by one or more fields |
| [**`$lastN`**]($lastn.md) | The $lastN accumulator operator returns the last N values in a group of documents. |
| [**`$max`**]($max.md) | The $max operator returns the maximum value from a set of input values. |
| [**`$maxN`**]($maxn.md) | The $maxN opertor retrieves the top N values based on a specified filtering criteria |
| [**`$median`**]($median.md) | The $median operator calculates the median value of a numeric field in a group of documents. |
| [**`$min`**]($min.md) | The $min operator retrieves the minimum value for a specified field |
| [**`$minN`**]($minn.md) | The $minN operator retrieves the bottom N values based on a specified filtering criteria |
| [**`$percentile`**]($percentile.md) | The $percentile operator calculates the percentile of numerical values that match a filtering criteria |
| [**`$stddevpop`**]($stddevpop.md) | The $stddevpop operator calculates the standard deviation of the specified values |
| [**`$stddevsamp`**]($stddevsamp.md) | The $stddevsamp operator calculates the standard deviation of a specified sample of values and not the entire population |
| [**`$sum`**]($sum.md) | The $sum operator calculates the sum of the values of a field based on a filtering criteria |
| [**`$top`**]($top.md) | The $top operator returns the first document from the result set sorted by one or more fields |
| [**`$topN`**]($topn.md) | The $topN operator returns the first N documents from the result sorted by one or more fields |
