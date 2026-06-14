using BetterPosters.Providers;
using BetterPosters.ScheduledTasks;
using MediaBrowser.Controller;
using MediaBrowser.Controller.Plugins;
using MediaBrowser.Controller.Providers;
using MediaBrowser.Model.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BetterPosters;

/// <summary>
/// Registers Better Posters services with Jellyfin.
/// </summary>
public class PluginServiceRegistrator : IPluginServiceRegistrator
{
    /// <inheritdoc />
    public void RegisterServices(IServiceCollection serviceCollection, IServerApplicationHost applicationHost)
    {
        serviceCollection.AddSingleton<IRemoteImageProvider, BetterPostersImageProvider>();
        serviceCollection.AddSingleton<IScheduledTask, BetterPostersUpdateTask>();
    }
}
