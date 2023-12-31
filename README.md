[![](https://img.shields.io/nuget/v/soenneker.utils.string.jaccardsimilarity.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.string.jaccardsimilarity/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.string.jaccardsimilarity/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.string.jaccardsimilarity/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.utils.string.jaccardsimilarity.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.string.jaccardsimilarity/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.String.JaccardSimilarity
### A utility library for comparing strings via the Jaccard similarity algorithm

## Installation

```
dotnet add package Soenneker.Utils.String.JaccardSimilarity
```

## Why?
Jaccard similarity is great for comparing sets of items, and it's often used for tasks like detecting similar documents or recommending content. It's useful because:

### Set-Focused: 
It works well when you care about what elements are present, not their order.

### Scale Doesn't Matter: 
It's not influenced by how big the sets are, just by what they share.

### Efficient: 
It's quick to calculate making it suitable for large datasets.

### Handles Noise Well: 
It stays reliable even if there's extra, less important information in the sets.

## Usage

```csharp
var text1 = "This is a test";
var text2 = "This is another test";

double result = JaccardSimilarityStringUtil.CalculateSimilarityPercentage(text1, text2); // 60
```
