using Newtonsoft.Json;

namespace HeartbeatSharp.Endpoints
{
    public struct Stats
    {
        [JsonProperty("last_beat_formatted")]
        public string LastBeatFormatted { get; set; }

        [JsonProperty("total_beats_formatted")]
        public string TotalBeatsFormatted { get; set; }

        [JsonProperty("total_visits")]
        public int TotalVisits { get; set; }

        [JsonProperty("total_uptime")]
        public int TotalUptime { get; set; }

        [JsonProperty("total_beats")]
        public int TotalBeats { get; set; }

        [JsonProperty("longest_missing_beat")]
        public int LongestMissingBeat { get; set; }
    }
}