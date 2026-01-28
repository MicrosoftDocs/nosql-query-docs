---
title: Window Operators - Operators
description: Window operators perform calculations across a set of documents in a specified window.
type: operators
category: window-operators
---

# Window operators - operators

Window operators perform calculations across a set of documents in a specified window.

## Other

| | Description |
| --- | --- |
| [**`$covariancePop`**]($covariancepop.md) | The $covariancePop operator returns the covariance of two numerical expressions |
| [**`$covarianceSamp`**]($covariancesamp.md) | The $covarianceSamp operator returns the covariance of a sample of two numerical expressions |
| [**`$denseRank`**]($denserank.md) | The $denseRank operator assigns and returns a positional ranking for each document within a partition based on a specified sort order |
| [**`$derivative`**]($derivative.md) | The $derivative operator calculates the average rate of change of the value of a field within a specified window. |
| [**`$documentNumber`**]($documentnumber.md) | The $documentNumber operator assigns and returns a position for each document within a partition based on a specified sort order |
| [**`$expMovingAvg`**]($expmovingavg.md) | The $expMovingAvg operator calculates the moving average of a field based on the specified number of documents to hold the highest weight |
| [**`$integral`**]($integral.md) | The $integral operator calculates the area under a curve with the specified range of documents forming the adjacent documents for the calculation. |
| [**`$linearFill`**]($linearfill.md) | The $linearFill operator interpolates missing values in a sequence of documents using linear interpolation. |
| [**`$locf`**]($locf.md) | The $locf operator propagates the last observed non-null value forward within a partition in a windowed query. |
| [**`$rank`**]($rank.md) | The $rank operator ranks documents within a partition based on a specified sort order. |
| [**`$shift usage on DocumentDB`**]($shift.md) | A window operator that shifts values within a partition and returns the shifted value. |
