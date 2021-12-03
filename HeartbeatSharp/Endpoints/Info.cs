using Newtonsoft.Json;

namespace HeartbeatSharp.Endpoints
{
    public struct Info
    {
        [JsonProperty("last_seen")]
        public string LastSeen { get; set; }

        [JsonProperty("time_difference")]
        public string TimeDifference { get; set; }

        [JsonProperty("missing_beat")]
        public string MissingBeat { get; set; }

        [JsonProperty("total_beats")]
        public string TotalBeats { get; set; }
    }
}