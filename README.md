[![](https://img.shields.io/nuget/v/soenneker.utils.string.jaccardsimilarity.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.string.jaccardsimilarity/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.string.jaccardsimilarity/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.string.jaccardsimilarity/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.utils.string.jaccardsimilarity.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.string.jaccardsimilarity/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.string.jaccardsimilarity/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.utils.string.jaccardsimilarity/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.String.JaccardSimilarity
A set-based Jaccard similarity calculator for space-delimited strings.

## Installation

```bash
dotnet add package Soenneker.Utils.String.JaccardSimilarity
```

## Usage

```csharp
using Soenneker.Utils.String.JaccardSimilarity;

var text1 = "This is a test";
var text2 = "This is another test";

double score = JaccardSimilarityStringUtil.CalculateSimilarity(text1, text2);
double percentage = JaccardSimilarityStringUtil.CalculateSimilarityPercentage(text1, text2);

// score == 0.6
// percentage == 60
```

The score is `intersection / union` for the two token sets. `CalculateSimilarity` returns a value from `0` to `1`; `CalculateSimilarityPercentage` returns that value multiplied by 100. Identical strings, including two empty strings, return `1` (or `100%`).

## Comparison rules

- Only the literal space character (`' '`) separates tokens; tabs and line breaks remain inside tokens.
- Matching is ordinal and case-sensitive.
- Duplicate tokens do not affect the result because each input is converted to a set.
- Empty tokens are retained, including those produced by leading, trailing, or repeated spaces.
- Token order is ignored.
- Punctuation is retained, so `"test"` and `"test."` are different tokens.

Normalize casing, whitespace, and punctuation before calling the utility if your application needs different rules. This is lexical set overlap, not semantic similarity, and both arguments must be non-null.
