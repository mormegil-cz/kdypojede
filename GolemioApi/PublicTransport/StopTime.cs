using Newtonsoft.Json;
using NodaTime;

namespace GolemioApi.PublicTransport
{
    public class StopTime
    {
        [JsonProperty(PropertyName = "arrival_time", Required = Required.Always)]
        public LocalTime ArrivalTime {get; set; }

        [JsonProperty(PropertyName = "arrival_time_seconds")]
        public decimal? ArrivalTimeSeconds { get; set; }

        [JsonProperty(PropertyName = "departure_time", Required = Required.Always)]
        public LocalTime DepartureTime {get; set; }

        [JsonProperty(PropertyName = "departure_time_seconds")]
        public decimal? DepartureTimeSeconds { get; set; }

        [JsonProperty(PropertyName = "drop_off_type", Required = Required.Always)]
        public string DropOffType { get; set; }

        [JsonProperty(PropertyName = "pickup_type", Required = Required.Always)]
        public string PickupType { get; set; }

        [JsonProperty(PropertyName = "shape_dist_traveled", Required = Required.Always)]
        public decimal ShapeDistanceTraveled { get; set; }

        [JsonProperty(PropertyName = "stop_headsign")]
        public string? StopHeadsign { get; set; }

        [JsonProperty(PropertyName = "stop_id", Required = Required.Always)]
        public string StopId { get; set; }

        [JsonProperty(PropertyName = "stop_sequence", Required = Required.Always)]
        public int StopSequence { get; set; }

        [JsonProperty(PropertyName = "trip_id", Required = Required.Always)]
        public string TripId { get; set; }

        /*
  {
    "arrival_time": "10:02:20",
    "arrival_time_seconds": null,
    "departure_time": "10:02:40",
    "departure_time_seconds": null,
    "drop_off_type": "0",
    "pickup_type": "0",
    "shape_dist_traveled": 12.32843,
    "stop_headsign": "",
    "stop_id": "U118Z101P",
    "stop_sequence": 13,
    "timepoint": null,
    "trip_id": "991_1679_191223",
    "stop": {
      "level_id": "",
      "location_type": 0,
      "parent_station": "U118S1",
      "platform_code": "1",
      "stop_code": null,
      "stop_desc": null,
      "stop_id": "U118Z101P",
      "stop_lat": 50.07827,
      "stop_lon": 14.4633,
      "stop_name": "Flora",
      "stop_timezone": null,
      "stop_url": "",
      "wheelchair_boarding": 2,
      "zone_id": "P"
    }
*/        
    }
}