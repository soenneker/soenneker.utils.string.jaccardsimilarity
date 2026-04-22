using Soenneker.Tests.HostedUnit;

using AwesomeAssertions;

namespace Soenneker.Utils.String.JaccardSimilarity.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class JaccardSimilarityStringUtilTests : HostedUnitTest
{
    public JaccardSimilarityStringUtilTests(Host host) : base(host)
    {
    }

    [Theory]
    [InlineData("", "", 1)]
    [InlineData("abc", "", 0)]
    [InlineData("", "xyz", 0)]
    [InlineData("kitten", "sitting", 0)]
    [InlineData("kitten", "kitten", 1)]
    [InlineData("abc", "def", 0)]
    [InlineData("abcdef", "abc", 0)]
    [InlineData("abc", "abcd", 0)]
    [InlineData("this is sitting on a porch", "this is sitting", .50)]
    [InlineData("the cat sat on a hat", "sad on a hat", .4285)]
    [InlineData("this is a test", "this is another test", .6)]
    public void CalculateSimilarity_Returns_Correct_Similarity_Score(string str1, string str2, double expectedScore)
    {
        double similarityScore = JaccardSimilarityStringUtil.CalculateSimilarity(str1, str2);

        similarityScore.Should().BeApproximately(expectedScore, 0.001);
    }

    [Theory]
    [InlineData("", "", 100.0)]
    [InlineData("abc", "", 0.0)]
    [InlineData("", "xyz", 0.0)]
    [InlineData("kitten", "sitting", 0)]
    [InlineData("kitten", "kitten", 100.0)]
    [InlineData("abc", "def", 0.0)]
    [InlineData("abcdef", "abc", 0.0)]
    [InlineData("this is sitting on a porch", "this is sitting", 50)]
    public void CalculateSimilarityPercentage_Returns_Correct_Percentage(string str1, string str2, double expectedPercentage)
    {
        double similarityPercentage = JaccardSimilarityStringUtil.CalculateSimilarityPercentage(str1, str2);

        similarityPercentage.Should().BeApproximately(expectedPercentage, 0.001);
    }
}