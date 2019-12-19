using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GeoJSON.Net.Feature;

namespace GolemioApi.PublicTransport
{
    public static class PublicTransportOperations
    {
        public static Task<FeatureCollection> GetVehiclePositions(GolemioConfiguration configuration, int? limit, int? offset, bool includePositions, string? routeId, string? routeShortName)
        {
            return ApiClient.Get<FeatureCollection>(configuration, "v1/vehiclepositions", new Dictionary<string, object?> {{"limit", limit}, {"offset", offset}, {"includePositions", includePositions ? "true" : "false"}, {"routeId", routeId}, {"routeShortName", routeShortName}});
        }
    }
}