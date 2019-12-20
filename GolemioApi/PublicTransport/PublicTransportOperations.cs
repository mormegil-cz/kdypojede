using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using GeoJSON.Net.Feature;
using NodaTime;

namespace GolemioApi.PublicTransport
{
    /// <summary>
    /// Public transport API
    /// </summary>
    /// <seealso href="https://golemioapi.docs.apiary.io/#reference/public-transport"/>
    public static class PublicTransportOperations
    {
        private static string BoolToStr(bool b) => b ? "true" : "false";

        private static string LocalDateToStr(LocalDate? d) => d?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

        private static string LocalTimeToStr(LocalTime? t) => t?.ToString("hh:mm:ss", CultureInfo.InvariantCulture);

        public static Task<FeatureCollection> GetStopTimes(GolemioConfiguration configuration, string stopId, LocalDate? date, LocalTime? from, LocalTime? to, int? limit, int? offset, bool includeStop)
        {
            return ApiClient.Get<FeatureCollection>(configuration, "v1/gtfs/stoptimes/" + stopId, new Dictionary<string, object?>
            {
                {"date", LocalDateToStr(date)},
                {"from", LocalTimeToStr(from)},
                {"to", LocalTimeToStr(to)},
                {"limit", limit},
                {"offset", offset},
                {"includeStop", BoolToStr(includeStop)},
            });
        }

        public static Task<FeatureCollection> GetTrip(GolemioConfiguration configuration, string tripId, LocalDate? date, bool includeShapes, bool includeStops, bool includeStopTimes, bool includeService, bool includeRoute)
        {
            return ApiClient.Get<FeatureCollection>(configuration, "v1/gtfs/trips/" + tripId, new Dictionary<string, object?>
            {
                {"date", LocalDateToStr(date)},
                {"includeShapes", BoolToStr(includeShapes)},
                {"includeStop", BoolToStr(includeStops)},
                {"includeStopTimes", BoolToStr(includeStopTimes)},
                {"includeService", BoolToStr(includeService)},
                {"includeRoute", BoolToStr(includeRoute)},
            });
        }

        public static Task<FeatureCollection> GetVehiclePositions(GolemioConfiguration configuration, int? limit, int? offset, bool includePositions, string? routeId, string? routeShortName)
        {
            return ApiClient.Get<FeatureCollection>(configuration, "v1/vehiclepositions", new Dictionary<string, object?>
            {
                {"limit", limit},
                {"offset", offset},
                {"includePositions", BoolToStr(includePositions)},
                {"routeId", routeId},
                {"routeShortName", routeShortName},
            });
        }
    }
}