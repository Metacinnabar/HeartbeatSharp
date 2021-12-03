using Newtonsoft.Json;

namespace HeartbeatSharp.Endpoints
{
    public struct Device
    {
        [JsonProperty("device_name")]
        public string DeviceName { get; set; }

        [JsonProperty("last_beat")]
        public LastBeat LastBeat { get; set; }

        [JsonProperty("total_beats")]
        public int TotalBeats { get; set; }

        [JsonProperty("longest_missing_beat")]
        public int LongestMissingBeat { get; set; }
    }
}