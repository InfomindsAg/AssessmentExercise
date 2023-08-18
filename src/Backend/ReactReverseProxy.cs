using System.Collections.ObjectModel;
using Yarp.ReverseProxy.Configuration;

namespace Backend;

internal static class ReactReverseProxy
{
    public static void AddReactReverseProxy(this IServiceCollection services)
    {
        services.AddReverseProxy().LoadFromMemory(GetRoutes(), GetClusters());
    }

    public static void UseReactRevereseProxy(this WebApplication app)
    {
        app.MapReverseProxy();
        app.MapGet("/", () => Results.Redirect("/app")).ExcludeFromDescription();
    }

    private const string RaactFrontendCluster = nameof(RaactFrontendCluster);
    private const string ReactFrontendAppRoute = nameof(ReactFrontendAppRoute);


    private static ClusterConfig[] GetClusters()
        => new[]
        {
            new ClusterConfig
            {
                ClusterId = RaactFrontendCluster,
                Destinations = new Dictionary<string, DestinationConfig>(StringComparer.OrdinalIgnoreCase)
                {
                    {"ReactFrontend", new DestinationConfig() { Address = "http://localhost:10001" } }
                }
            }
        };

    public static RouteConfig[] GetRoutes()
     => new[]
     {
         new RouteConfig {
                ClusterId = RaactFrontendCluster,
                RouteId = ReactFrontendAppRoute,
                Match = new()
                {
                   Path = "app/{**catch-all}",
                }
         }
     };
}
