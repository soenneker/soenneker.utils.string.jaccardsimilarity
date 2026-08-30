using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System;

namespace Soenneker.Utils.String.JaccardSimilarity;

/// <summary>
/// A utility library for comparing strings via the Jaccard similarity algorithm
/// </summary>
public static class JaccardSimilarityStringUtil
{
    /// <summary>
    /// Calculates the similarity percentage between two strings using the Jaccard similarity algorithm.
    /// </summary>
    /// <param name="s1">The first string.</param>
    /// <param name="s2">The second string.</param>
    /// <returns>The similarity percentage between the two strings.</returns>
    [Pure]
    public static double CalculateSimilarityPercentage(string s1, string s2)
    {
        double similarity = CalculateSimilarity(s1, s2);
        double percentageMatch = similarity * 100;

        return percentageMatch;
    }

    /// <summary>
    /// Calculates the similarity score between two strings using the Jaccard similarity algorithm
    /// </summary>
    /// <param name="s1">The first string.</param>
    /// <param name="s2">The second string.</param>
    /// <returns>The similarity score between the two strings.</returns>
    [Pure]
    public static double CalculateSimilarity(string s1, string s2)
    {
        if (s1 == s2)
            return 1.0;

        HashSet<string> hashSet1 = Tokenize(s1);
        HashSet<string> hashSet2 = Tokenize(s2);

        int originalCount1 = hashSet1.Count;
        hashSet1.IntersectWith(hashSet2);
        int intersectionCount = hashSet1.Count;

        int unionCount = originalCount1 + hashSet2.Count - intersectionCount;

        return (double)intersectionCount / unionCount;
    }

    private static HashSet<string> Tokenize(string value)
    {
        var result = new HashSet<string>(StringComparer.Ordinal);
        HashSet<string>.AlternateLookup<ReadOnlySpan<char>> lookup = result.GetAlternateLookup<ReadOnlySpan<char>>();
        ReadOnlySpan<char> span = value;
        var start = 0;

        // Preserve Split(' ') semantics, including empty entries.
        for (var i = 0; i <= span.Length; i++)
        {
            if (i != span.Length && span[i] != ' ')
                continue;

            ReadOnlySpan<char> token = span[start..i];
            if (!lookup.Contains(token))
                result.Add(token.ToString());

            start = i + 1;
        }

        return result;
    }
}
