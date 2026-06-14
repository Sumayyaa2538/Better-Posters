using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BetterPosters.Configuration;
using MediaBrowser.Common.Net;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Entities.Movies;
using MediaBrowser.Controller.Entities.TV;
using MediaBrowser.Controller.Providers;
using MediaBrowser.Model.Entities;
using MediaBrowser.Model.Providers;

namespace BetterPosters.Providers;

/// <summary>
/// Provides Better Posters primary images from btttr.cc.
/// </summary>
public class BetterPostersImageProvider : IRemoteImageProvider, IHasOrder
{
    private readonly IHttpClientFactory _httpClientFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="BetterPostersImageProvider"/> class.
    /// </summary>
    /// <param name="httpClientFactory">The HTTP client factory.</param>
    public BetterPostersImageProvider(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    /// <inheritdoc />
    public string Name => Plugin.PluginName;

    /// <inheritdoc />
    public int Order => 0;

    /// <inheritdoc />
    public bool Supports(BaseItem item)
    {
        return item is Movie or Series;
    }

    /// <inheritdoc />
    public IEnumerable<ImageType> GetSupportedImages(BaseItem item)
    {
        return Supports(item) ? [ImageType.Primary] : [];
    }

    /// <inheritdoc />
    public Task<IEnumerable<RemoteImageInfo>> GetImages(BaseItem item, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        if (!Supports(item))
        {
            return Task.FromResult<IEnumerable<RemoteImageInfo>>([]);
        }

        var imdbId = item.GetProviderId(MetadataProvider.Imdb);
        if (string.IsNullOrWhiteSpace(imdbId))
        {
            return Task.FromResult<IEnumerable<RemoteImageInfo>>([]);
        }

        var configuration = Plugin.Instance?.Configuration ?? new PluginConfiguration();
        var url = BetterPosterUrlBuilder.Build(imdbId, configuration);
        var language = BetterPosterUrlBuilder.GetLanguageCode(configuration.Language) ?? "en";

        return Task.FromResult<IEnumerable<RemoteImageInfo>>(
            [
                new RemoteImageInfo
                {
                    ProviderName = Name,
                    Url = url,
                    ThumbnailUrl = url,
                    Type = ImageType.Primary,
                    Width = 500,
                    Height = 750,
                    Language = language
                }
            ]);
    }

    /// <inheritdoc />
    public Task<HttpResponseMessage> GetImageResponse(string url, CancellationToken cancellationToken)
    {
        return _httpClientFactory.CreateClient(NamedClient.Default).GetAsync(new System.Uri(url), cancellationToken);
    }
}
