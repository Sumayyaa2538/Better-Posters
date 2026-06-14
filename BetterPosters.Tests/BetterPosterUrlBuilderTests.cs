using BetterPosters.Configuration;
using Xunit;

namespace BetterPosters.Tests;

public class BetterPosterUrlBuilderTests
{
    private const string ImdbId = "tt0111161";

    [Fact]
    public void Build_WithDefaultConfiguration_ReturnsDefaultPosterUrl()
    {
        var configuration = new PluginConfiguration();

        var url = BetterPosterUrlBuilder.Build(ImdbId, configuration);

        Assert.Equal("https://btttr.cc/poster/imdb/poster-default/tt0111161.jpg", url);
    }

    [Theory]
    [InlineData(true, true, false, false, "poster")]
    [InlineData(true, true, true, false, "poster-q")]
    [InlineData(true, true, false, true, "poster-a")]
    [InlineData(true, true, true, true, "poster-qa")]
    [InlineData(false, true, false, false, "poster-r")]
    [InlineData(false, true, true, false, "poster-rq")]
    [InlineData(false, true, false, true, "poster-ra")]
    [InlineData(false, true, true, true, "poster-rqa")]
    [InlineData(true, false, false, false, "poster-g")]
    [InlineData(true, false, true, false, "poster-gq")]
    [InlineData(true, false, false, true, "poster-ga")]
    [InlineData(true, false, true, true, "poster-gqa")]
    [InlineData(false, false, false, false, "poster-n")]
    [InlineData(false, false, true, false, "poster-nq")]
    [InlineData(false, false, false, true, "poster-na")]
    [InlineData(false, false, true, true, "poster-nqa")]
    public void Build_WithPosterOptionCombination_UsesExpectedPath(
        bool enableGenre,
        bool enableRating,
        bool enableQualityTags,
        bool enableAgeRating,
        string expectedPath)
    {
        var configuration = new PluginConfiguration
        {
            EnableGenre = enableGenre,
            EnableRating = enableRating,
            EnableQualityTags = enableQualityTags,
            EnableAgeRating = enableAgeRating
        };

        var url = BetterPosterUrlBuilder.Build(ImdbId, configuration);

        Assert.Equal($"https://btttr.cc/{expectedPath}/imdb/poster-default/tt0111161.jpg", url);
    }

    [Fact]
    public void Build_WithTrendTagsDisabled_AddsTagNoneQuery()
    {
        var configuration = new PluginConfiguration
        {
            EnableTrendTags = false
        };

        var url = BetterPosterUrlBuilder.Build(ImdbId, configuration);

        Assert.Equal("https://btttr.cc/poster/imdb/poster-default/tt0111161.jpg?tag=none", url);
    }

    [Theory]
    [InlineData(PosterLanguage.Spanish, "es")]
    [InlineData(PosterLanguage.French, "fr")]
    [InlineData(PosterLanguage.German, "de")]
    [InlineData(PosterLanguage.PortugueseBrazil, "pt-BR")]
    [InlineData(PosterLanguage.PortuguesePortugal, "pt-PT")]
    [InlineData(PosterLanguage.Italian, "it")]
    [InlineData(PosterLanguage.Dutch, "nl")]
    [InlineData(PosterLanguage.Polish, "pl")]
    [InlineData(PosterLanguage.Russian, "ru")]
    [InlineData(PosterLanguage.Turkish, "tr")]
    [InlineData(PosterLanguage.Arabic, "ar")]
    [InlineData(PosterLanguage.Japanese, "ja")]
    [InlineData(PosterLanguage.Korean, "ko")]
    [InlineData(PosterLanguage.Chinese, "zh")]
    [InlineData(PosterLanguage.Hindi, "hi")]
    [InlineData(PosterLanguage.Swedish, "sv")]
    [InlineData(PosterLanguage.Czech, "cs")]
    public void Build_WithNonEnglishLanguage_AddsLanguageQuery(PosterLanguage language, string expectedCode)
    {
        var configuration = new PluginConfiguration
        {
            Language = language
        };

        var url = BetterPosterUrlBuilder.Build(ImdbId, configuration);

        Assert.Equal($"https://btttr.cc/poster/imdb/poster-default/tt0111161.jpg?lang={expectedCode}", url);
    }

    [Theory]
    [InlineData(PosterRatingSource.Imdb, "IM")]
    [InlineData(PosterRatingSource.Tmdb, "TM")]
    [InlineData(PosterRatingSource.RottenTomatoes, "RT")]
    [InlineData(PosterRatingSource.Metacritic, "MC")]
    [InlineData(PosterRatingSource.Trakt, "TR")]
    [InlineData(PosterRatingSource.Letterboxd, "LB")]
    [InlineData(PosterRatingSource.RogerEbert, "RE")]
    public void Build_WithSpecificRatingSource_AddsRatingSourceQuery(PosterRatingSource source, string expectedCode)
    {
        var configuration = new PluginConfiguration
        {
            RatingSource = source
        };

        var url = BetterPosterUrlBuilder.Build(ImdbId, configuration);

        Assert.Equal($"https://btttr.cc/poster/imdb/poster-default/tt0111161.jpg?rs={expectedCode}", url);
    }

    [Fact]
    public void Build_WithAverageRatingSource_OmitsRatingSourceQuery()
    {
        var configuration = new PluginConfiguration
        {
            RatingSource = PosterRatingSource.Average
        };

        var url = BetterPosterUrlBuilder.Build(ImdbId, configuration);

        Assert.Equal("https://btttr.cc/poster/imdb/poster-default/tt0111161.jpg", url);
    }

    [Fact]
    public void Build_WithRatingDisabled_OmitsRatingSourceQuery()
    {
        var configuration = new PluginConfiguration
        {
            EnableRating = false,
            RatingSource = PosterRatingSource.Imdb
        };

        var url = BetterPosterUrlBuilder.Build(ImdbId, configuration);

        Assert.Equal("https://btttr.cc/poster-g/imdb/poster-default/tt0111161.jpg", url);
    }

    [Fact]
    public void Build_WithAllQueryParameters_UsesDeterministicQueryOrder()
    {
        var configuration = new PluginConfiguration
        {
            EnableTrendTags = false,
            Language = PosterLanguage.French,
            RatingSource = PosterRatingSource.Tmdb
        };

        var url = BetterPosterUrlBuilder.Build(ImdbId, configuration);

        Assert.Equal("https://btttr.cc/poster/imdb/poster-default/tt0111161.jpg?tag=none&lang=fr&rs=TM", url);
    }
}
